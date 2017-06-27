using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour {
	
	private Ball ball;
	private GameManager gameManager;

	IEnumerator Pause() {
		//Switch GameManager State
		gameManager = GameObject.FindObjectOfType<GameManager>();
		gameManager.SwitchState (GameState.Failed);

		//Find the ball and reset game start
//		ball = GameObject.FindObjectOfType<Ball>();
//		ball.gameStarted = false;

		//enable the restart and main menu buttons
		gameManager.EnableButtons();

		yield return new WaitForSeconds (2);
		//Reload level
		//Apllication.LoadLevel(Application.loadedLevel);
		//SceneManager.LoadScene("Main", LoadSceneMode.Single);

		print ("After Waiting 2 Seconds");
	}

	void OnTriggerEnter2D (Collider2D trigger){
		if (trigger.name == "Ball") {
			print ("Lost Triggered!");

			//Wait before restarting level
			StartCoroutine (Pause ());
		}
	}
}
