using Assets.Scripts.Game.Consts;

using UnityEngine;

namespace Assets.Scripts.Engine.Input {
    class KeyboardInputController : InputController, IInputController {
        void Update() {
            if (UnityEngine.Input.GetKey(KeyCode.LeftArrow)) {
                Debug.Log("left");
            }
            if (UnityEngine.Input.GetKey(KeyCode.RightArrow)) {
                Debug.Log("right");
            }
        }

        #region Events

        public override event InputDetectedDelegate InputDetected;

        private void OnInputDetected(GameConsts.Direction direction, InputEventType eventType) {
            var handler = InputDetected;
            if (handler != null) {
                handler(direction, eventType);
            }
        }

        #endregion
    }
}
