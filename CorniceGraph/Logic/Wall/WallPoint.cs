using System;
using System.Data;
using System.Drawing;
using CorniceGraph.Datasets;
using CorniceGraph.Logic.Line;

namespace CorniceGraph.Logic.Wall
{
    public class WallPoint
    {
        private dsWall dsWall;
        private double x;
        private double y;
        private double phi;
        private int N;

        public int SegnentNumer
        {
            get
            {
                return N;
            }
        }

        public int Numer
        {
            get
            {
                int n = 0;
                DataRow[] rc = dsWall.tbWallSegment.Select("", "[Номер] ASC");
                if (rc.Length < 0)
                    return 1;

                foreach (dsWall.tbWallSegmentRow rw in rc)
                {
                    if (rw.Номер < N && rw.Длина > 1e-6 || rw.Номер == N)
                        n++;
                }
                if ((rc[rc.Length - 1] as dsWall.tbWallSegmentRow).Номер + 1 == N)
                    n++;
                return n;
            }
        }

        public double X
        {
            get
            {
                Calc();
                return x;
            }
        }

        public double Y
        {
            get
            {
                Calc();
                return y;
            }
        }

        public PointF PointF
        {
            get
            {
                return Pointer.PointF;
            }
        }

        public Pointer Pointer
        {
            get
            {
                return new Pointer(X, Y, Phi);
            }
        }

        public double Phi
        {
            get
            {
                Calc();
                return phi;
            }
        }

        public WallPoint(dsWall dsWall, int Numer)
        {
            this.dsWall = dsWall;
            N = Numer;
            Calc();
        }

        private void Calc()
        {
            x = 0;
            y = 0;
            phi = 0;

            DataRow[] rc = dsWall.tbWallSegment.Select
                ("[Номер]<" + N.ToString(), "[Номер] ASC");

            foreach (dsWall.tbWallSegmentRow rw in rc)
            {
                double l = rw.Длина;
                double alpha = rw.Угол / 180 * Math.PI;
                x += l * Math.Cos(phi + alpha / 2) * MathEx.Si(alpha / 2);
                y += l * Math.Sin(phi + alpha / 2) * MathEx.Si(alpha / 2);
                phi += alpha;
            }
        }

        public void Draw(Graphics Graphics, CanvasView View, Font Font, Brush Brush)
        {
            PointF p = View.TranslateF(PointF);
            p.X += 0;
            p.Y += 0;
            Graphics.DrawString(Numer.ToString(), Font, Brush, p);
        }
    }

}
