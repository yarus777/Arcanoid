using Assets.Scripts.Engine.State.Serializers;

namespace Assets.Scripts.Engine.State {
    delegate void StateChangedDelegate(ISaveState obj);

    interface ISaveState {
        void Load(IStateSerializer stateSerializer);

        void Save(IStateSerializer stateSerializer);

        event StateChangedDelegate StateChanged;
    }
}
