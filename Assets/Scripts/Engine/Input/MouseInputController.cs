using UnityEngine;

namespace Assets.Scripts.Engine.Input {
    class MouseInputController : InputController {
        void FixedUpdate() {
            if (UnityEngine.Input.GetMouseButtonDown(0)) {
                OnDown(UnityEngine.Input.mousePosition);
            }
            if (UnityEngine.Input.GetMouseButton(0)) {
                OnDrag(UnityEngine.Input.mousePosition);
            }
            if (UnityEngine.Input.GetMouseButtonUp(0)) {
                OnUp(UnityEngine.Input.mousePosition);
            }
        }

        #region Events
        public override event InputDetectedDelegate PointerDown;
        public override event InputDetectedDelegate PointerUp;
        public override event InputDetectedDelegate PointerDrag;

        private void OnDown(Vector2 position) {
            var handler = PointerDown;
            if (handler != null) {
                handler(position);
            }
        }

        private void OnUp(Vector2 position) {
            var handler = PointerUp;
            if (handler != null) {
                handler(position);
            }
        }

        private void OnDrag(Vector2 position) {
            var handler = PointerDrag;
            if (handler != null) {
                handler(position);
            }
        }

        #endregion
    }
}
