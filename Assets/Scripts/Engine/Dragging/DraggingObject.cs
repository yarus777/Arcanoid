using System.Linq;
using Assets.Scripts.Game.Consts;

using UnityEngine;

namespace Assets.Scripts.Engine.Dragging {
    abstract class DraggingObject : MonoBehaviour {
        protected abstract GameConsts.Direction[] Directions { get; }

        private RectTransform _transform;
        private Camera _camera;

        private void Start() {
            _transform = transform as RectTransform;
            _camera = Camera.main;
        }

        private Vector2 _pointerOffset;

        public void OnDown() {
            var clickPosition = _camera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
            _pointerOffset = clickPosition - _transform.position;
        }

        public void OnDrag() {
            Vector2 pos = _camera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
            MoveTo(pos);
        }

        private void MoveTo(Vector2 position) {
            var x = _transform.anchoredPosition.x;
            var y = _transform.anchoredPosition.y;
            if (Directions.Any(dir => dir == GameConsts.Direction.Horizontal)) {
                x = position.x;
            }
            if (Directions.Any(dir => dir == GameConsts.Direction.Vertical)) {
                y = position.y;
            }
            _transform.anchoredPosition = new Vector2(x, y);
        }
    }
}
