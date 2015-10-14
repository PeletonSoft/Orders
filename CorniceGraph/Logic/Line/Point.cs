using System;
using System.Data;
using System.Drawing;
using CorniceGraph.Datasets;

namespace CorniceGraph.Logic.Line
{
    public class Point
    {
        private dsLines dsLines;
        private int Its_LineId;

        private int N;

        public int Numer
        {
            get
            {

                if (PrevSection == null)
                    return 1;
                DataRow[] rc =
                    dsLines.tbLineSections.Select(String.Format(
                        "[Код линии]={0:G} AND [Номер]<={1:G} AND [Длина]>0.001",
                        Line.ID, PrevSection.Numer), "[Номер] ASC");
                return rc.Length + 1;

            }
        }

        public string Name
        {
            get
            {
                return Numer.ToString();
            }
        }

        public Point(dsLines dsLines, int LineId, int Numer)
        {
            this.dsLines = dsLines;
            Its_LineId = LineId;
            N = Numer;
        }

        public Section PrevSection
        {
            get
            {
                DataRow[] rc =
                    dsLines.tbLineSections.Select
                        ("[Код линии]=" + Line.ID, "[Номер] ASC");
                if (N <= 1 || N > rc.Length + 1)
                    return null;
                return LineSections.SectionByID(dsLines, (rc[N - 2] as dsLines.tbLineSectionsRow).Код);
            }
        }

        public Pointer Pointer
        {
            get
            {
                if (PrevSection == null)
                    return Line.Start;
                return PrevSection.Finish(PrevSection.StartPoint.Pointer);
            }

        }



        public Logic.Line.Line Line
        {
            get
            {
                return new Logic.Line.Line(dsLines, null, Its_LineId);
            }
        }

        public void Draw(Graphics Graphics, CanvasView View, Font Font, Brush Brush)
        {
            PointF p = View.TranslateF(Pointer.PointF);
            p.X += 0;
            p.Y += 0;
            Graphics.DrawString(Numer.ToString(), Font, Brush, p);
        }

    }
}
