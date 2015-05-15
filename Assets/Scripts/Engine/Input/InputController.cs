using UnityEngine;

namespace Assets.Scripts.Engine.Input {
    abstract class InputController : MonoBehaviour, IInputController {
        public abstract event InputDetectedDelegate PointerDown;
        public abstract event InputDetectedDelegate PointerUp;
        public abstract event InputDetectedDelegate PointerDrag;
    }
}
