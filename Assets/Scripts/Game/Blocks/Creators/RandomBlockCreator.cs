using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Engine.Geometry;
using Assets.Scripts.Game.Blocks.Data;

namespace Assets.Scripts.Game.Blocks.Creators {
    class RandomBlockCreator : BlockCreator {
        private readonly IEnumerable<BlockInfo> _info; 

        public RandomBlockCreator(int count, float blockWidth, float blockHeight, int maxRow, int maxCol) {
            var matrix = new RandomMatrix(maxRow, maxCol);
            _info = matrix.Get(count).Select(x => new BlockInfo(x.X, x.Y, blockWidth, blockHeight));
        }

        public override IEnumerable<BlockInfo> BlocksInfo {
            get { return _info; }
        }
    }
}
