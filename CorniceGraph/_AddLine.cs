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
    public partial class TfAddLine : Form
    {
        public double theta;
        public double d;
        public double alpha;
        public double l;

        public TfAddLine()
        {
            InitializeComponent();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            alpha = Convert.ToDouble(edCorner.Value);
            alpha = (alpha/* < 0 ? -180 - alpha : 180 - alpha*/) * Math.PI / 180;
            l = Convert.ToDouble(edLength.Value);
            DialogResult = DialogResult.Yes;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void edDiag_ValueChanged(object sender, EventArgs e)
        {
            l = Convert.ToDouble(edLength.Value);
            double c = Convert.ToDouble(edDiag.Value);
            int s = c >= 0 ? 1 : -1;

            if (Math.Abs(c) > l + d)
                edDiag.Value = Convert.ToDecimal((l + d)*s);
            else
                if (Math.Abs(c) < Math.Abs(l - d))
                    edDiag.Value = Convert.ToDecimal(Math.Abs(l - d)*s);

            edCorner.ValueChanged -= edCorner_ValueChanged;
            edDiag.ValueChanged -= edDiag_ValueChanged;
            c = Convert.ToDouble(edDiag.Value);

            double psi = Math.Acos((c * c - d * d - l * l) / (2 * l * d));
            alpha = (psi - theta) * c;

            edCorner.Value = Convert.ToDecimal(alpha / Math.PI * 180);
            edCorner.ValueChanged += edCorner_ValueChanged;
            edDiag.ValueChanged += edDiag_ValueChanged;
        }

        private void edCorner_ValueChanged(object sender, EventArgs e)
        {
            l = Convert.ToDouble(edLength.Value);

            alpha = Convert.ToDouble(edCorner.Value);
            alpha = (alpha/* < 0 ? -180 - alpha : 180 - alpha*/) * Math.PI / 180;

            int s = alpha + theta >= 0 ? 1 : -1;
            double c = s*Math.Sqrt(l * l + d * d - 2 * l * d * Math.Cos(alpha + theta));

            edCorner.ValueChanged -= edCorner_ValueChanged;
            edDiag.ValueChanged -= edDiag_ValueChanged;
            edDiag.Value = Convert.ToDecimal(c);
            edCorner.ValueChanged += edCorner_ValueChanged;
            edDiag.ValueChanged += edDiag_ValueChanged;
        }

        private void rbCorner_CheckedChanged(object sender, EventArgs e)
        {
            edDiag.Enabled = rbDiag.Checked;
            edCorner.Enabled = rbCorner.Checked;
        }

        private void edLength_ValueChanged(object sender, EventArgs e)
        {
            edCorner_ValueChanged(edCorner, null);
        }
    }
}
