﻿using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using CorniceGraph.Datasets;
using CorniceGraph.Logic.Line;

namespace CorniceGraph.Logic.Splint
{
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

        public void Draw(Graphics Graphics, CanvasView View, Pointer Start, Pen Pen)
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

        public Line.Line Line
        {
            get
            {
                return new Line.Line(dsLines, dsSplints, LineId);
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

        public RectangleF Border(CanvasView View, Pointer Start)
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
                    double phi = (rw.Угол) * Math.PI / 180;
                    if (Math.Abs(alpha) > 0.0001)
                        return new SplintArcContour(l, alpha, phi, (SplintContourType)rw.Тип);
                    return new SplintLineContour(l, phi, (SplintContourType)rw.Тип);
                }
            }

            #endregion
        }
    }
}