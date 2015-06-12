using UnityEngine;

namespace Assets.Scripts.Game.Player {
    class PlayerController : MonoBehaviour {
        [SerializeField]
        private Player Player;

        public Player Platform {
            get {
                return Player;
            }
        }
    }
}
