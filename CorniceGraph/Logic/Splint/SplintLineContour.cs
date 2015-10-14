using System.Drawing;
using CorniceGraph.Logic.Line;

namespace CorniceGraph.Logic.Splint
{
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
}