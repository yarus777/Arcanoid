namespace Assets.Scripts.Engine.State.Serializers {
    public interface IReadStateSerializer {
        T Deserialize<T>(string key);
    }
}
