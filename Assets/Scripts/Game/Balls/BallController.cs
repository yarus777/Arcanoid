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
            CreateBall(true);
            //Ball.Send(_ballSpeed);
        }

        public void FinishGame() {
        }

        #endregion

        public void CreateBall(bool startImmediately) {
            var obj = Instantiate(BallPrefab.gameObject) as GameObject;
            var tr = obj.GetComponent<RectTransform>();
            tr.parent = transform;
            //RectTransformUtility.
            //tr.anchoredPosition = _player.GetComponent<RectTransform>().anchoredPosition;
            tr.localScale = new Vector3(1, 1, 1);

            var ball = obj.GetComponent<Ball>();
            _balls.Add(ball);
            Debug.Log(transform.position);
            Debug.Log(_player.transform.position);
            if (startImmediately) {
                ball.Send(_ballSpeed + new Vector2(Random.Range(-50, 50), Random.Range(-50, 50)));
            }
        }
    }
}
