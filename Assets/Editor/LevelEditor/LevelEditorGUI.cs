using UnityEngine;

namespace Assets.Editor.LevelEditor {
    partial class LevelEditor {
        protected override void OnGUI() {
            base.OnGUI();
            DrawField();
            GUILayout.BeginHorizontal();
            {
                GUILayout.BeginVertical(GUILayout.Width(Consts.FIELD_WIDTH));
                {
                    //GUILayout.Space(Consts.FIELD_HEIGHT);
                    GUILayout.BeginVertical(GUILayout.Height(Consts.FIELD_HEIGHT), GUILayout.ExpandHeight(true));
                    {
                        _field.Draw();
                    }
                    GUILayout.EndVertical();
                    DrawSaveLoadPanel();
                }
                GUILayout.EndVertical();
                DrawProperties();
            }
            GUILayout.EndHorizontal();
            Repaint();
        }

        private void DrawField() {
            GUI.DrawTexture(new Rect(0, 0, Consts.FIELD_WIDTH, Consts.FIELD_HEIGHT), _fieldTexture);
        }

        private void DrawSaveLoadPanel() {
            if (GUILayout.Button("New")) {
                
            }
            if (GUILayout.Button("Open")) {
                LoadLevel();
            }
            if (GUILayout.Button("Save")) {
                Save();
            }
        }

        private void DrawProperties() {
            _tabs.Draw();
        }
    }
}
