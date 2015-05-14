using Assets.Scripts.Game.Consts;

namespace Assets.Scripts.Engine.Input {
    public enum InputEventType {
        Down,
        Held
    }

    public delegate void InputDetectedDelegate(GameConsts.Direction direction, InputEventType eventType);

    public interface IInputController {
        event InputDetectedDelegate InputDetected;
    }
}
