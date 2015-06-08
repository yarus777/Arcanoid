using System.IO;

using Assets.Scripts.Engine.FileSystem;
using Assets.Scripts.Engine.State.StateSavers;

using UnityEditor;

using UnityEngine;

namespace Assets.Editor {
    class FileStateSaver : IStateSaver {
        public void Save(string serializedObject, string key) {
            var fullpath = Path.Combine(BaseEditor.ROOT_PATH, key + ".xml");
            FileSystem.Write(fullpath, serializedObject);
#if UNITY_EDITOR
            AssetDatabase.Refresh();
#endif
        }

        public string Load(string key) {
            var fullpath = Path.Combine(Path.Combine(Application.dataPath, "Resources"), key + ".xml");
            return FileSystem.Read(fullpath);
        }
    }
}
