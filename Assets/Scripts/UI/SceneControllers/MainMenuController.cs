using Assets.Scripts.Game.Consts;
using Assets.Scripts.UI.Popups;
using Assets.Scripts.UI.Popups.Implementations;

namespace Assets.Scripts.UI.SceneControllers {
    class MainMenuController : BaseSceneController {
        public void Play() {
            if (Arcanoid.Instance.Statistics.Get(GameConsts.StatisticItems.Lives).Count > 0) {
                GoToNextScene();
            }
            else {
                PopupController.Instance.ShowPopup<LivesEndPopup>();
            }
        }
    }
}
