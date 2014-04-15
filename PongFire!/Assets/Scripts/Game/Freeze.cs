using UnityEngine;
using System.Collections;

public class Freeze : MonoBehaviour {
	
	// Lets us check if game is frozen
	public bool frozen = false;
	
	// Stores original values if game is paused
	private float originalAV;
	private Vector2 originalV;
	
	void Update() {
		if (Input.GetKey("p")) {
			freeze ();
		}
	}
	
	// Freezes game, saving values if to be resumed again
	public void freeze() {
		frozen = true;
		originalAV = rigidbody2D.angularVelocity;
		originalV = rigidbody2D.velocity;
		
		rigidbody2D.angularVelocity = 0;
		rigidbody2D.velocity = new Vector2(0.0f, 0.0f);
	}
	
	// Unfreezes game, resuming original state
	public void unFreeze() {
		frozen = false;
		
		rigidbody2D.angularVelocity = originalAV;
		rigidbody2D.velocity = originalV;
	}
}
