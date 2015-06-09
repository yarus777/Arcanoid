using UnityEngine;

namespace Assets.Scripts.Engine.State.StateSavers {
    class ResourceStateLoader : IStateLoader {
        public string Load(string key) {
            var saved = Resources.Load<TextAsset>(key);
            if (saved) {
                return saved.text;
            }
            return null;
        }
    }
}
