using UnityEngine;
using System.Collections;

public class PaddleControlLeft : MonoBehaviour {
	
	// Speed that paddle moves
	public float speed;
	
	// Boundary variables
	public float yMin, yMax;
	
	// Firing variables
	public GameObject shot;		// Shots to be fired
	public Transform shotSpawn;	// Orientation of how the shot should be fired
	public float firerate;		// Limits the number of shots in a timeframe
	private float nextfire;		// Tracker for limit
	
	// Script to check if game should be paused
	public Freeze freezeScript;

	// Update is called once per frame
	void Update () {
		if (!freezeScript.frozen) {
			if ((Input.GetKey ("q") || Input.GetKey ("e")) && 
		    			Time.time > nextfire) {
				nextfire = Time.time + firerate;
				Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			}
		
			// Moves paddle when key is pressed or held down
			if (Input.GetKey ("w")) {
				rigidbody2D.velocity = new Vector2(0.0f, speed);
			} else if (Input.GetKey ("s")) {
				rigidbody2D.velocity = new Vector2(0.0f, -speed);
			}
		
			// Stops the paddle when key isn't held down anymore
			if (Input.GetKeyUp ("w") || Input.GetKeyUp ("s")) {
				rigidbody2D.velocity = new Vector2 (0.0f, 0.0f);
			}
		
			// Sets the paddles position to its max when it passes the border
			if (transform.position.y > yMax) {
				transform.position = new Vector3(transform.position.x, yMax, transform.position.z);
			} else if (transform.position.y < yMin) {
				transform.position = new Vector3(transform.position.x, yMin, transform.position.z);
			}
		}
	}
}