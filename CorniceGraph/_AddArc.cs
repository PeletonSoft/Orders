using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CorniceGraph.Datasets;

namespace CorniceGraph
{
    public partial class TfAddArc : Form
    {
        private int NewAggregate = 0;

        public double theta;
        public double d;
        public double alpha;

        public TfAddArc()
        {
            InitializeComponent();
        }

        private void TfAddArc_Shown(object sender, EventArgs e)
        {
            pc.TabStop = false;
            pc.SizeMode = TabSizeMode.Fixed;
            pc.Appearance = TabAppearance.FlatButtons;
            pc.ItemSize = new Size(0, 1);
            MakeSituation();
            (Tag as TfMain).dsWall.tbMeasure.RowChanged += tbMeasure_RowChanged;
            (Tag as TfMain).dsWall.tbMeasure.RowDeleted += tbMeasure_RowChanged;
        }

        public void tbMeasure_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            pnDataPreview.Invalidate();
        }

        private void pc_Selecting(object sender, TabControlCancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void pnSizePreview_Paint(object sender, PaintEventArgs e)
        {
            double stWidth = 0.1; 
            double stHeight = 0.1;

            double a = Convert.ToDouble(edLength.Value) / 2;
            double b = Convert.ToDouble(edHeight.Value);

            Rectangle R = new Rectangle();
            double k = 0;


            if ((pnSizePreview.Width * (1 - 2 * stWidth)) / (pnSizePreview.Height * (1 - 2 * stHeight)) > 2 * a / b)
            {
                // вертикально
                k = b > 0.0005 ? (1 - 2 * stHeight) * pnSizePreview.Height / b : 0;
                R.X = (int)(pnSizePreview.Width / 2 - a * k);
                R.Y = (int)(stHeight * pnSizePreview.Height);
            }
            else
            {
                // горизонтально
                k = (0.5 - stWidth) * pnSizePreview.Width / a;
                R.X = (int)(stWidth * pnSizePreview.Width);
                R.Y = (int)(pnSizePreview.Height * (1 - stHeight) - b * k);
            }

            R.Width = (int)(2 * a * k);
            R.Height = (int)(2 * b * k);
            
            Pen P = new Pen(Color.Black);
            P.Width = 2;

            if (cbDown.Checked)
            {
                R.Y = (int)(pnSizePreview.Height * stHeight) - R.Height / 2;
                if (k < 0.0005)
                    e.Graphics.DrawLine(P,
                        (int)(pnSizePreview.Width * stWidth), (int)(pnSizePreview.Height * stHeight),
                        (int)(pnSizePreview.Width * (1 - stWidth)), (int)(pnSizePreview.Height * stHeight));
                else
                    if (R.Width < 1 || R.Height < 1)
                        e.Graphics.DrawLine(P, R.X + R.Width, R.Y + R.Height / 2, R.X + R.Width, R.Y + R.Height);
                    else
                        e.Graphics.DrawArc(P, R, 0, 180);
            }          
            else
            {
            if (k < 0.0005)
                e.Graphics.DrawLine(P,
                    (int)(pnSizePreview.Width * stWidth), (int)(pnSizePreview.Height * (1 - stHeight)),
                    (int)(pnSizePreview.Width * (1 - stWidth)), (int)(pnSizePreview.Height * (1 - stHeight)));
            else
                if (R.Width < 1 || R.Height < 1)
                    e.Graphics.DrawLine(P, R.X, R.Y, R.X + R.Width, R.Y + R.Height / 2);
                else
                    e.Graphics.DrawArc(P, R, 180, 180);
            }          


            P.Dispose();
        }

        private void edLength_ValueChanged(object sender, EventArgs e)
        {
            pnSizePreview.Invalidate();
        }

        private void MakeSituation()
        {
            btLast.Enabled = pc.SelectedIndex > 0;
            btNext.Enabled = pc.SelectedIndex < pc.TabCount - 1; ;
            btOk.Enabled = pc.SelectedIndex == pc.TabCount - 1;

            if (pc.TabPages[pc.SelectedIndex] == tsSize)
            {
                rbExistSize.Enabled = tbAgregateBindingSource.Count > 0;
                dbgAgregate.Enabled = rbExistSize.Checked && NewAggregate == 0;
            }

            if (pc.TabPages[pc.SelectedIndex] == tsType)
            {
                rbTypeLine_CheckedChanged(null, null);
            }

            if (pc.TabPages[pc.SelectedIndex] == tsApproximate)
            {
                rbApproximateMax_CheckedChanged(null, null);
            }

            Label[] lc = {lbType,lbSize,lbMeasure,lbData,lbApproximate,lbResult,lbPosition};
            foreach (Label lb in lc)
            {
                int n = Convert.ToInt32(lb.Tag);
                if (n < pc.SelectedIndex)
                {
                    lb.ForeColor = Color.Black;
                    lb.BackColor = Color.White;
                }
                if (n == pc.SelectedIndex)
                {
                    lb.ForeColor = Color.Red;
                    lb.BackColor = Color.White;
                }
                if (n > pc.SelectedIndex)
                {
                    lb.ForeColor = Color.Black;
                    lb.BackColor = System.Drawing.SystemColors.Control;
                }
            }

        }

        private void btLast_Click(object sender, EventArgs e)
        {
            pc.Selecting -= pc_Selecting;
            pc.SelectedIndex--;
            pc.Selecting += pc_Selecting;

            MakeSituation();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            if (pc.TabPages[pc.SelectedIndex] == tsSize)
            {
                if (rbExistSize.Checked)
                    rbTypeCustom.Checked = true;
                else
                {
                    dsWall.tbAgregateRow rw = (dsWall.tbAgregateRow)
                        (Tag as TfMain).dsWall.tbAgregate.NewRow();
                    rw.Выпуклость = Convert.ToDouble(tbCurve.Value) / 100;
                    rw.Высота_базы = Convert.ToDouble(edAdvHeight.Value);
                    rw.Высота_прогиба = Convert.ToDouble(edHeight.Value);
                    rw.Длина_базы = Convert.ToDouble(edLength.Value);
                    rw.Интервал_измерений = Convert.ToDouble(edInterval.Value);
                    rw.Название = edName.Text;
                    rw.Прогиб_вниз = cbDown.Checked;
                    rw.Тип_апроксимации = rbApproximateMax.Checked ? 1 : (rbApproximateAvg.Checked ? 2 : 3);
                    rw.Центрирование = rbMeasureCenter.Checked;
                    rw.Часть_арки = rbResultAll.Checked ? 0 : (rbResultLeft.Checked ? -1 : 1);
                    (Tag as TfMain).dsWall.tbAgregate.Rows.Add(rw);
                    (Tag as TfMain).dsWall.tbAgregate.AcceptChanges();
                    tbAgregateBindingSource.Position = tbAgregateBindingSource.Find("Код", rw.Код);
                    tbMeasureBindingSource.Filter = String.Format
                        ("[Код агрегата]={0:G}", rw.Код);
                    rbExistSize.Enabled = true;
                    rbExistSize.Checked = true;
                    cbMeasure.Checked = true;
                    rbTypeEllipce.Checked = true;
                    rbNewSize.Enabled = false;
                    NewAggregate = rw.Код;
                    dbgAgregate.Enabled = false;
                }
            }

            if (pc.TabPages[pc.SelectedIndex + 1] == tsData && cbMeasure.Checked)
            {
                cbMeasure.Checked = false;
                (Tag as TfMain).dsWall.tbMeasure.Clear();
                double L = Convert.ToDouble(edLength.Value) / 2;
                double H = Convert.ToDouble(edHeight.Value);
                double T = Convert.ToDouble(edAdvHeight.Value);
                double d = Convert.ToDouble(edInterval.Value);
                double lambda = 1 - H / L;
                double mu = Convert.ToDouble(tbCurve.Value) / 100;
                int AgregateId =
                    ((tbAgregateBindingSource.Current as DataRowView).Row as dsWall.tbAgregateRow).Код;
                dsWall.tbMeasureRow rwm;
                double x = 0;

                if (rbMeasureCenter.Checked)
                    for (int i = 0; i <= (L + 0.001) / d; i++)
                    {
                        x = -i * d;
                        rwm = (dsWall.tbMeasureRow)(Tag as TfMain).dsWall.tbMeasure.NewRow();
                        rwm.Координата = x;
                        rwm.Измерение = ArcYByX(lambda, mu, x / L) * L + T;
                        rwm.Код_агрегата = AgregateId;
                        (Tag as TfMain).dsWall.tbMeasure.Rows.Add(rwm);

                        if (i > 0)
                        {
                            rwm = (dsWall.tbMeasureRow)(Tag as TfMain).dsWall.tbMeasure.NewRow();
                            rwm.Координата = -x;
                            rwm.Измерение = ArcYByX(lambda, mu, x / L) * L + T;
                            rwm.Код_агрегата = AgregateId;
                            (Tag as TfMain).dsWall.tbMeasure.Rows.Add(rwm);
                        }

                    }
                else
                {
                    for (int i = 0; i <= 2 * (L + 0.001) / d; i++)
                    {
                        x = i * d;
                        rwm = (dsWall.tbMeasureRow)(Tag as TfMain).dsWall.tbMeasure.NewRow();
                        rwm.Координата = x;
                        rwm.Измерение = ArcYByX(lambda, mu, x / L - 1) * L + T;
                        rwm.Код_агрегата = AgregateId;
                        (Tag as TfMain).dsWall.tbMeasure.Rows.Add(rwm);
                    }
                }

                (Tag as TfMain).dsWall.tbMeasure.AcceptChanges();

            }

            if (pc.TabPages[pc.SelectedIndex + 1] == tsApproximate)
            {
                dsWall.AcceptChanges();
            }

            pc.Selecting -= pc_Selecting;
            pc.SelectedIndex++;
            pc.Selecting += pc_Selecting;

            MakeSituation();

        }

        private void btOk_Click(object sender, EventArgs e)
        {
            double L = Convert.ToDouble(edLength.Value) / 2;
            double H = Convert.ToDouble(edHeight.Value);
            double T = Convert.ToDouble(edAdvHeight.Value);
            double S = rbMeasureCenter.Checked ? 0 : L;

            double lambda = 1 - H / L;
            double mu = Convert.ToDouble(tbCurve.Value) / 100;

            double psi, c, C;
            CalcArc(lambda, mu, out psi, out C, out c);

            dsWall.tbAggregateWallRow rw;
            int AgregateId =
                ((tbAgregateBindingSource.Current as DataRowView).Row as dsWall.tbAgregateRow).Код;

            if (rbResultLeft.Checked)
            {
                rw = (Tag as TfMain).dsWall.tbAggregateWall.NewRow() as dsWall.tbAggregateWallRow;
                rw.Код_агрегата = AgregateId;
                rw.Угол = (cbDown.Checked ? -1 : 1) * (90 - psi * 180 / Math.PI);
                rw.Длина = c * L;
                rw.Номер = 1;
                (Tag as TfMain).dsWall.tbAggregateWall.Rows.Add(rw);

                rw = (Tag as TfMain).dsWall.tbAggregateWall.NewRow() as dsWall.tbAggregateWallRow;
                rw.Код_агрегата = AgregateId;
                rw.Угол = (cbDown.Checked ? -1 : 1) * psi * 180 / Math.PI;
                rw.Длина = C * L;
                rw.Номер = 2;
                (Tag as TfMain).dsWall.tbAggregateWall.Rows.Add(rw);
            }

            if (rbResultRight.Checked)
            {
                rw = (Tag as TfMain).dsWall.tbAggregateWall.NewRow() as dsWall.tbAggregateWallRow;
                rw.Код_агрегата = AgregateId;
                rw.Угол = (cbDown.Checked ? -1 : 1) * psi * 180 / Math.PI;
                rw.Длина = C * L;
                rw.Номер = 1;
                (Tag as TfMain).dsWall.tbAggregateWall.Rows.Add(rw);

                rw = (Tag as TfMain).dsWall.tbAggregateWall.NewRow() as dsWall.tbAggregateWallRow;
                rw.Код_агрегата = AgregateId;
                rw.Угол = (cbDown.Checked ? -1 : 1) * (90 - psi * 180 / Math.PI);
                rw.Длина = c * L;
                rw.Номер = 2;
                (Tag as TfMain).dsWall.tbAggregateWall.Rows.Add(rw);

            }

            if (rbResultAll.Checked)
            {
                rw = (Tag as TfMain).dsWall.tbAggregateWall.NewRow() as dsWall.tbAggregateWallRow;
                rw.Код_агрегата = AgregateId;
                rw.Угол = (cbDown.Checked ? -1 : 1) * (90 - psi * 180 / Math.PI);
                rw.Длина = c * L;
                rw.Номер = 1;
                (Tag as TfMain).dsWall.tbAggregateWall.Rows.Add(rw);

                rw = (Tag as TfMain).dsWall.tbAggregateWall.NewRow() as dsWall.tbAggregateWallRow;
                rw.Код_агрегата = AgregateId;
                rw.Угол = 2 * (cbDown.Checked ? -1 : 1) * psi * 180 / Math.PI;
                rw.Длина = 2 * C * L;
                rw.Номер = 2;
                (Tag as TfMain).dsWall.tbAggregateWall.Rows.Add(rw);

                rw = (Tag as TfMain).dsWall.tbAggregateWall.NewRow() as dsWall.tbAggregateWallRow;
                rw.Код_агрегата = AgregateId;
                rw.Угол = (cbDown.Checked ? -1 : 1) * (90 - psi * 180 / Math.PI);
                rw.Длина = c * L;
                rw.Номер = 3;
                (Tag as TfMain).dsWall.tbAggregateWall.Rows.Add(rw);
            }

            dsWall.tbAgregateRow rwa = (dsWall.tbAgregateRow)
                (tbAgregateBindingSource.Current as DataRowView).Row;

            rwa.Выпуклость = Convert.ToDouble(tbCurve.Value) / 100;
            rwa.Высота_базы = Convert.ToDouble(edAdvHeight.Value);
            rwa.Высота_прогиба = Convert.ToDouble(edHeight.Value);
            rwa.Длина_базы = Convert.ToDouble(edLength.Value);
            rwa.Интервал_измерений = Convert.ToDouble(edInterval.Value);
            rwa.Название = edName.Text;
            rwa.Прогиб_вниз = cbDown.Checked;
            rwa.Тип_апроксимации = rbApproximateMax.Checked ? 1 : (rbApproximateAvg.Checked ? 2 : 3);
            rwa.Центрирование = rbMeasureCenter.Checked;
            rwa.Часть_арки = rbResultAll.Checked ? 0 : (rbResultLeft.Checked ? -1 : 1);
            (Tag as TfMain).dsWall.AcceptChanges();

            FormClosing -= TfAddArc_FormClosing;
            DialogResult = DialogResult.Yes;
        }

        private void TfAddArc_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (MessageBox.Show("Вы уверены что хоти отказаться от добавления контура арки?",
                "Внимание", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button3) != DialogResult.Yes);
            if (!e.Cancel)
            {
                if (NewAggregate == 0)
                    return;
                string sFilter = String.Format("[Код агрегата]={0:G}", NewAggregate);

                foreach (DataRow rw in (Tag as TfMain).dsWall.tbMeasure.Select(sFilter))
                    rw.Delete();
                foreach (DataRow rw in (Tag as TfMain).dsWall.tbAggregateWall.Select(sFilter))
                    rw.Delete();
                (Tag as TfMain).dsWall.AcceptChanges();
                (Tag as TfMain).dsWall.tbAgregate.FindByКод(NewAggregate).Delete();
                (Tag as TfMain).dsWall.AcceptChanges();
            }
        }

