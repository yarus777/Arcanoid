using System.Collections.Generic;

using Assets.Scripts.Game.Blocks.Creators;
using Assets.Scripts.Serialization.Levels;

namespace Assets.Scripts.Game.Levels {
    class RandomLevel : Level {
        private Hardness.Hardness _hardness;

        public RandomLevel(Hardness.Hardness hardness) {
            _hardness = hardness;
        }

        public override void Init(IEnumerable<BlockInfo> blocks) {
            Blocks =  new RandomBlockCreator(10, 5, 4).BlocksInfo;
        }
    }
}
