using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public float playerVelocity;
    public float boundary;
    private Vector3 playerPosition;

    private int playerLives;
    private int playerPoints;

	// Use this for initialization
	void Start () {

        playerPosition = gameObject.transform.position;
        playerLives = 3;
        playerPoints = 0;
	
	}
	
	// Update is called once per frame
	void Update () {

        playerPosition.x += Input.GetAxis("Horizontal") * playerVelocity;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        transform.position = playerPosition;

        if (playerPosition.x < -boundary)
        {
            transform.position = new Vector3(-boundary, playerPosition.y, playerPosition.z);
        }
        if (playerPosition.x > boundary)
        {
            transform.position = new Vector3(boundary, playerPosition.y, playerPosition.z);
        }
	
	}

    void addPoints(int points)
    {
        playerPoints += points;
    }

    void TakeLife(){
        playerLives--;
    }

    void OnGUI()
    {
        GUI.Label(new Rect(3.0f, 1.0f, 200.0f, 200.0f), "Live's: " + playerLives + "  Score: " + playerPoints);
    }
}