        private void pnTypePreview_Paint(object sender, PaintEventArgs e)
        {
            double L = Convert.ToDouble(edLength.Value) / 2;
            double H = Convert.ToDouble(edHeight.Value);

            double lambda = 1 - H / L;
            double mu = Convert.ToDouble(tbCurve.Value) / 100;

            double psi, c, C;
            CalcArc(lambda, mu, out psi, out C, out c);

            double stWidth = 0.1;
            double stHeight = 0.1;

            double k = 
                (pnTypePreview.Width * (1 - 2 * stWidth)) / (pnTypePreview.Height * (1 - 2 * stHeight)) > 2 * L / H ?
                    (1 - 2 * stHeight) * pnTypePreview.Height / (H+0.001) : (1 - 2 * stWidth) * pnTypePreview.Width / (2 * L);

            double phi = - Math.PI / 2;
            double x = pnTypePreview.Width / 2 - k * L;
            double y = (1 - stHeight) * pnTypePreview.Height;
            Pen P = new Pen(Color.Black);
            P.Width = 3;

            TfMain.DrawSection(e.Graphics, P, x, y, phi, k * c * L, -psi + Math.PI / 2, out x, out y, out phi);
            TfMain.DrawSection(e.Graphics, P, x, y, phi, 2* k * C * L, 2 * psi, out x, out y, out phi);
            TfMain.DrawSection(e.Graphics, P, x, y, phi, k * c * L, -psi + Math.PI / 2, out x, out y, out phi);

            P.Dispose();

        }

