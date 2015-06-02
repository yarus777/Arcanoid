namespace Assets.Scripts.Engine.State.Serializers {
    interface IStateSerializer {
        void Serialize(string key, object obj);

        T Deserialize<T>(string key);
    }
}
