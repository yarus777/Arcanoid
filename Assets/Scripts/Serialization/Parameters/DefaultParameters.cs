using System.Xml.Serialization;

using Assets.Scripts.Engine.State.Serializers;
using Assets.Scripts.Parameters;

namespace Assets.Scripts.Serialization.Parameters {
    [XmlRoot]
    public class DefaultParameters {
        [XmlElement("lives")]
        public int LivesCount;

        public DefaultParameters() {
            LivesCount = 5;
        }

        public static DefaultParameters Load(IReadStateSerializer serializer) {
            return serializer.Deserialize<DefaultParameters>(Strings.PARAMETERS_PATH);
        }
    }
}
