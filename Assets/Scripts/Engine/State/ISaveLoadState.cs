using Assets.Scripts.Engine.State.Serializers;

namespace Assets.Scripts.Engine.State {
    delegate void StateChangedDelegate(ISaveLoadState obj);

    interface ISaveLoadState : ILoadState {
        void Save(IStateSerializer stateSerializer);

        event StateChangedDelegate StateChanged;
    }
}
