using System;
using System.Drawing;
using CorniceGraph.Datasets;
using CorniceGraph.Logic.Line;

namespace CorniceGraph.Logic
{
    public class ArcSection : LengthSection
    {
        public override LineSectionType Type
        {
            get
            {
                return LineSectionType.Arc;
            }
        }

        public override Pointer Finish(Pointer Start)
        {
            return new Pointer(
                Start.X + 2 * Length * Math.Cos(Start.Phi + Alpha / 2) * Math.Sin(Alpha / 2) / Alpha,
                Start.Y + 2 * Length * Math.Sin(Start.Phi + Alpha / 2) * Math.Sin(Alpha / 2) / Alpha,
                Start.Phi + Alpha);
        }

        public override string FullName
        {
            get
            {
                return String.Format("{0:G} [L={1:N2} R={2:N2} \u03B1={3:N1}\u00B0]",
                    Name, Length, Math.Abs(Radius),
                    Alpha > 0 ? 180 - Alpha * 180 / Math.PI : -180 - Alpha * 180 / Math.PI);
            }
        }

        public double Radius
        {
            get
            {
                return Math.Abs(Length / Alpha);
            }
        }

        public ArcSection(dsLines dsLines, int ID) :
            base(dsLines, ID)
        {
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

        public override void Draw(Graphics Graphics, Pen Pen, CanvasView View)
        {
            float R = (float)(Radius * View.Zoom);
            PointF C = View.TranslateF(Center);
            RectangleF RectangleF = new RectangleF(C.X - R, C.Y - R, 2 * R, 2 * R);

            Graphics.DrawArc(Pen, RectangleF,
                (float)(View.Translate(Center).Phi * 180 / Math.PI),
                -(View.Mirrow ? -1 : 1) * (float)(Alpha * 180 / Math.PI));

        }
    }
}
