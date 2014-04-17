using UnityEngine;
using System.Collections;

public class Puck : MonoBehaviour {
	
	// Which puck is it
	public bool rightPuck;
	
	// Used to pause game when victory is met
	public FreezeGame freezeScript;
	
	// Performs action when Collision happens
	void OnCollisionEnter2D(Collision2D collisionInfo) {
		if (rightPuck) {
			if (collisionInfo.gameObject.tag == "Left Goal") {
				freezeScript.freezeObjects("Right Wins");
			}
		} else {
		 	if (collisionInfo.gameObject.tag == "Right Goal") {
				freezeScript.freezeObjects("Left Wins");
		 	}
		 }		
	}
}
