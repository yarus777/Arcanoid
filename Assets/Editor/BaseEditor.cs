using Assets.Scripts.Engine.State.Serializers;

using UnityEditor;

namespace Assets.Editor {
    abstract class BaseEditor : EditorWindow {
        protected abstract void Load();
        protected abstract void Save();

        protected IStateSerializer Serializer = new XmlSerializer(new FileStateSaver());

        private bool _loaded = false;
        protected virtual void OnGUI() {
            if (!_loaded) {
                Load();
                _loaded = true;
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
