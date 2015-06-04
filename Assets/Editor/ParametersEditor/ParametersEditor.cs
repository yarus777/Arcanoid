using Assets.Scripts.Engine.Exceptions;
using Assets.Scripts.Parameters;
using Assets.Scripts.Serialization.Parameters;

using UnityEditor;

namespace Assets.Editor.ParametersEditor {
    partial class ParametersEditor : BaseEditor {
        [MenuItem("Arcanoid/Parameters")]
        public static void Init() {
            GetWindow<ParametersEditor>().title = "Parameters";
        }

        protected override void Load() {
            try {
                _parms = Serializer.Deserialize<DefaultParameters>(Strings.PARAMETERS_PATH);
            }
            catch (NotSavedException e) {
                _parms = new DefaultParameters();        
            }
        }

        protected override void Save() {
            Serializer.Serialize(Strings.PARAMETERS_PATH, _parms);
        }

        private DefaultParameters _parms;
    }
}