        private void tbCurve_Scroll(object sender, EventArgs e)
        {
            pnTypePreview.Invalidate();
        }

        private void rbTypeLine_CheckedChanged(object sender, EventArgs e)
        {
            tbCurve.Enabled = (rbTypeCustom.Checked);
            if (rbTypeLine.Checked) tbCurve.Value = 0;
            if (rbTypeCurve.Checked) tbCurve.Value = 100;
            if (rbTypeEllipce.Checked)
            {
                double L = Convert.ToDouble(edLength.Value) / 2;
                double H = Convert.ToDouble(edHeight.Value);
                double lambda = 1 - H / L;
                double min = 100;
                int imin = 0;
                for (int i = 0; i <= 100; i++)
                {
                    double max = 0;
                    double mu = (double)i/100;
                    for (int j = 0; j <= 100; j++)
                    {
                        double x = (double)j / 100;
                        double y = ArcYByX(lambda, mu, x);
                        double ye = (1 - lambda)*Math.Sqrt(1-x*x);
                        max = Math.Max(max, Math.Abs(y - ye));
                    }
                    if (min > max)
                    {
                        min = max;
                        imin = i;
                    }
                }
                tbCurve.Value = (int)(imin);
            }

            pnTypePreview.Invalidate();
        }

        private void pnMeasurePreview_Paint(object sender, PaintEventArgs e)
        {
            double L = Convert.ToDouble(edLength.Value) / 2;
            double H = Convert.ToDouble(edHeight.Value);
            double T = Convert.ToDouble(edAdvHeight.Value);
            double d = Convert.ToDouble(edInterval.Value);

            Rectangle R = new Rectangle();
            double k = 0;

            double stWidth = 0.1;
            double stHeight = 0.1;

            if ((pnMeasurePreview.Width * (1 - 2 * stWidth)) / (pnMeasurePreview.Height * (1 - 2 * stHeight)) > 2 * L / ( H + T ))
            {
                // вертикально
                k = (H + T) > 0.0005 ? (1 - 2 * stHeight) * pnMeasurePreview.Height / (H + T) : 0;
                R.X = (int)(pnMeasurePreview.Width / 2 - L * k);
                R.Y = (int)(stHeight * pnMeasurePreview.Height);
            }
            else
            {
                // горизонтально
                k = (0.5 - stWidth) * pnMeasurePreview.Width / L;
                R.X = (int)(stWidth * pnMeasurePreview.Width);
                R.Y = (int)(pnMeasurePreview.Height * (1 - stHeight) - (H + T) * k);
            }

            R.Width = (int)(2 * L * k);
            R.Height = (int)(2 * H * k);

            Pen P = new Pen(Color.Black);
            P.Width = 2;

            if (k < 0.0005)
                    e.Graphics.DrawLine(P,
                        (int)(pnMeasurePreview.Width * stWidth), (int)(pnMeasurePreview.Height * (1 - stHeight)),
                        (int)(pnMeasurePreview.Width * (1 - stWidth)), (int)(pnMeasurePreview.Height * (1 - stHeight)));
                else
                    if (R.Width < 1 || R.Height < 1)
                        e.Graphics.DrawLine(P, R.X, R.Y, R.X + R.Width, R.Y + R.Height / 2);
                    else
                        e.Graphics.DrawArc(P, R, 180, 180);

            P.Color = Color.Red;
            e.Graphics.DrawLine(P,
                R.Left, (int)(R.Top + R.Height / 2 + k * T),
                R.Right, (int)(R.Top + R.Height / 2 + k * T));

            P.Color = Color.Red;
            P.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            P.Width = 1;

            if (rbMeasureCenter.Checked)
                for (int i = 0; i <= (L+0.001) / d; i++)
                {
                    double yp = 1 - Math.Pow(i * d / L, 2) > 0 ? H * Math.Sqrt(1 - Math.Pow(i * d / L, 2)) : 0;
                    e.Graphics.DrawLine(P,
                        R.Left + R.Width / 2 + (int)(k * i * d), (int)(R.Top + R.Height / 2 + k * T),
                        R.Left + R.Width / 2 + (int)(k * i * d), (int)(R.Top + R.Height / 2 - k * yp));
                    e.Graphics.DrawLine(P,
                        R.Left + R.Width / 2 - (int)(k * i * d), (int)(R.Top + R.Height / 2 + k * T),
                        R.Left + R.Width / 2 - (int)(k * i * d), (int)(R.Top + R.Height / 2 - k * yp));
                }
            else
            {
                for (int i = 0; i <= 2 * (L + 0.001) / d; i++)
                {

                    double yp = 1 - Math.Pow((-L + i * d) / L, 2) > 0 ? H * Math.Sqrt(1 - Math.Pow((-L + i * d) / L, 2)) : 0;
                    e.Graphics.DrawLine(P,
                        R.Left + (int)(k * i * d), (int)(R.Top + R.Height / 2 + k * T),
                        R.Left + (int)(k * i * d), (int)(R.Top + R.Height / 2 - k * yp));
                }
            }
            P.Dispose();

        }

