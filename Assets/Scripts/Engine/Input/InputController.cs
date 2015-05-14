using UnityEngine;

namespace Assets.Scripts.Engine.Input {
    abstract class InputController : MonoBehaviour, IInputController {
        public abstract event InputDetectedDelegate InputDetected;
    }
}
