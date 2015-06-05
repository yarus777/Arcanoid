using System.Collections.Generic;
using System.Linq;

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
        private IList<IFailReason> _failReasons;
        private IList<IWinReason> _winReasons;

        private GameState _state;
        public GameState GameState {
            get {
                return _state;
            }
            private set {
                if (_state == value) {
                    return;
                }
                _state = value;
                OnStateChanged(_state);
            }
        }

        public delegate void StateChangedDelegate(GameState state);
        public event StateChangedDelegate StateChanged;

        private void OnStateChanged(GameState state) {
            if (state == GameState.Win || state == GameState.Lose) {
                OnLevelEnd();
            }
            var handler = StateChanged;
            if (handler != null) {
                handler.Invoke(state);
            }
        }

        #region Event handlers

        private void OnFail(IFailReason reason) {
            Console.LogInfo("You are lose");
            _failReasons.Remove(reason);
            GameState = GameState.Lose;
        }

        private void OnWin(IWinReason reason) {
            _winReasons.Remove(reason);
            if (_winReasons.Count == 0) {
                Console.LogInfo("You are win");
                GameState = GameState.Win;
            }
        }

        #endregion

        #region Game components

        public void StartGame(Level level) {
            _failReasons = level.FailReasons.ToList();
            _winReasons = level.WinReasons.ToList();

            foreach (var reason in _failReasons) {
                reason.Failed += OnFail;
            }
            foreach (var reason in _winReasons) {
                reason.Win += OnWin;
                reason.Subscribe();
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

        private void OnLevelEnd() {
            foreach (var reason in _winReasons) {
                reason.Unsubscribe();
            }
        }
    }
}
