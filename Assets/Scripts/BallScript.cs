using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

    private bool ballIsActive;
    private Vector3 ballPosition;
    private Vector2 ballInitialForce;
    public GameObject playerObject;

	// Use this for initialization
	void Start () {

        // создаем силу
        ballInitialForce = new Vector2(100.0f, 300.0f);

        // переводим в неактивное состояние
        ballIsActive = false;

        // запоминаем положение
        ballPosition = transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {

    if (Input.GetButtonDown ("Jump") == true) {
				// check if is the first play
				if (!ballIsActive){
					// reset the force
					rigidbody2D.isKinematic = false;
					
					// add a force
					rigidbody2D.AddForce(ballInitialForce);
					
					// set ball active
					ballIsActive = !ballIsActive;
				}
			}
			
			if (!ballIsActive && playerObject != null){
				
				// get and use the player position
				ballPosition.x = playerObject.transform.position.x;
				
				// apply player X position to the ball
				transform.position = ballPosition;
			}
			
			// Check if ball falls
			if (ballIsActive && transform.position.y < -6) {
				ballIsActive = !ballIsActive;
				ballPosition.x = playerObject.transform.position.x;
				ballPosition.y = -3.84f;
				transform.position = ballPosition;
				
				rigidbody2D.isKinematic = true;

                //добавили вызов метода
                playerObject.SendMessage("TakeLife");
			}
			
		}       
	
}
