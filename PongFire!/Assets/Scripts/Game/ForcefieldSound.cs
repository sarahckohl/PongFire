using UnityEngine;
using System.Collections;

public class ForcefieldSound : MonoBehaviour {
	
	public bool blueGoal;
	
	void OnCollisionEnter2D(Collision2D collisionInfo) {
		if (blueGoal) {
			if (collisionInfo.gameObject.name == "Blue Puck") {
				audio.Play ();
			}
		} else {
			if (collisionInfo.gameObject.name == "Red Puck") {
				audio.Play ();
			}
		}		
	}
}
