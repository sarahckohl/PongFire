using UnityEngine;
using System.Collections;

public class Puck : MonoBehaviour {
	
	// Which puck is it
	public bool redPuck;
	
	// Used to pause game when victory is met
	public FreezeGame freezeScript;
	
	// Performs action when Collision happens
	void OnCollisionEnter2D(Collision2D collisionInfo) {
		audio.Play();
	
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
