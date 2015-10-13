using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CorniceGraph.Datasets;

namespace CorniceGraph.Logic
{
    public class WallSections
    {

        public enum WallType { Corner = 0, Arc = 1, Wall = 2, Line = 3 };

        public static void FillNode(TreeNode nd, WallType Type, dsWall dsWall, int ID)
        {
            switch (Type)
            {
                case WallType.Wall:
                    nd.Tag = new Wall(dsWall, ID);
                    break;
                case WallType.Arc:
                    nd.Tag = new Arc(dsWall, ID);
                    break;
                case WallType.Line:
                    nd.Tag = new Line(dsWall, ID);
                    break;
                case WallType.Corner:
                    nd.Tag = new Corner(dsWall, ID);
                    break;
            }

            nd.Text = (nd.Tag as Section).FullName;
            nd.ImageKey = (nd.Tag as Section).Type.ToString();
            nd.SelectedImageKey = (nd.Tag as Section).Type.ToString();
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

        public static Section SectionByID(dsWall dsWall, int ID)
        {
            switch (TypeByID(dsWall, ID))
            {
                case WallType.Arc:
                    return new Arc(dsWall, ID);
                case WallType.Corner:
                    return new Corner(dsWall, ID);
                case WallType.Line:
                    return new Line(dsWall, ID);
            }
            return null;
        }

        public class Walls : IEnumerable
        {
            protected dsWall dsWall;

            public int Count
            {
                get
                {
                    return dsWall.tbWall.Rows.Count;
                }
            }

            public void FillNode(TreeNode nd)
            {
                nd.Tag = this;
                nd.Text = Name;
                nd.ImageKey = "walls";
                nd.SelectedImageKey = "walls";
            }


            #region IEnumerable Members
            public Walls(dsWall dsWall)
            {
                this.dsWall = dsWall;
            }

            public IEnumerator GetEnumerator()
            {
                return new Enumerator(dsWall);
            }

            #endregion

            private class Enumerator : IEnumerator
            {
                private int Index;
                private dsWall dsWall;

                public Enumerator(dsWall dsWall)
                {
                    this.dsWall = dsWall;
                    Reset();
                }
                #region IEnumerator Members

                public object Current
                {
                    get
                    {
                        dsWall.tbWallRow rw =
                            dsWall.tbWall.Select("", "[Номер] ASC")[Index] as dsWall.tbWallRow;
                        return new Wall(dsWall, rw.Код);
                    }
                }

                public bool MoveNext()
                {
                    Index++;
                    return (Index < dsWall.tbWall.Rows.Count);
                }

                public void Reset()
                {
                    Index = -1;
                }

                #endregion
            }

            public Wall FirstWall
            {
                get
                {
                    foreach (Wall Wall in this)
                        return Wall;
                    return null;
                }
            }

            public Wall LastWall
            {
                get
                {
                    Wall L = null;
                    foreach (Wall Wall in this)
                        L = Wall;
                    return L;
                }
            }

            public double Length
            {
                get
                {
                    double L = 0;
                    foreach (Wall Wall in this)
                        L += Wall.Length;
                    return L;
                }
            }

            public string Name
            {
                get
                {
                    return String.Format("Стена [L={0:N2}]", Length);
                }
            }
        }

        public abstract class Section
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

            public Section(dsWall dsWall, int ID)
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

        public abstract class LengthSection : Section
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

            public Point StartPoint
            {
                get
                {
                    Calc();
                    return new Point(dsWall, start);
                }
            }

            public Point FinishPoint
            {
                get
                {
                    Calc();
                    return new Point(dsWall, finish);
                }
            }
            public LengthSection(dsWall dsWall, int ID)
                : base(dsWall, ID)
            {
            }

            protected override string Get_Name()
            {
                return String.Format("{0:G}-{1:G}", StartPoint.Numer, FinishPoint.Numer);
            }



            public abstract void Draw(Graphics Graphics, Pen Pen, CanvasView View);

        }

        public abstract class WallPartSection : LengthSection
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

        public class Wall : LengthSection, IEnumerable
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

            public Corner PrevCorner
            {
                get
                {
                    Calc();
                    if (StartPoint.Numer == 1)
                        return null;
                    DataRow[] rc = dsWall.tbWallSegment.Select("[Номер]=" + (start - 1).ToString());
                    if (rc.Length <= 0)
                        return null;
                    return new Corner(dsWall, (rc[0] as dsWall.tbWallSegmentRow).Код);
                }
            }

