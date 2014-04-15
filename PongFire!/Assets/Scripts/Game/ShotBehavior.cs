using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour {
	// Variable to set rotation and shot speed
	public float rotSpeed, speed;

	// Use this for initialization
	void Start () {
		// Gives the shot a rotation
		rigidbody2D.angularVelocity = rotSpeed;

		// Gives forward velocity to shot when fired
		rigidbody2D.velocity = transform.right * speed;
	}
}
