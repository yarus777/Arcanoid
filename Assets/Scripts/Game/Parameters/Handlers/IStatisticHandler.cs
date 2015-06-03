using Assets.Scripts.Engine.State;
using Assets.Scripts.Game.Consts;

namespace Assets.Scripts.Game.Parameters.Handlers {
    interface IStatisticHandler : ISaveLoadState {
        GameConsts.StatisticItems Type { get; }
        int Count { get; }
    }
}
