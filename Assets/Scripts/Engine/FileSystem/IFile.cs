namespace Assets.Scripts.Engine.FileSystem {
    interface IFile {
        void Write(string path, string content);

        string Read(string path);
    }
}
