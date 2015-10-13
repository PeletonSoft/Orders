using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Clients
{
    public partial class TfClients : Form
    {

        public TfClients(string connectionString, int customerId)
        {
            InitializeComponent();
            _connectionString = connectionString;
            _startCustomerId = customerId;
        }

        
        const string _unknownCustomer = "Неизвестный покупатель";

        private readonly string _connectionString;
        private readonly int _startCustomerId;

        private void TfClients_Load(object sender, EventArgs e)
        {
            dbgList.AutoGenerateColumns = false;

            using (var dataContext = new ClientDataContext(_connectionString))
            {
                var filter = dataContext.Customers
                    .Where(cust => cust.Код == _startCustomerId);

                edFilter.Text =
                    filter.Any()
                        ? filter.First().ФИО
                        : _unknownCustomer;
            }

            MakeFilter();
        }

        
        private void edFilter_TextChanged(object sender, EventArgs e)
        {
            updateData();
        }

        private Guid checkedGuid;
        private void updateData()
        {
            var text = edFilter.Text.Trim();
            
            ThreadStart proc = () =>
                {
                    var thisGuid = Guid.NewGuid();
                    checkedGuid = thisGuid;

                    Thread.Sleep(1000);

                    if (thisGuid != checkedGuid)
                        return;

                    MakeFilter(text);
                };

            (new Thread(proc)).Start();
        }

        private void MakeFilter(string text)
        {
            var filter = GetFilter(text);
            var find = filter.FindIndex(x => x.ФИО.ToUpper() == text.ToUpper());


            ThreadStart ret =
                () =>
                    {
                        dbgList.DataSource = filter;

                        if (find >= 0)
                        {
                            dbgList.Rows[find].Selected = true;
                            dbgList.FirstDisplayedScrollingRowIndex = find;
                        }
                        else
                            if(filter.Count > 0)
                            {
                                dbgList.Rows[0].Selected = true;
                                dbgList.FirstDisplayedScrollingRowIndex = 0;
                            }

                        btOk.Enabled = filter.Count > 0;
                        btNew.Enabled = filter.Count == 0;
                        btEdit.Enabled = filter.Count > 0;
                    };

            Invoke(ret);
        }

        private void MakeFilter()
        {
            var text = edFilter.Text.Trim();
            MakeFilter(text);
        }

        private List<Customer> GetFilter(string text)
        {
            var dataContext = new ClientDataContext(_connectionString);

            var nearFilter = dataContext.Customers
                .Where(cst => cst.ФИО.IndexOf(text) >= 0
                              || cst.Телефон.IndexOf(text) >= 0)
                .OrderBy(cst => cst.ФИО)
                .Take(50);

            var certainFilter = dataContext.Customers
                .Where(cst => cst.ФИО == text);

            return nearFilter.Union(certainFilter)
                .OrderBy(cst => cst.ФИО)
                .ToList();
        }

        private void edFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                MakeFilter();
            if (e.KeyData == Keys.Up ||
                e.KeyData == Keys.Down ||
                e.KeyData == Keys.PageUp ||
                e.KeyData == Keys.PageDown)
                dbgList.Focus();

        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            SelectedCustomer = null;
            DialogResult = DialogResult.Cancel;
        }

        public Customer SelectedCustomer { get; private set; }
        private void btOk_Click(object sender, EventArgs e)
        {
            if (dbgList.SelectedRows.Count == 0)
                return;

            var current = (Customer)dbgList.SelectedRows[0].DataBoundItem;

            edFilter.Text = current.ФИО;
            MakeFilter();
            checkedGuid = Guid.NewGuid();

            if (dbgList.SelectedRows.Count == 0)
                return;

            SelectedCustomer = (Customer)dbgList.SelectedRows[0].DataBoundItem;

            DialogResult = DialogResult.Yes;
        }

        private void dbgList_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dbgList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > ' ')
            {
                edFilter.Focus();
                edFilter.Text = e.KeyChar.ToString();
                edFilter.SelectionStart = edFilter.Text.Length;
            }

        }

        private void btNew_Click(object sender, EventArgs e)
        {
            MakeFilter();
            if(!btNew.Enabled)
                return;

            var form =
                new TfEditClient(
                    _connectionString, 
                    new Customer()
                        {
                            Код = 0,
                            ФИО = edFilter.Text
                        });

            form.Location = 
                new Point(
                    Location.X + Width / 2 - form.Width / 2,
                    Location.Y + Height / 2 - form.Height / 2);


            if (form.ShowDialog() != DialogResult.OK)
                return;

            var customer =
                new Customer()
                    {
                        ФИО = form.CustomerName,
                        Телефон = form.CustomerTelephone,
                        Основной_телефон = form.CustomerMainTelephone,
                        Активен = true
                    };

            using(var dataContext = new ClientDataContext(_connectionString))
            {
                dataContext.Customers.InsertOnSubmit(customer);
                dataContext.SubmitChanges();
            }

            edFilter.Text = customer.ФИО;
            MakeFilter();
            checkedGuid = Guid.NewGuid();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (dbgList.SelectedRows.Count == 0)
                return;

            var current = (Customer)dbgList.SelectedRows[0].DataBoundItem;
            if (current.ФИО == _unknownCustomer)
            {
                MessageBox.Show("Данного покупателя не следует редактировать.\nСледует заводить нового покупателя.",
                                "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            edFilter.Text = current.ФИО;
            MakeFilter();
            checkedGuid = Guid.NewGuid();

            if (dbgList.SelectedRows.Count == 0)
                return;
            current = (Customer)dbgList.SelectedRows[0].DataBoundItem;

            if (dbgList.SelectedRows.Count == 0)
                return;

            var form =
                new TfEditClient(
                    _connectionString,
                    new Customer()
                    {
                        Код = current.Код,
                        ФИО = current.ФИО,
                        Телефон = current.Телефон
                    });

            form.Location =
                new Point(
                    Location.X + Width / 2 - form.Width / 2,
                    Location.Y + Height / 2 - form.Height / 2);


            if (form.ShowDialog() != DialogResult.OK)
                return;

            var customer =
                new Customer()
                {
                    ФИО = form.CustomerName,
                    Телефон = form.CustomerTelephone,
                    Основной_телефон = form.CustomerMainTelephone,
                    Активен = true
                };

            using (var dataContext = new ClientDataContext(_connectionString))
            {
                var dbCustomer = dataContext.Customers
                    .Where(cust => cust.Код == current.Код)
                    .First();
                dbCustomer.ФИО = customer.ФИО;
                dbCustomer.Телефон = customer.Телефон;
                dbCustomer.Основной_телефон = customer.Основной_телефон;
                dataContext.SubmitChanges();
            }

            edFilter.Text = customer.ФИО;
            MakeFilter();

            checkedGuid = Guid.NewGuid();

        }

        public static Customer SelectCustomer(string connectionString, int customerId)
        {
            var form = new TfClients(connectionString, customerId);
            form.ShowDialog();
            return form.SelectedCustomer;
        }
    }
}