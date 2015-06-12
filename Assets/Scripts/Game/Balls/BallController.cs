using Assets.Scripts.Game.GameInterfaces;
using Assets.Scripts.Game.Levels;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game.Balls {
    class BallController : MonoBehaviour, IGameComponent {
        [SerializeField]
        private Ball BallPrefab;

        private List<Ball> _balls = new List<Ball>();
        private Player.Player _player;
        private Vector2 _ballSpeed;

        public void Init(Vector2 ballSpeed, Player.Player player) {
            _ballSpeed = ballSpeed;
            _player = player;
        }

        #region IGameComponent

        public void StartGame(Level level) {
            var ball = CreateBall();
            SetToPlayer(ball);
            SendBall(ball);
        }

        public void FinishGame() {
        }

        #endregion

        public Ball CreateBall() {
            var obj = Instantiate(BallPrefab.gameObject) as GameObject;
            var tr = obj.GetComponent<RectTransform>();
            tr.parent = transform;
            tr.localScale = new Vector3(1, 1, 1);
            var ball = obj.GetComponent<Ball>();
            _balls.Add(ball);
            return ball;
        }

        private void SendBall(Ball ball) {
            ball.Send(_ballSpeed + new Vector2(Random.Range(-50, 50), Random.Range(-50, 50)));
        }

        private void SetToPlayer(Ball ball) {
            var tr = ball.GetComponent<RectTransform>();
            var plTr = _player.GetComponent<RectTransform>();
            tr.anchoredPosition = plTr.anchoredPosition + new Vector2(0, tr.sizeDelta.y / 2);
        }
    }
}
