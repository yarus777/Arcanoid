using UnityEngine;

namespace Assets.Scripts.UI.GameScene {
    class GameUIController : MonoBehaviour {
        [SerializeField]
        private InfoController InfoController;

        public InfoController Info {
            get {
                return InfoController;
            }
        }
    }
}
