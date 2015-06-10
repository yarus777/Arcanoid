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
        private Vector2 _blockSize;

        private readonly Dictionary<BlockType, Texture> _textures;
        private readonly Texture _selectedTexture;
        private BlockInfo _selected;

        public FieldPanel(float width, float height, Vector2 blockSize, Dictionary<BlockType, Texture> textures) {
            _width = width;
            _height = height;
            _blockSize = blockSize;
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
                GUI.DrawTexture(new Rect(block.X * _blockSize.x, block.Y * _blockSize.y, _blockSize.x, _blockSize.y), _textures[block.Type]);
            }
            if (_selected != null) {
                GUI.DrawTexture(new Rect(_selected.X * _blockSize.x, _selected.Y * _blockSize.y, _blockSize.x, _blockSize.y), _selectedTexture);
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
                        if (e.button == 0) {
                            OnMouseUp(e.mousePosition);
                        }
                        else if (e.button == 2) {
                            OnMiddleUp(e.mousePosition);
                        }
                        break;
                }
            }
        }

        #region Input event handlers

        private Vector2 _capturedOffset;

        private void OnMouseDown(Vector2 position) {
            foreach (var block in _blocks) {
                var dx = position.x - block.X * _blockSize.x;
                var dy = position.y - block.Y * _blockSize.y;
                if (dx < _blockSize.x && dy < _blockSize.y && dx >= 0 && dy >= 0) {
                    _selected = block;
                    _capturedOffset = new Vector2(dx, dy);
                    return;
                }
            }
            _selected = null;
        }

        private void OnMouseDrag(Vector2 position) {
            if (_selected == null) {
                return;
            }
            var pos = SnapToGrid(position - _capturedOffset);
            _selected.X = (int)pos.x;
            _selected.Y = (int)pos.y;
        }

        private void OnMouseUp(Vector2 position) {
            _capturedOffset = Vector2.zero;
        }

        private void OnMiddleUp(Vector2 position) {
            _blocks.Remove(_selected);
            _selected = null;
        }

        #endregion

        #region Snapping
        private Vector2 SnapToGrid(Vector2 pos) {
            return new Vector2((int)(pos.x / _blockSize.x), (int)(pos.y / _blockSize.y));
        }

        #endregion
    }
}
