using System.IO;

using Assets.Scripts.Engine.Exceptions;
using Assets.Scripts.Engine.State.StateSavers;

namespace Assets.Scripts.Engine.State.Serializers {
    public class XmlSerializer : AbstractSerializer {
        public XmlSerializer(IStateSaver stateSaver)
            : base(stateSaver) {
        }

        public override void Serialize(string key, object obj) {
            var serializer = new System.Xml.Serialization.XmlSerializer(obj.GetType());
            using (var writer = new StringWriter()) {
                serializer.Serialize(writer, obj);
                StateSaver.Save(writer.ToString(), key);
            }
        }

        public override T Deserialize<T>(string key) {
            try {
                var serializedObj = StateSaver.Load(key);
                if (string.IsNullOrEmpty(serializedObj)) {
                    throw new NotSavedException(key);
                }
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                using (var reader = new StringReader(serializedObj)) {
                    return (T)serializer.Deserialize(reader);
                }
            }
            catch (IOException e) {
                throw new NotSavedException(key);
            }
        }
    }
}
