using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CorniceGraph.Datasets;
using System.Collections;
using System.IO;

namespace CorniceGraph
{
    public partial class TfMain : Form
    {
        public class View
        {
            public double X;
            public double Y;
            public double Phi;
            public double Zoom;
            public bool Mirrow;

            public View(double X, double Y, double Phi, double Zoom, bool Mirrow)
            {
                this.X = X;
                this.Y = Y;
                this.Phi = Phi;
                this.Zoom = Zoom;
                this.Mirrow = Mirrow;
            }

            public View(double X, double Y, double Phi, double Zoom)
            {
                this.X = X;
                this.Y = Y;
                this.Phi = Phi;
                this.Zoom = Zoom;
                this.Mirrow = false;                
            }

            public View(double X, double Y, double Phi)
            {
                this.X = X;
                this.Y = Y;
                this.Phi = Phi;
                this.Zoom = 1;
                this.Mirrow = false;
            }

            public View(double X, double Y)
            {
                this.X = X;
                this.Y = Y;
                this.Phi = 0;
                this.Zoom = 1;
                this.Mirrow = false;
            }

            public View()
            {
                this.X = 0;
                this.Y = 0;
                this.Phi = 0;
                this.Zoom = 1;
                this.Mirrow = false;
            }

            public PointF TranslateF(Pointer Pointer)
            {
                return Translate(Pointer).PointF;
            }

            public PointF TranslateF(PointF Point)
            {
                return TranslateF((float)Point.X, (float)Point.Y);
            }

            public PointF TranslateF(double X, double Y)
            {
                return Translate(X,Y,0).PointF;
            }

            public Pointer Translate(Pointer Pointer)
            {
                return Translate(Pointer.X, Pointer.Y, Pointer.Phi);
            }

            public Pointer Translate(double X, double Y, double Phi)
            {
                Pointer p = new Pointer();
                p.X = (float)(this.X + Zoom * (X * Math.Cos(this.Phi) + Y * Math.Sin(this.Phi)));
                p.Y = (float)(this.Y + (Mirrow ? -1 : 1) *
                    Zoom * (X * Math.Sin(this.Phi) - Y * Math.Cos(this.Phi)));
                p.Phi = (Mirrow ? -1 : 1) * (this.Phi + Phi);
                return p;
            }

            public View AutoZoom(RectangleF RectangleF, double Width, double Height, double cx, double cy)
            {
                double kx = 0;
                if (RectangleF.Right - RectangleF.Left > 0.1)
                    kx = (RectangleF.Right - RectangleF.Left) / (Width * (1 - cx));
                double ky = 0;
                if (RectangleF.Bottom - RectangleF.Top > 0.1)
                    ky = (RectangleF.Bottom - RectangleF.Top) / (Height * (1 - cy));

                return new View(this.X, this.Y, this.Phi, this.Zoom / Math.Max(kx, ky), this.Mirrow);

            }

            public View AutoStart(RectangleF RectangleF, double Width, double Height)
            {
                return new View(
                    this.X - (RectangleF.Left + RectangleF.Right) / 2 + Width / 2, 
                    this.Y - (RectangleF.Bottom + RectangleF.Top) / 2 + Height / 2, 
                    this.Phi, this.Zoom, this.Mirrow);
            }
        }

        public class Pointer
        {
            public double X;
            public double Y;
            public double Phi;

            public Pointer()
            {
                this.X = 0;
                this.Y = 0;
                this.Phi = 0;
            }

            public Pointer(double X, double Y)
            {
                this.X = X;
                this.Y = Y;
                this.Phi = 0;
            }

            public Pointer(double X, double Y, double Phi)
            {
                this.X = X;
                this.Y = Y;
                this.Phi = Phi;
            }

            public PointF PointF
            {
                get
                {
                    return new PointF((float)X, (float)Y);
                }
            }

            public Pointer ClearancePointer(double Clearance)
            {
                Pointer P = new Pointer();
                P.Phi = Phi;
                P.X = this.X - Clearance * Math.Sin(P.Phi);
                P.Y = this.Y + Clearance * Math.Cos(P.Phi);
                return P;

            }
        }

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

                if (Math.Abs(rw.Угол)<1e-6)
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
                                dsWall.tbWall.Select("","[Номер] ASC")[Index] as dsWall.tbWallRow;
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
                        double L=0;
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
                        return new Point(dsWall,finish);
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

                

                public abstract void Draw(Graphics Graphics, Pen Pen, View View);

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
                            if (Section.Type == Type && Section.ID==ID)
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

                public virtual void DrawNumer(Graphics Graphics, View View, Font Font, Brush Brush)
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
                        if (rc.Length<=0)
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

                public override void Draw(Graphics Graphics, Pen Pen, View View)
                {
                    foreach (WallPartSection Section in this)
                        Section.Draw(Graphics, Pen, View);
                }

                public void DrawNumer(Graphics Graphics, View View, Font Font, Brush Brush)
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
                    return SectionByID(dsWall,(rc[0] as dsWall.tbWallSegmentRow).Код).Wall;
                }

