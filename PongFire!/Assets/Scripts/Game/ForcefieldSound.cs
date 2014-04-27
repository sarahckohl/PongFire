using UnityEngine;
using System.Collections;

public class ForcefieldSound : MonoBehaviour {
	
	public bool blueGoal;
	
	public float pushBack;
	
	void OnTriggerEnter2D(Collider2D collisionInfo) {
		if (blueGoal) {
			if (collisionInfo.gameObject.name == "Blue Puck") {
				audio.Play ();
				collisionInfo.rigidbody2D.AddForce(new Vector2(pushBack, 0.0f));
			}
		} else {
			if (collisionInfo.gameObject.name == "Red Puck") {
				audio.Play ();
				collisionInfo.rigidbody2D.AddForce(new Vector2(-pushBack, 0.0f));
			}
		}		
	}
}
