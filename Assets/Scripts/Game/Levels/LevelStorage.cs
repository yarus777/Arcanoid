using System.Collections.Generic;

namespace Assets.Scripts.Game.Levels {
    class LevelStorage {
        private readonly List<Level> _levels;

        public LevelStorage() {
            _levels = new List<Level>();    
            _levels.Add(new Level());
        }

        public Level this[int number] {
            get {
                return _levels[number];
            }
        }
    }
}
