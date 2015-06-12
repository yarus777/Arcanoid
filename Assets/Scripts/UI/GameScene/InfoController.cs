using Assets.Scripts.Game.Consts;
using Assets.Scripts.Game.Parameters.Handlers;

using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.GameScene {
    internal class InfoController : MonoBehaviour {
        [SerializeField]
        private Text Lives;

        [SerializeField]
        private Text Score;

        private IStatisticHandler _score;
        private IStatisticHandler _lives;

        private void Start() {
            _score = Arcanoid.Instance.Statistics.Get(GameConsts.StatisticItems.Score);
            _lives = Arcanoid.Instance.Statistics.Get(GameConsts.StatisticItems.Lives);
        }

        private void Update() {
            Lives.text = "Lives: " + _lives.Count;
            Score.text = "Score: " + _score.Count;
        }
    }
}
