using Assets.Scripts.Game.Consts;

namespace Assets.Scripts.Game.Parameters.Handlers {
    class ScoreHandler : IStatisticHandler {
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
    }
}
