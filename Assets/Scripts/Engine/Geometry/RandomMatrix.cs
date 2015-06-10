using System;
using System.Collections.Generic;
using System.Linq;

using Random = UnityEngine.Random;

namespace Assets.Scripts.Engine.Geometry {
    class RandomMatrix : Matrix {
        public RandomMatrix(int x, int y, int count)
            : base(x, y) {
            SetCells(Get(count));
        }

        private IEnumerable<ITransponable> Get(int count) {
            var list = new List<ITransponable>();
            while (list.Count < count) {
                var elem = GetRandom(list);
                if (elem == null) {
                    throw new ArgumentOutOfRangeException("count");
                }
                list.Add(elem);
            }
            return list;
        }

        private CellCoords GetRandom(IList<ITransponable> existing) {
            var index = Random.Range(0, Width * Height - existing.Count);
            for (var i = 0; i < Width; i++) {
                for (var j = 0; j < Height; j++) {
                    if (existing.Any(coord => coord.X == i && coord.Y == j)) {
                        continue;
                    }
                    if (index == 0) {
                        return new CellCoords(i, j);
                    }
                    index--;
                }
            }
            return null;
        }
    }
}
