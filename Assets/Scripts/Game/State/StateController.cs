using System.Collections.Generic;

using Assets.Scripts.Engine;
using Assets.Scripts.Game.GameInterfaces;
using Assets.Scripts.Game.Levels;
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
        private IEnumerable<IFailReason> _failReasons;
        private IEnumerable<IWinReason> _winReasons;

        private GameState _state;
        public GameState GameState {
            get {
                return _state;
            }
            private set {
                _state = value;
                OnStateChanged(_state);
            }
        }

        public delegate void StateChangedDelegate(GameState state);
        public event StateChangedDelegate StateChanged;

        private void OnStateChanged(GameState state) {
            var handler = StateChanged;
            if (handler != null) {
                handler.Invoke(state);
            }
        }

        #region Event handlers

        private void OnFail() {
            Console.LogInfo("You are lose");
            GameState = GameState.Lose;
        }

        private void OnWin() {
            Console.LogInfo("You are win");
            GameState = GameState.Win;
        }

        #endregion

        #region Game components

        public void StartGame(Level level) {
            _failReasons = level.FailReasons;
            _winReasons = level.WinReasons;

            foreach (var reason in _failReasons) {
                reason.Failed += OnFail;
            }
            foreach (var reason in _winReasons) {
                reason.Win += OnWin;
            }
            GameState = GameState.Run;
        }

        public void FinishGame() {
        }

        public void DeInit() {
            foreach (var reason in _failReasons) {
                reason.Failed -= OnFail;
            }
            foreach (var reason in _winReasons) {
                reason.Win -= OnWin;
            }
        }

        #endregion
    }
}
