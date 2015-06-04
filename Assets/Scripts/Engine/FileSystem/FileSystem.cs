using Assets.Scripts.Engine.FileSystem.Implementations;

namespace Assets.Scripts.Engine.FileSystem {
    public class FileSystem {
        private static readonly IFile file = new CommonFile();

        public static void Write(string absolutPath, string content) {
            file.Write(absolutPath, content);
        }

        public static string Read(string absolutPath) {
            return file.Read(absolutPath);
        }
    }
}
