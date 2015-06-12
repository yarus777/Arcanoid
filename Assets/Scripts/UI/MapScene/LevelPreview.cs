using Assets.Scripts;
using Assets.Scripts.Engine.Loading;
using Assets.Scripts.Game.Consts;
using Assets.Scripts.UI.Popups;
using Assets.Scripts.UI.Popups.Implementations;

using UnityEngine;
using UnityEngine.UI;

public class LevelPreview : MonoBehaviour {
    public const float WIDTH = 200;
    public const float HEIGHT = 200;

    [SerializeField]
    private Text LevelNumber;

    private int _levelNumber;
    public int Number {
        get {
            return _levelNumber;
        }
        set {
            _levelNumber = value;
            LevelNumber.text = "" + value;
            gameObject.name = "Level_" + value;
        }
    }

    public void OnClick() {
        if (Arcanoid.Instance.Statistics.Get(GameConsts.StatisticItems.Lives).Count > 0) {
            Arcanoid.Instance.LevelStorage.SetCurrentLevel(Number);
            LoadingController.Instance.SceneLoader.ToScene("GameScene");
        }
        else {
            PopupController.Instance.ShowPopup<LivesEndPopup>();
        }
        
    }
}
