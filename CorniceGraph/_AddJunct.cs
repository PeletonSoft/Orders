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
    public partial class TfAddJunct : Form
    {
        public TfAddJunct()
        {
            InitializeComponent();
        }
        public double Maximum;
        public void tb_Scroll(object sender, EventArgs e)
        {
            if (tb.Value==0) 
                tb.Value+=2;
            if (tb.Value == tb.Maximum)
                tb.Value-=2;

            edLeft.ValueChanged -= edLeft_ValueChanged;
            edLeft.Value = (Convert.ToDecimal(Maximum * tb.Value / tb.Maximum) < edLeft.Minimum ?
                edLeft.Minimum : Convert.ToDecimal(Maximum * tb.Value / tb.Maximum));
            edLeft.ValueChanged += edLeft_ValueChanged;

            edRight.ValueChanged -= edRight_ValueChanged;
            edRight.Value = Convert.ToDecimal(Maximum - Convert.ToDouble(edLeft.Value));
            edRight.ValueChanged += edRight_ValueChanged;
        }

        private void edLeft_ValueChanged(object sender, EventArgs e)
        {
            edRight.ValueChanged -= edRight_ValueChanged;
            edRight.Value = (Convert.ToDecimal(Maximum - Convert.ToDouble(edLeft.Value)) < edRight.Minimum ?
                edRight.Minimum : Convert.ToDecimal(Maximum - Convert.ToDouble(edLeft.Value)));
            edRight.ValueChanged += edRight_ValueChanged;

            tb.Value = Convert.ToInt32(Convert.ToDouble(edLeft.Value) / Maximum * tb.Maximum);
        }

        private void edRight_ValueChanged(object sender, EventArgs e)
        {
            edLeft.ValueChanged -= edLeft_ValueChanged;
            edLeft.Value = Convert.ToDecimal(Maximum - Convert.ToDouble(edRight.Value));
            edLeft.ValueChanged += edLeft_ValueChanged;

            tb.Value = Convert.ToInt32(Convert.ToDouble(edLeft.Value) / Maximum * tb.Maximum);

        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
