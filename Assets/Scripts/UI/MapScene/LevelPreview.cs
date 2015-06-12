using UnityEngine;
using System.Collections;
using Assets.Scripts;
using Assets.Scripts.Engine.Loading;
using Assets.Scripts.Game.Levels;
using UnityEngine.UI;

public class LevelPreview : MonoBehaviour
{

    public Text LevelNumber;
    private int _levelNumber;

    public int Number
    {
        get
        {
            return _levelNumber;
        }
        set
        {
            _levelNumber = value;
            LevelNumber.text = value.ToString();
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        Arcanoid.Instance.LevelStorage.SetCurrentLevel(Number); 
        LoadingController.Instance.SceneLoader.ToNextScene();
        
    }
}
