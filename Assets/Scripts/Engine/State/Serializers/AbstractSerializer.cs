using Assets.Scripts.Engine.State.StateSavers;

namespace Assets.Scripts.Engine.State.Serializers {
    public abstract class AbstractSerializer : IReadStateSerializer {
        public IStateLoader StateSaver { get; private set; }

        protected AbstractSerializer(IStateLoader stateSaver) {
            StateSaver = stateSaver;
        }

        public abstract T Deserialize<T>(string key);
    }
}
