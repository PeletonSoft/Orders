using System.Collections;
using CorniceGraph.Datasets;

namespace CorniceGraph.Logic.Line
{
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
                    return new Logic.Line.Line(dsLines, dsSplints, rw.Код);
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


}
