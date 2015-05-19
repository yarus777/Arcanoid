using System.Collections.Generic;

namespace Assets.Scripts.Engine.Geometry {
    class Matrix {
        public class CellCoords {
            public int X { get; private set; }
            public int Y { get; private set; }

            public CellCoords(int x, int y) {
                X = x;
                Y = y;
            }

        }

        public int Width { get; private set; }
        public int Height { get; private set; }

        public Matrix(int x, int y) {
            Width = x;
            Height = y;
        }

        public virtual IEnumerable<CellCoords> Get(int count) {
            var currentCount = 0;
            for (var i = 0; i < Height; i++) {
                for (var j = 0; j < Width; j++) {
                    if (currentCount++ == count) {
                        yield break;
                    }
                    yield return new CellCoords(i, j);
                }
            }
        }
    }
}
