using System;

using UnityEngine;

namespace Assets.Scripts.Engine.State.StateSavers {
    class ResourceStateSaver : IStateSaver {
        public void Save(string serializedObject, string key) {
            throw new NotSupportedException("Saving to resources is not supported during runtime");
        }

        public string Load(string key) {
            var saved = Resources.Load<TextAsset>(key);
            if (saved) {
                return saved.text;
            }
            return null;
        }
    }
}
