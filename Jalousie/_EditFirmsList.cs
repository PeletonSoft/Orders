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
    public partial class TfEditFirmsList : Form
    {
        public TfEditFirmsList()
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

        private void TfEditFirmsList_Shown(object sender, EventArgs e)
        {
            edName.Focus();
        }
    }
}
