using System.IO;

namespace Assets.Scripts.Engine.State.Serializers {
    abstract class XmlSerializer : IStateSerializer {
        public void Serialize(string key, object obj) {
            var serializer = new System.Xml.Serialization.XmlSerializer(obj.GetType());
            using (var writer = new StringWriter()) {
                serializer.Serialize(writer, obj);
            }
            Save(serializer.ToString(), key);
        }

        public T Deserialize<T>(string key) {
            var serializedObj = Load(key);
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            using (var reader = new StringReader(serializedObj)) {
                return (T)serializer.Deserialize(reader);
            }
        }

        protected abstract void Save(string serializedObject, string key);
        protected abstract string Load(string key);
    }
}
