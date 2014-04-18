using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour {
	public float timeMade;

	// Variable to set rotation and shot speed
	public float rotSpeed, speed;

	// Use this for initialization
	void Start () {
		// Allows us to know when the object was made
		timeMade = Time.time;
	
		// Gives the shot a rotation
		rigidbody2D.angularVelocity = rotSpeed;

		// Gives forward velocity to shot when fired
		rigidbody2D.velocity = transform.right * speed;
	}
}