        private void edAdvHeight_ValueChanged(object sender, EventArgs e)
        {
            pnMeasurePreview.Invalidate();
        }

        public static double ArcYByX(double lambda, double mu, double x)
        {
            if (x < 0)
                x = -x;
            if (x > 1 - 1e-6)
                return 0;
            if (lambda < 0)
                return ArcXByY(lambda / (lambda - 1), mu, x / (1 - lambda)) * (1 - lambda);
            if (lambda < 1e-6)
                return Math.Sqrt(1 - x * x);
            if (lambda > 1 - 1e-6)
                return 0;
            if (mu < 1e-6)
                return x < lambda ? (1-lambda) : Math.Sqrt(2 * x * lambda + 1 - 2 * lambda - x * x);

            double H = (1 - lambda);
            double r = (1 - mu) * (1 - lambda);
            double R = (2 * mu + lambda * lambda - 2 * mu * lambda) / (2 * mu * (1 - lambda));
            double p = R * (1 - r) / (R - r);
            return x < p ? Math.Sqrt(R * R - x * x) + H - R : Math.Sqrt(r * r - (x - (1 - r)) * (x - (1 - r)));
        }

        public static double ArcXByY(double lambda, double mu, double y)
        {
            if (y < 0)
                y = -y;
            if (y > 1 - lambda + 1e-6)
                return 0;
            if (lambda < 0)
                return ArcYByX(lambda / (lambda - 1), mu, y / (1 - lambda)) * (1 - lambda);
            if (lambda < 1e-6)
                return Math.Sqrt(1 - y * y);
            if (lambda > 1 - 1e-6)
                return 0;
            if (mu < 1e-6)
                return lambda + Math.Sqrt((1 - lambda) * (1 - lambda) - y * y);

            double H = (1 - lambda);
            double r = (1 - mu) * (1 - lambda);
            double R = (2 * mu + lambda * lambda - 2 * mu * lambda) / (2 * mu * (1 - lambda));
            double py = r * (R - H) / (R - r);
            return y > py ? Math.Sqrt(R * R - (y - H + R) * (y - H + R)) : (1 - r) + Math.Sqrt(r * r - y * y);

        }
        private void pnDataPreview_Paint(object sender, PaintEventArgs e)
        {
            double L = Convert.ToDouble(edLength.Value) / 2;
            double H = Convert.ToDouble(edHeight.Value);
            double T = Convert.ToDouble(edAdvHeight.Value);
            double d = Convert.ToDouble(edInterval.Value);

            Rectangle R = new Rectangle();
            double k = 0;

            double stWidth = 0.1;
            double stHeight = 0.1;

            if ((pnDataPreview.Width * (1 - 2 * stWidth)) / (pnDataPreview.Height * (1 - 2 * stHeight)) > 2 * L / (H + T))
            {
                // вертикально
                k = (H + T) > 0.0005 ? (1 - 2 * stHeight) * pnDataPreview.Height / (H + T) : 0;
                R.X = (int)(pnDataPreview.Width / 2 - L * k);
                R.Y = (int)(stHeight * pnDataPreview.Height);
            }
            else
            {
                // горизонтально
                k = (0.5 - stWidth) * pnDataPreview.Width / L;
                R.X = (int)(stWidth * pnDataPreview.Width);
                R.Y = (int)(pnDataPreview.Height * (1 - stHeight) - (H + T) * k);
            }

            R.Width = (int)(2 * L * k);
            R.Height = (int)(2 * H * k);

            Pen P = new Pen(Color.Black);
            P.Width = 2;

            P.Color = Color.Red;
            e.Graphics.DrawLine(P,
                R.Left, (int)(R.Top + R.Height / 2 + k * T),
                R.Right, (int)(R.Top + R.Height / 2 + k * T));

            P.Color = Color.Red;
            P.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            P.Width = 1;

            double S = rbMeasureCenter.Checked ? 0 : L;

            DataRow[] rc = (Tag as TfMain).dsWall.tbMeasure.Select(
                String.Format("[Код агрегата]={0:G}",
                ((tbAgregateBindingSource.Current as DataRowView).Row as dsWall.tbAgregateRow).Код), 
                "[Координата] ASC");

            int count = 0;
            foreach (dsWall.tbMeasureRow rw in rc)
            {
                if (rw.RowState == DataRowState.Detached || rw.RowState == DataRowState.Deleted)
                    continue;
                count++;
            }
            Point[] pc = new Point[count];
            count = 0;

            foreach (dsWall.tbMeasureRow rw in rc)
            {
                if (rw.RowState == DataRowState.Detached || rw.RowState == DataRowState.Deleted)
                    continue;
                double x = rw.Координата - S;
                double y = rw.Измерение;
                e.Graphics.DrawLine(P,
                    R.Left + R.Width / 2 + (int)(k * x), (int)(R.Top + R.Height / 2 + k * T),
                    R.Left + R.Width / 2 + (int)(k * x), (int)(R.Top + R.Height / 2 + k * (T - y)));
                pc[count].X = R.Left + R.Width / 2 + (int)(k * x);
                pc[count].Y = (int)(R.Top + R.Height / 2 + k * (T - y));
                count++;
            }

            P.Color = Color.Black;
            P.Width = 3;

            if (count>1)
                e.Graphics.DrawCurve(P, pc);
            
            P.Dispose();

        }

