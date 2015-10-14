using System;
using System.Drawing;

namespace CorniceGraph.Logic.Line
{
    public class CanvasView
    {
        public double X;
        public double Y;
        public double Phi;
        public double Zoom;
        public bool Mirrow;

        public CanvasView(double X, double Y, double Phi, double Zoom, bool Mirrow)
        {
            this.X = X;
            this.Y = Y;
            this.Phi = Phi;
            this.Zoom = Zoom;
            this.Mirrow = Mirrow;
        }

        public CanvasView(double X, double Y, double Phi, double Zoom)
        {
            this.X = X;
            this.Y = Y;
            this.Phi = Phi;
            this.Zoom = Zoom;
            this.Mirrow = false;                
        }

        public CanvasView(double X, double Y, double Phi)
        {
            this.X = X;
            this.Y = Y;
            this.Phi = Phi;
            this.Zoom = 1;
            this.Mirrow = false;
        }

        public CanvasView(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
            this.Phi = 0;
            this.Zoom = 1;
            this.Mirrow = false;
        }

        public CanvasView()
        {
            this.X = 0;
            this.Y = 0;
            this.Phi = 0;
            this.Zoom = 1;
            this.Mirrow = false;
        }

        public PointF TranslateF(Pointer Pointer)
        {
            return Translate(Pointer).PointF;
        }

        public PointF TranslateF(PointF Point)
        {
            return TranslateF((float)Point.X, (float)Point.Y);
        }

        public PointF TranslateF(double X, double Y)
        {
            return Translate(X,Y,0).PointF;
        }

        public Pointer Translate(Pointer Pointer)
        {
            return Translate(Pointer.X, Pointer.Y, Pointer.Phi);
        }

        public Pointer Translate(double X, double Y, double Phi)
        {
            Pointer p = new Pointer();
            p.X = (float)(this.X + Zoom * (X * Math.Cos(this.Phi) + Y * Math.Sin(this.Phi)));
            p.Y = (float)(this.Y + (Mirrow ? -1 : 1) *
                          Zoom * (X * Math.Sin(this.Phi) - Y * Math.Cos(this.Phi)));
            p.Phi = (Mirrow ? -1 : 1) * (this.Phi + Phi);
            return p;
        }

        public CanvasView AutoZoom(RectangleF RectangleF, double Width, double Height, double cx, double cy)
        {
            double kx = 0;
            if (RectangleF.Right - RectangleF.Left > 0.1)
                kx = (RectangleF.Right - RectangleF.Left) / (Width * (1 - cx));
            double ky = 0;
            if (RectangleF.Bottom - RectangleF.Top > 0.1)
                ky = (RectangleF.Bottom - RectangleF.Top) / (Height * (1 - cy));

            return new CanvasView(this.X, this.Y, this.Phi, this.Zoom / Math.Max(kx, ky), this.Mirrow);

        }

        public CanvasView AutoStart(RectangleF RectangleF, double Width, double Height)
        {
            return new CanvasView(
                this.X - (RectangleF.Left + RectangleF.Right) / 2 + Width / 2, 
                this.Y - (RectangleF.Bottom + RectangleF.Top) / 2 + Height / 2, 
                this.Phi, this.Zoom, this.Mirrow);
        }
    }
}