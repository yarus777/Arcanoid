using UnityEditor;

using UnityEngine;

namespace Assets.Editor.ParametersEditor {
    partial class ParametersEditor {
        protected override void OnGUI() {
            base.OnGUI();
            GUILayout.BeginVertical();
            {
                DrawParameter("Default lives", ref _parms.LivesCount);
            }
            GUILayout.EndVertical();
        }

        private void DrawParameter(string label, ref int value) {
            value = EditorGUILayout.IntField(label, value);
        }
    }
}
