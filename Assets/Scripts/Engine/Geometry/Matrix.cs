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

        private int _width;
        private int _height;

        public Matrix(int x, int y) {
            _width = x;
            _height = y;
        }

        public virtual IEnumerable<CellCoords> Get(int count) {
            int currentCount = 0;
            for (var i = 0; i < _height; i++) {
                for (var j = 0; j < _width; j++) {

                }
            }
        }
    }
}
