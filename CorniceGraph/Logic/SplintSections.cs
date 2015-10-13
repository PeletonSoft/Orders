using System;
using System.Drawing;

namespace CorniceGraph.Logic
{
    public class SplintSections
    {
        public enum SplintContourType
        {
            LeftLug = -1, RightLug = -2, PreCork = -3,
            LeftEmbrasure = 1, RightEmbrasure = 2,
            Cork = 3, InsideLine = 4, OutsideLine = 5
        };

        public static SplintContourType ReverseSplintContourType(SplintContourType SplintContourType)
        {
            return (SplintContourType)(-(int)SplintContourType);
        }

        public abstract class SplintContour
        {
            protected double l;
            protected double alpha;
            protected double phi;
            protected SplintContourType type;

            public double Length
            {
                get
                {
                    return l;
                }
            }

            public double Alpha
            {
                get
                {
                    return alpha;
                }
            }

            public double Phi
            {
                get
                {
                    return phi;
                }
            }

            public SplintContourType Type
            {
                get
                {
                    return type;
                }
            }

            public System.Drawing.Drawing2D.DashStyle DashStyle
            {
                get
                {
                    switch (Type)
                    {
                        case SplintContourType.Cork:
                            return System.Drawing.Drawing2D.DashStyle.Solid;
                        case SplintContourType.InsideLine:
                            return System.Drawing.Drawing2D.DashStyle.Dot;
                        case SplintContourType.OutsideLine:
                            return System.Drawing.Drawing2D.DashStyle.Solid;
                        case SplintContourType.LeftLug:
                            return System.Drawing.Drawing2D.DashStyle.DashDot;
                        case SplintContourType.RightLug:
                            return System.Drawing.Drawing2D.DashStyle.DashDot;
                        case SplintContourType.LeftEmbrasure:
                            return System.Drawing.Drawing2D.DashStyle.DashDotDot;
                        case SplintContourType.RightEmbrasure:
                            return System.Drawing.Drawing2D.DashStyle.DashDotDot;
                    }
                    return System.Drawing.Drawing2D.DashStyle.Custom;
                }
            }

            public Pointer Finish(Pointer Start)
            {
                return new Pointer(
                    Start.X + Length * Math.Cos(Start.Phi + Alpha / 2) * TfMain.sinx(Alpha / 2),
                    Start.Y + Length * Math.Sin(Start.Phi + Alpha / 2) * TfMain.sinx(Alpha / 2),
                    Start.Phi + Alpha + Phi);
            }

            public abstract void Draw(Graphics Graphics, CanvasView View, Pointer Start, Pen Pen);

            public SplintContour(double Length, double Alpha, double Phi, SplintContourType Type)
            {
                l = Length;
                alpha = Alpha;
                phi = Phi;
                type = Type;
            }
        }

        public class SplintLineContour : SplintContour
        {
            public SplintLineContour(double Length, double Phi, SplintContourType Type) :
                base(Length, 0, Phi, Type)
            {
            }


            public override void Draw(Graphics Graphics, CanvasView View, Pointer Start, Pen Pen)
            {
                Pen.DashStyle = DashStyle;
                PointF StartF = View.TranslateF(Start);
                PointF FinishF = View.TranslateF(this.Finish(Start));
                Graphics.DrawLine(Pen, StartF, FinishF);
            }
        }

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
                    Start.X + Length / 2 * Math.Cos(Start.Phi + Alpha / 4) * TfMain.sinx(Alpha / 4),
                    Start.Y + Length / 2 * Math.Sin(Start.Phi + Alpha / 4) * TfMain.sinx(Alpha / 4),
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
}