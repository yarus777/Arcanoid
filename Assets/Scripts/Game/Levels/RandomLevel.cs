using Assets.Scripts.Game.Blocks.Creators;
using Assets.Scripts.Serialization.Levels;

namespace Assets.Scripts.Game.Levels {
    class RandomLevel : Level {
        private Hardness.Hardness _hardness;

        public RandomLevel(Hardness.Hardness hardness) {
            _hardness = hardness;
        }

        public override void Init(LevelInfo level) {
            Blocks =  new RandomBlockCreator(10, 5, 4).BlocksInfo;
        }
    }
}
