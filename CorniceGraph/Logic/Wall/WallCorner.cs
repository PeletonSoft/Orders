using System;
using System.Data;
using CorniceGraph.Datasets;
using CorniceGraph.Logic.Line;

namespace CorniceGraph.Logic.Wall
{
    public class WallCorner : WallSection
    {
        private double phi;
        private double beta;
        private int point;

        public double Phi
        {
            get
            {
                Calc();
                return phi;
            }
        }

        public double Beta
        {
            get
            {
                Calc();
                return beta;
            }
        }

        public WallPoint Point
        {
            get
            {
                Calc();
                return new WallPoint(dsWall, point);
            }
        }

        public Wall NextWall
        {
            get
            {
                Calc();
                DataRow[] rc = dsWall.tbWallSegment.Select
                    ("[Номер]>" + dsWall.tbWallSegment.FindByКод(ID).Номер.ToString(),
                        "[Номер] ASC");
                if (rc.Length <= 0)
                    return null;
                return WallSections.SectionByID(dsWall, (rc[0] as dsWall.tbWallSegmentRow).Код).Wall;
            }
        }


        public WallCorner(dsWall dsWall, int ID)
            : base(dsWall, ID)
        {
        }

        protected override void Calc()
        {
            WallType = WallType.Corner;
            phi = dsWall.tbWallSegment.FindByКод(ID).Угол;
            beta = phi > 0 ? 180 - phi : -phi - 180;
            phi = phi / 180 * Math.PI;
            point = dsWall.tbWallSegment.FindByКод(ID).Номер;
        }

        protected override string Get_Name()
        {
            return Point.Numer.ToString();
        }

        protected override string Get_FullName()
        {
            return String.Format("{0:G} [\u03B2={1:N1}\u00B0]", Point.Numer, Beta);
        }

        protected override Wall Get_Wall()
        {
            Calc();
            DataRow[] rc = dsWall.tbWallSegment.Select
                ("[Номер]<" + dsWall.tbWallSegment.FindByКод(ID).Номер.ToString(),
                    "[Номер] DESC");
            if (rc.Length <= 0)
                return null;
            return WallSections.SectionByID(dsWall, (rc[0] as dsWall.tbWallSegmentRow).Код).Wall;
        }

        public override Pointer Finish(Pointer Start)
        {
            return new Pointer(Start.X, Start.Y, Start.Phi + Phi);
        }
    }
}
