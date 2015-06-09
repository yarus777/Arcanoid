using Assets.Scripts.Game.Blocks.Creators;
using Assets.Scripts.Game.Consts;

namespace Assets.Scripts.Game.Levels {
    class RandomLevel : Level {
        private Hardness.Hardness _hardness;

        public RandomLevel(Hardness.Hardness hardness)
            : base(null) {
            _hardness = hardness;
        }

        public override BlockCreator BlockCreator {
            get {
                return new RandomBlockCreator(10, GameConsts.BLOCK_SIZE.x, GameConsts.BLOCK_SIZE.y, 5, 4);
            }
        }
    }
}
