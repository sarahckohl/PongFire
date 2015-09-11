using UnityEngine;
using System.Collections;

public class Puck : MonoBehaviour {
	
	// Which puck is it
	public bool redPuck;
	
	// Used to pause game when victory is met
	public FreezeGame freezeScript;
	
	public Freeze freeze;

	void Update() {
		if(!freeze.frozen) {
			transform.Translate(.01f, 0, 0,Space.Self); // move forward

			if (redPuck) {
				transform.Rotate (Vector3.back, Time.deltaTime * 60, Space.Self);
			} else {
				transform.Rotate (Vector3.forward, Time.deltaTime * 60, Space.Self);
			}
		}
	}

	
	// Performs action when Collision happens
	void OnCollisionEnter2D(Collision2D collisionInfo) {
		GetComponent<AudioSource>().Play();
	
		if (redPuck) {
			if (collisionInfo.gameObject.tag == "Blue Goal") {
				freezeScript.freezeObjects("Red Wins");
			}
		} else {
		 	if (collisionInfo.gameObject.tag == "Red Goal") {
				freezeScript.freezeObjects("Blue Wins");
		 	}
		}		
	}
}
