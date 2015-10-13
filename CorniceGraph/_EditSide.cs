using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CorniceGraph
{
    public partial class TfEditSide : Form
    {
        public TfEditSide()
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

        private void rbFirstStep_CheckedChanged(object sender, EventArgs e)
        {
            edFirstSide.Enabled = cbFirstSide.Checked;
            edLastSide.Enabled = cbLastSide.Checked;
        }
    }
}
