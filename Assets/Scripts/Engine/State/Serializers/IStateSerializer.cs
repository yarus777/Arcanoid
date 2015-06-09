namespace Assets.Scripts.Engine.State.Serializers {
    public interface IStateSerializer : IReadStateSerializer {
        void Serialize(string key, object obj);
    }
}
