using Assets.Scripts.Engine.Exceptions;
using Assets.Scripts.Engine.State;
using Assets.Scripts.Engine.State.Serializers;
using Assets.Scripts.Game.Consts;
using Assets.Scripts.Game.State;

namespace Assets.Scripts.Game.Parameters.Handlers {
    class LivesHandler : IStatisticHandler {
        private const string KEY = "lives";

        public LivesHandler() {
            Arcanoid.Instance.StateController.StateChanged += OnGameStateChanged;
        }

        #region State handlers

        private void OnGameStateChanged(GameState state) {
            switch (state) {
                case GameState.Lose:
                    OnLose();
                    break;
            }
        }

        private void OnLose() {
            Count--;
            OnStateChanged();
        }

        #endregion

        public GameConsts.StatisticItems Type {
            get {
                return GameConsts.StatisticItems.Lives;
            }
        }

        public int Count { get; private set; }

        #region Save state

        public void Load(IStateSerializer stateSerializer) {
            try {
                Count = stateSerializer.Deserialize<int>(KEY);
            }
            catch (NotSavedException e) {
                Count = Arcanoid.Instance.DefaultParameters.LivesCount;
            }
        }

        public void Save(IStateSerializer stateSerializer) {
        }

        public event StateChangedDelegate StateChanged;

        private void OnStateChanged() {
            var handler = StateChanged;
            if (handler != null) {
                handler.Invoke(this);
            }
        }

        #endregion
    }
}
