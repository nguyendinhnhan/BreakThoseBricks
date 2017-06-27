using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(AudioSource), typeof(Collider2D))]
public class BasePowerUp : MonoBehaviour {

	public float DropSpeed = 1; //How fast does it drop?
	public AudioClip Sound; //Sound played when the powerup is picked up

	// Use this for initialization
	void Start () {
		GetComponent<AudioSource>().playOnAwake = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator OnTriggerEnter2D(Collider2D other)
	{
		//Only interact with the paddle
		if (other.name == "Paddle")
		{
			//Notify the derived powerups that its being picked up
			OnPickup();

			//Disable further collisions
			GetComponent<Collider2D>().enabled = false;
			GetComponent<Renderer>().enabled = false;

			//Change the sound pitch
			GetComponent<AudioSource>().pitch = Time.timeScale;

			//Play audio and wait
			GetComponent<AudioSource>().PlayOneShot(Sound);
			yield return new WaitForSeconds(Sound.length);
		}
	}

	//Every powerup which derives from this class should implement this.
	protected virtual void OnPickup()
	{

	}
}
