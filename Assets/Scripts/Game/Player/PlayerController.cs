using Assets.Scripts.Engine.Input;

using UnityEngine;

namespace Assets.Scripts.Game.Player {
    class PlayerController : MonoBehaviour {
        [SerializeField]
        private Player Player;

        [SerializeField]
        private MouseInputController KeyboardController;

        void Start() {
            Player.Init(KeyboardController);
        }
    }
}
