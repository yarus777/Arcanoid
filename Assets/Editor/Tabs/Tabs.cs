using System.Linq;

using UnityEngine;

namespace Assets.Editor.Tabs {
    class Tabs {
        private readonly Tab[] _tabs;
        private readonly string[] _captions;

        private int _selected;

        public Tabs(params Tab[] tabs) {
            _tabs = tabs;
            _captions = tabs.Select(tab => tab.Title).ToArray();
        }

        public void Draw() {
            GUILayout.BeginVertical();
            {
                _selected = GUILayout.Toolbar(_selected, _captions);
                _tabs[_selected].Draw();
            }
            GUILayout.EndVertical();
        }
    }
}
