using System;
using System.Drawing;

namespace CorniceGraph.Logic.Line
{
    public class Pointer
    {
        public double X;
        public double Y;
        public double Phi;

        public Pointer()
        {
            this.X = 0;
            this.Y = 0;
            this.Phi = 0;
        }

        public Pointer(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
            this.Phi = 0;
        }

        public Pointer(double X, double Y, double Phi)
        {
            this.X = X;
            this.Y = Y;
            this.Phi = Phi;
        }

        public PointF PointF
        {
            get
            {
                return new PointF((float)X, (float)Y);
            }
        }

        public Pointer ClearancePointer(double Clearance)
        {
            Pointer P = new Pointer();
            P.Phi = Phi;
            P.X = this.X - Clearance * Math.Sin(P.Phi);
            P.Y = this.Y + Clearance * Math.Cos(P.Phi);
            return P;

        }
    }
}