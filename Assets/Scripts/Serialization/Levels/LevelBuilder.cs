using Assets.Scripts.Game.Levels;

namespace Assets.Scripts.Serialization.Levels {
    class LevelBuilder {
        public static Level Restore(LevelInfo level) {
            return new Level(level.Blocks);
        }
    }
}
