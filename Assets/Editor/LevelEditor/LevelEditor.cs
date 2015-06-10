using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Assets.Editor.LevelEditor.Panels;
using Assets.Scripts.Engine.Exceptions;
using Assets.Scripts.Game.Consts;
using Assets.Scripts.Serialization;
using Assets.Scripts.Serialization.Levels;

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
        private Dictionary<BlockType, Texture> _blockTextures;

        #endregion

        #region Drawing

        private Tabs.Tabs _tabs;
        private LevelInfo _level;

        private LevelInfo Level {
            get {
                return _level;
            }
            set {
                _level = value;
                OnLevelLoaded();
            }
        }

        private string _loadedFilename;
        private FieldPanel _field;
        private BlockTab _blockTab;
        private TaskTab _taskTab;

        #endregion

        protected override void Load() {
            _fieldTexture = Resources.LoadAssetAtPath<Texture>(Consts.FIELD_TEXTURE_PATH);
            var types = Enum.GetValues(typeof(BlockType)).Cast<BlockType>();
            _blockTextures = types.ToDictionary(
                type => type,
                type => (Texture)AssetDatabase.LoadAssetAtPath(Consts.BLOCKS_TEXTURES_PATH + type + ".png", typeof(Texture))
            );

            _taskTab = new TaskTab();
            _blockTab = new BlockTab(_blockTextures);
            _tabs = new Tabs.Tabs(_blockTab, _taskTab);
            _field = new FieldPanel(Consts.FIELD_WIDTH, Consts.FIELD_HEIGHT, new Vector2(Consts.BLOCK_WIDTH, Consts.BLOCK_HEIGHT), _blockTextures);

            Level = new LevelInfo();
        }

        private void LoadLevel() {
            var filename = EditorUtility.OpenFilePanel("Open level", Path.Combine(ROOT_PATH, Consts.LEVELS_PATH), "xml");
            if (string.IsNullOrEmpty(filename)) {
                return;
            }
            try {
                _loadedFilename = filename.Replace(ROOT_PATH, "");
                _loadedFilename = _loadedFilename.Replace(".xml", "");
                Level = Serializer.Deserialize<LevelInfo>(_loadedFilename);
            }
            catch (NotSavedException e) {
                EditorUtility.DisplayDialog("Error", "Wrong data format", "OK");
            }
        }

        protected override void Save() {
            if (string.IsNullOrEmpty(_loadedFilename)) {
                var filename = EditorUtility.SaveFilePanel("Save as", Path.Combine(ROOT_PATH, Consts.LEVELS_PATH), "0", "xml");
                if (string.IsNullOrEmpty(filename)) {
                    return;
                }
                _loadedFilename = filename.Replace(ROOT_PATH, "");
                _loadedFilename = _loadedFilename.Replace(".xml", "");
            }
            Serializer.Serialize(_loadedFilename, Level);
        }

        private void OnLevelLoaded() {
            _field.Init(Level.Blocks);
            _blockTab.Init(Level.Blocks);
        }
    }
}
