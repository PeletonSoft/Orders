using System;
using System.Drawing;
using CorniceGraph.Logic.Line;

namespace CorniceGraph.Logic
{
    public static class DrawEx
    {
        public static void DrawArc(Graphics G, Pen P, double X, double Y, double R, double beta0, double alpha)
        {
            RectangleF Rect = new RectangleF(
                (float)(X - Math.Abs(R)), (float)(Y - Math.Abs(R)),
                (float)(2 * Math.Abs(R)), (float)(2 * Math.Abs(R)));
            G.DrawArc(P, Rect, (float)(beta0 * 180 / Math.PI), (float)(alpha * 180 / Math.PI));

        }

        public static void DrawSection(Graphics G, Pen P, double x0, double y0, double phi0, double l, double alpha,
            out double x, out double y, out double phi)
        {
            phi = phi0 + alpha;
            x = x0 + l * Math.Cos(phi0 + alpha / 2) *MathEx.Si(alpha / 2);
            y = y0 + l * Math.Sin(phi0 + alpha / 2) *MathEx.Si(alpha / 2);

            if (l < 1)
                return;

            PointF z0 = new PointF((float)x0, (float)y0);
            PointF z = new PointF((float)x, (float)y);
            if (Math.Abs(alpha) < 0.01)
                G.DrawLine(P, z0, z);
            else
            {
                double R = l/alpha;
                if (2*l > 5*Math.Abs(alpha))
                {
                    double X = x - R * Math.Sin(phi);
                    double Y = y + R * Math.Cos(phi);
                    double beta0 = phi0 - Math.PI / 2 * Math.Sign(alpha);
                    DrawArc(G, P, X, Y, R, beta0, alpha);
                }

            }
        }

        public static void DrawZoom(Graphics Graphics, CanvasView View, int Width, int Height)
        {
            double M = 100 * View.Zoom;
            while (M > 0.8 * Width)
                M /= 10;
            Pen ZoomPen = new Pen(Color.Magenta, 2);
            Graphics.DrawLine(ZoomPen, 10, Height - 10, 10 + (int)M, Height - 10);
            Graphics.DrawLine(ZoomPen, 10, Height - 10, 10, Height - 13);
            Graphics.DrawLine(ZoomPen, 10 + (int)M, Height - 10, 10 + (int)M, Height - 13);
            Graphics.DrawString((M / View.Zoom).ToString("N2") + " м", new Font("Arial", 8),
                new SolidBrush(Color.Green), 10 + (float)M, Height - 18);

        }
    }
}
