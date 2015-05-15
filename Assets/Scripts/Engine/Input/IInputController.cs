using UnityEngine;

namespace Assets.Scripts.Engine.Input {
    public delegate void InputDetectedDelegate(Vector2 pointerPosition);

    public interface IInputController {
        event InputDetectedDelegate PointerDown;
        event InputDetectedDelegate PointerUp;
        event InputDetectedDelegate PointerDrag;
    }
}
