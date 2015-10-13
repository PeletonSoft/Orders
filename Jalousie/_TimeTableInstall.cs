using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jalousie.Datasets;

namespace Jalousie
{
    public partial class TfTimeTableInstall : Form
    {
        public int? OrderId { get; set; }
        public int? TypeId { get; set; }

        public TfTimeTableInstall()
        {
            InitializeComponent();
        }


        private void FTimeTableInstall_Load(object sender, EventArgs e)
        {
            dsBlanks.tbTypes.Load(LocalService.GetTypesList().Tables[0].CreateDataReader());
            var nr = (dsBlanks.tbTypesRow)dsBlanks.tbTypes.NewRow();

            nr.Код = 0;
            nr.Название = "Карнизы";
            nr.Описание = "";
            nr.Активен = true;

            dsBlanks.tbTypes.Rows.Add(nr);
            dsBlanks.tbTypes.AcceptChanges();
        }

        public DateTime? InstallDate { get; set; }

        private void btOk_Click(object sender, EventArgs e)
        {
            var drv = (DataRowView)tbPlanBindingSource.Current;
            var row = (dsOrders.tbPlanRow)(drv).Row;

            InstallDate = row.Дата;

            if (!check(row.Дата))
                return;

            if (OrderId == null)
            {
                DialogResult = DialogResult.OK;
                return;
            }

            bool hasError;
            bool hasWarning;
            string msg = "";
            LocalService.SetPlanPosition((int)OrderId, row.Дата, out hasError, out hasWarning, out msg);

            if (hasError)
            {
                MessageBox.Show(msg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (msg != "")
            {
                MessageBox.Show(msg, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            DialogResult = DialogResult.OK;
        }

        private bool check(DateTime date)
        {

            /*
            if (rw.Заказной && (date - DateTime.Now).Days < 14) 
            {
                MessageBox.Show("Для изделий с заказной тканью срок изготовления не может быть меньше 14 дней.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            */
            return true;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void dbg_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            var dbg = (DataGridView)sender;
            var drv = (DataRowView)dbg.Rows[e.RowIndex].DataBoundItem;
            var rw = (dsOrders.tbPlanRow)drv.Row;
            Color Color = ((rw.Дата.DayOfYear - DateTime.Today.DayOfYear) % 2 == 0) ?
                Color.Blue : Color.White;
            Color AdvColor;

            if (rw.Свободно && !rw.Занято)
                AdvColor = Color.Green;
            else if (!rw.Свободно && !rw.Занято)
                AdvColor = Color.Yellow;
            else
                AdvColor = Color.Red;
            e.CellStyle.BackColor = Color.FromArgb(
                Color.R / 10 + AdvColor.R / 5 + 177,
                Color.G / 10 + AdvColor.G / 5 + 177,
                Color.B / 10 + AdvColor.B / 5 + 177);
        }

        private void tbTypesBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (tbTypesBindingSource.Current != null)
            {
                var drv = (DataRowView)tbTypesBindingSource.Current;
                var row = (dsBlanks.tbTypesRow)drv.Row;
                var type = row.Код;
                dsOrders.tbPlan.Clear();
                dsOrders.tbPlan.Load(LocalService.GetPlan(type).Tables[0].CreateDataReader());

            }
        }

        private void TfTimeTableInstall_Shown(object sender, EventArgs e)
        {
            var isView = TypeId == null;
            cbJalType.Enabled = isView;
            pnSelect.Visible = !isView;
            cbJalType.SelectedValue = TypeId ?? 1;
            if (InstallDate != null)
            {
                var index = tbPlanBindingSource.Find("Дата", InstallDate);
                if (index >= 0)
                {
                    tbPlanBindingSource.Position = index;
                }

            }

        }

    }
}