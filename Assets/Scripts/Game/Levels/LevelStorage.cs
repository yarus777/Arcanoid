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

            //_levels = new List<Level>();    
            //_levels.Add(new Level());
        }

        public Level this[int number] {
            get {
                var lvl = _levels.FirstOrDefault(level => level.Number == number);
                if (lvl == null) {
                    return new RandomLevel(new Hardness.Hardness());
                }
                return lvl;
            }
        }
    }
}
