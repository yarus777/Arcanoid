using Assets.Scripts.Game.GameInterfaces;
using Assets.Scripts.Game.Levels;

using UnityEngine;

namespace Assets.Scripts.Game.Balls {
    class BallController : MonoBehaviour, IGameComponent {
        [SerializeField]
        private Ball Ball;

        private Vector2 _ballSpeed;

        public void Init(Vector2 ballSpeed) {
            _ballSpeed = ballSpeed;
        }

        public void StartGame(Level level) {
            Ball.Send(_ballSpeed);
        }

        public void FinishGame() {
        }
    }
}
