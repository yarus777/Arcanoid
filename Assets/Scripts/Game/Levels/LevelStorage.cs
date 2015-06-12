using System.Collections.Generic;
using System.Linq;

using Assets.Scripts.Engine.Loading;

namespace Assets.Scripts.Game.Levels {
    class LevelStorage {
        private readonly List<Level> _levels;

        private int _currentLevel;
        public Level CurrentLevel {
            get {
                return this[_currentLevel];
            }
        }

        public LevelStorage() {
            _levels = LoadingController.Instance.LevelLoader.Load();
        }

        public Level this[int number] {
            get {
                var lvl = _levels.FirstOrDefault(level => level.Number == number);
                if (lvl == null) {
                    var randomLevel = new RandomLevel(new Hardness.Hardness());
                    randomLevel.Init(null);
                    return randomLevel;
                }
                return lvl;
            }
        }

        public void SetCurrentLevel(int levelNumber) {
            _currentLevel = levelNumber;
        }
    }
}
