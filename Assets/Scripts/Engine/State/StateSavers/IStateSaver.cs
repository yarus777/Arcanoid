namespace Assets.Scripts.Engine.State.StateSavers {
    public interface IStateSaver {
        void Save(string serializedObject, string key);
        string Load(string key);
    }
}
