using Assets.Scripts.Serialization.Levels;
using System.Collections.Generic;

namespace Assets.Scripts.Game.Blocks.Creators {
    class RestoringBlockCreator : BlockCreator {
        private readonly IEnumerable<BlockInfo> _blocks; 

        public RestoringBlockCreator(IEnumerable<BlockInfo> blocks) {
            _blocks = blocks;
        }

        public override IEnumerable<BlockInfo> BlocksInfo {
            get {
                return _blocks;
            }
        }
    }
}
