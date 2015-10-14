using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using CorniceGraph.Datasets;
using CorniceGraph.Logic.Line;

namespace CorniceGraph.Logic.Wall
{
    public class WallLine : WallPartSection
    {

        public WallLine(dsWall dsWall, int ID) :
            base(dsWall, ID)
        {
        }

        protected override void Calc()
        {
            WallType = WallType.Line;
            dsWall.tbWallSegmentRow rw = dsWall.tbWallSegment.FindByКод(ID);
            L = rw.Длина;
            start = rw.Номер;
            finish = rw.Номер + 1;
        }

        protected override string Get_FullName()
        {
            return String.Format("{0:G} [L={1:N2}]", Name, Length);
        }

        protected override Wall Get_Wall()
        {
            DataRow[] rc = dsWall.tbWallDetail.Select
                ("[Код сегмента]=" + ID.ToString());

            if (rc.Length <= 0)
                return null;
            return new Wall(dsWall, (rc[0] as dsWall.tbWallDetailRow).Код_стены);
        }

        public override Pointer Finish(Pointer Start)
        {
            return new Pointer(
                Start.X + Length * Math.Cos(Start.Phi),
                Start.Y + Length * Math.Sin(Start.Phi),
                Start.Phi);
        }

        public override void Draw(Graphics Graphics, Pen Pen, CanvasView View)
        {
            PointF StartF = View.TranslateF(StartPoint.Pointer);
            PointF FinishF = View.TranslateF(this.Finish(StartPoint.Pointer));
            Graphics.DrawLine(Pen, StartF, FinishF);
        }
    }


}
