namespace Assets.Scripts.Engine.State.StateSavers {
    interface ILoadAll : IStateLoader {
        string[] LoadAll(string path);
    }
}
