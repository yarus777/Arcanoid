using UnityEngine;

namespace Assets.Scripts.Game {
    class Game : MonoBehaviour {
        public static Game Instance { get; private set; }

        private void Awake() {
            Instance = this;
        }
    }
}
