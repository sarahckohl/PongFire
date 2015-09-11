using UnityEngine;
using System.Collections;

public class ForcefieldSound : MonoBehaviour {
	
	public bool blueGoal;
	
	public float pushBack;
	
	void OnTriggerEnter2D(Collider2D collisionInfo) {
		if (blueGoal) {
			if (collisionInfo.gameObject.name == "Blue Puck") {
				GetComponent<AudioSource>().Play ();
				collisionInfo.GetComponent<Rigidbody2D>().AddForce(new Vector2(pushBack, 0.0f));
			}
		} else {
			if (collisionInfo.gameObject.name == "Red Puck") {
				GetComponent<AudioSource>().Play ();
				collisionInfo.GetComponent<Rigidbody2D>().AddForce(new Vector2(-pushBack, 0.0f));
			}
		}		
	}
}
