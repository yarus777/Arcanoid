namespace Assets.Scripts.Engine.State.StateSavers {
    public interface IStateSaver : IStateLoader {
        void Save(string serializedObject, string key);
        
    }
}
