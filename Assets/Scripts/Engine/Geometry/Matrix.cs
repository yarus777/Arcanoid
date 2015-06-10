using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Engine.Geometry {
    class Matrix : IEnumerable<ITransponable> {
        public int Width { get; private set; }
        public int Height { get; private set; }

        private IEnumerable<ITransponable> _cells;  

        public Matrix(int x, int y) {
            Width = x;
            Height = y;
        }

        public void SetCells(IEnumerable<ITransponable> cells) {
            _cells = cells;
        }

        public Matrix Normalize() {
            if (_cells != null) {
                foreach (var cell in _cells) {
                    cell.Transpone(-Width / 2, -Height / 2);
                }
            }
            return this;
        }


        #region IEnumerable

        public virtual IEnumerator<ITransponable> GetEnumerator() {
            return _cells.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

        public class CellCoords : ITransponable {
            public int X { get; private set; }
            public int Y { get; private set; }

            public CellCoords(int x, int y) {
                X = x;
                Y = y;
            }

            public void Transpone(int byX, int byY) {
                X += byX;
                Y += byY;
            }
        }
    }
}