            public Corner NextCorner
            {
                get
                {
                    if (StartPoint.Numer == dsWall.tbWallSegment.Rows.Count)
                        return null;
                    DataRow[] rc = dsWall.tbWallSegment.Select("[Номер]=" + finish.ToString());
                    if (rc.Length <= 0)
                        return null;
                    return new Corner(dsWall, (rc[0] as dsWall.tbWallSegmentRow).Код);
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
                        if (Section is Line)
                        {
                            S.X = F.X; S.Y = F.Y;
                        }
                        else
                        {
                            double alpha = phi - F.Phi;
                            S.X = F.X + (Section as Arc).Radius * (1 - Math.Cos(alpha));
                            S.Y = F.Y + (Section as Arc).Radius * Math.Sin(alpha);
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
                        return SectionByID
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
                foreach (Section Section in this)
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

        public class Corner : Section
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

            public Point Point
            {
                get
                {
                    Calc();
                    return new Point(dsWall, point);
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
                    return SectionByID(dsWall, (rc[0] as dsWall.tbWallSegmentRow).Код).Wall;
                }
            }


            public Corner(dsWall dsWall, int ID)
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
                return SectionByID(dsWall, (rc[0] as dsWall.tbWallSegmentRow).Код).Wall;
            }

            public override Pointer Finish(Pointer Start)
            {
                return new Pointer(Start.X, Start.Y, Start.Phi + Phi);
            }
        }

        public class Arc : WallPartSection
        {
            private double r;
            private double alpha;

            public override double Alpha
            {
                get
                {
                    Calc();
                    return alpha;
                }
            }

            public double Radius
            {
                get
                {
                    Calc();
                    return r;
                }
            }

            public Pointer Center
            {
                get
                {
                    Pointer C = new Pointer();
                    C.X = StartPoint.Pointer.X - Length / Alpha * Math.Sin(StartPoint.Pointer.Phi);
                    C.Y = StartPoint.Pointer.Y + Length / Alpha * Math.Cos(StartPoint.Pointer.Phi);
                    if (Alpha > 0)
                        C.Phi = Math.PI / 2 - StartPoint.Pointer.Phi;
                    else
                        C.Phi = -Math.PI / 2 - StartPoint.Pointer.Phi;

                    return C;
                }
            }

            public Arc(dsWall dsWall, int ID)
                : base(dsWall, ID)
            {
            }

            protected override void Calc()
            {
                WallType = WallType.Arc;
                dsWall.tbWallSegmentRow rw = dsWall.tbWallSegment.FindByКод(ID);
                L = rw.Длина;
                alpha = rw.Угол * Math.PI / 180;
                r = Math.Abs(L / alpha);
                start = rw.Номер;
                finish = rw.Номер + 1;
            }

            protected override string Get_FullName()
            {
                return String.Format("{0:G} [L={1:N2} R={2:N2} \u03B1={3:N1}\u00B0]",
                    Name, L, r, alpha * 180 / Math.PI);
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
                double Si = Math.Sin(Alpha / 2) / (Alpha / 2);
                return new Pointer(
                    Start.X + Length * Math.Cos(Start.Phi + Alpha / 2) * Si,
                    Start.Y + Length * Math.Sin(Start.Phi + Alpha / 2) * Si,
                    Start.Phi + Alpha);
            }

            public Pointer Middle
            {
                get
                {
                    double Si = Math.Sin(Alpha / 4) / (Alpha / 4);
                    return new Pointer(
                        StartPoint.Pointer.X + Length / 2 * Math.Cos(StartPoint.Pointer.Phi + Alpha / 4) * Si,
                        StartPoint.Pointer.Y + Length / 2 * Math.Sin(StartPoint.Pointer.Phi + Alpha / 4) * Si,
                        StartPoint.Pointer.Phi + Alpha / 2);
                }
            }

            public override void Draw(Graphics Graphics, Pen Pen, CanvasView View)

            {
                float R = (float)(Radius * View.Zoom);
                PointF C = View.TranslateF(Center);
                RectangleF RectangleF = new RectangleF(C.X - R, C.Y - R, 2 * R, 2 * R);

                Graphics.DrawArc(Pen, RectangleF,
                    (float)(View.Translate(Center).Phi * 180 / Math.PI),
                    -(View.Mirrow ? -1 : 1) * (float)(Alpha * 180 / Math.PI));
                //DrawNumer(Graphics,CanvasView);
            }
        }

        public class Line : WallPartSection
        {

            public Line(dsWall dsWall, int ID) :
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

        public class Point
        {
            private dsWall dsWall;
            private double x;
            private double y;
            private double phi;
            private int N;

            public int SegnentNumer
            {
                get
                {
                    return N;
                }
            }

            public int Numer
            {
                get
                {
                    int n = 0;
                    DataRow[] rc = dsWall.tbWallSegment.Select("", "[Номер] ASC");
                    if (rc.Length < 0)
                        return 1;

                    foreach (dsWall.tbWallSegmentRow rw in rc)
                    {
                        if (rw.Номер < N && rw.Длина > 1e-6 || rw.Номер == N)
                            n++;
                    }
                    if ((rc[rc.Length - 1] as dsWall.tbWallSegmentRow).Номер + 1 == N)
                        n++;
                    return n;
                }
            }

            public double X
            {
                get
                {
                    Calc();
                    return x;
                }
            }

            public double Y
            {
                get
                {
                    Calc();
                    return y;
                }
            }

            public PointF PointF
            {
                get
                {
                    return Pointer.PointF;
                }
            }

            public Pointer Pointer
            {
                get
                {
                    return new Pointer(X, Y, Phi);
                }
            }

            public double Phi
            {
                get
                {
                    Calc();
                    return phi;
                }
            }

            public Point(dsWall dsWall, int Numer)
            {
                this.dsWall = dsWall;
                N = Numer;
                Calc();
            }

            private void Calc()
            {
                x = 0;
                y = 0;
                phi = 0;

                DataRow[] rc = dsWall.tbWallSegment.Select
                    ("[Номер]<" + N.ToString(), "[Номер] ASC");

                foreach (dsWall.tbWallSegmentRow rw in rc)
                {
                    double l = rw.Длина;
                    double alpha = rw.Угол / 180 * Math.PI;
                    x += l * Math.Cos(phi + alpha / 2) * TfMain.sinx(alpha / 2);
                    y += l * Math.Sin(phi + alpha / 2) * TfMain.sinx(alpha / 2);
                    phi += alpha;
                }
            }

            public void Draw(Graphics Graphics, CanvasView View, Font Font, Brush Brush)
            {
                PointF p = View.TranslateF(PointF);
                p.X += 0;
                p.Y += 0;
                Graphics.DrawString(Numer.ToString(), Font, Brush, p);
            }
        }

    }
}