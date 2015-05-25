using Assets.Scripts.Game.Consts;

namespace Assets.Scripts.Game.Parameters.Handlers {
    interface IStatisticHandler {
        GameConsts.StatisticItems Type { get; }
        int Count { get; }
    }
}
