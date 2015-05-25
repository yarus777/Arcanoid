using Assets.Scripts.Game.Consts;

namespace Assets.Scripts.Game.Parameters.Handlers {
    class LivesHandler : IStatisticHandler {
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
    }
}
