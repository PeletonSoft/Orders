using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using CorniceGraph.Datasets;
using CorniceGraph.Logic.Splint;

namespace CorniceGraph.Logic.Line
{
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
                return String.Format("Линия-{0:G}", Numer);
            }

        }

        public string FullName
        {
            get
            {
                if (TfMain.CorniceType != 3)
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
            return new Enumerator(dsLines, dsSplints, LineId);
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
                int C = 0;
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
                if (TfMain.CorniceType != 3)
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
        public double ClearanceByWall(Wall.Wall Wall)
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
                    if (TfMain.CorniceType != 3)
                    {
                        DataRow[] rc = dsLines.tbLineSections.Select
                            ("[Код линии]=" + LineId.ToString(), "[Номер] ASC");
                        return LineSections.SectionByID(dsLines, (rc[Index] as dsLines.tbLineSectionsRow).Код);
                    }

                    DataRow[] rcSplint = dsLines.tbSplintSections.Select
                        ("[Код линии]=" + LineId.ToString(), "[Номер] ASC");
                    SplintContourType StartType = SplintContourType.PreCork;
                    SplintComponent SptintCompontent = null;
                    for (int i = 0; i <= Index; i++)
                    {
                        StartType = SplintSections.ReverseSplintContourType(StartType);
                        dsLines.tbSplintSectionsRow rw = (dsLines.tbSplintSectionsRow)rcSplint[i];
                        SptintCompontent = new SplintComponent
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
                if (TfMain.CorniceType != 3)
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
}
