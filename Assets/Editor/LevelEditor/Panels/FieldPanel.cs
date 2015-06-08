using System.Collections.Generic;

using Assets.Scripts.Serialization;
using Assets.Scripts.Serialization.Levels;

using UnityEditor;

using UnityEngine;

namespace Assets.Editor.LevelEditor.Panels {
    class FieldPanel {
        private List<BlockInfo> _blocks;
        private float _width;
        private float _height;

        private readonly Dictionary<BlockType, Texture> _textures;
        private readonly Texture _selectedTexture;
        private BlockInfo _selected;

        public FieldPanel(float width, float height, Dictionary<BlockType, Texture> textures) {
            _width = width;
            _height = height;
            _textures = textures;
            _selectedTexture = (Texture)AssetDatabase.LoadAssetAtPath(Consts.SELECTED_BLOCK_PATH, typeof(Texture));
        }

        public void Init(List<BlockInfo> blocks) {
            _blocks = blocks;
        }

        public void Draw() {
            if (_blocks == null) {
                return;
            }
            foreach (var block in _blocks) {
                GUI.DrawTexture(new Rect(block.Position.x, block.Position.y, block.Size.x, block.Size.y), _textures[block.Type]);
            }
            if (_selected != null) {
                GUI.DrawTexture(new Rect(_selected.Position.x, _selected.Position.y, _selected.Size.x, _selected.Size.y), _selectedTexture);
            }
            CheckInput();
        }

        private void CheckInput() {
            var e = Event.current;
            if (e.isMouse) {
                switch (e.type) {
                    case EventType.MouseDown:
                        OnMouseDown(e.mousePosition);
                        break;
                    case EventType.MouseDrag:
                        OnMouseDrag(e.mousePosition);
                        break;
                    case EventType.MouseUp:
                        OnMouseUp(e.mousePosition);
                        break;
                }
            }
        }

        #region Input event handlers

        private Vector2 _capturedOffset;

        private void OnMouseDown(Vector2 position) {
            foreach (var block in _blocks) {
                var delta = position - block.Position;
                if (delta.x < block.Size.x && delta.y < block.Size.y) {
                    _selected = block;
                    _capturedOffset = delta;
                    return;
                }
            }
            _selected = null;
        }

        private void OnMouseDrag(Vector2 position) {
            if (_selected == null) {
                return;
            }
            _selected.Position = position - _capturedOffset;
        }

        private void OnMouseUp(Vector2 position) {
            _capturedOffset = Vector2.zero;
        }

        #endregion
    }
}
