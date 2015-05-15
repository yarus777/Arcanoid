using Assets.Scripts.Engine.Dragging;
using Assets.Scripts.Engine.Input;

using UnityEngine;

namespace Assets.Scripts.Game.Player {
    public class Player : MonoBehaviour {
        [SerializeField]
        private DraggingObject Movable;

        public void Init(IInputController inputController) {
            Movable.Init(inputController);
        }
    }
}