        public static void CalcArc(double lambda, double mu, out double psi, out double C, out double c)
        {
            if (lambda < 0)
            {
                double tpsi, tc, tC;
                CalcArc(lambda/(lambda-1), mu, out tpsi, out tC, out tc);
                psi = Math.PI / 2 - tpsi;
                C = tc * (1 - lambda);
                c = tC * (1 - lambda);
                return;
            }

            if (lambda < 1e-6)
            {
                psi = Math.PI / 2;
                C = Math.PI / 2;
                c = 0;
                return;
            }

            if (lambda > 1 - 1e-6)
            {
                psi = 0;
                C = 1;
                c = 0;
                return;
            }

            if (mu < 1e-6)
            {
                C = lambda;
                psi = 0;
                c = Math.PI * (1 - lambda) / 2;
                return;
            }

            psi = Math.Atan
                (2 * (lambda + mu - mu * lambda) * mu * (1 - lambda) /
                (lambda * (2 * mu + lambda - 2 * mu * lambda)));
            C = psi * (2 * mu + lambda * lambda - 2 * mu * lambda) / (2 * mu * (1 - lambda));
            c = (1 - mu) * (1 - lambda) * (Math.PI / 2 - psi);
            return;
        }

        private void rbApproximateMax_CheckedChanged(object sender, EventArgs e)
        {
            double L = Convert.ToDouble(edLength.Value) / 2;
            double S = rbMeasureCenter.Checked ? 0 : L;
            double H = Convert.ToDouble(edHeight.Value);
            double T = Convert.ToDouble(edAdvHeight.Value);
            double lambda = 1 - H / L;
            double min = 100;
            int imin = 0;

            DataRow[] rc = (Tag as TfMain).dsWall.tbMeasure.Select(
                String.Format("[Код агрегата]={0:G}",
                    ((tbAgregateBindingSource.Current as DataRowView).Row as dsWall.tbAgregateRow).Код),
                "[Координата] ASC");

            for (int i = 0; i <= 100; i++)
            {
                double max = 0;
                double mu = (double)i / 100;
                double n = 0;
                double sumd = 0;
                double sums = 0;
                foreach (dsWall.tbMeasureRow rw in rc)
                {
                    if (rw.RowState == DataRowState.Detached || rw.RowState == DataRowState.Deleted)
                        continue;

                    double x = (rw.Координата - S) / L;
                    double y = ArcYByX(lambda, mu, x);
                    double yr = (rw.Измерение - T) / L;

                    max = Math.Max(max, Math.Abs(y - yr));
                    n++;
                    sumd += Math.Abs(y - yr);
                    sums += Math.Pow(y - yr, 2);
                }

                if (rbApproximateMax.Checked && min > max)
                {
                    min = max;
                    imin = i;
                }

                if (rbApproximateAvg.Checked && min > sumd / n)
                {
                    min = sumd / n;
                    imin = i;
                }

                if (rbApproximateStd.Checked && min > Math.Sqrt(sums / n))
                {
                    min = Math.Sqrt(sums / n);
                    imin = i;
                }

            }

            tbCurve.Value = (int)(imin);
            pnApproximatePreview.Invalidate();
        }

