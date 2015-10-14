using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using CorniceGraph.Datasets;

namespace CorniceGraph.Logic.Wall
{
    public class Walls : IEnumerable<Wall>
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

        IEnumerator<Wall> IEnumerable<Wall>.GetEnumerator()
        {
            return new WallEnumerator(dsWall);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (this as IEnumerable<Wall>).GetEnumerator();
        }

        #endregion

        private class WallEnumerator : IEnumerator<Wall>
        {
            private int Index;
            private dsWall dsWall;

            public WallEnumerator(dsWall dsWall)
            {
                this.dsWall = dsWall;
                Reset();
            }
            #region IEnumerator Members

            public Wall Current
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

            object IEnumerator.Current => Current;

            #endregion

            public void Dispose()
            {
            }
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
}
