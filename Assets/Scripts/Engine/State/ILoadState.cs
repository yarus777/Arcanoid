using Assets.Scripts.Engine.State.Serializers;

namespace Assets.Scripts.Engine.State {
    interface ILoadState {
        void Load(IStateSerializer stateSerializer);
    }
}
