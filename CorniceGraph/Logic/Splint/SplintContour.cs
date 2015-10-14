using System;
using System.Drawing;
using CorniceGraph.Logic.Line;

namespace CorniceGraph.Logic.Splint
{
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
                Start.X + Length * Math.Cos(Start.Phi + Alpha / 2) * MathEx.Si(Alpha / 2),
                Start.Y + Length * Math.Sin(Start.Phi + Alpha / 2) * MathEx.Si(Alpha / 2),
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
}