                public override Pointer Finish(Pointer Start)
                {
                    return new Pointer(Start.X, Start.Y, Start.Phi+Phi);
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

                public override void Draw(Graphics Graphics, Pen Pen, View View)
                    
                {
                    float R = (float)(Radius * View.Zoom);
                    PointF C = View.TranslateF(Center);
                    RectangleF RectangleF = new RectangleF(C.X - R, C.Y - R, 2 * R, 2 * R);

                    Graphics.DrawArc(Pen, RectangleF,
                        (float)(View.Translate(Center).Phi * 180 / Math.PI),
                        -(View.Mirrow ? -1 : 1) * (float)(Alpha * 180 / Math.PI));
                    //DrawNumer(Graphics,View);
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

                    if (rc.Length<=0)
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

                public override void Draw(Graphics Graphics, Pen Pen, View View)
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
                        ("[Номер]<" + N.ToString(),"[Номер] ASC");

                    foreach (dsWall.tbWallSegmentRow rw in rc)
                    {
                        double l = rw.Длина;
                        double alpha = rw.Угол / 180 * Math.PI;
                        x += l * Math.Cos(phi + alpha / 2) * sinx(alpha / 2);
                        y += l * Math.Sin(phi + alpha / 2) * sinx(alpha / 2);
                        phi += alpha;
                    }
                }

                public void Draw(Graphics Graphics, View View, Font Font, Brush Brush)
                {
                    PointF p = View.TranslateF(PointF);
                    p.X += 0;
                    p.Y += 0;
                    Graphics.DrawString(Numer.ToString(), Font, Brush, p);
                }
            }

        }

        public class LineSections
        {
            public enum LineSectionType { Line = 0, Arc = 1, Junct = 2 };

            public abstract class Section
            {
                protected dsLines dsLines;
                protected int Its_ID;
                protected double alpha;
                protected double length;


                public abstract LineSectionType Type
                {
                    get;
                }

                public int ID
                {
                    get
                    {
                        return Its_ID;
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

                public double Length
                {
                    get
                    {
                        Calc();
                        return length;
                    }
                }

                public Section(dsLines dsLines, int ID)
                {
                    Its_ID = ID;
                    this.dsLines = dsLines;
                    Calc();
                }

                public abstract Pointer Finish(Pointer Start);

                private void Calc()
                {
                    dsLines.tbLineSectionsRow rw = (dsLines.tbLineSectionsRow)
                        dsLines.tbLineSections.Select("[Код]=" + ID.ToString())[0];
                    length = rw.Длина;
                    alpha = rw.Угол * Math.PI / 180;
                }

                public void FillNode(TreeNode nd)
                {
                    nd.Text = FullName;
                    nd.Tag = this;
                    nd.SelectedImageKey = Type.ToString();
                    nd.ImageKey = Type.ToString();
                }

                private int LineId
                {
                    get
                    {
                        return dsLines.tbLineSections.FindByКод(ID).Код_линии;
                    }
                }

                public int Numer
                {
                    get
                    {
                        return dsLines.tbLineSections.FindByКод(ID).Номер;
                    }
                }

                public Point StartPoint
                {
                    get
                    {
                        int N = dsLines.tbLineSections.Select
                            (String.Format(
                                "[Код линии]={0:G} AND [Номер]<={1:G}", LineId,
                                dsLines.tbLineSections.FindByКод(ID).Номер)).Length;
                        return new Point(dsLines, LineId, N);
                    }
                }

                public Point FinishPiont
                {
                    get
                    {
                        int N = dsLines.tbLineSections.Select
                            (String.Format(
                                "[Код линии]={0:G} AND [Номер]<={1:G}", LineId,
                                dsLines.tbLineSections.FindByКод(ID).Номер)).Length;
                        return new Point(dsLines, LineId, N + 1);
                    }
                }

                public abstract string Name
                {
                    get;
                }

                public abstract string FullName
                {
                    get;
                }

                public Line Line
                {
                    get
                    {
                        return new Line(dsLines, null, LineId);
                    }
                }

                public abstract void Draw(Graphics Graphics, Pen Pen, View View);

                public abstract void DrawNumer(Graphics Graphics, View View, Font Font, Brush Brush);

            }

            public class JunctSection : Section
            {
                public override LineSectionType Type
                {
                    get 
                    {
                        return LineSectionType.Junct;
                    }
                }

                public override Pointer Finish(Pointer Start)
                {
                    return new Pointer(Start.X, Start.Y, Start.Phi + Alpha);
                }

                public JunctSection(dsLines dsLines, int ID) :
                    base(dsLines, ID)
                {
                }

                public override string Name
                {
                    get
                    {
                        return StartPoint.Numer.ToString();
                    }
                }

                public override string FullName
                {
                    get
                    {
                        return String.Format("{0:G} [\u03B1={1:N1}\u00B0]",
                            Name, Alpha >= 0 ? 180 - Alpha * 180 / Math.PI : -180 - Alpha * 180 / Math.PI);

                    }

                }

                public override void Draw(Graphics Graphics, Pen Pen, View View)
                {
                    Pen.Width += 2;
                    PointF PointF = View.TranslateF(StartPoint.Pointer);
                    Graphics.DrawLine(Pen, PointF.X - 5, PointF.Y - 5, PointF.X + 5, PointF.Y + 5);
                    Graphics.DrawLine(Pen, PointF.X - 5, PointF.Y + 5, PointF.X + 5, PointF.Y - 5);
                    Pen.Width -= 2;
                }

                public override void DrawNumer(Graphics Graphics, View View, Font Font, Brush Brush)
                {
                }
            }

            public abstract class LengthSection: Section
            {

                public override string Name
                {
                    get
                    {
                        return String.Format("{0:G}-{1:G}", StartPoint.Name, FinishPiont.Name);
                    }
                }

                public override string FullName
                {
                    get
                    {
                        return String.Format("{0:G} [L={1:N2}]", Name, Length);
                    }
                }

                public LengthSection(dsLines dsLines, int ID) :
                    base(dsLines, ID)
                {
                }

                public override void DrawNumer(Graphics Graphics, View View, Font Font, Brush Brush)
                {
                    StartPoint.Draw(Graphics, View, Font, Brush);
                    FinishPiont.Draw(Graphics, View, Font, Brush);
                }

            }

            public class LineSection : LengthSection
            {
                public override LineSectionType Type
                {
                    get
                    {
                        return LineSectionType.Line;
                    }
                }
                public override Pointer Finish(Pointer Start)
                {
                    return new Pointer(
                        Start.X + Length * Math.Cos(Start.Phi),
                        Start.Y + Length * Math.Sin(Start.Phi),
                        Start.Phi);
                }

                public LineSection(dsLines dsLines, int ID) :
                    base(dsLines, ID)
                {
                }

                public override void Draw(Graphics Graphics, Pen Pen, View View)
                {
                    PointF StartF = View.TranslateF(StartPoint.Pointer);
                    PointF FinishF = View.TranslateF(FinishPiont.Pointer);
                    Graphics.DrawLine(Pen, StartF, FinishF);
                }
            }

            public class ArcSection : LengthSection
            {
                public override LineSectionType Type
                {
                    get
                    {
                        return LineSectionType.Arc;
                    }
                }

                public override Pointer Finish(Pointer Start)
                {
                    return new Pointer(
                        Start.X + 2 * Length * Math.Cos(Start.Phi + Alpha / 2) * Math.Sin(Alpha / 2) / Alpha,
                        Start.Y + 2 * Length * Math.Sin(Start.Phi + Alpha / 2) * Math.Sin(Alpha / 2) / Alpha,
                        Start.Phi + Alpha);
                }

                public override string FullName
                {
                    get
                    {
                        return String.Format("{0:G} [L={1:N2} R={2:N2} \u03B1={3:N1}\u00B0]",
                            Name, Length, Math.Abs(Radius), 
                            Alpha > 0 ? 180 - Alpha * 180 / Math.PI : -180 - Alpha * 180 / Math.PI);
                    }
                }

                public double Radius
                {
                    get
                    {
                        return Math.Abs(Length / Alpha);
                    }
                }

                public ArcSection(dsLines dsLines, int ID) :
                    base(dsLines, ID)
                {
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
                            C.Phi = - Math.PI / 2 - StartPoint.Pointer.Phi;
                        return C;
                    }
                }

                public override void Draw(Graphics Graphics, Pen Pen, View View)
                {
                    float R = (float)(Radius * View.Zoom);
                    PointF C = View.TranslateF(Center);
                    RectangleF RectangleF = new RectangleF(C.X - R, C.Y - R, 2 * R, 2 * R);

                    Graphics.DrawArc(Pen, RectangleF,
                        (float)(View.Translate(Center).Phi * 180 / Math.PI),
                        -(View.Mirrow ? -1 : 1) * (float)(Alpha * 180 / Math.PI));

                }
            }

            public static Section SectionByID(dsLines dsLines, int ID)
            {
                dsLines.tbLineSectionsRow rw = dsLines.tbLineSections.FindByКод(ID);
                if (rw == null)
                    return null;
                if (rw.Длина < 0.001)
                    return new JunctSection(dsLines, ID);
                if (Math.Abs(rw.Угол) < 0.01)
                    return new LineSection(dsLines, ID);
                return new ArcSection(dsLines, ID);
            }

            public class Line : IEnumerable
            {
                private dsLines dsLines;
                private dsSplints dsSplints;

                private int LineId;

                public int Numer
                {
                    get
                    {
                        return dsLines.tbLine.FindByКод(LineId).Номер_линии;
                    }
                }

                public string Profile
                {
                    get
                    {
                        return dsLines.tbLine.FindByКод(LineId).Название;
                    }
                }

                public int ProfileId
                {
                    get
                    {
                        return dsLines.tbLine.FindByКод(LineId).Код_профиля;
                    }
                }

                public double Clearance
                {
                    get
                    {
                        return dsLines.tbLine.FindByКод(LineId).Отлет;
                    }
                }

                public string Name
                {
                    get
                    {
                        return String.Format("Линия-{0:G}",Numer);
                    }

                }

                public string FullName
                {
                    get
                    {
                        if (CorniceType != 3)
                        {
                            string Side = "";
                            if (FirstSide.IsSide)
                                Side += " " + FirstSide.Name;
                            if (LastSide.IsSide)
                                Side += " " + LastSide.Name;

                            return String.Format("{0:G} [L={1:N2} О=({2:N2} {3:N2}){4:G} C={5:N2}]",
                                Name, Length, FirstSide.Step, FirstSide.Step, Side, Clearance);
                        }
                        return String.Format("{0:G}", Name);

                    }

                }

                public void FillNode(TreeNode nd)
                {
                    nd.Text = FullName;
                    nd.Tag = this;
                    nd.SelectedImageKey = "curve";
                    nd.ImageKey = "curve";
                }

                #region IEnumerable Members

                public IEnumerator GetEnumerator()
                {
                    return new Enumerator(dsLines,dsSplints, LineId);
                }

                #endregion

                public int ID
                {
                    get
                    {
                        return LineId;
                    }
                }

                public int Count
                {
                    get
                    {
                        int C=0;
                        foreach (object Section in this)
                            C++;
                        return C;
                    }
                }

                public double Length
                {
                    get
                    {
                        double L = 0;
                        if (CorniceType != 3)
                            foreach (Section Section in this)
                                L += Section.Length;
                        return L;
                    }
                }

                public Line(dsLines dsLines, dsSplints dsSplints, int ID)
                {
                    this.dsLines = dsLines;
                    this.dsSplints = dsSplints;
                    LineId = ID;
                }

                public Pointer Start
                {
                    get
                    {
                        dsLines.tbStartLineRow rw = dsLines.tbStartLine.FindByКод(StartId);
                        return new Pointer(rw.X, rw.Y, rw.Phi * Math.PI / 180);
                    }
                }

                public int StartId
                {
                    get
                    {
                        DataRow[] rc = dsLines.tbStartLine.Select("[Код линии]=" + ID.ToString());
                        dsLines.tbStartLineRow rw = (dsLines.tbStartLineRow)rc[0];
                        return rw.Код;
                    }
                }
                public double ClearanceByWall(WallSections.Wall Wall)
                {
                    dsLines.tbClearanceRow rwc = (dsLines.tbClearanceRow)
                        (dsLines.tbClearance.Select
                        (String.Format("[Код стены]={0:G} AND [Код линии]={1:G}",
                        Wall.ID, ID))[0]);
                    return rwc.Отлет;
                }

                public Side FirstSide
                {
                    get
                    {
                        dsLines.tbSideRow rws = (dsLines.tbSideRow)
                            dsLines.tbSide.Select
                                (String.Format("[Код линии]={0:G} AND [Положение]=0", ID))[0];
                        return new Side(dsLines, rws.Код);
                    }
                }

                public Side LastSide
                {
                    get
                    {
                        dsLines.tbSideRow rws = (dsLines.tbSideRow)
                            dsLines.tbSide.Select
                                (String.Format("[Код линии]={0:G} AND [Положение]=1", ID))[0];
                        return new Side(dsLines, rws.Код);
                    }
                }

                public class Enumerator : IEnumerator
                {
                    #region IEnumerator Members
                    private int Index;
                    private int LineId;
                    private dsLines dsLines;
                    private dsSplints dsSplints;

                    public object Current
                    {
                        get 
                        {
                            if (CorniceType != 3)
                            {
                                DataRow[] rc = dsLines.tbLineSections.Select
                                    ("[Код линии]=" + LineId.ToString(), "[Номер] ASC");
                                return SectionByID(dsLines, (rc[Index] as dsLines.tbLineSectionsRow).Код);
                            }

                            DataRow[] rcSplint = dsLines.tbSplintSections.Select
                                ("[Код линии]=" + LineId.ToString(), "[Номер] ASC");
                            SplintSections.SplintContourType StartType = SplintSections.SplintContourType.PreCork;
                            SplintSections.SplintComponent SptintCompontent = null;
                            for (int i = 0; i <= Index; i++)
                            {
                                StartType = SplintSections.ReverseSplintContourType(StartType);
                                dsLines.tbSplintSectionsRow rw = (dsLines.tbSplintSectionsRow)rcSplint[i];
                                SptintCompontent = new SplintSections.SplintComponent
                                        (dsSplints, dsLines, rw.Код_компоненты, StartType, 
                                        rw.Значение, rw.Номер, LineId);
                                StartType = SptintCompontent.FinishType;
                            }

                            return SptintCompontent;

                        }
                    }

                    public bool MoveNext()
                    {
                        ++Index;
                        if (CorniceType != 3)
                            return Index < dsLines.tbLineSections.Select("[Код линии]=" + LineId.ToString()).Length;
                        return Index < dsLines.tbSplintSections.Select("[Код линии]=" + LineId.ToString()).Length;
                    }

                    public void Reset()
                    {
                        Index = -1;
                    }

                    public Enumerator(dsLines dsLines, dsSplints Splints, int LineId)
                    {
                        this.dsLines = dsLines;
                        this.LineId = LineId;
                        this.dsSplints = Splints;
                        Index = -1;
                    }

                    #endregion

                }

                public Section FirstSection
                {
                    get
                    {
                        foreach (Section FirstSection in this)
                            return FirstSection;
                        return null;
                    }
                }

                public Section LastSection
                {
                    get
                    {
                        Section L = null;
                        foreach (Section FirstSection in this)
                            L = FirstSection;
                        return L;
                    }
                }
            }

            public class Lines : IEnumerable
            {
                dsLines dsLines;
                dsSplints dsSplints;

                #region IEnumerable Members

                public IEnumerator GetEnumerator()
                {
                    return new Enumerator(dsLines, dsSplints);
                }

                #endregion

                public Lines(dsLines dsLines, dsSplints dsSplints)
                {
                    this.dsLines = dsLines;
                    this.dsSplints = dsSplints;
                }

                private class Enumerator : IEnumerator
                {
                    int Index;
                    dsLines dsLines;
                    dsSplints dsSplints;

                    #region IEnumerator Members

                    public object Current
                    {
                        get 
                        {
                            dsLines.tbLineRow rw = (dsLines.tbLineRow)
                                dsLines.tbLine.Select("", "[Номер линии] ASC")[Index];
                            return new Line(dsLines, dsSplints, rw.Код);
                        }
                    }

                    public bool MoveNext()
                    {
                        Index++;
                        return Index < dsLines.tbLine.Rows.Count;
                    }

                    public void Reset()
                    {
                        Index = -1;
                    }

                    public Enumerator(dsLines dsLines, dsSplints dsSplints)
                    {
                        Index = -1;
                        this.dsLines = dsLines;
                        this.dsSplints = dsSplints;
                    }
                    #endregion
                }

            }

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
                    this.dsLines=dsLines;
                    Its_LineId=LineId;
                    N=Numer;
                }

                public Section PrevSection
                {
                    get
                    {
                        DataRow[] rc =
                            dsLines.tbLineSections.Select
                                ("[Код линии]=" + Line.ID,"[Номер] ASC");
                        if (N <= 1 || N > rc.Length + 1)
                            return null;
                        return SectionByID(dsLines, (rc[N - 2] as dsLines.tbLineSectionsRow).Код);
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



                public Line Line
                {
                    get
                    {
                        return new Line(dsLines, null, Its_LineId);
                    }
                }

                public void Draw(Graphics Graphics, View View, Font Font, Brush Brush)
                {
                    PointF p = View.TranslateF(Pointer.PointF);
                    p.X += 0;
                    p.Y += 0;
                    Graphics.DrawString(Numer.ToString(), Font, Brush, p);
                }

            }

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

                public Line Line
                {
                    get
                    {
                        return new Line(dsLines, null, dsLines.tbSide.FindByКод(ID).Код_линии);
                    }
                }
            }
        }

        public class SplintSections
        {
            public enum SplintContourType
            {
                LeftLug = -1, RightLug = -2, PreCork = -3,
                LeftEmbrasure = 1, RightEmbrasure = 2,
                Cork = 3, InsideLine = 4, OutsideLine = 5
            };

            public static SplintContourType ReverseSplintContourType(SplintContourType SplintContourType)
            {
                return (SplintContourType)(-(int)SplintContourType);
            }

            public abstract class SplintContour
            {
                protected double l;
                protected double alpha;
                protected double phi;
                protected SplintContourType type;

                public double Length
                {
                    get
                    {
                        return l;
                    }
                }

                public double Alpha
                {
                    get
                    {
                        return alpha;
                    }
                }

                public double Phi
                {
                    get
                    {
                        return phi;
                    }
                }

                public SplintContourType Type
                {
                    get
                    {
                        return type;
                    }
                }

                public System.Drawing.Drawing2D.DashStyle DashStyle
                {
                    get
                    {
                        switch (Type)
                        {
                            case SplintContourType.Cork:
                                return System.Drawing.Drawing2D.DashStyle.Solid;
                            case SplintContourType.InsideLine:
                                return System.Drawing.Drawing2D.DashStyle.Dot;
                            case SplintContourType.OutsideLine:
                                return System.Drawing.Drawing2D.DashStyle.Solid;
                            case SplintContourType.LeftLug:
                                return System.Drawing.Drawing2D.DashStyle.DashDot;
                            case SplintContourType.RightLug:
                                return System.Drawing.Drawing2D.DashStyle.DashDot;
                            case SplintContourType.LeftEmbrasure:
                                return System.Drawing.Drawing2D.DashStyle.DashDotDot;
                            case SplintContourType.RightEmbrasure:
                                return System.Drawing.Drawing2D.DashStyle.DashDotDot;
                        }
                        return System.Drawing.Drawing2D.DashStyle.Custom;
                    }
                }

                public Pointer Finish(Pointer Start)
                {
                    return new Pointer(
                        Start.X + Length * Math.Cos(Start.Phi + Alpha / 2) * sinx(Alpha / 2),
                        Start.Y + Length * Math.Sin(Start.Phi + Alpha / 2) * sinx(Alpha / 2),
                        Start.Phi + Alpha + Phi);
                }

                public abstract void Draw(Graphics Graphics, View View, Pointer Start, Pen Pen);

                public SplintContour(double Length, double Alpha, double Phi, SplintContourType Type)
                {
                    l = Length;
                    alpha = Alpha;
                    phi = Phi;
                    type = Type;
                }
            }

            public class SplintLineContour: SplintContour
            {
                public SplintLineContour(double Length, double Phi, SplintContourType Type) :
                    base(Length, 0, Phi, Type)
                {
                }


                public override void Draw(Graphics Graphics, View View, Pointer Start, Pen Pen)
                {
                    Pen.DashStyle = DashStyle;
                    PointF StartF = View.TranslateF(Start);
                    PointF FinishF = View.TranslateF(this.Finish(Start));
                    Graphics.DrawLine(Pen, StartF, FinishF);
                }
            }

            public class SplintArcContour : SplintContour
            {
                public SplintArcContour(double Length, double Alpha, double Phi, SplintContourType Type) :
                    base(Length, Alpha, Phi, Type)
                {
                }

                public Pointer Center(Pointer Start)
                {
                    Pointer C = new Pointer();
                    C.X = Start.X - Length / Alpha * Math.Sin(Start.Phi);
                    C.Y = Start.Y + Length / Alpha * Math.Cos(Start.Phi);
                    if (Alpha > 0)
                        C.Phi = Math.PI / 2 - Start.Phi;
                    else
                        C.Phi = -Math.PI / 2 - Start.Phi;
                    return C;

                }

                public Pointer Middle(Pointer Start)
                {
                    return new Pointer(
                        Start.X + Length / 2 * Math.Cos(Start.Phi + Alpha / 4) * sinx(Alpha / 4),
                        Start.Y + Length / 2 * Math.Sin(Start.Phi + Alpha / 4) * sinx(Alpha / 4),
                        Start.Phi + Alpha / 2);
                }

                public double Radius
                {
                    get
                    {
                        return Math.Abs(Length / Alpha);
                    }
                }

                public override void Draw(Graphics Graphics, View View, Pointer Start, Pen Pen)
                {
                    Pen.DashStyle = DashStyle;
                    float R = (float)(Radius * View.Zoom);
                    PointF C = View.TranslateF(Center(Start));
                    RectangleF RectangleF = new RectangleF(C.X - R, C.Y - R, 2 * R, 2 * R);

                    Graphics.DrawArc(Pen, RectangleF,
                        (float)(View.Translate(Center((Start))).Phi * 180 / Math.PI),
                        -(View.Mirrow ? -1 : 1) * (float)(Alpha * 180 / Math.PI));

                }
            }

            public class SplintComponent : IEnumerable
            {
                private dsSplints dsSplints;
                private dsLines dsLines;
                private int ComponentId;
                private SplintContourType starttype;
                private double value;
                private int numer;
                private int LineId;

                public int Id
                {
                    get
                    {
                        return ComponentId;
                    }
                }

                public int Numer
                {
                    get
                    {
                        return numer;
                    }
                }

                public SplintContourType StartType
                {
                    get
                    {
                        return starttype;
                    }
                }

                public double Value
                {
                    get
                    {
                        return value;
                    }
                }

                public string Name
                {
                    get
                    {
                        return dsSplints.tbComponents.FindByКод(Id).Название;
                    }
                }

                public string FullName
                {
                    get
                    {
                        return String.Format("{0:G}. {1:G} [L={2:N2} \u03B2={3:N2}]",
                            Numer, Name, Length, Value);
                    }
                }

                public double Length
                {
                    get
                    {
                        double L = 0;
                        foreach (SplintContour Contour in this)
                            if (Contour.Type == SplintContourType.OutsideLine)
                                L += Contour.Length;
                        return L;
                    }
                }

                public SplintComponent(dsSplints dsSplints, dsLines dsLines, int ComponentId,
                    SplintContourType StartType, double Value, int Numer, int LineId)
                {
                    this.dsLines = dsLines;
                    this.dsSplints = dsSplints;
                    this.ComponentId = ComponentId;
                    starttype = StartType;
                    value = Value;
                    numer = Numer;
                    this.LineId = LineId;
                }

                public void Draw(Graphics Graphics, View View, Pointer Start, Pen Pen)
                {
                    foreach (SplintContour Contour in this)
                    {
                        Contour.Draw(Graphics, View, Start, Pen);
                        Start = Contour.Finish(Start);
                    }
                }

                public SplintContourType FinishType
                {
                    get
                    {
                        foreach (SplintContour Contour in this)
                        {
                            if (Contour.Type == StartType)
                                continue;
                            if (Contour.Type == SplintContourType.Cork ||
                                Contour.Type == SplintContourType.LeftEmbrasure ||
                                Contour.Type == SplintContourType.LeftLug ||
                                Contour.Type == SplintContourType.RightEmbrasure ||
                                Contour.Type == SplintContourType.RightLug)
                                return Contour.Type;
                        }
                        return SplintContourType.PreCork;
                    }
                }

                public Pointer Finish(Pointer Start)
                {
                    foreach (SplintContour Contour in this)
                    {
                        if (Contour.Type == FinishType)
                        {
                            Start = Contour.Finish(Start);
                            Start.Phi += Math.PI - Contour.Phi;
                            break;
                        }
                        Start = Contour.Finish(Start);
                    }
                    return Start;
                }

                public void FillNode(TreeNode nd)
                {
                    nd.Tag = this;
                    nd.Text = FullName;
                    nd.ImageKey = "Line";
                    nd.SelectedImageKey = "Line";
                }

                public LineSections.Line Line
                {
                    get
                    {
                        return new LineSections.Line(dsLines, dsSplints, LineId);
                    }
                }

                private RectangleF BorderWall(RectangleF RectangleF, PointF PointF)
                {
                    if (PointF.X < RectangleF.Left)
                    {
                        RectangleF.Width -= PointF.X - RectangleF.X;
                        RectangleF.X = PointF.X;
                    }
                    if (PointF.X > RectangleF.Right)
                        RectangleF.Width = PointF.X - RectangleF.X;
                    if (PointF.Y < RectangleF.Top)
                    {
                        RectangleF.Height -= PointF.Y - RectangleF.Y;
                        RectangleF.Y = PointF.Y;
                    }
                    if (PointF.Y > RectangleF.Bottom)
                        RectangleF.Height = PointF.Y - RectangleF.Y;
                    return RectangleF;

                }

                public RectangleF Border(View View, Pointer Start)
                {
                    RectangleF RectangleF = new RectangleF(
                        (float)View.Translate(Start).X, (float)View.Translate(Start).Y, 1, 1);

                    foreach (SplintContour Contour in this)
                    {
                        Start = Contour.Finish(Start);
                        RectangleF = BorderWall(RectangleF, View.Translate(Start).PointF);
                    }
                    return RectangleF;
                }


                #region IEnumerable Members

                public IEnumerator GetEnumerator()
                {
                    return new Enumerator(dsSplints, Id, StartType, Value);
                }

                #endregion

                public class Enumerator : IEnumerator
                {
                    private int Index = -1;
                    private dsSplints dsSplints;
                    private SplintContourType StartType;
                    private int ComponentId;
                    private double Value;

                    public bool MoveNext()
                    {
                        dsSplints.tbContourRow[] rc = (dsSplints.tbContourRow[])
                            dsSplints.tbContour.Select("[Код компоненты]=" + ComponentId.ToString(), "[Номер] ASC");
                        Index++;
                        return Index < rc.Length;
                    }

                    public void Reset()
                    {
                        Index = -1;
                    }

                    public Enumerator(dsSplints dsSplints, int ComponentId, SplintContourType StartType, double Value)
                    {
                        this.dsSplints = dsSplints;
                        this.StartType = StartType;
                        this.ComponentId = ComponentId;
                        this.Value = Value;
                        Index = -1;
                    }

                    #region IEnumerator Members

                    public object Current
                    {
                        get 
                        {
                            dsSplints.tbContourRow[] rc = (dsSplints.tbContourRow[])
                                dsSplints.tbContour.Select("[Код компоненты]=" + ComponentId.ToString(), "[Номер] ASC");
                            int mt = 0;
                            
                            foreach (dsSplints.tbContourRow rws in rc)
                            {
                                if (rws.Тип == (int)StartType)
                                    break;
                                ++mt;
                            }
                            
                            dsSplints.tbContourRow rw = rc[(Index + mt) % rc.Length];

                            double l = rw.L0 + rw.LK * Value;
                            double alpha = (rw.Phi0 + rw.PhiK * Value) * Math.PI / 180;
                            double phi  = (rw.Угол) * Math.PI / 180;
                            if (Math.Abs(alpha) > 0.0001)
                                return new SplintArcContour(l, alpha, phi, (SplintContourType)rw.Тип);
                            return new SplintLineContour(l, phi, (SplintContourType)rw.Тип);
                        }
                    }

                    #endregion
                }
            }
        }

        public static int OrderId;
        public static int OrderType;
        public static int CorniceType;
        private static bool IsClose = false;

        public TfMain(int OrderId, string ConnectionString)
        {
            InitializeComponent();
            TfMain.OrderId = OrderId;
            LocalService.ConnectionString = ConnectionString;

            DataTable tbOrder = LocalService.GetOrderInfo(OrderId).Tables[0];
            if (tbOrder.Rows.Count <= 0)
            {
                MessageBox.Show("Данного заказа не существует. Приложение будет закрыто!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TfMain.IsClose = true;
                return;
            }
            DataRow rwOrder = tbOrder.Rows[0];
            OrderType = Convert.ToInt32(rwOrder["Код типа гнутия"]);
            CorniceType = Convert.ToInt32(rwOrder["Код типа карниза"]);

            dsSplints.Clear();
            dsSplints.tbComponents.Load(LocalService.GetSplintComponents().Tables[0].CreateDataReader());
            dsSplints.tbContour.Load(LocalService.GetSplintContour().Tables[0].CreateDataReader());


            dsLines.tbLine.Clear();
            dsLines.tbLine.Load(LocalService.GetLinesList(OrderId).Tables[0].CreateDataReader());

            foreach (dsLines.tbLineRow rwl in dsLines.tbLine.Rows)
            {
                DataColumn cl = new DataColumn(rwl.Номер_линии.ToString(), typeof(double));
                cl.DefaultValue = rwl.Отлет;
                dsLines.tbWallClearance.Columns.Add(cl);

                DataGridViewTextBoxColumn dbgcol = new DataGridViewTextBoxColumn();
                dbgcol.DataPropertyName = rwl.Номер_линии.ToString();
                dbgcol.HeaderText = rwl.Номер_линии.ToString();
                dbgcol.Width = 80;
                dbgcol.DefaultCellStyle.Format = "N3";
                dbgcol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dbgcol.ReadOnly = false;
                dbgClearance.Columns.Add(dbgcol);
                dbgClearanceCurve.Columns.Add(dbgcol.Clone() as DataGridViewTextBoxColumn);
            }

            tb.TabStop = false;
            tb.SizeMode = TabSizeMode.Fixed;
            tb.Appearance = TabAppearance.FlatButtons;
            tb.ItemSize = new Size(0, 1);

            Text += String.Format(" (Заказ №{0:G})", OrderId);

            if (LocalService.OrderState(OrderId) != 0)
            {
                btRLine.Enabled = false;
                btSave.Enabled = false;
                btWallToLine.Enabled = false;
                tbWall.Enabled = false;
                tbPicture.Enabled = false;
                Text += " - только просмотр";
            }

            if (!LocalService.IsWallExists(OrderId))
                return;

            try
            {
                dsWall.tbWall.Load(LocalService.GetWallList(OrderId).Tables[0].CreateDataReader());
                dsWall.tbWallDetail.Load(LocalService.GetWallDetail(OrderId).Tables[0].CreateDataReader());
                dsWall.AcceptChanges();

                int i = 0;
                foreach (dsWall.tbWallRow rww in dsWall.tbWall)
                {
                    dsWall.tbWallSegmentRow rws;

                    if (Math.Abs(rww.Угол) > 0.001)
                    {
                        rws = (dsWall.tbWallSegmentRow)dsWall.tbWallSegment.NewRow();
                        rws.Длина = 0;
                        rws.Угол = rww.Угол;
                        rws.Номер = ++i;
                        dsWall.tbWallSegment.Rows.Add(rws);
                        dsWall.tbWallSegment.AcceptChanges();
                        rww.Код_сегмента = rws.Код;
                    }

                    foreach (dsWall.tbWallDetailRow rwwd in dsWall.tbWallDetail.Select
                        ("[Код стены]=" + rww.Код.ToString()))
                    {
                        rws = (dsWall.tbWallSegmentRow)dsWall.tbWallSegment.NewRow();
                        rws.Длина = rwwd.Длина;
                        rws.Угол = rwwd.Угол;
                        rws.Номер = ++i;
                        dsWall.tbWallSegment.Rows.Add(rws);
                        dsWall.tbWallSegment.AcceptChanges();
                        rwwd.Код_сегмента = rws.Код;
                    }
                }

                dsWall.tbAgregate.Load(LocalService.GetAgregate(OrderId).Tables[0].CreateDataReader());
                dsWall.tbMeasure.Load(LocalService.GetMeasure(OrderId).Tables[0].CreateDataReader());

                dsWall.AcceptChanges();
                dsLines.tbClearance.Load(LocalService.GetLineClearance(OrderId).Tables[0].CreateDataReader());

                foreach (dsWall.tbWallRow rwwd in dsWall.tbWall)
                {
                    dsLines.tbWallClearanceRow rwwc = (dsLines.tbWallClearanceRow)
                        dsLines.tbWallClearance.NewRow();
                    rwwc.Код_стены = rwwd.Код;
                    rwwc.Стена = (new WallSections.Wall(dsWall, rwwd.Код)).Name;
                    foreach (dsLines.tbLineRow rwl in dsLines.tbLine)
                    {
                        DataRow[] rwcc = dsLines.tbClearance.Select
                            (String.Format("[Код стены]={0:G} AND [Код линии]={1:G}",
                            rwwd.Код, rwl.Код));
                        if (rwcc.Length <= 0)
                            rwwc[rwl.Номер_линии.ToString()] = rwl.Отлет;
                        else
                            rwwc[rwl.Номер_линии.ToString()] =
                                (rwcc[0] as dsLines.tbClearanceRow).Отлет;
                    }
                    dsLines.tbWallClearance.Rows.Add(rwwc);
                }

                dsLines.tbStartLine.Load(LocalService.GetLineStartPosition(OrderId).Tables[0].CreateDataReader());
                dsLines.tbLineSections.Load(LocalService.GetCorniceLineSection(OrderId).Tables[0].CreateDataReader());
                dsLines.tbSplintSections.Load(LocalService.GetLineSplint(OrderId).Tables[0].CreateDataReader());
                dsLines.tbSide.Load(LocalService.GetCorniceSide(OrderId).Tables[0].CreateDataReader());

                dsLines.AcceptChanges();
                DataRow rwv =
                    LocalService.GetCorniceView(OrderId).Tables[0].Rows[0];


                btAutoSize_Click(null, null);

                tb.Selecting -= tb_Selecting;
                tb.SelectedTab = tsCurve;
                tb.Selecting += tb_Selecting;

                UpdateTVCurve();

                edStartX.Value = Convert.ToDecimal(rwv["X"]);
                edStartY.Value = Convert.ToDecimal(rwv["Y"]);
                edRotate.Value = Convert.ToDecimal(rwv["Поворот"]);
                edZoom.Value = Convert.ToDecimal(rwv["Масштаб"]);
                cbMirrow.Checked = Convert.ToBoolean(rwv["Отражение"]);
                pnWall.Invalidate();
                tvCurve.Focus();

            }
            catch
            {
                int SelectedId = 0;
                UpdateTV(ref SelectedId);
                pnWall.Invalidate();
            }

        }
        
        public static double sinx(double x)
        {
            if (Math.Abs(x) < 0.01)
                return 1 - x * x / 6 * (1 + x * x / 120);
            else
                return Math.Sin(x) / x;
        }

        public static void MyDrawArc(Graphics G, Pen P, double X, double Y, double R, double beta0, double alpha)
        {
            RectangleF Rect = new RectangleF(
                (float)(X - Math.Abs(R)), (float)(Y - Math.Abs(R)),
                (float)(2 * Math.Abs(R)), (float)(2 * Math.Abs(R)));
            G.DrawArc(P, Rect, (float)(beta0 * 180 / Math.PI), (float)(alpha * 180 / Math.PI));

        }

        public static void DrawSection(Graphics G, Pen P, double x0, double y0, double phi0, double l, double alpha,
            out double x, out double y, out double phi)
        {
            phi = phi0 + alpha;
            x = x0 + l * Math.Cos(phi0 + alpha / 2) * sinx(alpha / 2);
            y = y0 + l * Math.Sin(phi0 + alpha / 2) * sinx(alpha / 2);

            if (l < 1)
                return;

            PointF z0 = new PointF((float)x0, (float)y0);
            PointF z = new PointF((float)x, (float)y);
            if (Math.Abs(alpha) < 0.01)
                G.DrawLine(P, z0, z);
            else
            {
                double R = l/alpha;
                if (2*l > 5*Math.Abs(alpha))
                {
                    double X = x - R * Math.Sin(phi);
                    double Y = y + R * Math.Cos(phi);
                    double beta0 = phi0 - Math.PI / 2 * Math.Sign(alpha);
                    MyDrawArc(G, P, X, Y, R, beta0, alpha);
                }

            }
        }

        public void CheckWall(ref int SelectedId)
        {
            double MinLen = 0.001;
            bool IsSuccessful;

            dsWall.tbWallDetail.Clear();
            dsWall.tbWallDetail.AcceptChanges();
            dsWall.tbWall.Clear();
            dsWall.tbWall.AcceptChanges();

            do
            {
                IsSuccessful = true;

                dsWall.tbWallSegmentRow[] rwwc = dsWall.tbWallSegment.Select("", "[Номер] ASC") as dsWall.tbWallSegmentRow[];
                if (rwwc.Length <= 0)
                    continue;

                int i = 0;

                for (i = 0; i < rwwc.Length && rwwc[i].Длина >= 0; i++) ;
                if (i < rwwc.Length)
                {
                    rwwc[i].Длина = 0;
                    dsWall.tbWallSegment.AcceptChanges();
                    IsSuccessful = false;
                    continue;
                }

                for (i = 0; i < rwwc.Length && Math.Abs(rwwc[i].Угол) < 360; i++) ;
                if (i < rwwc.Length)
                {
                    rwwc[i].Угол -= Math.Floor(rwwc[i].Угол / 360) * 360 + (rwwc[i].Угол < -360 ? 360 : 0);
                    dsWall.tbWallSegment.AcceptChanges();
                    IsSuccessful = false;
                    continue;
                }

                for (i = 0; i < rwwc.Length && (Math.Abs(rwwc[i].Угол) < 180 || rwwc[i].Длина >= MinLen); i++) ;
                if (i < rwwc.Length)
                {
                    rwwc[i].Угол -= Math.Floor(rwwc[i].Угол / 180) * 180 + (rwwc[i].Угол < -180 ? 180 : 0);
                    dsWall.tbWallSegment.AcceptChanges();
                    IsSuccessful = false;
                    continue;
                }

                if (rwwc[0].Длина < MinLen)
                {
                    if (rwwc[0].Код == SelectedId && rwwc.Length > 1)
                        SelectedId = rwwc[1].Код;
                    rwwc[0].Delete();
                    dsWall.tbWallSegment.AcceptChanges();
                    IsSuccessful = false;
                    continue;
                }

                if (rwwc[rwwc.Length - 1].Длина < MinLen)
                {
                    if (rwwc[0].Код == SelectedId && rwwc.Length > 1)
                        SelectedId = rwwc[rwwc.Length - 2].Код;
                    rwwc[rwwc.Length - 1].Delete();
                    dsWall.tbWallSegment.AcceptChanges();
                    IsSuccessful = false;
                    continue;
                }

                for (i = 1; i < rwwc.Length &&
                    Math.Abs(rwwc[i].Длина * rwwc[i - 1].Угол - rwwc[i - 1].Длина * rwwc[i].Угол) > 1e-6; i++) ;
                if (i < rwwc.Length)
                {
                    if (rwwc[i].Код == SelectedId)
                        SelectedId = rwwc[i].Код;
                    rwwc[i].Угол += rwwc[i - 1].Угол;
                    rwwc[i].Длина += rwwc[i - 1].Длина;
                    rwwc[i - 1].Delete();
                    dsWall.tbWallSegment.AcceptChanges();
                    IsSuccessful = false;
                    continue;
                }
            }
            while (!IsSuccessful);

            dsWall.tbWallSegmentRow[] rwc = dsWall.tbWallSegment.Select("", "[Номер] ASC") as dsWall.tbWallSegmentRow[];
            for (int j = 0; j < rwc.Length; j++)
                rwc[j].Номер = j + 1;
            dsWall.tbWallSegment.AcceptChanges();

            if (rwc.Length > 0)
            {
                int WallNumer = 0;
                int WallDetailNumer = 0;

                dsWall.tbWallRow rww = (dsWall.tbWallRow)dsWall.tbWall.NewRow();
                rww.Номер = ++WallNumer;
                rww.Угол = 0;
                dsWall.tbWall.Rows.Add(rww);
                dsWall.tbWall.AcceptChanges();

                for (int j = 0; j < rwc.Length; j++)
                {
                    if (rwc[j].Длина < MinLen)
                    {
                        rww = (dsWall.tbWallRow)dsWall.tbWall.NewRow();
                        rww.Номер = ++WallNumer;
                        rww.Угол = rwc[j].Угол;
                        rww.Код_сегмента = rwc[j].Код;
                        dsWall.tbWall.Rows.Add(rww);
                        dsWall.tbWall.AcceptChanges();
                        WallDetailNumer = 0;
                    }
                    else
                    {
                        dsWall.tbWallDetailRow rwwd = (dsWall.tbWallDetailRow)dsWall.tbWallDetail.NewRow();
                        dsWall.tbWallDetail.Rows.Add(rwwd);
                        rwwd.Код_стены = rww.Код;
                        rwwd.Номер = ++WallDetailNumer;
                        rwwd.Длина = rwc[j].Длина;
                        rwwd.Угол = rwc[j].Угол;
                        rwwd.Код_сегмента = rwc[j].Код;
                        dsWall.tbWallDetail.AcceptChanges();
                    }
                }
            }
        }

        private View CurrentView()
        {
            return new View(
                Convert.ToDouble(edStartX.Value),
                Convert.ToDouble(edStartY.Value),
                Convert.ToDouble(edRotate.Value) * Math.PI / 180,
                Convert.ToDouble(edZoom.Value), cbMirrow.Checked);

        }
        
        private void TfMain_Load(object sender, EventArgs e)
        {
            
        }

        private void UpdateTV(ref int SelectedId)
        {
            CheckWall(ref SelectedId);
            tv.Nodes.Clear();
            
            foreach (WallSections.Wall Wall in new WallSections.Walls(dsWall))
            {
                if (Wall.PrevCorner!=null)
                    WallSections.FillNode
                        (tv.Nodes.Add(""), WallSections.WallType.Corner,
                        dsWall, Wall.PrevCorner.ID);
                TreeNode ndWall = tv.Nodes.Add("");
                WallSections.FillNode(ndWall, Wall.Type, dsWall, Wall.ID);

                foreach (WallSections.Section Section in (ndWall.Tag as WallSections.Wall))
                {
                    TreeNode nd = ndWall.Nodes.Add("");
                    WallSections.FillNode(nd, Section.Type, dsWall, Section.ID);

                    if ((nd.Tag as WallSections.Section).ID == SelectedId)
                        tv.SelectedNode = nd;
                }
            }
            tv.ExpandAll();
            pnWall.Invalidate();
        }
 
        private void tv_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode nd = ((TreeView)sender).GetNodeAt(e.Location);
                if (nd != null) ((TreeView)sender).SelectedNode = nd;
                ((TreeView)sender).Focus();
            }
        }

        private void btAddLine_Click(object sender, EventArgs e)
        {
            TfAddLine f = new TfAddLine() { Tag = this, d = 0, theta = 0 };
            int CurrNumer = -1;

            if (tv.SelectedNode == null)
            {
                f.edCorner.Enabled = false;
                f.rbCorner.Enabled = false;
            }
            else
            {
                WallSections.Wall Wall = (tv.SelectedNode.Tag as WallSections.Section).Wall;
                f.theta = Wall.Theta;
                f.d = Wall.Diameter;
                f.edCorner.Value = Convert.ToDecimal(90);
                CurrNumer = Wall.FinishPoint.SegnentNumer;
            }

            if (f.d < 1e-6)
                f.rbDiag.Enabled = false;

            if (f.ShowDialog() != DialogResult.Yes)
                return;

            foreach (dsWall.tbWallSegmentRow rwos in dsWall.tbWallSegment.Rows)
                if (rwos.Номер >= CurrNumer)
                    rwos.Номер += 3;
            dsWall.tbWallSegment.AcceptChanges();

            dsWall.tbWallSegmentRow rws = (dsWall.tbWallSegmentRow)dsWall.tbWallSegment.NewRow();
            rws.Номер = ++CurrNumer;
            rws.Длина = 0;
            rws.Угол = f.alpha * 180 / Math.PI;
            rws.Угол = rws.Угол < 0 ? -180 - rws.Угол : 180 - rws.Угол;
            dsWall.tbWallSegment.Rows.Add(rws);
            dsWall.tbWallSegment.AcceptChanges();

            rws = (dsWall.tbWallSegmentRow)dsWall.tbWallSegment.NewRow();
            rws.Номер = ++CurrNumer;
            rws.Длина = f.l;
            rws.Угол = 0;
            dsWall.tbWallSegment.Rows.Add(rws);
            dsWall.tbWallSegment.AcceptChanges();
            int SelectedId = rws.Код;

            UpdateTV(ref SelectedId);

            TreeNode nss = tv.SelectedNode;

            if (nss != null)
            {
                WallSections.Section ss = (WallSections.Section)nss.Tag;
                if (ss is WallSections.WallPartSection)
                    tv.SelectedNode = nss.Parent;
            }
        }

        private void btAddArc_Click(object sender, EventArgs e)
        {
            TfAddArc f = new TfAddArc() { Tag = this };
            f.tbAgregateBindingSource.DataSource = dsWall;
            f.tbMeasureBindingSource.DataSource = dsWall;
            int CurrNumer = -1;

            if (tv.SelectedNode == null)
            {
                f.edCorner.Enabled = false;
                f.rbCorner.Enabled = false;
            }
            else
            {
                WallSections.Wall Wall = (tv.SelectedNode.Tag as WallSections.Section).Wall;
                f.theta = Wall.Theta;
                f.d = Wall.Diameter;
                f.edCorner.Value = Convert.ToDecimal(90);
                CurrNumer = Wall.FinishPoint.SegnentNumer;
            }

            if (f.d < 1e-6)
                f.rbDiag.Enabled = false;

            if (f.ShowDialog() != DialogResult.Yes)
                return;

            foreach (dsWall.tbWallSegmentRow rwos in dsWall.tbWallSegment.Rows)
                if (rwos.Номер >= CurrNumer)
                    rwos.Номер += 6;
            dsWall.tbWallSegment.AcceptChanges();

            int AggregateId = ((f.tbAgregateBindingSource.Current as DataRowView).Row as dsWall.tbAgregateRow).Код;
            DataRow[] NewWalls = dsWall.tbAggregateWall.Select(
                String.Format("[Код агрегата]={0:G}", AggregateId), "[Номер] ASC");

            dsWall.tbWallSegmentRow rws = (dsWall.tbWallSegmentRow)dsWall.tbWallSegment.NewRow();
            rws.Номер = ++CurrNumer;
            rws.Длина = 0;
            rws.Угол = f.alpha * 180 / Math.PI;
            rws.Угол = rws.Угол < 0 ? -180 - rws.Угол : 180 - rws.Угол;
            dsWall.tbWallSegment.Rows.Add(rws);
            dsWall.tbWallSegment.AcceptChanges();

            int SelectedId = 0;
            foreach (dsWall.tbAggregateWallRow rwaw in NewWalls)
            {
                rws = (dsWall.tbWallSegmentRow)dsWall.tbWallSegment.NewRow();
                rws.Номер = ++CurrNumer;
                rws.Длина = rwaw.Длина;
                rws.Угол = rwaw.Угол;
                dsWall.tbWallSegment.Rows.Add(rws);
                dsWall.tbWallSegment.AcceptChanges();
                SelectedId = rws.Код;
            }

            UpdateTV(ref SelectedId);

            TreeNode nss = tv.SelectedNode;

            if (nss != null)
            {
                WallSections.Section ss = (WallSections.Section)nss.Tag;
                if (ss is WallSections.WallPartSection)
                    tv.SelectedNode = nss.Parent;
            }
        }

        private void btDeleteWall_Click(object sender, EventArgs e)
        {
            TreeNode nd = tv.SelectedNode;
            if (nd == null)
                return;

            WallSections.Section Section = (WallSections.Section)nd.Tag;
            if (Section is WallSections.WallPartSection && Section.Wall.Count <= 1)
                Section = Section.Wall;
            int SelectedId = 0;
            int LeftId = 0;
            int RightId = 0;

            switch (Section.Type)
            {
                case WallSections.WallType.Arc:
                    if (MessageBox.Show("Вы уверены, что хотите удалите выделенную дугу?",
                        "Внимание", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button3) != DialogResult.Yes)
                        return;
                    
                    if (new WallSections.Walls(dsWall).Count > 1)
                        SelectedId = (Section.Wall.NextCorner != null) ? 
                            Section.Wall.NextCorner.ID : Section.Wall.PrevCorner.ID;
                    
                    dsWall.tbWallSegment.FindByКод(Section.ID).Delete();
                    dsWall.tbWallSegment.AcceptChanges();
                    UpdateTV(ref SelectedId);
                    MessageBox.Show("Выделенная дуга была успешно удалена.",
                        "Успешное удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case WallSections.WallType.Line:
                    if (MessageBox.Show("Вы уверены, что хотите удалите выделенную прямую?",
                        "Внимание", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button3) != DialogResult.Yes)
                        return;

                    if (new WallSections.Walls(dsWall).Count > 1)
                        SelectedId = (Section.Wall.NextCorner != null) ?
                            Section.Wall.NextCorner.ID : Section.Wall.PrevCorner.ID;

                    dsWall.tbWallSegment.FindByКод(Section.ID).Delete();
                    dsWall.tbWallSegment.AcceptChanges();
                    UpdateTV(ref SelectedId);
                    MessageBox.Show("Выделенная прямая была успешно удалена.",
                        "Успешное удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case WallSections.WallType.Wall:
                    TfDeleteWall f = new TfDeleteWall() { Tag = this };
                    f.rbLeft.Enabled = Section.Wall.PrevCorner != null;
                    f.rbRight.Enabled = Section.Wall.NextCorner != null;
                    f.rbLeft.Checked = f.rbLeft.Enabled;

                    if (f.ShowDialog() != DialogResult.OK)
                        return;
                    LeftId = Section.Wall.PrevCorner != null ? Section.Wall.PrevCorner.ID : 0;
                    RightId = Section.Wall.NextCorner != null ? Section.Wall.NextCorner.ID : 0;

                    if (f.rbLeft.Checked)
                        dsWall.tbWallSegment.FindByКод(LeftId).Delete();
                    if (f.rbRight.Checked)
                        dsWall.tbWallSegment.FindByКод(RightId).Delete();

                    foreach (dsWall.tbWallDetailRow rw in dsWall.tbWallDetail.Select
                        ("[Код стены]=" + Section.ID.ToString()))
                        dsWall.tbWallSegment.FindByКод(rw.Код_сегмента).Delete();

                    dsWall.tbWallSegment.AcceptChanges();

                    UpdateTV(ref SelectedId);
                    MessageBox.Show("Выделенная стена была успешно удалена.",
                        "Успешное удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case WallSections.WallType.Corner:
                    TfDeleteCorner fс = new TfDeleteCorner() { Tag = this };
                    WallSections.Corner Corner = (WallSections.Corner)Section;
                    fс.rbRight.Enabled = Corner.NextWall != null;
                    fс.rbRight.Checked = fс.rbRight.Enabled;

                    if (fс.ShowDialog() != DialogResult.OK)
                        return;

                    LeftId = Corner.Wall.ID;
                    RightId = Corner.NextWall != null ? Corner.NextWall.ID : 0;

                    if (fс.rbLeft.Checked)
                    foreach (dsWall.tbWallDetailRow rw in dsWall.tbWallDetail.Select
                        ("[Код стены]=" + LeftId.ToString()))
                        dsWall.tbWallSegment.FindByКод(rw.Код_сегмента).Delete();

                    if (fс.rbRight.Checked)
                        foreach (dsWall.tbWallDetailRow rw in dsWall.tbWallDetail.Select
                            ("[Код стены]=" + RightId.ToString()))
                            dsWall.tbWallSegment.FindByКод(rw.Код_сегмента).Delete();

                    dsWall.tbWallSegment.FindByКод(Corner.ID).Delete();
                    dsWall.tbWallSegment.AcceptChanges();

                    UpdateTV(ref SelectedId);
                    MessageBox.Show("Выделенный угол был успешно удален.",
                        "Успешное удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
            if (tv.Nodes.Count > 0 && tv.SelectedNode == null)
                tv.SelectedNode = tv.Nodes[0];
            
        }

        private void btWallUp_Click(object sender, EventArgs e)
        {
            TreeNode nd = tv.SelectedNode;
            if (nd == null)
                return;
            WallSections.Section Section = (WallSections.Section)nd.Tag;
            int SelectedId;
            if (Section.Type == WallSections.WallType.Wall)
            {
            }
            else
            {
                if (Section.Type == WallSections.WallType.Corner)
                {
                }
                else
                {
                    DataRow[] rws = dsWall.tbWallSegment.Select
                        ("[Номер]<=" + dsWall.tbWallSegment.FindByКод(Section.ID).Номер, 
                        "[Номер] DESC");
                    if (rws.Length < 2)
                        return;
                    SelectedId=Section.ID;
                    int TempNumer = dsWall.tbWallSegment.FindByКод(Section.ID).Номер;
                    dsWall.tbWallSegment.FindByКод(Section.ID).Номер =
                        (rws[1] as dsWall.tbWallSegmentRow).Номер;
                    (rws[1] as dsWall.tbWallSegmentRow).Номер = TempNumer;
                    dsWall.tbWallSegment.AcceptChanges();
                    UpdateTV(ref SelectedId);
                }
            }
            if (tv.Nodes.Count > 0 && tv.SelectedNode == null)
                tv.SelectedNode = tv.Nodes[0];
        }

        private void btWallDown_Click(object sender, EventArgs e)
        {
            TreeNode nd = tv.SelectedNode;
            if (nd == null)
                return;
            WallSections.Section Section = (WallSections.Section)nd.Tag;
            int SelectedId;
            if (Section.Type == WallSections.WallType.Wall)
            {
            }
            else
            {
                if (Section.Type == WallSections.WallType.Corner)
                {
                }
                else
                {
                    DataRow[] rws = dsWall.tbWallSegment.Select
                        ("[Номер]>=" + dsWall.tbWallSegment.FindByКод(Section.ID).Номер,
                        "[Номер] ASC");
                    if (rws.Length < 2)
                        return;
                    SelectedId = Section.ID;
                    int TempNumer = dsWall.tbWallSegment.FindByКод(Section.ID).Номер;
                    dsWall.tbWallSegment.FindByКод(Section.ID).Номер =
                        (rws[1] as dsWall.tbWallSegmentRow).Номер;
                    (rws[1] as dsWall.tbWallSegmentRow).Номер = TempNumer;
                    dsWall.tbWallSegment.AcceptChanges();
                    UpdateTV(ref SelectedId);
                }
            }
            if (tv.Nodes.Count > 0 && tv.SelectedNode == null)
                tv.SelectedNode = tv.Nodes[0];
        }

        private void pnWall_Paint(object sender, PaintEventArgs e)
        {
            Pen PenGreen = new Pen(Color.Green) 
                { Width = 3, DashStyle = System.Drawing.Drawing2D.DashStyle.Dot };
            Pen PenRed = new Pen(Color.Red) 
                { Width = 2, DashStyle = System.Drawing.Drawing2D.DashStyle.Dot };

            Pen PenBlackLine = new Pen(Color.Black) 
                { Width = 1, DashStyle = System.Drawing.Drawing2D.DashStyle.Solid };
            Pen PenRedLine = new Pen(Color.Red) 
                { Width = 1, DashStyle = System.Drawing.Drawing2D.DashStyle.Solid };
            Pen PenRedBLine = new Pen(Color.Red) 
                { Width = 2, DashStyle = System.Drawing.Drawing2D.DashStyle.Solid };

            foreach (WallSections.Wall Wall in new WallSections.Walls(dsWall))
            {
                if (tb.SelectedTab == tsLine &&
                    ((tbWallClearanceBindingSource.Current as DataRowView).Row as
                        dsLines.tbWallClearanceRow).Код_стены == Wall.ID ||
                    tb.SelectedTab == tsCurve && tvCurve.SelectedNode != null &&
                    (tvCurve.SelectedNode.Tag is WallSections.Walls ||
                        tvCurve.SelectedNode.Tag is WallSections.Section &&
                    ((tvCurve.SelectedNode.Tag as WallSections.Section).Wall.ID == Wall.ID ||
                    (tvCurve.SelectedNode.Tag as WallSections.Section).Type == WallSections.WallType.Corner)))
                    Wall.Draw(e.Graphics, PenRed, CurrentView());
                else
                    Wall.Draw(e.Graphics, PenGreen, CurrentView());
           }


            if (tb.SelectedTab == tsLine || tb.SelectedTab == tsWall)
                foreach (WallSections.Wall Wall in new WallSections.Walls(dsWall))
                    Wall.DrawNumer(e.Graphics, CurrentView(), new Font("Arial", 10), new SolidBrush(Color.Red));

            if (tb.SelectedTab == tsCurve)
            {
                foreach (LineSections.Line Line in new LineSections.Lines(dsLines, dsSplints))
                    if (CorniceType != 3)
                    {
                        foreach (LineSections.Section Section in Line)
                        {
                            Pen Pen = PenBlackLine;
                            if (tvCurve.SelectedNode != null)
                            {
                                if (tvCurve.SelectedNode.Tag is LineSections.Line &&
                                    (tvCurve.SelectedNode.Tag as LineSections.Line).ID == Line.ID)
                                    Pen = PenRedLine;
                                if (tvCurve.SelectedNode.Tag is LineSections.Section)
                                {
                                    LineSections.Section LS =
                                        (tvCurve.SelectedNode.Tag as LineSections.Section);
                                    if (LS.Line.ID == Line.ID)
                                    {
                                        if (LS.ID == Section.ID)
                                            Pen = PenRedBLine;
                                        else
                                            Pen = PenRedLine;
                                    }
                                }
                            }

                            Section.Draw(e.Graphics, Pen, CurrentView());
                        }
                    }
                    else
                    {
                        Pointer Start = Line.Start;

                        foreach (SplintSections.SplintComponent Component in Line)
                        {

                            Pen Pen = PenBlackLine;
                            
                            if (tvCurve.SelectedNode != null)
                            {
                                if (tvCurve.SelectedNode.Tag is LineSections.Line &&
                                    (tvCurve.SelectedNode.Tag as LineSections.Line).ID == Line.ID)
                                    Pen = PenRedLine;
                                if (tvCurve.SelectedNode.Tag is SplintSections.SplintComponent)
                                {
                                    SplintSections.SplintComponent LS =
                                        (tvCurve.SelectedNode.Tag as SplintSections.SplintComponent);
                                    if (LS.Line.ID == Line.ID)
                                    {
                                        if (LS.Numer == Component.Numer)
                                            Pen = PenRedBLine;
                                        else
                                            Pen = PenRedLine;
                                    }
                                }
                            }

                            Component.Draw(e.Graphics, CurrentView(), Start, Pen);
                            Start = Component.Finish(Start);
                        }
                    }

                LineSections.Line SelectedLine = null;
                if (tvCurve.SelectedNode != null)
                {
                    if (tvCurve.SelectedNode.Tag is LineSections.Line)
                        SelectedLine = tvCurve.SelectedNode.Tag as LineSections.Line;
                    if (tvCurve.SelectedNode.Tag is LineSections.Section)
                        SelectedLine = (tvCurve.SelectedNode.Tag as LineSections.Section).Line;
                    if (SelectedLine != null && CorniceType != 3)
                        foreach (LineSections.Section Section in SelectedLine)
                            Section.DrawNumer
                                (e.Graphics, CurrentView(), new Font("Arial", 8), new SolidBrush(Color.Blue));

                    if (tvCurve.SelectedNode.Tag is WallSections.Walls ||
                        tvCurve.SelectedNode.Tag is WallSections.Section)
                        foreach (WallSections.Wall Wall in new WallSections.Walls(dsWall))
                            Wall.DrawNumer
                                (e.Graphics, CurrentView(), new Font("Arial", 10), new SolidBrush(Color.Red));

                }

            }

            DrawZoom(e.Graphics, CurrentView(), pnWall.Width, pnWall.Height);
            DrawArrow(e.Graphics, CurrentView(), pnWall.Width, pnWall.Height);



        }

        public static void DrawZoom(Graphics Graphics, View View, int Width, int Height)
        {
            double M = 100 * View.Zoom;
            while (M > 0.8 * Width)
                M /= 10;
            Pen ZoomPen = new Pen(Color.Magenta, 2);
            Graphics.DrawLine(ZoomPen, 10, Height - 10, 10 + (int)M, Height - 10);
            Graphics.DrawLine(ZoomPen, 10, Height - 10, 10, Height - 13);
            Graphics.DrawLine(ZoomPen, 10 + (int)M, Height - 10, 10 + (int)M, Height - 13);
            Graphics.DrawString((M / View.Zoom).ToString("N2") + " м", new Font("Arial", 8),
                new SolidBrush(Color.Green), 10 + (float)M, Height - 18);

        }

        public void DrawArrow(Graphics Graphics, View View, int Width, int Height)
        {
            Pen ZoomPen = new Pen(Color.Brown, 1);
            int LWidth = Width - 30;
            int LHeight = Height - 30;
            if (CorniceType != 3)
            {
                Graphics.DrawLine(ZoomPen, LWidth + 8, LHeight + 10, LWidth + 8, LHeight + 20);
                Graphics.DrawLine(ZoomPen, LWidth + 16, LHeight + 10, LWidth + 16, LHeight + 20);
                Graphics.DrawLine(ZoomPen, LWidth + 12, LHeight, LWidth, LHeight + 12);
                Graphics.DrawLine(ZoomPen, LWidth + 12, LHeight, LWidth + 24, LHeight + 12);
            }
            else
            {
                Graphics.DrawLine(ZoomPen, LWidth + 10, LHeight + 8, LWidth + 20, LHeight + 8);
                Graphics.DrawLine(ZoomPen, LWidth + 10, LHeight + 16, LWidth + 20, LHeight + 16);
                Graphics.DrawLine(ZoomPen, LWidth, LHeight + 12, LWidth + 14, LHeight);
                Graphics.DrawLine(ZoomPen, LWidth, LHeight + 12, LWidth + 14, LHeight + 24);
            }
        }

        private void edWallX_ValueChanged(object sender, EventArgs e)
        {
            pnWall.Invalidate();
        }

        private void tb_Selecting(object sender, TabControlCancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void btWallToLine_Click(object sender, EventArgs e)
        {
            if ((new WallSections.Walls(dsWall)).Count <= 0)
            {
                MessageBox.Show("Перед отрисовкой линий нужно отрисовать стены.","Внимание",
                    MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            dsLines.tbClearance.Clear();
            dsLines.tbWallClearance.Clear();
            dsLines.AcceptChanges();

            foreach (WallSections.Wall Wall in new WallSections.Walls(dsWall))
            {
                dsLines.tbWallClearanceRow rwwc = (dsLines.tbWallClearanceRow)
                    dsLines.tbWallClearance.NewRow();
                rwwc.Код_стены = Wall.ID;
                rwwc.Стена = Wall.Name;
                dsLines.tbWallClearance.Rows.Add(rwwc);
                dsLines.tbWallClearance.AcceptChanges();
            }

            tb.Selecting -= tb_Selecting;
            tb.SelectedTab = tsLine;
            tb.Selecting += tb_Selecting;
            btAutoSize_Click(null, null);
            if (CorniceType == 3)
                btToPicture_Click(null, null);
            pnWall.Invalidate();
        }

        private void tbWallClearanceBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            pnWall.Invalidate();
        }

        private void btToPicture_Click(object sender, EventArgs e)
        {
            dsLines.tbClearance.Clear();
            dsLines.tbClearance.AcceptChanges();
            foreach (dsLines.tbLineRow rwl in dsLines.tbLine.Rows)
            {
                foreach (dsLines.tbWallClearanceRow rwwc in dsLines.tbWallClearance)
                {
                    dsLines.tbClearanceRow rwc = (dsLines.tbClearanceRow)dsLines.tbClearance.NewRow();
                    rwc.Код_линии = rwl.Код;
                    rwc.Код_стены = rwwc.Код_стены;
                    rwc.Отлет = Convert.ToDouble(rwwc[rwl.Номер_линии.ToString()]);
                    dsLines.tbClearance.Rows.Add(rwc);
                    dsLines.tbClearance.AcceptChanges();
                }

                dsLines.tbSideRow rwside = (dsLines.tbSideRow)
                    dsLines.tbSide.NewRow();
                rwside.Код_линии = rwl.Код;
                rwside.Положение = false;
                rwside.Боковина = false;
                rwside.Угол = 90;
                rwside.Отступ = 0;
                dsLines.tbSide.Rows.Add(rwside);
                dsLines.tbSide.AcceptChanges();

                rwside = (dsLines.tbSideRow) dsLines.tbSide.NewRow();
                rwside.Код_линии = rwl.Код;
                rwside.Положение = true;
                rwside.Боковина = false;
                rwside.Угол = 90;
                rwside.Отступ = 0;
                dsLines.tbSide.Rows.Add(rwside);
                dsLines.tbSide.AcceptChanges();

            }

           foreach (LineSections.Line Line in new LineSections.Lines(dsLines, dsSplints))
               Calulate(Line);

            UpdateTVCurve();

            tb.Selecting -= tb_Selecting;
            tb.SelectedTab = tsCurve;
            tb.Selecting += tb_Selecting;

            pnWall.Invalidate();
            tvCurve.Focus();

        }

        private void UpdateTVCurve()
        {
            tvCurve.Nodes.Clear();
            TreeNode ndWalls = tvCurve.Nodes.Add("");
            (new WallSections.Walls(dsWall)).FillNode(ndWalls);

            foreach (WallSections.Wall Wall in new WallSections.Walls(dsWall))
            {
                if (Wall.PrevCorner != null)
                    WallSections.FillNode
                        (ndWalls.Nodes.Add(""), WallSections.WallType.Corner,
                        dsWall, Wall.PrevCorner.ID);
                TreeNode ndWall = ndWalls.Nodes.Add("");
                WallSections.FillNode(ndWall, Wall.Type, dsWall, Wall.ID);

                foreach (WallSections.Section Section in (ndWall.Tag as WallSections.Wall))
                {
                    TreeNode nd = ndWall.Nodes.Add("");
                    WallSections.FillNode(nd, Section.Type, dsWall, Section.ID);

                }
            }

            foreach (LineSections.Line Line in new LineSections.Lines(dsLines, dsSplints))
            {
                TreeNode ndLine = tvCurve.Nodes.Add("");
                Line.FillNode(ndLine);
                if (CorniceType != 3)
                    foreach (LineSections.Section Section in Line)
                        Section.FillNode(ndLine.Nodes.Add(""));
                else
                    foreach (SplintSections.SplintComponent Compontent in Line)
                        Compontent.FillNode(ndLine.Nodes.Add(""));
                
            }
            tvCurve.ExpandAll();
            ndWalls.Collapse();
        }

        private void Calulate(LineSections.Line Line)
        {
            double R = 0.1;
            foreach (dsLines.tbLineSectionsRow rwls in
                dsLines.tbLineSections.Select("[Код линии]=" + Line.ID.ToString()))
                rwls.Delete();
            dsLines.tbLineSections.AcceptChanges();

            foreach (dsLines.tbStartLineRow rwsl in
                            dsLines.tbStartLine.Select("[Код линии]=" + Line.ID.ToString()))
                rwsl.Delete();
            dsLines.tbStartLine.AcceptChanges();

            dsLines.tbStartLineRow srw = (dsLines.tbStartLineRow)
                dsLines.tbStartLine.NewRow();

            if (CorniceType == 3)
            {
                srw.Код_линии = Line.ID;
                srw.X = Line.FirstSide.Step;
                srw.Y = (Line.FirstSide.IsSide ? 0 : Line.ClearanceByWall((new WallSections.Walls(dsWall)).FirstWall));
                srw.Phi = (Line.FirstSide.IsSide ?  0: -90);
                dsLines.tbStartLine.Rows.Add(srw);
                dsLines.tbStartLine.AcceptChanges();
                return;
            }

            if ((new WallSections.Walls(dsWall)).Count == 0)
                return;
            
            srw.Код_линии = Line.ID;
            srw.X = 0;
            srw.Y = Line.ClearanceByWall((new WallSections.Walls(dsWall)).FirstWall);
            dsLines.tbStartLine.Rows.Add(srw);
            dsLines.tbStartLine.AcceptChanges();

            Pointer Start = null;
            Pointer Finish = null;
            Pointer Delta = null;
            dsLines.tbLineSectionsRow rws;

            int i = 0;
            foreach (WallSections.Wall Wall in new WallSections.Walls(dsWall))
            {

                foreach (WallSections.WallPartSection WallPart in Wall)
                {
                    if (
                        (Wall.LastSection.ID != WallPart.ID || Wall.NextCorner == null) &&
                        (Wall.FirstSection.ID != WallPart.ID || Wall.PrevCorner == null))
                    {
                        rws = (dsLines.tbLineSectionsRow)
                            dsLines.tbLineSections.NewRow();
                        rws.Код_линии = Line.ID;
                        rws.Номер = ++i;
                        rws.Длина = WallPart.Length - WallPart.Alpha * Line.ClearanceByWall(Wall);
                        rws.Угол = WallPart.Alpha * 180 / Math.PI;
                        dsLines.tbLineSections.Rows.Add(rws);
                        dsLines.tbLineSections.AcceptChanges();

                    }
                    else
                        if (
                            Wall.LastSection.ID == WallPart.ID && Wall.NextCorner != null &&
                            (Wall.FirstSection.ID != WallPart.ID || Wall.PrevCorner == null))
                        {
                            // только начало
                            Start = WallPart.StartPoint.Pointer.ClearancePointer
                                (Line.ClearanceByWall(Wall));
                        }
                        else
                        {
                            // только конец
                            Finish = WallPart.FinishPoint.Pointer.ClearancePointer
                                (Line.ClearanceByWall(Wall));
                            Delta = new Pointer(
                                (Finish.X - Start.X) * Math.Cos(Start.Phi) +
                                (Finish.Y - Start.Y) * Math.Sin(Start.Phi),
                                -(Finish.X - Start.X) * Math.Sin(Start.Phi) +
                                (Finish.Y - Start.Y) * Math.Cos(Start.Phi),
                                Finish.Phi - Start.Phi);

                            double LR = R * Math.Tan(Math.Abs(Delta.Phi / 2));
                            double L1 = Delta.X - Delta.Y / Math.Tan(Delta.Phi) - LR;
                            double L2 = Delta.Y / Math.Sin(Delta.Phi) - LR;

                            rws = (dsLines.tbLineSectionsRow)
                                dsLines.tbLineSections.NewRow();
                            rws.Код_линии = Line.ID;
                            rws.Номер = ++i;
                            rws.Длина = L1;
                            rws.Угол = 0;
                            dsLines.tbLineSections.Rows.Add(rws);
                            dsLines.tbLineSections.AcceptChanges();

                            rws = (dsLines.tbLineSectionsRow)
                                dsLines.tbLineSections.NewRow();
                            rws.Код_линии = Line.ID;
                            rws.Номер = ++i;
                            rws.Длина = R * Math.Abs(Delta.Phi);
                            rws.Угол = Delta.Phi * 180 / Math.PI;
                            dsLines.tbLineSections.Rows.Add(rws);
                            dsLines.tbLineSections.AcceptChanges();

                            if (
                                Wall.FirstSection.ID == WallPart.ID && Wall.PrevCorner != null &&
                                (Wall.LastSection.ID != WallPart.ID || Wall.NextCorner == null))
                            {
                                rws = (dsLines.tbLineSectionsRow)
                                    dsLines.tbLineSections.NewRow();
                                rws.Код_линии = Line.ID;
                                rws.Номер = ++i;
                                rws.Длина = L2;
                                rws.Угол = 0;
                                dsLines.tbLineSections.Rows.Add(rws);
                                dsLines.tbLineSections.AcceptChanges();
                            }
                            else
                                Start = LineSections.SectionByID(dsLines, rws.Код).FinishPiont.Pointer;
                        }


                }
                foreach (dsLines.tbLineSectionsRow rwls in
                                dsLines.tbLineSections.Select(String.Format
                                ("[Код линии]={0:G} AND [Длина]<0",Line.ID)))
                    rwls.Delete();
                dsLines.tbLineSections.AcceptChanges();

                i=0;
                foreach (dsLines.tbLineSectionsRow rwls in
                                dsLines.tbLineSections.Select(String.Format
                                ("[Код линии]={0:G}", Line.ID), "[Номер] ASC"))
                    rwls.Номер = ++i;
                dsLines.tbStartLine.AcceptChanges();

            }

            // начальние отступы и боковины

            dsLines.tbStartLine.FindByКод(Line.StartId).X = 0;
            dsLines.tbStartLine.FindByКод(Line.StartId).Y = 
                Line.ClearanceByWall((new WallSections.Walls(dsWall)).FirstWall);
            dsLines.tbStartLine.FindByКод(Line.StartId).Phi = 0;

            dsLines.tbLineSections.FindByКод(Line.FirstSection.ID).Длина -= Line.FirstSide.Step;
            dsLines.tbLineSections.AcceptChanges();
            dsLines.tbStartLine.FindByКод(Line.StartId).X += Line.FirstSide.Step;
            dsLines.tbStartLine.AcceptChanges();

            if (Line.FirstSide.IsSide)
            {
                double beta = Math.PI - Line.FirstSide.Alpha;
                double LR = R * Math.Tan(beta / 2);
                double C = Line.ClearanceByWall((new WallSections.Walls(dsWall)).FirstWall);
                if (C < LR * Math.Sin(beta))
                {
                    beta = Math.Acos(1 - C / R);
                    LR = R * Math.Tan(beta / 2);
                }


                if (Math.Abs(C) > 0.001)
                {
                    dsLines.tbLineSections.FindByКод(Line.FirstSection.ID).Длина -=
                        LR + C * Math.Cos(beta) / Math.Sin(beta);
                    dsLines.tbLineSections.AcceptChanges();

                    foreach (dsLines.tbLineSectionsRow rwls in
                       dsLines.tbLineSections.Select("[Код линии]=" + Line.ID.ToString(), "[Номер] ASC"))
                        rwls.Номер += 2;
                    i += 2;

                    rws = (dsLines.tbLineSectionsRow)
                        dsLines.tbLineSections.NewRow();
                    rws.Код_линии = Line.ID;
                    rws.Номер = 2;
                    rws.Длина = R * beta;
                    rws.Угол = -beta * 180 / Math.PI;
                    dsLines.tbLineSections.Rows.Add(rws);
                    dsLines.tbLineSections.AcceptChanges();

                    if (C / Math.Sin(beta) - LR > 0.001)
                    {
                        rws = (dsLines.tbLineSectionsRow)
                            dsLines.tbLineSections.NewRow();
                        rws.Код_линии = Line.ID;
                        rws.Номер = 1;
                        rws.Длина = C / Math.Sin(beta) - LR;
                        rws.Угол = 0;
                        dsLines.tbLineSections.Rows.Add(rws);
                        dsLines.tbLineSections.AcceptChanges();
                    }

                    dsLines.tbStartLine.FindByКод(Line.StartId).Y -=
                        Line.ClearanceByWall((new WallSections.Walls(dsWall)).FirstWall);
                    dsLines.tbStartLine.FindByКод(Line.StartId).Phi += beta * 180 / Math.PI;
                    dsLines.tbStartLine.AcceptChanges();

                    dsLines.tbLineSections.AcceptChanges();
                }
            }

            dsLines.tbLineSections.FindByКод(Line.LastSection.ID).Длина -= Line.LastSide.Step;
            dsLines.tbLineSections.AcceptChanges();

            if (Line.LastSide.IsSide)
            {
                double beta = Math.PI - Line.LastSide.Alpha;
                double C = Line.ClearanceByWall((new WallSections.Walls(dsWall)).LastWall);
                double LR = R * Math.Tan(beta / 2);
                if (C < LR * Math.Sin(beta))
                {
                    beta = Math.Acos(1 - C / R);
                    LR = R * Math.Tan(beta / 2);
                }
                if (Math.Abs(C) > 0.001)
                {
                    dsLines.tbLineSections.FindByКод(Line.LastSection.ID).Длина -= LR + C / Math.Tan(beta);
                    dsLines.tbLineSections.AcceptChanges();

                    rws = (dsLines.tbLineSectionsRow)
                        dsLines.tbLineSections.NewRow();
                    rws.Код_линии = Line.ID;
                    rws.Номер = ++i;
                    rws.Длина = R * beta;
                    rws.Угол = -beta * 180 / Math.PI;
                    dsLines.tbLineSections.Rows.Add(rws);
                    dsLines.tbLineSections.AcceptChanges();

                    if (C / Math.Sin(beta) - LR > 0.001)
                    {
                        rws = (dsLines.tbLineSectionsRow)
                            dsLines.tbLineSections.NewRow();
                        rws.Код_линии = Line.ID;
                        rws.Номер = ++i;
                        rws.Длина = C / Math.Sin(beta) - LR;
                        rws.Угол = 0;
                        dsLines.tbLineSections.Rows.Add(rws);
                        dsLines.tbLineSections.AcceptChanges();
                    }

                }
            }

            i = 0;
            foreach (dsLines.tbLineSectionsRow rwls in
                            dsLines.tbLineSections.Select(String.Format
                            ("[Код линии]={0:G}", Line.ID), "[Номер] ASC"))
                rwls.Номер = ++i;
            dsLines.tbStartLine.AcceptChanges();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (CorniceType == 3)
            {
                foreach (LineSections.Line Line in new LineSections.Lines(dsLines, dsSplints))
                {

                    SplintSections.SplintContourType SplintContourType = SplintSections.SplintContourType.PreCork;
                    foreach (SplintSections.SplintComponent SptintCompontent in Line)
                        SplintContourType = SptintCompontent.FinishType;

                    if (SplintContourType!=SplintSections.SplintContourType.Cork)
                    {
                        MessageBox.Show("Пластиковая шина не полностью нарисована. Такой рисунок нельзя сохранить.",
                            "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }                
            }

            LocalService.ClearCorniceGraphics(OrderId);

            foreach (WallSections.Wall Wall in new WallSections.Walls(dsWall))
            {
                int? WallId = null; // Код
                int? _OrderId = TfMain.OrderId; // Код заказа
                int? Numer = dsWall.tbWall.FindByКод(Wall.ID).Номер; // Номер
                double? Corner = dsWall.tbWall.FindByКод(Wall.ID).Угол; // Угол
                LocalService.EditWallList(ref WallId, ref _OrderId, ref Numer, ref Corner, 1);

                foreach (WallSections.WallPartSection WallPart in Wall)
                {
                    dsWall.tbWallDetailRow rwwd = (dsWall.tbWallDetailRow)
                        dsWall.tbWallDetail.Select("[Код сегмента]=" + WallPart.ID.ToString())[0];
                    int? WallDetailId = null; // Код
                    int? _Numer = rwwd.Номер; // Номер
                    double? Length = rwwd.Длина; // Длина
                    double? Alpha = rwwd.Угол;
                    LocalService.EditWallDetail
                        (ref WallDetailId, ref WallId, ref _Numer, ref Length, ref Alpha, 1);
                }

                foreach (LineSections.Line Line in new LineSections.Lines(dsLines, dsSplints))
                {
                    dsLines.tbClearanceRow rwcl = (dsLines.tbClearanceRow)
                        dsLines.tbClearance.Select(String.Format
                        ("[Код стены]={0:G} AND [Код линии]={1:G}",
                        Wall.ID, Line.ID))[0];
                    int? LineClearanceId = null; // Код
                    int? LineId = Line.ID; // Код линии
                    double? Clearance = rwcl.Отлет; // Отлет
                    LocalService.EditLineClearance
                        (ref LineClearanceId, ref LineId, ref WallId, ref Clearance, 1);
                }

            }

            foreach (LineSections.Line Line in new LineSections.Lines(dsLines, dsSplints))
            {
                int? LineId = Line.ID; // Код линии
                int? StartPositionId = null; // Код
                double? X = Line.Start.X; // X
                double? Y = Line.Start.Y; // Y
                double? Phi = Line.Start.Phi * 180 / Math.PI;
                LocalService.EditLineStartPosition(
                    ref StartPositionId, ref LineId, ref X, ref Y, ref Phi, 1);

                int? Numer;
                if (CorniceType != 3)
                    foreach (LineSections.Section Section in Line)
                    {
                        int? LineSectionId = null; // Код

                        Numer = Section.Numer; // Номер
                        double? Length = Section.Length; // Длина
                        double? Alpha = Section.Alpha * 180 / Math.PI; // Угол
                        LocalService.EditLineSection
                            (ref LineSectionId, ref LineId, ref Numer, ref Length, ref Alpha, 1);
                    }
                else
                {
                    int i = 0;
                    foreach (SplintSections.SplintComponent Compontent in Line)
                    {
                        int? LineSplintId = null;
                        Numer = ++i;
                        int? ComponentId = Compontent.Id;
                        double? Value = Compontent.Value;
                        LocalService.EditLineSplint
                            (ref LineSplintId, ref LineId, ref ComponentId, ref Numer, ref Value, 1);
                    }
                }

                int? SideId = null; // Код
                bool? IsSide = Line.FirstSide.IsSide; // Боковина
                bool? Position = Line.FirstSide.Position; // Положение
                double? Step = Line.FirstSide.Step; // Отступ
                double? Side = Line.FirstSide.Alpha * 180 / Math.PI; // Угол
                double? Radius = 0.1; // Радиус

                LocalService.EditCorniceSide
                    (ref SideId, ref LineId, ref IsSide, ref Position, ref Step, ref Side, ref Radius, 1);

                SideId = null; // Код
                IsSide = Line.LastSide.IsSide; // Боковина
                Position = Line.LastSide.Position; // Положение
                Step = Line.LastSide.Step; // Отступ
                Side = Line.LastSide.Alpha * 180 / Math.PI; // Угол
                Radius = 0.1; // Радиус

                LocalService.EditCorniceSide
                    (ref SideId, ref LineId, ref IsSide, ref Position, ref Step, ref Side, ref Radius, 1);

                int? ViewId = null; // Код
                double? StartX = CurrentView().X; // X
                double? StartY = CurrentView().Y; // Y
                double? Rotate = CurrentView().Phi * 180 / Math.PI; // Поворот
                double? Zoom = CurrentView().Zoom; // Масштаб
                bool? Mirrow = CurrentView().Mirrow; // Отражение
                LocalService.EditCorniceView
                    (ref ViewId, OrderId, ref StartX, ref StartY, ref Rotate, ref Zoom, ref Mirrow, 1);
            }

            foreach (dsWall.tbAgregateRow rwa in dsWall.tbAgregate)
            {
                int? AgregateId = null; // Код
                string AgregateName = rwa.Название; // Название
                double? Base = rwa.Длина_базы; // Длина базы
                double? Height = rwa.Высота_прогиба; // Высота прогиба
                double? Salience = rwa.Выпуклость; // Выпуклость
                bool? IsDown = rwa.Прогиб_вниз; // Прогиб вниз
                int? Approximate = rwa.Тип_апроксимации; // Тип апроксимации
                double? BaseHeight = rwa.Высота_базы; // Высота базы
                double? Interval = rwa.Интервал_измерений; // Интеграл измерений
                bool? IsCenter = rwa.Центрирование; // Центрирование
                int? Part = rwa.Часть_арки;

                LocalService.EditAgregate(ref AgregateId, OrderId, ref AgregateName, ref Base,
                    ref Height, ref Salience, ref IsDown, ref Approximate, ref BaseHeight,
                    ref Interval, ref IsCenter, ref Part, 1);

                foreach (dsWall.tbMeasureRow rwm in
                    dsWall.tbMeasure.Select("[Код агрегата]=" + rwa.Код.ToString()))
                {
                    int? MeasureId = null;
                    double? X = rwm.Координата;
                    double? Y = rwm.Измерение;
                    LocalService.EditMeasure(ref MeasureId, ref AgregateId, ref X, ref Y, 1);
                }
            }


            Bitmap PictureBitmap = new Bitmap(pnWall.Width, pnWall.Height);
            Graphics g = Graphics.FromImage(PictureBitmap);

            g.FillRectangle(new SolidBrush(Color.White), 0, 0, pnWall.Width, pnWall.Height);

            Pen PenGreen = new Pen(Color.Green) 
                { Width = 3, DashStyle = System.Drawing.Drawing2D.DashStyle.Dot };
            Pen PenBlackLine = new Pen(Color.Black) 
                { Width = 1, DashStyle = System.Drawing.Drawing2D.DashStyle.Solid };

            foreach (WallSections.Wall Wall in new WallSections.Walls(dsWall))
                Wall.Draw(g, PenGreen, CurrentView());


            foreach (LineSections.Line Line in new LineSections.Lines(dsLines, dsSplints))
                if (CorniceType != 3)
                    foreach (LineSections.Section Section in Line)
                        Section.Draw(g, PenBlackLine, CurrentView());
                else
                {
                    Pointer Start = Line.Start;
                    foreach (SplintSections.SplintComponent Component in Line)
                    {
                        Component.Draw(g, CurrentView(), Start, PenBlackLine);
                        Start = Component.Finish(Start);
                    }
                }

            DrawZoom(g, CurrentView(), pnWall.Width, pnWall.Height);
            DrawArrow(g, CurrentView(), pnWall.Width, pnWall.Height);

            LocalService.UpadteCorniceInfo(OrderId);
            LocalService.SaveCornicePicture(OrderId, PictureBitmap);
            Close();
        }

        private void tvCurve_DoubleClick(object sender, EventArgs e)
        {
            btSide_Click(null, null);
        }

        private void tvCurve_AfterSelect(object sender, TreeViewEventArgs e)
        {
            pnWall.Invalidate();
        }

        private void btSide_Click(object sender, EventArgs e)
        {
            if (!tbPicture.Enabled)
                return;

            if (CorniceType == 2)
            {
                MessageBox.Show("Карнизы данного типа не поддлежат гнутию.");
                return;
            }

            LineSections.Line Line = null;
            if (tvCurve.SelectedNode == null)
                return;
            if (tvCurve.SelectedNode.Tag is LineSections.Line)
                Line = tvCurve.SelectedNode.Tag as LineSections.Line;
            if (tvCurve.SelectedNode.Tag is LineSections.Section)
                Line = (tvCurve.SelectedNode.Tag as LineSections.Section).Line;
            if (tvCurve.SelectedNode.Tag is SplintSections.SplintComponent)
                Line = (tvCurve.SelectedNode.Tag as SplintSections.SplintComponent).Line;

            if (Line == null)
                return;

            TfEditSide f = new TfEditSide();

            f.cbFirstSide.Checked = Line.FirstSide.IsSide;
            f.cbLastSide.Checked = Line.LastSide.IsSide;

            f.edLastSide.Value = Convert.ToDecimal(Line.LastSide.Alpha * 180 / Math.PI);
            f.edLastStep.Value = Convert.ToDecimal(Line.LastSide.Step);
            f.edFirstSide.Value = Convert.ToDecimal(Line.FirstSide.Alpha * 180 / Math.PI);
            f.edFirstStep.Value = Convert.ToDecimal(Line.FirstSide.Step);

            if (f.ShowDialog() != DialogResult.OK)
                return;

            dsLines.tbSide.FindByКод(Line.FirstSide.ID).Боковина = f.cbFirstSide.Checked;
            dsLines.tbSide.FindByКод(Line.FirstSide.ID).Отступ = Convert.ToDouble(f.edFirstStep.Value);
            dsLines.tbSide.FindByКод(Line.FirstSide.ID).Угол = Convert.ToDouble(f.edFirstSide.Value);

            dsLines.tbSide.FindByКод(Line.LastSide.ID).Боковина = f.cbLastSide.Checked;
            dsLines.tbSide.FindByКод(Line.LastSide.ID).Отступ = Convert.ToDouble(f.edLastStep.Value);
            dsLines.tbSide.FindByКод(Line.LastSide.ID).Угол = Convert.ToDouble(f.edLastSide.Value);

            dsLines.tbSide.AcceptChanges();

            Calulate(Line);

            UpdateTVCurve();
            foreach (TreeNode ndf in tvCurve.Nodes)
                foreach (TreeNode nd in tvCurve.Nodes)
                    if (nd.Tag is LineSections.Line && (nd.Tag as LineSections.Line).ID == Line.ID)
                        tvCurve.SelectedNode = nd;
            tvCurve.Focus();
            pnWall.Invalidate();
        }

        private void edStartX_ValueChanged(object sender, EventArgs e)
        {
            pnWall.Invalidate();
        }

        private RectangleF BorderWall(RectangleF RectangleF, PointF PointF)
        {
            if (PointF.X < RectangleF.Left)
            {
                RectangleF.Width -= PointF.X - RectangleF.X;
                RectangleF.X = PointF.X;
            }
            if (PointF.X > RectangleF.Right)
                RectangleF.Width = PointF.X - RectangleF.X;
            if (PointF.Y < RectangleF.Top)
            {
                RectangleF.Height -= PointF.Y - RectangleF.Y;
                RectangleF.Y = PointF.Y;
            }
            if (PointF.Y > RectangleF.Bottom)
                RectangleF.Height = PointF.Y - RectangleF.Y;
            return RectangleF;

        }

        private void btAutoSize_Click(object sender, EventArgs e)
        {
            if ((new WallSections.Walls(dsWall)).Count == 0)
                return;

            View View = CurrentView();
            WallSections.Walls Walls = new WallSections.Walls(dsWall);

            RectangleF RectangleF = new RectangleF
                (View.TranslateF(Walls.FirstWall.StartPoint.Pointer), new SizeF(0,0));

            foreach (WallSections.Wall Wall in Walls)
                foreach (WallSections.WallPartSection WallPart in Wall)
                {
                    RectangleF = BorderWall(RectangleF, View.TranslateF(WallPart.StartPoint.Pointer));
                    RectangleF = BorderWall(RectangleF, View.TranslateF(WallPart.FinishPoint.Pointer));
                    if (WallPart is WallSections.Arc)
                        RectangleF = BorderWall(RectangleF,View.TranslateF((WallPart as WallSections.Arc).Middle));
                }

            double cx = 0.15;
            double cy = 0.15;

            double kx = 0;
            if (RectangleF.Right - RectangleF.Left > 0.1)
                kx = (RectangleF.Right - RectangleF.Left) / (pnWall.Width * (1 - cx));
            double ky = 0;
            if (RectangleF.Bottom - RectangleF.Top > 0.1)
                ky = (RectangleF.Bottom - RectangleF.Top) / (pnWall.Height * (1 - cy));

            edZoom.Value = 
                Convert.ToDecimal(Math.Min(
                Convert.ToDouble(edZoom.Value) / Math.Max(kx, ky),
                Convert.ToDouble(edZoom.Maximum)));

            View = CurrentView();
            RectangleF = new RectangleF
                (View.TranslateF(Walls.FirstWall.StartPoint.Pointer), new SizeF(0,0));

            foreach (WallSections.Wall Wall in Walls)
                foreach (WallSections.WallPartSection WallPart in Wall)
                {
                    RectangleF = BorderWall(RectangleF, View.TranslateF(WallPart.StartPoint.Pointer));
                    RectangleF = BorderWall(RectangleF, View.TranslateF(WallPart.FinishPoint.Pointer));
                    if (WallPart is WallSections.Arc)
                        RectangleF = BorderWall(RectangleF, View.TranslateF((WallPart as WallSections.Arc).Middle));
                }


            edStartX.Value = Convert.ToDecimal(
                Convert.ToDouble(edStartX.Value) - (RectangleF.Left + RectangleF.Right) / 2 + pnWall.Width / 2);
            edStartY.Value = Convert.ToDecimal(
                Convert.ToDouble(edStartY.Value) - (RectangleF.Bottom + RectangleF.Top) / 2 + pnWall.Height / 2);

            pnWall.Invalidate();
        }

        private void btRLine_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                    "Возврат к линиям автоматически означает что будет потеряна вся имеющаяся графика линий.\n" +
                    "Нажмите ДА для продолжения", "Внимание",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            dsLines.tbSide.Clear();
            dsLines.tbLineSections.Clear();
            dsLines.AcceptChanges();

            tb.Selecting -= tb_Selecting;
            tb.SelectedTab = tsLine;
            tb.Selecting += tb_Selecting;
            tbWallClearanceBindingSource.Position = 0;

            if (CorniceType == 3)
            {
                dsLines.tbWallClearance.Clear();
                dsLines.AcceptChanges();

                tb.Selecting -= tb_Selecting;
                tb.SelectedTab = tsWall;
                tb.Selecting += tb_Selecting;
                int SelectedId = 0;
                UpdateTV(ref SelectedId);
            }
            pnWall.Invalidate();
            
        }

        private void btRWall_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                    "Возврат к стенам автоматически означает что будет потеряна информация об отлетах.\n" +
                    "Нажмите ДА для продолжения", "Внимание",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            dsLines.tbWallClearance.Clear();
            dsLines.AcceptChanges();

            tb.Selecting -= tb_Selecting;
            tb.SelectedTab = tsWall;
            tb.Selecting += tb_Selecting;
            int SelectedId = 0;
            UpdateTV(ref SelectedId);
            pnWall.Invalidate();

        }

        private void btJunk_Click(object sender, EventArgs e)
        {
            if (tvCurve.SelectedNode == null)
                return;
            if (!(tvCurve.SelectedNode.Tag is LineSections.LengthSection))
                return;
            LineSections.LengthSection LengthSection = (LineSections.LengthSection)
                tvCurve.SelectedNode.Tag;

            TfAddJunct f = new TfAddJunct() { Tag = this };
            f.Maximum = LengthSection.Length;
            f.edLeft.Maximum = Convert.ToDecimal(f.Maximum) - f.edLeft.Minimum;
            f.edRight.Maximum = Convert.ToDecimal(f.Maximum) - f.edRight.Minimum;

            f.tb.Value = 50;
            f.tb_Scroll(f.tb, null);


            if (f.ShowDialog() != DialogResult.OK)
                return;

            double k = Convert.ToDouble(f.edLeft.Value) / LengthSection.Length;

            int Numer = LengthSection.Numer;
            int ID = LengthSection.ID;
            int LineId = LengthSection.Line.ID;

            foreach (dsLines.tbLineSectionsRow rwls in dsLines.tbLineSections.Select(String.Format
                ("[Код линии]={0:G} AND [Номер]>{1:G}", LineId, Numer)))
            {
                rwls.Номер += 2;
            }
            dsLines.tbLineSections.AcceptChanges();

            dsLines.tbLineSectionsRow rw = (dsLines.tbLineSectionsRow)
                dsLines.tbLineSections.NewRow();
            rw.Код_линии = LineId;
            rw.Номер = Numer + 2;
            rw.Длина = dsLines.tbLineSections.FindByКод(ID).Длина * (1 - k);
            rw.Угол = dsLines.tbLineSections.FindByКод(ID).Угол * (1 - k);
            dsLines.tbLineSections.Rows.Add(rw);

            dsLines.tbLineSections.FindByКод(ID).Длина = dsLines.tbLineSections.FindByКод(ID).Длина * k;
            dsLines.tbLineSections.FindByКод(ID).Угол = dsLines.tbLineSections.FindByКод(ID).Угол * k;

            rw = (dsLines.tbLineSectionsRow)dsLines.tbLineSections.NewRow();
            rw.Код_линии = LineId;
            rw.Номер = Numer + 1;
            rw.Длина = 0;
            rw.Угол = 0;
            dsLines.tbLineSections.Rows.Add(rw);

            dsLines.tbLineSections.AcceptChanges();

            UpdateTVCurve();

            foreach (TreeNode ndf in tvCurve.Nodes)
                foreach (TreeNode nd in ndf.Nodes)
                    if (nd.Tag is LineSections.JunctSection &&
                        (nd.Tag as LineSections.JunctSection).ID == rw.Код)
                        tvCurve.SelectedNode = nd;

            tvCurve.Focus();

            pnWall.Invalidate();

        }

        private void TfMain_Shown(object sender, EventArgs e)
        {
            if (IsClose)
                Close();
        }

        private void btPlus_Click(object sender, EventArgs e)
        {
            if (!tbPicture.Enabled)
                return;
            LineSections.Line Line = null;
            if (tvCurve.SelectedNode == null)
                return;
            if (tvCurve.SelectedNode.Tag is LineSections.Line)
                Line = tvCurve.SelectedNode.Tag as LineSections.Line;

            if (CorniceType == 3)
            {

                if (tvCurve.SelectedNode.Tag is SplintSections.SplintComponent)
                    Line = (tvCurve.SelectedNode.Tag as SplintSections.SplintComponent).Line;
                
                if (Line == null)
                    return;


                SplintSections.SplintContourType SplintContourType = SplintSections.SplintContourType.PreCork;
                foreach (SplintSections.SplintComponent SptintCompontent in Line)
                    SplintContourType = SptintCompontent.FinishType;

                TfAddSplint f = new TfAddSplint() { Tag = this };
                f.lcb.Enabled = true;
                f.Text = "Новый элемент шины";
                f.StartType = SplintSections.ReverseSplintContourType(SplintContourType);
                f.tbComponentsBindingSource.DataSource = dsSplints;

                if (f.ComponentList() == "")
                {
                    MessageBox.Show("Карниз уже полностью собран или нет нужных деталей!");
                    return;
                }

                string sFilter = String.Format
                    ("[Код профиля]={0:G} AND [Код] IN ({1:G})", Line.ProfileId, f.ComponentList());
                dsSplints.tbComponentsRow[] rcComp = (dsSplints.tbComponentsRow[])
                    dsSplints.tbComponents.Select(sFilter);
                if (rcComp.Length <= 0)
                {
                    MessageBox.Show("Карниз уже полностью собран или нет нужных деталей!");
                    return;
                }
                f.tbComponentsBindingSource.Filter = sFilter;
                f.lcb_SelectedIndexChanged(f.lcb, null);

                if (f.ShowDialog() != DialogResult.OK)
                    return;

                dsLines.tbSplintSectionsRow rws = (dsLines.tbSplintSectionsRow)
                    dsLines.tbSplintSections.NewRow();
                rws.Код_компоненты = Convert.ToInt32(f.lcb.SelectedValue);
                rws.Код_линии = Line.ID;
                rws.Номер = Line.Count + 1;
                rws.Значение = Convert.ToDouble(f.edValue.Value);

                dsLines.tbSplintSections.Rows.Add(rws);
                dsLines.tbSplintSections.AcceptChanges();

                UpdateTVCurve();

                foreach (TreeNode ndf in tvCurve.Nodes)
                    foreach (TreeNode nd in ndf.Nodes)
                        if (nd.Tag is SplintSections.SplintComponent &&
                            (nd.Tag as SplintSections.SplintComponent).Numer == rws.Номер)
                            tvCurve.SelectedNode = nd;

                tvCurve.Focus();
                pnWall.Invalidate();
            }
            else
            {

            }
        }

        private void btMinus_Click(object sender, EventArgs e)
        {
            if (!tbPicture.Enabled)
                return;
            LineSections.Line Line = null;
            if (tvCurve.SelectedNode == null)
                return;
            if (tvCurve.SelectedNode.Tag is LineSections.Line)
                Line = tvCurve.SelectedNode.Tag as LineSections.Line;

            if (CorniceType == 3)
            {

                if (tvCurve.SelectedNode.Tag is SplintSections.SplintComponent)
                    Line = (tvCurve.SelectedNode.Tag as SplintSections.SplintComponent).Line;

                if (Line == null)
                    return;
                if (Line.Count <= 0)
                    return;
                SplintSections.SplintComponent Compontent = null;
                foreach (SplintSections.SplintComponent SplintCompontent in Line)
                    Compontent = SplintCompontent;

                if (MessageBox.Show(
                        "Сейчас будет удален элемент №"+Compontent.Numer.ToString()+".\n" +
                        "Нажмите ДА для продолжения", "Внимание",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) != DialogResult.Yes)
                    return;
                dsLines.tbSplintSections.Select("[Код линии]=" + Line.ID.ToString(), "[Номер] DESC")[0].Delete();
                dsLines.tbSplintSections.AcceptChanges();

                UpdateTVCurve();
                foreach (TreeNode ndf in tvCurve.Nodes)
                    if ((ndf.Tag is LineSections.Line) &&
                            (ndf.Tag as LineSections.Line).ID == Line.ID)
                        tvCurve.SelectedNode = ndf;
                tvCurve.Focus();
                pnWall.Invalidate();



            }

        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (!tbPicture.Enabled)
                return;

            if (tvCurve.SelectedNode == null)
                return;

            if (CorniceType == 3)
            {
                if (!(tvCurve.SelectedNode.Tag is SplintSections.SplintComponent))
                    return;

                SplintSections.SplintComponent Component =
                    (tvCurve.SelectedNode.Tag as SplintSections.SplintComponent);

                TfAddSplint f = new TfAddSplint() { Tag = this };
                f.lcb.Enabled = false;
                f.Text = "Редактирование элемента шины";
                f.StartType = Component.StartType;
                f.tbComponentsBindingSource.DataSource = dsSplints;
                f.tbComponentsBindingSource.Filter = "[Код]=" + Component.Id.ToString();
                f.lcb_SelectedIndexChanged(f.lcb, null);
                f.edValue.Value = Convert.ToDecimal(Component.Value);

                if (f.ShowDialog() != DialogResult.OK)
                    return;

                dsLines.tbSplintSectionsRow rws = (dsLines.tbSplintSectionsRow)
                    dsLines.tbSplintSections.Select("[Номер]=" + Component.Numer.ToString() +
                        " AND [Код линии]=" + Component.Line.ID.ToString())[0];
                rws.Значение = Convert.ToDouble(f.edValue.Value);

                dsLines.tbSplintSections.AcceptChanges();
                
                UpdateTVCurve();

                foreach (TreeNode ndf in tvCurve.Nodes)
                    foreach (TreeNode nd in ndf.Nodes)
                        if (nd.Tag is SplintSections.SplintComponent &&
                            (nd.Tag as SplintSections.SplintComponent).Numer == Component.Numer)
                            tvCurve.SelectedNode = nd;

                tvCurve.Focus();
                pnWall.Invalidate();
            }
            else
            {

            }

        }

        private void pnWall_MouseMove(object sender, MouseEventArgs e)
        {
            lbC.Text = String.Format("({0:N3}  {1:N3})",
                (e.X - CurrentView().X) / CurrentView().Zoom,
                (e.Y - CurrentView().Y) / CurrentView().Zoom);
        }




    }
}
