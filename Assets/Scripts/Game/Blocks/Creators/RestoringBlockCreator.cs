using System.Collections.Generic;
using System.Linq;

using Assets.Scripts.Engine.Geometry;
using Assets.Scripts.Game.Consts;
using Assets.Scripts.Serialization.Levels;

namespace Assets.Scripts.Game.Blocks.Creators {
    class RestoringBlockCreator : BlockCreator {
        private readonly IEnumerable<BlockInfo> _blocks; 

        public RestoringBlockCreator(IEnumerable<BlockInfo> blocks) {
            var matrix = new Matrix(GameConsts.FIELD_WIDTH, GameConsts.FIELD_HEIGHT);
            matrix.SetCells(blocks.Cast<ITransponable>());
            _blocks = matrix.Normalize().Cast<BlockInfo>();
        }

        public override IEnumerable<BlockInfo> BlocksInfo {
            get {
                return _blocks;
            }
        }
    }
}
