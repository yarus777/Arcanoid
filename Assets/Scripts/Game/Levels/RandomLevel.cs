using Assets.Scripts.Game.Blocks.Creators;

namespace Assets.Scripts.Game.Levels {
    class RandomLevel : Level {
        private Hardness.Hardness _hardness;

        public RandomLevel(Hardness.Hardness hardness)
            : base(null) {
            _hardness = hardness;
        }

        public override BlockCreator BlockCreator {
            get {
                return new RandomBlockCreator(10, 5, 4);
            }
        }
    }
}
