using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Jalousie
{
    public partial class TfInsertDictionary : Form
    {
        public TfInsertDictionary()
        {
            InitializeComponent();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void rbInteger_CheckedChanged(object sender, EventArgs e)
        {
            edFloat.Enabled = rbFloat.Checked;
            edInteger.Enabled = rbInteger.Checked;
            edText.Enabled = rbText.Checked;
            lbfValue.Enabled = rbFloat.Checked;
            lbiValue.Enabled = rbInteger.Checked;
            lbtValue.Enabled = rbText.Checked;
            if (edFloat.Enabled) edFloat.Focus(); else edFloat.Value = 0;
            if (edInteger.Enabled) edInteger.Focus(); else edInteger.Value = 0;
            if (edText.Enabled) edText.Focus(); else edText.Text = "";
        }
    }
}
