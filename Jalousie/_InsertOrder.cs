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
    public partial class TfInsertOrder : Form
    {
        public TfInsertOrder()
        {
            InitializeComponent();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            if (lbClientName.Tag == null)
            {
                MessageBox.Show("Вы не выбрали покупателя.", "Внимание", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Вы уверены что хотите сделать новый заказ?", "Внимание",
                MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button3)!=DialogResult.Yes)
                return;

            DialogResult = DialogResult.OK;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btClient_Click(object sender, EventArgs e)
        {
            var customerId = (int?) lbClientName.Tag ?? 0;
            var customer = Clients.TfClients.SelectCustomer
                (Settings.Default.ShopConnectionString, customerId);

            if (customer != null)
            {
                    lbClientName.Tag = customer.Код;
                    lbClientName.Text = customer.ФИО;
                    lbClientTel.Text = customer.Телефон;
            }

        }

        private void btInstallDate_Click(object sender, EventArgs e)
        {
            var f = new TfTimeTableInstall() {TypeId = (int) lbBlankType.Tag, InstallDate = (DateTime?)btInstallDate.Tag};
            if(f.ShowDialog() != DialogResult.OK || f.InstallDate == null)
            {
                return;
            }
            btInstallDate.ForeColor = SystemColors.ControlText;
            btInstallDate.Tag = f.InstallDate;
            btInstallDate.Text = ((DateTime)f.InstallDate).ToShortDateString();
        }
    }
}
