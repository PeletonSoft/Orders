using System;
using System.Drawing;
using System.Windows.Forms;
using CorniceGraph.Datasets;

namespace CorniceGraph.Logic.Line
{
    public abstract class Section
    {
        protected dsLines dsLines;
        protected int Its_ID;
        protected double alpha;
        protected double length;


        public abstract LineSectionType Type
        {
            get;
        }

        public int ID
        {
            get
            {
                return Its_ID;
            }
        }

        public double Alpha
        {
            get
            {
                Calc();
                return alpha;
            }
        }

        public double Length
        {
            get
            {
                Calc();
                return length;
            }
        }

        public Section(dsLines dsLines, int ID)
        {
            Its_ID = ID;
            this.dsLines = dsLines;
            Calc();
        }

        public abstract Pointer Finish(Pointer Start);

        private void Calc()
        {
            dsLines.tbLineSectionsRow rw = (dsLines.tbLineSectionsRow)
                dsLines.tbLineSections.Select("[Код]=" + ID.ToString())[0];
            length = rw.Длина;
            alpha = rw.Угол * Math.PI / 180;
        }

        public void FillNode(TreeNode nd)
        {
            nd.Text = FullName;
            nd.Tag = this;
            nd.SelectedImageKey = Type.ToString();
            nd.ImageKey = Type.ToString();
        }

        private int LineId
        {
            get
            {
                return dsLines.tbLineSections.FindByКод(ID).Код_линии;
            }
        }

        public int Numer
        {
            get
            {
                return dsLines.tbLineSections.FindByКод(ID).Номер;
            }
        }

        public Point StartPoint
        {
            get
            {
                int N = dsLines.tbLineSections.Select
                    (String.Format(
                        "[Код линии]={0:G} AND [Номер]<={1:G}", LineId,
                        dsLines.tbLineSections.FindByКод(ID).Номер)).Length;
                return new Point(dsLines, LineId, N);
            }
        }

        public Point FinishPiont
        {
            get
            {
                int N = dsLines.tbLineSections.Select
                    (String.Format(
                        "[Код линии]={0:G} AND [Номер]<={1:G}", LineId,
                        dsLines.tbLineSections.FindByКод(ID).Номер)).Length;
                return new Point(dsLines, LineId, N + 1);
            }
        }

        public abstract string Name
        {
            get;
        }

        public abstract string FullName
        {
            get;
        }

        public Logic.Line.Line Line
        {
            get
            {
                return new Logic.Line.Line(dsLines, null, LineId);
            }
        }

        public abstract void Draw(Graphics Graphics, Pen Pen, CanvasView View);

        public abstract void DrawNumer(Graphics Graphics, CanvasView View, Font Font, Brush Brush);

    }
}
