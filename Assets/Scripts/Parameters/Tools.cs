using Assets.Scripts.Engine.State.Serializers;

namespace Assets.Scripts.Parameters {
    class Tools {
        public static readonly IStateSerializer StateSerializer = new PlayerPrefsSerializer();
    }
}
