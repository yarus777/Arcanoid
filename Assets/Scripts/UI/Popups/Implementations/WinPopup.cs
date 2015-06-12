using Assets.Scripts.Engine.Loading;

namespace Assets.Scripts.UI.Popups.Implementations {
    class WinPopup : Popup {
        protected override void OnClose() {
            base.OnClose();
            LoadingController.Instance.SceneLoader.ToPreviousScene();
        }
    }
}
