using System.IO;

using Assets.Scripts.Engine.Exceptions;
using Assets.Scripts.Engine.State.StateSavers;

namespace Assets.Scripts.Engine.State.Serializers {
    public class XmlReader : AbstractSerializer {
        public XmlReader(IStateLoader stateLoader)
            : base(stateLoader) {
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
            catch (IOException) {
                throw new NotSavedException(key);
            }
        }
    }
}
