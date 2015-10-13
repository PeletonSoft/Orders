using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Jalousie.Datasets;
using Jalousie.Properties;

namespace Jalousie
{
    public partial class TfEditOrderTitle : Form
    {
        public TfEditOrderTitle()
        {
            InitializeComponent();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            if (lbClientName.Tag == null)
            {
                MessageBox.Show("Вы не выбрали покупателя.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Вы уверены что хотите сделать изменения в заказе?", "Внимание",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button3) != DialogResult.Yes)
                return;

            DialogResult = DialogResult.OK;
        }

        private void btClient_Click(object sender, EventArgs e)
        {

            var customerId = lbClientName.Tag == null ? 0 : (int)lbClientName.Tag;
            var customer = Clients.TfClients.SelectCustomer
                (Settings.Default.ShopConnectionString, customerId);

            if (customer != null)
            {
                lbClientName.Tag = customer.Код;
                lbClientName.Text = customer.ФИО;
                lbClientTel.Text = customer.Телефон;
            }
        }

        private void cbIsOrdered_CheckedChanged(object sender, EventArgs e)
        {
            if(cbIsOrdered.Checked && btInstallDate.Tag != null)
            {
                var installDate = (DateTime) btInstallDate.Tag;
                var delta = installDate - DateTime.Now;
                if (delta.Days < 14)
                {
                    var balloon = CreateBalloon();
                    balloon.ToolTipTitle = "Дата изготовления сброшена";
                    balloon.Show("Изделия из заказной ткани требуют на изготовление 15 дней.", btInstallDate);

                    btInstallDate.Tag = null;
                    ViewInstallDate();
                }
            }
        }

        
        private static ToolTip CreateBalloon()
        {
            return new ToolTip
            {
                UseFading = true,
                UseAnimation = true,
                IsBalloon = true,
                ShowAlways = true,
                AutoPopDelay = 5000,
                InitialDelay = 10000,
                ReshowDelay = 500
            };
        }

        private void lbInstallDate_Click(object sender, EventArgs e)
        {
            var f = new TfTimeTableInstall { TypeId = (int)lbBlankType.Tag, InstallDate = (DateTime?)btInstallDate.Tag, OrderId = (int)lbCode.Tag};
            if (f.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            
            btInstallDate.Tag = f.InstallDate;
            ViewInstallDate();
        }

        public void ViewInstallDate()
        {
            var installDate = (DateTime?) btInstallDate.Tag;
            btInstallDate.ForeColor = installDate != null ? SystemColors.ControlText : Color.Red;
            btInstallDate.Text = installDate != null 
                ? ((DateTime)installDate).ToShortDateString() 
                : "<не указана>";
        }
    }
}
