using System.IO;

namespace Assets.Scripts.Engine.FileSystem.Implementations {
    class CommonFile : IFile {
        public void Write(string path, string content) {
            File.WriteAllText(path, content);
        }

        public string Read(string path) {
            return File.ReadAllText(path);
        }
    }
}
