using System;
using System.Collections.Generic;
using System.Linq;

using Random = UnityEngine.Random;

namespace Assets.Scripts.Engine.Geometry {
    class RandomMatrix : Matrix {
        public RandomMatrix(int x, int y)
            : base(x, y) {
        }

        public override IEnumerable<CellCoords> Get(int count) {
            var list = new List<CellCoords>();
            while (list.Count < count) {
                list.Add(GetRandom(list));
            }
            return list;
        }

        private CellCoords GetRandom(IList<CellCoords> existing) {
            var index = Random.Range(0, Width * Height - existing.Count);
            for (var i = _xBegin; i < _xBegin + Width; i++) {
                for (var j = _yBegin; j < _yBegin + Height; j++) {
                    if (existing.Any(coord => coord.X == i && coord.Y == j)) {
                        continue;
                    }
                    if (index == 0) {
                        return new CellCoords(i, j);
                    }
                    index--;
                }
            }
            throw new ArgumentOutOfRangeException("count");
        }
    }
}
