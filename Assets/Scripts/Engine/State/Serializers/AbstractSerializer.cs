using Assets.Scripts.Engine.State.StateSavers;

namespace Assets.Scripts.Engine.State.Serializers {
    public abstract class AbstractSerializer : IStateSerializer {
        protected IStateSaver StateSaver { get; private set; }

        protected AbstractSerializer(IStateSaver stateSaver) {
            StateSaver = stateSaver;
        }

        public abstract void Serialize(string key, object obj);

        public abstract T Deserialize<T>(string key);
    }
}
