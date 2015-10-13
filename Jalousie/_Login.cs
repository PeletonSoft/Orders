using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Jalousie
{
    public partial class TfLogin : Form
    {
        public TfLogin()
        {
            InitializeComponent();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            if (!LocalService.CheckPassword(
                Convert.ToInt32(tv.SelectedNode.Tag), edPassword.Text))
            {
                edPassword.Text = "";
                edPassword.Focus();
                MessageBox.Show("Вы ввели неправильный пароль.\nПопробуйте еще раз.",
                   "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void edPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyData == Keys.Return || e.KeyData == Keys.Enter) && btOk.Enabled)
            {
                btOk_Click(null, null);
                e.Handled = true;
            }

            if (e.KeyData == Keys.Escape)
            {
                btCancel_Click(null, null);
                e.Handled = true;
            }

        }

        private void tv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                btCancel_Click(null, null);
                e.Handled = true;
            }
        }

        private void tv_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var nd = ((TreeView) sender).GetNodeAt(e.Location);
                if (nd != null) ((TreeView) sender).SelectedNode = nd;
                ((TreeView) sender).Focus();
            }
            if (e.Button == MouseButtons.Left)
            {
                var nd = ((TreeView) sender).GetNodeAt(e.Location);
                if (nd != null && nd.Level == 1)
                {
                    ThreadStart BackThread = () => Thread.Sleep(50);
                    BackThread.BeginInvoke(delegate
                                      {
                                          ThreadStart FrontThread = () => edPassword.Focus();
                                          Invoke(FrontThread, null);
                                      }, null);
                }
            }
        }

        private void tv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            btOk.Enabled = e.Node.Level == 1;
        }

    }
}
