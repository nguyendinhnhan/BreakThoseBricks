using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Make sure there is always an AudioSource component on the GameObject where this script is added
[RequireComponent(typeof(AudioSource))]
public class Paddle : MonoBehaviour {

	//Make the AudioClip configurable in the editor
	public AudioClip Sound;

	// Use this for initialization
	void Start () {
		print ("This is Start");
	}
	
	// Update is called once per frame
	void Update () {
		//Set variable for current position
		Vector3 paddlePos = new Vector3 (8f, this.transform.position.y, 0f);

		//Get mouse position
		float mousePos = Input.mousePosition.x / Screen.width * 16;
		//Debug.Log ("mousePos: " + mousePos);

		//Set new mouse X position
		paddlePos.x = Mathf.Clamp(mousePos, 0.8f, 15.2f);

		//Change paddle to match new X position
		this.transform.position = paddlePos;
	}

	//OnCollisionEnter will only be called when one of the colliders has a rigidbody
	void OnCollisionEnter2D(Collision2D col){
		//Change the sound pitch if a slowdown powerup has been picked up
		GetComponent<AudioSource>().pitch = Time.timeScale;

		//Play it once for this collision hit
		GetComponent<AudioSource>().PlayOneShot(Sound);
	}
}
