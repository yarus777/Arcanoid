using System.IO;

using Assets.Scripts.Engine.State.StateSavers;

namespace Assets.Scripts.Engine.State.Serializers {
    public class XmlSerializer : XmlReader, IStateSerializer {
        private readonly IStateSaver _saver;

        public XmlSerializer(IStateSaver stateSaver)
            : base(stateSaver) {
            _saver = stateSaver;
        }

        public void Serialize(string key, object obj) {
            var serializer = new System.Xml.Serialization.XmlSerializer(obj.GetType());
            using (var writer = new StringWriter()) {
                serializer.Serialize(writer, obj);
                _saver.Save(writer.ToString(), key);
            }
        }
    }
}
