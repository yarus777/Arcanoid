using UnityEngine;

namespace Assets.Scripts.Engine.Loading {
    class SceneLoader {
        private int _currentScene = 0;

        public string CurrentScene {
            get {
                return LevelOrder.Scenes[_currentScene];
            }
        }

        public bool ToNextScene() {
            if (LevelOrder.Scenes.ContainsKey(_currentScene + 1)) {
                _currentScene++;
                ToScene(CurrentScene);
                return true;
            }
            return false;
        }

        public bool ToPreviousScene() {
            if (LevelOrder.Scenes.ContainsKey(_currentScene - 1)) {
                _currentScene--;
                ToScene(CurrentScene);
                return true;
            }
            return false;
        }

        public void ToScene(string name) {
            Application.LoadLevel(name);
        }
    }
}
