using CorniceGraph.Datasets;
using CorniceGraph.Logic.Line;

namespace CorniceGraph.Logic.Wall
{
    public abstract class WallSection
    {
        protected int Its_ID;
        protected dsWall dsWall;
        protected WallType WallType;

        public int ID
        {
            get
            {
                return Its_ID;
            }
        }
        public string Name
        {
            get
            {
                Calc();
                return Get_Name();
            }
        }

        public WallType Type
        {
            get
            {
                return WallType;
            }
        }

        public string FullName
        {
            get
            {
                Calc();
                return Get_FullName();
            }
        }

        public Wall Wall
        {
            get
            {
                return Get_Wall();
            }
        }

        public abstract Pointer Finish(Pointer Start);

        public WallSection(dsWall dsWall, int ID)
        {
            Its_ID = ID;
            this.dsWall = dsWall;
            Calc();
        }

        protected abstract void Calc();
        protected abstract string Get_Name();
        protected abstract string Get_FullName();
        protected abstract Wall Get_Wall();
    }
}
