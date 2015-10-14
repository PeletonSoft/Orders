using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CorniceGraph.Datasets;
using CorniceGraph.Logic;
using CorniceGraph.Logic.Line;
using CorniceGraph.Logic.Splint;

namespace CorniceGraph
{
    public partial class TfAddSplint : Form
    {
        public TfAddSplint()
        {
            InitializeComponent();
        }

        public SplintContourType StartType;

        public void lcb_SelectedIndexChanged(object sender, EventArgs e)
        {
            dsSplints.tbComponentsRow rw =
                (Tag as TfMain).dsSplints.tbComponents.FindByКод(Convert.ToInt32(lcb.SelectedValue));
            edValue.Maximum = Convert.ToDecimal(rw.Максимум);
            edValue.Minimum = Convert.ToDecimal(rw.Минимум);
            edValue.Value = Convert.ToDecimal(rw.Значение);
            edValue.Increment = Convert.ToDecimal(rw.Инкремент);
            edValue.DecimalPlaces = rw.Мантиса;
            lbmin.Text = rw.Минимум.ToString("N" + rw.Мантиса.ToString());
            lbmax.Text = rw.Максимум.ToString("N" + rw.Мантиса.ToString());

            edValue.Enabled = rw.Вариация;
            tb.Enabled = rw.Вариация;
            if (!rw.Вариация)
            {
                pn.Invalidate();
                return;
            }

            tb.Scroll -= tb_Scroll;
            tb.Value = Convert.ToInt32((edValue.Value - edValue.Minimum) / (edValue.Maximum - edValue.Minimum) *
                (tb.Maximum - tb.Minimum) + tb.Minimum);
            tb.Scroll += tb_Scroll;
            pn.Invalidate();

        }

        private void tb_Scroll(object sender, EventArgs e)
        {
            decimal newValue =
                (edValue.Maximum - edValue.Minimum) * (tb.Value - tb.Minimum) / (tb.Maximum - tb.Minimum) +
                edValue.Minimum;
            edValue.Value = (newValue < edValue.Minimum ? edValue.Minimum :
                (newValue > edValue.Maximum ? edValue.Maximum : newValue));
            pn.Invalidate();
        }

        private void TfAddSplint_Shown(object sender, EventArgs e)
        {
            
        }

        private void edValue_ValueChanged(object sender, EventArgs e)
        {
            if (edValue.Maximum - edValue.Minimum <= 0)
                return;
            tb.Scroll -= tb_Scroll;
            tb.Value = Convert.ToInt32((edValue.Value - edValue.Minimum) / (edValue.Maximum - edValue.Minimum) *
                (tb.Maximum - tb.Minimum) + tb.Minimum);
            tb.Scroll += tb_Scroll;
            pn.Invalidate();
        }

        private void pn_Paint(object sender, PaintEventArgs e)
        {
            SplintComponent SplintCompontent =
                new SplintComponent(
                    (Tag as TfMain).dsSplints, (Tag as TfMain).dsLines, Convert.ToInt32(lcb.SelectedValue),
                    StartType, Convert.ToDouble(edValue.Value), 0, 0);
            CanvasView View = new CanvasView(20, 20, 0, 200, true);
            Pointer Start = new Pointer(0, 0, -Math.PI / 2);
            View = View.AutoZoom(SplintCompontent.Border(View, Start), pn.Width, pn.Height, 0.15, 0.25);
            View = View.AutoStart(SplintCompontent.Border(View, Start), pn.Width, pn.Height);
            SplintCompontent.Draw(e.Graphics, View, Start, new Pen(Color.Black, 2));
            DrawEx.DrawZoom(e.Graphics, View, pn.Width, pn.Height);
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public string ComponentList()
        {
            dsSplints.tbContourRow[] rc = (dsSplints.tbContourRow[])
                (Tag as TfMain).dsSplints.tbContour.Select("[Тип]="+((int)StartType).ToString());
            int i = 0;
            if (rc.Length <= 0)
                return "";
            string s = "";
            foreach (dsSplints.tbContourRow rw in rc)
            {
                i++;
                if (i > 1)
                    s += ',';
                s += rw.Код_компоненты.ToString();
            }
            return s;
        }
    }
}
