using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

	public GameObject quitButton;

	//Basic fuction load level
	public void LoadLevel (int level) {
		SceneManager.LoadScene(level, LoadSceneMode.Single);
	}

	public void QuitGame(){
		if (Application.isEditor) {
			Debug.Log ("Attempted to quit from the Editor.");
		} else if (Application.isWebPlayer) {
			quitButton = GameObject.FindGameObjectWithTag ("Quit");
			quitButton.SetActive (false);
			Debug.Log ("Attempted to quit from the Web Player.");
		} else if (Application.platform == RuntimePlatform.WebGLPlayer) {
			quitButton = GameObject.FindGameObjectWithTag ("Quit");
			quitButton.SetActive (false);
			Debug.Log ("Attempted to quit from the WebGL Player.");
		}
		else {
			Application.Quit();
		}
	}

}
