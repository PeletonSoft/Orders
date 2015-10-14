using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CorniceGraph.Datasets;

namespace CorniceGraph.Logic.Wall
{
    public class WallSections
    {
        public static void FillNode(TreeNode nd, WallType Type, dsWall dsWall, int ID)
        {
            switch (Type)
            {
                case WallType.Wall:
                    nd.Tag = new Wall(dsWall, ID);
                    break;
                case WallType.Arc:
                    nd.Tag = new WallArc(dsWall, ID);
                    break;
                case WallType.Line:
                    nd.Tag = new WallLine(dsWall, ID);
                    break;
                case WallType.Corner:
                    nd.Tag = new WallCorner(dsWall, ID);
                    break;
            }

            nd.Text = (nd.Tag as WallSection).FullName;
            nd.ImageKey = (nd.Tag as WallSection).Type.ToString();
            nd.SelectedImageKey = (nd.Tag as WallSection).Type.ToString();
        }

        public static WallType TypeByID(dsWall dsWall, int ID)
        {
            dsWall.tbWallSegmentRow rw = dsWall.tbWallSegment.FindByКод(ID);

            if (rw == null)
                return WallType.Wall;
            if (rw.Длина < 1e-6)
                return WallType.Corner;

            if (Math.Abs(rw.Угол) < 1e-6)
                return WallType.Line;
            return WallType.Arc;

        }

        public static WallSection SectionByID(dsWall dsWall, int ID)
        {
            switch (TypeByID(dsWall, ID))
            {
                case WallType.Arc:
                    return new WallArc(dsWall, ID);
                case WallType.Corner:
                    return new WallCorner(dsWall, ID);
                case WallType.Line:
                    return new WallLine(dsWall, ID);
            }
            return null;
        }
    }
}