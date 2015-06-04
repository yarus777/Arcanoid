using Assets.Scripts.Engine.Exceptions;
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
