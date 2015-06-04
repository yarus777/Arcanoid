using UnityEditor;

using UnityEngine;

namespace Assets.Editor.LevelEditor {
    partial class LevelEditor : BaseEditor {
        [MenuItem("Arcanoid/Level Editor")]
        public static void Init() {
            GetWindow<LevelEditor>().title = "Level Editor";
        }

        #region Textures

        private Texture _fieldTexture;

        #endregion

        protected override void Load() {
            _fieldTexture = Resources.LoadAssetAtPath<Texture>(Consts.FIELD_TEXTURE_PATH);

            _loaded = true;
        }

        protected override void Save() {
            throw new System.NotImplementedException();
        }
    }
}
