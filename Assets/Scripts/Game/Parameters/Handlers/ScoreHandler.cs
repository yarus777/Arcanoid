using Assets.Scripts.Engine.State;
using Assets.Scripts.Engine.State.Serializers;
using Assets.Scripts.Game.Consts;

namespace Assets.Scripts.Game.Parameters.Handlers {
    class ScoreHandler : IStatisticHandler {
        private const string KEY = "score";
        public GameConsts.StatisticItems Type {
            get {
                return GameConsts.StatisticItems.Score;
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

        #endregion
    }
}
