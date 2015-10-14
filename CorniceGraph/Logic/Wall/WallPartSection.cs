using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using CorniceGraph.Datasets;
using CorniceGraph.Logic.Line;

namespace CorniceGraph.Logic.Wall
{
    public abstract class WallPartSection : LengthWallSection
    {
        public int Index
        {
            get
            {
                int i = -1;
                bool find = false;
                foreach (WallPartSection Section in this.Wall)
                {
                    if (!find)
                        i++;
                    if (Section.Type == Type && Section.ID == ID)
                        find = true;
                }
                return i;
            }
        }

        public virtual double Alpha
        {
            get
            {
                return 0;
            }
        }
        public WallPartSection(dsWall dsWall, int ID)
            : base(dsWall, ID)
        {
        }

        public virtual void DrawNumer(Graphics Graphics, CanvasView View, Font Font, Brush Brush)
        {
            StartPoint.Draw(Graphics, View, Font, Brush);
            FinishPoint.Draw(Graphics, View, Font, Brush);
        }

    }
}
