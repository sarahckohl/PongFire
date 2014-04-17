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
	
	// The movement the paddle will follow
	private bool arcPaddle;
	
	// Used for horizontal movement and arc
	public float maxX, arcValue;
	private float baseX;
	
	// Reload variables
	private int startingAmmo, ammoPerClip;

	void Start() {
		arcPaddle = ApplicationModel.isArc;
		baseX = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (!freezeScript.frozen) {
			if ((Input.GetKey ("d")) && 
		    			Time.time > nextfire) {
				nextfire = Time.time + firerate;
				Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			}
		
			straightMovement();
		
			// Sets the paddles position to its max when it passes the border
			if (transform.position.y > yMax) {
				transform.position = new Vector3(transform.position.x, yMax, transform.position.z);
			} else if (transform.position.y < yMin) {
				transform.position = new Vector3(transform.position.x, yMin, transform.position.z);
			}
			
			if (arcPaddle) {
				arcPosition();
			}
		}
	}
	
	// For moving paddle up and down
	void straightMovement() {
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
	}
	
	// Gives the paddle an arcing motion
	void arcPosition() {
		float arcPercent = Mathf.Abs(transform.position.y)/yMax;
		
		transform.rotation = Quaternion.Euler (0, 0, arcValue * Mathf.Sin(transform.position.y/yMax));
		
		// Uses cos to achieve the arc, -1 to get an accurate position
		transform.position = new Vector3(baseX + Mathf.Cos(maxX*arcPercent) - 1, transform.position.y, transform.position.z);
	}
}