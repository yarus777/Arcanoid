using Assets.Scripts.Game.Levels;

namespace Assets.Scripts.Serialization.Levels {
    class LevelBuilder {
        public static Level Restore(LevelInfo level) {
            var lvl = new Level();
            lvl.Init(level.Blocks);
            return lvl;
        }
    }
}
