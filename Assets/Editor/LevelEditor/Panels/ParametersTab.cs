using Assets.Editor.Tabs;
using Assets.Scripts.Serialization.Levels;

using UnityEditor;

namespace Assets.Editor.LevelEditor.Panels {
    class ParametersTab : Tab {
        public ParametersTab()
            : base("Parameters") {
        }

        private LevelInfo _level;
        public void Init(LevelInfo level) {
            _level = level;
        }

        public override void Draw() {
            _level.Number = EditorGUILayout.IntField("Level number", _level.Number);
        }
    }
}
