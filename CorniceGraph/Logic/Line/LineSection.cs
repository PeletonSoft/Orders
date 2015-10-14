using System;
using System.Drawing;
using CorniceGraph.Datasets;

namespace CorniceGraph.Logic.Line
{
    public class LineSection : LengthSection
    {
        public override LineSectionType Type
        {
            get { return LineSectionType.Line; }
        }

        public override Pointer Finish(Pointer Start)
        {
            return new Pointer(
                Start.X + Length*Math.Cos(Start.Phi),
                Start.Y + Length*Math.Sin(Start.Phi),
                Start.Phi);
        }

        public LineSection(dsLines dsLines, int ID) :
            base(dsLines, ID)
        {
        }

        public override void Draw(Graphics Graphics, Pen Pen, CanvasView View)
        {
            PointF StartF = View.TranslateF(StartPoint.Pointer);
            PointF FinishF = View.TranslateF(FinishPiont.Pointer);
            Graphics.DrawLine(Pen, StartF, FinishF);
        }
    }
}
