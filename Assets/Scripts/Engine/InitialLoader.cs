using UnityEngine;

namespace Assets.Scripts.Engine {
    class InitialLoader : MonoBehaviour {
        private void Start() {
            Arcanoid.Instance.Init();
        }
    }
}
