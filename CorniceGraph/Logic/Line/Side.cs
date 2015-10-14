using System;
using CorniceGraph.Datasets;

namespace CorniceGraph.Logic.Line
{
    public class Side
    {
        protected dsLines dsLines;
        protected int Its_Id;
        protected bool siSide;
        protected bool pos;
        protected double size;
        protected double alpha;
        protected double step;

        public int ID
        {
            get
            {
                return Its_Id;
            }
        }

        public bool IsSide
        {
            get
            {
                Calc();
                return siSide;
            }
        }

        public bool Position
        {
            get
            {
                Calc();
                return pos;
            }
        }

        public double Step
        {
            get
            {
                Calc();
                return step;
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

        public Side(dsLines dsLines, int ID)
        {
            this.dsLines = dsLines;
            this.Its_Id = ID;
        }

        private void Calc()
        {
            dsLines.tbSideRow rws = dsLines.tbSide.FindByКод(ID);
            siSide = rws.Боковина;
            alpha = rws.Угол * Math.PI / 180;
            pos = rws.Положение;
            step = rws.Отступ;
        }

        public string Name
        {
            get
            {
                string s = Position ? "К" : "Н";
                if (IsSide)
                    s += String.Format("Б={0:N1}\u00B0", Alpha * 180 / Math.PI);
                else
                    return "";
                return s;
            }
        }

        public Logic.Line.Line Line
        {
            get
            {
                return new Logic.Line.Line(dsLines, null, dsLines.tbSide.FindByКод(ID).Код_линии);
            }
        }
    }

}
