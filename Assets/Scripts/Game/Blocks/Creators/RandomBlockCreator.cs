using System.Collections.Generic;
using System.Linq;

using Assets.Scripts.Engine.Geometry;
using Assets.Scripts.Serialization.Levels;

namespace Assets.Scripts.Game.Blocks.Creators {
    class RandomBlockCreator : BlockCreator {
        private readonly IEnumerable<BlockInfo> _info; 

        public RandomBlockCreator(int count, int maxRow, int maxCol) {
            var matrix = new RandomMatrix(maxRow, maxCol, count);
            _info = matrix.Normalize().Select(x => new BlockInfo { X = x.X, Y = x.Y });
        }

        public override IEnumerable<BlockInfo> BlocksInfo {
            get { return _info; }
        }
    }
}
