namespace Assets.Scripts.Engine.State.Serializers {
    public interface IStateSerializer {
        void Serialize(string key, object obj);

        T Deserialize<T>(string key);
    }
}
