using UnityEngine;

namespace Assets.Scripts.Engine.State.StateSavers {
    class PlayerPrefsStateSaver : IStateSaver {
        public void Save(string serializedObject, string key) {
            PlayerPrefs.SetString(key, serializedObject);
        }

        public string Load(string key) {
            return PlayerPrefs.GetString(key);
        }
    }
}
