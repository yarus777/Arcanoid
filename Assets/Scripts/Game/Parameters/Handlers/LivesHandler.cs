using Assets.Scripts.Engine.State;
using Assets.Scripts.Engine.State.Serializers;
using Assets.Scripts.Game.Consts;

namespace Assets.Scripts.Game.Parameters.Handlers {
    class LivesHandler : IStatisticHandler {
        private const string KEY = "lives";

        public GameConsts.StatisticItems Type {
            get {
                return GameConsts.StatisticItems.Lives;
            }
        }

        public int Count {
            get {
                return 0;
            }
        }

        #region Save state

        public void Load(IStateSerializer stateSerializer) {
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
