using UnityEngine;
using System.Collections;

public class Freeze : MonoBehaviour {
	
	// Lets us check if game is frozen
	public bool frozen = false;
	
	// Stores original values if game is paused
	private float originalAV;
	private Vector2 originalV;
	
	// Freezes game, saving values if to be resumed again
	public void freeze() {
		frozen = true;
		originalAV = GetComponent<Rigidbody2D>().angularVelocity;
		originalV = GetComponent<Rigidbody2D>().velocity;
		
		GetComponent<Rigidbody2D>().angularVelocity = 0;
		GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
	}
	
	// Unfreezes game, resuming original state
	public void unFreeze() {
		frozen = false;
		
		GetComponent<Rigidbody2D>().angularVelocity = originalAV;
		GetComponent<Rigidbody2D>().velocity = originalV;
	}
}