        private void pnApproximatePreview_Paint(object sender, PaintEventArgs e)
        {
            double L = Convert.ToDouble(edLength.Value) / 2;
            double H = Convert.ToDouble(edHeight.Value);
            double T = Convert.ToDouble(edAdvHeight.Value);
            double S = rbMeasureCenter.Checked ? 0 : L;

            double lambda = 1 - H / L;
            double mu = Convert.ToDouble(tbCurve.Value) / 100;

            double psi, c, C;
            CalcArc(lambda, mu, out psi, out C, out c);

            double stWidth = 0.1;
            double stHeight = 0.1;

            double k =
                (pnApproximatePreview.Width * (1 - 2 * stWidth)) / (pnApproximatePreview.Height * (1 - 2 * stHeight)) > 2 * L / H ?
                    (1 - 2 * stHeight) * pnApproximatePreview.Height / (H + 0.001) : 
                    (1 - 2 * stWidth) * pnApproximatePreview.Width / (2 * L);

            double phi = -Math.PI / 2;
            double x = pnApproximatePreview.Width / 2 - k * L;
            double y = (1 - stHeight) * pnApproximatePreview.Height;

            Pen P = new Pen(Color.Black);
            P.Width = 3;

            TfMain.DrawSection(e.Graphics, P, x, y, phi, k * c * L, -psi + Math.PI / 2, out x, out y, out phi);
            TfMain.DrawSection(e.Graphics, P, x, y, phi, 2 * k * C * L, 2 * psi, out x, out y, out phi);
            TfMain.DrawSection(e.Graphics, P, x, y, phi, k * c * L, -psi + Math.PI / 2, out x, out y, out phi);

            P.Color = Color.Red;
            P.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            P.Width = 3;

            DataRow[] rc = (Tag as TfMain).dsWall.tbMeasure.Select(
                String.Format("[Код агрегата]={0:G}",
                ((tbAgregateBindingSource.Current as DataRowView).Row as dsWall.tbAgregateRow).Код),
                "[Координата] ASC");

            foreach (dsWall.tbMeasureRow rw in rc)
            {
                if (rw.RowState == DataRowState.Detached || rw.RowState == DataRowState.Deleted)
                    continue;
                int X = pnApproximatePreview.Width / 2 + (int)(k * (rw.Координата - S));
                int Y = (int)(pnApproximatePreview.Height * (1 - stHeight) - k * (rw.Измерение - T));
                e.Graphics.DrawEllipse(P, X - 5, Y - 5, 10, 10);
            }

            P.Dispose();
        }

