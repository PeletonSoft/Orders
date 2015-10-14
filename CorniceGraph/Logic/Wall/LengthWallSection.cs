using System;
using System.Drawing;
using CorniceGraph.Datasets;
using CorniceGraph.Logic.Line;

namespace CorniceGraph.Logic.Wall
{
    public abstract class LengthWallSection : WallSection
    {
        protected double L;
        protected int start;
        protected int finish;

        public double Length
        {
            get
            {
                Calc();
                return L;
            }
        }

        public WallPoint StartPoint
        {
            get
            {
                Calc();
                return new WallPoint(dsWall, start);
            }
        }

        public WallPoint FinishPoint
        {
            get
            {
                Calc();
                return new WallPoint(dsWall, finish);
            }
        }
        public LengthWallSection(dsWall dsWall, int ID)
            : base(dsWall, ID)
        {
        }

        protected override string Get_Name()
        {
            return String.Format("{0:G}-{1:G}", StartPoint.Numer, FinishPoint.Numer);
        }



        public abstract void Draw(Graphics Graphics, Pen Pen, CanvasView View);

    }
}
