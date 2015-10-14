using System;
using System.Drawing;
using CorniceGraph.Datasets;

namespace CorniceGraph.Logic.Line
{
    public abstract class LengthSection : Section
    {

        public override string Name
        {
            get
            {
                return String.Format("{0:G}-{1:G}", StartPoint.Name, FinishPiont.Name);
            }
        }

        public override string FullName
        {
            get
            {
                return String.Format("{0:G} [L={1:N2}]", Name, Length);
            }
        }

        public LengthSection(dsLines dsLines, int ID) :
            base(dsLines, ID)
        {
        }

        public override void DrawNumer(Graphics Graphics, CanvasView View, Font Font, Brush Brush)
        {
            StartPoint.Draw(Graphics, View, Font, Brush);
            FinishPiont.Draw(Graphics, View, Font, Brush);
        }

    }
}
