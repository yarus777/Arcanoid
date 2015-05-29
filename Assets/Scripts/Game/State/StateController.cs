using System.Collections.Generic;

using Assets.Scripts.Engine;
using Assets.Scripts.Game.GameInterfaces;
using Assets.Scripts.Game.State.FailReasons;
using Assets.Scripts.Game.State.WinReasons;

using Console = Assets.Scripts.Engine.Tools.Console;

namespace Assets.Scripts.Game.State {
    enum GameState {
        Pause,
        Win,
        Lose,
        Run
    }

    class StateController : IUninitialize, IGameComponent {
        private readonly List<IFailReason> _failReasons = new List<IFailReason>();
        private readonly List<IWinReason> _winReasons = new List<IWinReason>();

        public GameState GameState { get; private set; }

        public void RegisterFailReason(IFailReason reason) {
            if (_failReasons.Contains(reason)) {
                Console.LogError("Fail reason already added!");
                return;
            }
            reason.Failed += OnFail;
            _failReasons.Add(reason);
        }

        public void RegisterWinReason(IWinReason reason) {
            if (_winReasons.Contains(reason)) {
                Console.LogError("Win reason already added!");
                return;
            }
            _winReasons.Add(reason);
        }

        public void DeInit() {
            foreach (var reason in _failReasons) {
                reason.Failed -= OnFail;
            }
            foreach (var reason in _winReasons) {
                reason.Win -= OnWin;
            }
        }

        private void OnFail() {
            Console.LogInfo("You are lose");
            GameState = GameState.Lose;
        }

        private void OnWin() {
            Console.LogInfo("You are win");
            GameState = GameState.Win;
        }

        #region Game components

        public void StartGame() {
            GameState = GameState.Run;
        }

        public void FinishGame() {
        }

        #endregion

    }
}