        private void pnResultPreview_Paint(object sender, PaintEventArgs e)
        {
            double L = Convert.ToDouble(edLength.Value) / 2;
            double H = Convert.ToDouble(edHeight.Value);
            double T = Convert.ToDouble(edAdvHeight.Value);
            double S = rbMeasureCenter.Checked ? 0 : L;

            double lambda = 1 - H / L;
            double mu = Convert.ToDouble(tbCurve.Value) / 100;

            double psi, c, C;
            CalcArc(lambda, mu, out psi, out C, out c);

            double stWidth = 0.1;
            double stHeight = 0.1;

            double k =
                (pnResultPreview.Width * (1 - 2 * stWidth)) / (pnResultPreview.Height * (1 - 2 * stHeight)) > 2 * L / H ?
                    (1 - 2 * stHeight) * pnResultPreview.Height / (H + 0.001) :
                    (1 - 2 * stWidth) * pnResultPreview.Width / (2 * L);


            double phi = 0;
            double x = 0;
            double y = 0;

            if (cbDown.Checked)
            {
                if (rbResultLeft.Checked)
                {
                    phi = -Math.PI;
                    x = pnResultPreview.Width / 2;
                    y = stHeight * pnResultPreview.Height + k * H;
                }
                else
                {
                    phi = Math.PI / 2;
                    x = pnResultPreview.Width / 2 + k * L;
                    y = stHeight * pnResultPreview.Height;
                }
            }
            else
            {
                if (rbResultRight.Checked)
                {
                    phi = 0;
                    x = pnResultPreview.Width / 2;
                    y = (1 - stHeight) * pnResultPreview.Height - k * H;
                }
                else
                {
                    phi = -Math.PI / 2;
                    x = pnResultPreview.Width / 2 - k * L;
                    y = (1 - stHeight) * pnResultPreview.Height;
                }
            }


            Pen P = new Pen(Color.Black);
            P.Width = 3;

            if (!rbResultRight.Checked && !cbDown.Checked || !rbResultLeft.Checked && cbDown.Checked)
            {
                TfMain.DrawSection(e.Graphics, P, x, y, phi, k * c * L, -psi + Math.PI / 2, out x, out y, out phi);
                TfMain.DrawSection(e.Graphics, P, x, y, phi, k * C * L, psi, out x, out y, out phi);
            }
            if (!rbResultRight.Checked && cbDown.Checked || !rbResultLeft.Checked && !cbDown.Checked)
            {
                TfMain.DrawSection(e.Graphics, P, x, y, phi, k * C * L, psi, out x, out y, out phi);
                TfMain.DrawSection(e.Graphics, P, x, y, phi, k * c * L, -psi + Math.PI / 2, out x, out y, out phi);
            }

            P.Dispose();

        }

