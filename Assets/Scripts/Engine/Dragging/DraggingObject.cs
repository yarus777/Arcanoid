using Assets.Scripts.Engine.Input;
using Assets.Scripts.Game.Consts;

using UnityEngine;

namespace Assets.Scripts.Engine.Dragging {
    abstract class DraggingObject : MonoBehaviour {
        protected abstract GameConsts.Direction[] Directions { get; }

        private IInputController _inputController;

        public void Init(IInputController inputController) {
            _inputController = inputController;
            _inputController.PointerDown += OnPointerDown;
            _inputController.PointerUp += OnPointerUp;
            _inputController.PointerDrag += OnPointerDrag;
        }

        #region EVent Handlers

        private void OnPointerDrag(Vector2 pointerPosition) {
            Debug.Log("up");
        }

        private void OnPointerUp(Vector2 pointerPosition) {
            Debug.Log("up");
        }

        private void OnPointerDown(Vector2 pointerPosition) {
            Debug.Log("down");
        }

        #endregion
    }
}
