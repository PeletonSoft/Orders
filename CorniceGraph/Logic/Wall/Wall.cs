using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using CorniceGraph.Datasets;
using CorniceGraph.Logic.Line;

namespace CorniceGraph.Logic.Wall
{
    public class Wall : LengthWallSection, IEnumerable
    {
        private double theta;
        private double d;
        private double h;
        private double phi;
        private int count;

        public double Theta
        {
            get
            {
                Calc();
                return theta;
            }
        }

        public double Diameter
        {
            get
            {
                Calc();
                return d;
            }
        }

        public double Count
        {
            get
            {
                Calc();
                return count;
            }
        }

        public Wall(dsWall dsWall, int ID)
            : base(dsWall, ID)
        {
        }

        public WallCorner PrevCorner
        {
            get
            {
                Calc();
                if (StartPoint.Numer == 1)
                    return null;
                DataRow[] rc = dsWall.tbWallSegment.Select("[Номер]=" + (start - 1).ToString());
                if (rc.Length <= 0)
                    return null;
                return new WallCorner(dsWall, (rc[0] as dsWall.tbWallSegmentRow).Код);
            }
        }

        public WallCorner NextCorner
        {
            get
            {
                if (StartPoint.Numer == dsWall.tbWallSegment.Rows.Count)
                    return null;
                DataRow[] rc = dsWall.tbWallSegment.Select("[Номер]=" + finish.ToString());
                if (rc.Length <= 0)
                    return null;
                return new WallCorner(dsWall, (rc[0] as dsWall.tbWallSegmentRow).Код);
            }
        }

        protected override void Calc()
        {
            WallType = WallType.Wall;

            dsWall.tbWallDetailRow[] rwwc = (dsWall.tbWallDetailRow[])
                dsWall.tbWallDetail.Select(String.Format("[Код стены]={0:G}", ID));
            start = dsWall.tbWallSegment.FindByКод((rwwc[0]).Код_сегмента).Номер;
            finish = dsWall.tbWallSegment.FindByКод((rwwc[rwwc.Length - 1]).Код_сегмента).Номер + 1;
            count = rwwc.Length;

            L = 0;
            Pointer F = new Pointer();
            foreach (WallPartSection Section in this)
            {
                L += Section.Length;
                F = Section.Finish(F);
            }
            phi = Math.Atan2(F.Y, F.X);
            theta = F.Phi - phi;
            d = Math.Sqrt(F.X * F.X + F.Y * F.Y);

            F = new Pointer();
            Pointer S = new Pointer(0, 0, phi);
            foreach (WallPartSection Section in this)
            {
                if ((phi - F.Phi) * (phi - Section.Finish(F).Phi) <= 0)
                {
                    if (Section is WallLine)
                    {
                        S.X = F.X; S.Y = F.Y;
                    }
                    else
                    {
                        double alpha = phi - F.Phi;
                        S.X = F.X + (Section as WallArc).Radius * (1 - Math.Cos(alpha));
                        S.Y = F.Y + (Section as WallArc).Radius * Math.Sin(alpha);
                    }
                    h = S.X * Math.Sin(phi) - S.Y * Math.Cos(phi);
                }

                F = Section.Finish(F);
            }

        }

        protected override string Get_FullName()
        {
            return String.Format("{0:G} [L={1:N2} d={2:N2} h={4:N2} \u03B8={3:N1}\u00B0]",
                Name, L, d, theta * 180 / Math.PI, h);
        }

        protected override Wall Get_Wall()
        {
            return this;
        }

        #region IEnumerable Members

        public IEnumerator GetEnumerator()
        {
            return new Enumerator(dsWall, ID);
        }

        private class Enumerator : IEnumerator
        {
            #region IEnumerator Members

            private int Index;
            private dsWall dsWall;
            private int WallId;

            public Enumerator(dsWall dsWall, int WallId)
            {
                Index = -1;
                this.dsWall = dsWall;
                this.WallId = WallId;
            }

            public object Current
            {
                get
                {
                    DataRow[] rwwc = dsWall.tbWallDetail.Select
                        (String.Format("[Код стены]={0:G}", WallId));
                    return WallSections.SectionByID
                        (dsWall, (rwwc[Index] as dsWall.tbWallDetailRow).Код_сегмента);
                }
            }

            public bool MoveNext()
            {
                Index++;
                DataRow[] rwwc = dsWall.tbWallDetail.Select
                    (String.Format("[Код стены]={0:G}", WallId));
                return (Index < rwwc.Length);
            }

            public void Reset()
            {
                Index = -1;
            }

            #endregion
        }
        #endregion

        public override Pointer Finish(Pointer Start)
        {
            Pointer F = Start;
            foreach (WallSection Section in this)
                F = Section.Finish(F);
            return F;
        }

        public override void Draw(Graphics Graphics, Pen Pen, CanvasView View)
        {
            foreach (WallPartSection Section in this)
                Section.Draw(Graphics, Pen, View);
        }

        public void DrawNumer(Graphics Graphics, CanvasView View, Font Font, Brush Brush)
        {
            foreach (WallPartSection Section in this)
                Section.DrawNumer(Graphics, View, Font, Brush);
        }

        public WallPartSection FirstSection
        {
            get
            {
                foreach (WallPartSection WallPartSection in this)
                    return WallPartSection;
                return null;
            }
        }

        public WallPartSection LastSection
        {
            get
            {
                WallPartSection L = null;
                foreach (WallPartSection WallPartSection in this)
                    L = WallPartSection;
                return L;
            }
        }

    }
}
