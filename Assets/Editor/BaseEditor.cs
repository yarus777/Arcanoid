using Assets.Scripts.Engine.State.Serializers;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor {
    abstract class BaseEditor : EditorWindow {
        public static readonly string ROOT_PATH = Path.Combine(Application.dataPath, "Resources");

        protected abstract void Load();
        protected abstract void Save();

        protected IStateSerializer Serializer = new XmlSerializer(new FileStateSaver());

        private bool _loaded = false;
        protected virtual void OnGUI() {
            if (!_loaded) {
                _loaded = true;
                Load();
            }
        }

        private void OnDestroy() {
            SaveWithPrompt();
        }

        protected void SaveWithPrompt() {
            if (EditorUtility.DisplayDialog("Saving", "Save?", "Yes", "No")) {
                Save();
            }
        }
    }
}
