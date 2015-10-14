using System;
using System.Drawing;
using CorniceGraph.Logic.Line;

namespace CorniceGraph.Logic.Splint
{
    public class SplintArcContour : SplintContour
    {
        public SplintArcContour(double Length, double Alpha, double Phi, SplintContourType Type) :
            base(Length, Alpha, Phi, Type)
        {
        }

        public Pointer Center(Pointer Start)
        {
            Pointer C = new Pointer();
            C.X = Start.X - Length / Alpha * Math.Sin(Start.Phi);
            C.Y = Start.Y + Length / Alpha * Math.Cos(Start.Phi);
            if (Alpha > 0)
                C.Phi = Math.PI / 2 - Start.Phi;
            else
                C.Phi = -Math.PI / 2 - Start.Phi;
            return C;

        }

        public Pointer Middle(Pointer Start)
        {
            return new Pointer(
                Start.X + Length / 2 * Math.Cos(Start.Phi + Alpha / 4) * MathEx.Si(Alpha / 4),
                Start.Y + Length / 2 * Math.Sin(Start.Phi + Alpha / 4) * MathEx.Si(Alpha / 4),
                Start.Phi + Alpha / 2);
        }

        public double Radius
        {
            get
            {
                return Math.Abs(Length / Alpha);
            }
        }

        public override void Draw(Graphics Graphics, CanvasView View, Pointer Start, Pen Pen)
        {
            Pen.DashStyle = DashStyle;
            float R = (float)(Radius * View.Zoom);
            PointF C = View.TranslateF(Center(Start));
            RectangleF RectangleF = new RectangleF(C.X - R, C.Y - R, 2 * R, 2 * R);

            Graphics.DrawArc(Pen, RectangleF,
                (float)(View.Translate(Center((Start))).Phi * 180 / Math.PI),
                -(View.Mirrow ? -1 : 1) * (float)(Alpha * 180 / Math.PI));

        }
    }
}