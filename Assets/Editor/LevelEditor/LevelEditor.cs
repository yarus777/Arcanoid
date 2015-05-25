using UnityEditor;

using UnityEngine;

namespace Assets.Editor.LevelEditor {
    partial class LevelEditor : EditorWindow {
        [MenuItem("Arcanoid/Level Editor")]
        public static void Init() {
            GetWindow<LevelEditor>().title = "Level Editor";
        }

        #region Textures

        private Texture _fieldTexture;

        #endregion

        private void Load() {
            _fieldTexture = Resources.LoadAssetAtPath<Texture>(Consts.FIELD_TEXTURE_PATH);

            _loaded = true;
        }
    }
}
