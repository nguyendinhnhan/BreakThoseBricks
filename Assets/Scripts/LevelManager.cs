using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public GameObject[] bricks;
	public int count = 0;
	private GameManager gameManager;
	private LevelLoader levelLoader;
	public string FinishTime;

	// Use this for initialization
	void Start () {
		bricks = GameObject.FindGameObjectsWithTag ("Brick");
		count = bricks.Length;

		if (count == 0) {
			Debug.Log ("All bricks are gone");

			//Wait before returning to Main level
			StartCoroutine(Pause());
		}
	}

	IEnumerator Pause() {
		print ("Before Waiting  seconds");
		//Switch GameManager State
		gameManager = GameObject.FindObjectOfType<GameManager>();
		gameManager.SwitchState (GameState.Completed);
		gameManager.ChangeText ("You Win :)");
		FinishTime = gameManager.formattedTime;

		Debug.Log ("Took " + FinishTime + " to finish the game");

		yield return new WaitForSeconds (5);

		//Reload Main Menu
		levelLoader.LoadLevel(0);
		print ("After Waiting 5 Seconds went to main menu");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
