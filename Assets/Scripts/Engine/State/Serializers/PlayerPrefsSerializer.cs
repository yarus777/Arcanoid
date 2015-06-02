using UnityEngine;

namespace Assets.Scripts.Engine.State.Serializers {
    class PlayerPrefsSerializer : XmlSerializer {
        protected override void Save(string serializedObject, string key) {
            PlayerPrefs.SetString(key, serializedObject);
        }

        protected override string Load(string key) {
            return PlayerPrefs.GetString(key);
        }
    }
}
