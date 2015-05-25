using UnityEngine;

namespace Assets.Editor.LevelEditor {
    partial class LevelEditor {
        private bool _loaded;
        private void OnGUI() {
            if (!_loaded) {
                Load();
            }
            DrawField();
            GUILayout.BeginHorizontal();
            {
                GUILayout.BeginVertical(GUILayout.Width(Consts.FIELD_WIDTH));
                {
                    GUILayout.Space(Consts.FIELD_HEIGHT);
                    DrawSaveLoadPanel();
                }
                GUILayout.EndVertical();
                DrawProperties();
            }
            GUILayout.EndHorizontal();
        }

        private void DrawField() {
            GUI.DrawTexture(new Rect(0, 0, Consts.FIELD_WIDTH, Consts.FIELD_HEIGHT), _fieldTexture);
        }

        private void DrawSaveLoadPanel() {
            if (GUILayout.Button("New")) {
                
            }
            if (GUILayout.Button("Open")) {

            }
            if (GUILayout.Button("Save")) {

            }
        }

        private void DrawProperties() {
            DrawBlocks();
        }

        private void DrawBlocks() {
            
        }
    }
}
