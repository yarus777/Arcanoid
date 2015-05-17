using UnityEngine;

namespace Assets.Scripts.Game.Balls {
    [RequireComponent(typeof(Rigidbody2D))]
    class Ball : MonoBehaviour {
        public void Send(Vector2 speed) {
            rigidbody2D.AddForce(speed, ForceMode2D.Impulse);
        }
    }
}
