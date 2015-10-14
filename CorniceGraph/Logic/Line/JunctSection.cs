using System;
using System.Drawing;
using CorniceGraph.Datasets;

namespace CorniceGraph.Logic.Line
{
    public class JunctSection : Section
    {
        public override LineSectionType Type => LineSectionType.Junct;

        public override Pointer Finish(Pointer Start)
        {
            return new Pointer(Start.X, Start.Y, Start.Phi + Alpha);
        }

        public JunctSection(dsLines dsLines, int ID) :
            base(dsLines, ID)
        {
        }

        public override string Name => StartPoint.Numer.ToString();

        public override string FullName => 
            $"{Name:G} [\u03B1={(Alpha >= 0 ? 180 - Alpha*180/Math.PI : -180 - Alpha*180/Math.PI):N1}\u00B0]";

        public override void Draw(Graphics Graphics, Pen Pen, CanvasView View)
        {
            Pen.Width += 2;
            PointF PointF = View.TranslateF(StartPoint.Pointer);
            Graphics.DrawLine(Pen, PointF.X - 5, PointF.Y - 5, PointF.X + 5, PointF.Y + 5);
            Graphics.DrawLine(Pen, PointF.X - 5, PointF.Y + 5, PointF.X + 5, PointF.Y - 5);
            Pen.Width -= 2;
        }

        public override void DrawNumer(Graphics Graphics, CanvasView View, Font Font, Brush Brush)
        {
        }
    }

}