        private void rbResultLeft_CheckedChanged(object sender, EventArgs e)
        {
            pnResultPreview.Invalidate();
        }

        private void tbAgregateBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (tbAgregateBindingSource.Current == null || rbNewSize.Checked)
                return;
            dsWall.tbAgregateRow rw = (dsWall.tbAgregateRow)
                (tbAgregateBindingSource.Current as DataRowView).Row;
            edLength.Value = Convert.ToDecimal(rw.Длина_базы);
            edHeight.Value = Convert.ToDecimal(rw.Высота_прогиба);
            cbDown.Checked = rw.Прогиб_вниз;
            tbCurve.Value = Convert.ToInt32(rw.Выпуклость * 100);
            cbMeasure.Checked = false;
            edAdvHeight.Value = Convert.ToDecimal(rw.Высота_базы);
            edInterval.Value = Convert.ToDecimal(rw.Интервал_измерений);
            rbMeasureCenter.Checked = rw.Центрирование;
            rbMeasureLeft.Checked = !rw.Центрирование;
            rbApproximateMax.Checked = rw.Тип_апроксимации == 1;
            rbApproximateAvg.Checked = rw.Тип_апроксимации == 2;
            rbApproximateStd.Checked = rw.Тип_апроксимации == 3;
            rbResultLeft.Checked = rw.Часть_арки == -1;
            rbResultAll.Checked = rw.Часть_арки == 0;
            rbResultRight.Checked = rw.Часть_арки == 1;
            rbTypeCustom.Checked = true;
            tbMeasureBindingSource.Filter = String.Format
                ("[Код агрегата]={0:G}", rw.Код);

        }

        private void rbExistSize_CheckedChanged(object sender, EventArgs e)
        {
            dbgAgregate.Enabled = rbExistSize.Checked && NewAggregate == 0;
            if (rbExistSize.Checked)
                tbAgregateBindingSource_CurrentChanged(dbgAgregate, null);
            else
            {
                edName.Text = "Арка";
                edLength.Value = Convert.ToDecimal(0.1);
                edHeight.Value = Convert.ToDecimal(0.0);
            }
        }

        private void rbCorner_CheckedChanged(object sender, EventArgs e)
        {
            edDiag.Enabled = rbDiag.Checked;
            edCorner.Enabled = rbCorner.Checked;
        }

        private void edDiag_ValueChanged(object sender, EventArgs e)
        {
            double l = Convert.ToDouble(edLength.Value);
            double c = Convert.ToDouble(edDiag.Value);
            int s = c >= 0 ? 1 : -1;

            if (Math.Abs(c) > l + d)
                edDiag.Value = Convert.ToDecimal((l + d) * s);
            else
                if (Math.Abs(c) < Math.Abs(l - d))
                    edDiag.Value = Convert.ToDecimal(Math.Abs(l - d) * s);

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
            double l = Convert.ToDouble(edLength.Value);

            alpha = Convert.ToDouble(edCorner.Value);
            alpha = (alpha/* < 0 ? -180 - alpha : 180 - alpha*/) * Math.PI / 180;

            int s = alpha + theta >= 0 ? 1 : -1;
            double c = s * Math.Sqrt(l * l + d * d - 2 * l * d * Math.Cos(alpha + theta));

            edCorner.ValueChanged -= edCorner_ValueChanged;
            edDiag.ValueChanged -= edDiag_ValueChanged;
            edDiag.Value = Convert.ToDecimal(c);
            edCorner.ValueChanged += edCorner_ValueChanged;
            edDiag.ValueChanged += edDiag_ValueChanged;
        }


    }

}
