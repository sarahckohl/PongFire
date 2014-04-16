using UnityEngine;
using System.Collections;

public class Puck : MonoBehaviour {
	
	// Which puck is it
	public bool rightPuck;
	
	// Used to pause game when victory is met
	public FreezeGame freezeScript;
	
	void OnCollisionExit2D(Collision2D collisionInfo) {	
		if (rightPuck) {
			if (collisionInfo.gameObject.tag == "Left Goal") {
				freezeScript.freezeObjects("Right Wins");
				// Debug.Log("Right Wins");
			}
		} else {
		 	if (collisionInfo.gameObject.tag == "Right Goal") {
				freezeScript.freezeObjects("Left Wins");
				// Debug.Log ("Left Wins");
		 	}
		 }		
	}
}
