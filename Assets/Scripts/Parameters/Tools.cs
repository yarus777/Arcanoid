using Assets.Scripts.Engine.State.Serializers;
using Assets.Scripts.Engine.State.StateSavers;

namespace Assets.Scripts.Parameters {
    class Tools {
        public static readonly IStateSerializer StateSerializer = new XmlSerializer(new PlayerPrefsStateSaver());
    }
}
