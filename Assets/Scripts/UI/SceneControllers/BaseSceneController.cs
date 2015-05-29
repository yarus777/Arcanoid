using Assets.Scripts.Engine.Loading;

using UnityEngine;

namespace Assets.Scripts.UI.SceneControllers {
    abstract class BaseSceneController : MonoBehaviour {
        protected void GoToNextScene() {
            LoadingController.Instance.SceneLoader.ToNextScene();
        }
    }
}
