using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using CorniceGraph.Datasets;
using CorniceGraph.Logic.Line;

namespace CorniceGraph.Logic.Wall
{
    public class WallArc : WallPartSection
    {
        private double r;
        private double alpha;

        public override double Alpha
        {
            get
            {
                Calc();
                return alpha;
            }
        }

        public double Radius
        {
            get
            {
                Calc();
                return r;
            }
        }

        public Pointer Center
        {
            get
            {
                Pointer C = new Pointer();
                C.X = StartPoint.Pointer.X - Length / Alpha * Math.Sin(StartPoint.Pointer.Phi);
                C.Y = StartPoint.Pointer.Y + Length / Alpha * Math.Cos(StartPoint.Pointer.Phi);
                if (Alpha > 0)
                    C.Phi = Math.PI / 2 - StartPoint.Pointer.Phi;
                else
                    C.Phi = -Math.PI / 2 - StartPoint.Pointer.Phi;

                return C;
            }
        }

        public WallArc(dsWall dsWall, int ID)
            : base(dsWall, ID)
        {
        }

        protected override void Calc()
        {
            WallType = WallType.Arc;
            dsWall.tbWallSegmentRow rw = dsWall.tbWallSegment.FindByКод(ID);
            L = rw.Длина;
            alpha = rw.Угол * Math.PI / 180;
            r = Math.Abs(L / alpha);
            start = rw.Номер;
            finish = rw.Номер + 1;
        }

        protected override string Get_FullName()
        {
            return String.Format("{0:G} [L={1:N2} R={2:N2} \u03B1={3:N1}\u00B0]",
                Name, L, r, alpha * 180 / Math.PI);
        }

        protected override Wall Get_Wall()
        {
            DataRow[] rc = dsWall.tbWallDetail.Select
                ("[Код сегмента]=" + ID.ToString());

            if (rc.Length <= 0)
                return null;
            return new Wall(dsWall, (rc[0] as dsWall.tbWallDetailRow).Код_стены);

        }

        public override Pointer Finish(Pointer Start)
        {
            double Si = Math.Sin(Alpha / 2) / (Alpha / 2);
            return new Pointer(
                Start.X + Length * Math.Cos(Start.Phi + Alpha / 2) * Si,
                Start.Y + Length * Math.Sin(Start.Phi + Alpha / 2) * Si,
                Start.Phi + Alpha);
        }

        public Pointer Middle
        {
            get
            {
                double Si = Math.Sin(Alpha / 4) / (Alpha / 4);
                return new Pointer(
                    StartPoint.Pointer.X + Length / 2 * Math.Cos(StartPoint.Pointer.Phi + Alpha / 4) * Si,
                    StartPoint.Pointer.Y + Length / 2 * Math.Sin(StartPoint.Pointer.Phi + Alpha / 4) * Si,
                    StartPoint.Pointer.Phi + Alpha / 2);
            }
        }

        public override void Draw(Graphics Graphics, Pen Pen, CanvasView View)

        {
            float R = (float)(Radius * View.Zoom);
            PointF C = View.TranslateF(Center);
            RectangleF RectangleF = new RectangleF(C.X - R, C.Y - R, 2 * R, 2 * R);

            Graphics.DrawArc(Pen, RectangleF,
                (float)(View.Translate(Center).Phi * 180 / Math.PI),
                -(View.Mirrow ? -1 : 1) * (float)(Alpha * 180 / Math.PI));
            //DrawNumer(Graphics,CanvasView);
        }
    }
}
