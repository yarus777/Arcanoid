using System.Collections.Generic;

using Assets.Scripts.Game.Blocks.Data;

namespace Assets.Scripts.Game.Blocks.Creators {
    class RandomBlockCreator : BlockCreator {
        public RandomBlockCreator(int count, float blockWidth, float blockHeight, int maxRow, int maxCol) {
            
        }

        public override IEnumerable<BlockInfo> BlocksInfo {
            get {
                throw new System.NotImplementedException();
            }
        }
    }
}
