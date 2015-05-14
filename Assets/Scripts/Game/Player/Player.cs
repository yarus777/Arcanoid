using Assets.Scripts.Engine.Input;
using Assets.Scripts.Engine.Moving;

using UnityEngine;

namespace Assets.Scripts.Game.Player {
    public class Player : MonoBehaviour {
        [SerializeField]
        private MovingObject Movable;

        public void Init(IInputController inputController) {
            Movable.Init(inputController);
        }
    }
}
