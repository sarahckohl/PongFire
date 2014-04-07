﻿using UnityEngine;
using System.Collections;

public class PaddleControlRight : MonoBehaviour {

	// Speed that paddle moves
	public float speed;

	// Boundary variables
	public float yMin, yMax;

	// Firing variables
	public GameObject shot;		// Shots to be fired
	public Transform shotSpawn;	// Orientation of how the shot should be fired
	public float firerate;		// Limits the number of shots in a timeframe
	private float nextfire;		// Tracker for limit

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetKey ("u") || Input.GetKey ("o")) && 
		    		Time.time > nextfire) {
			nextfire = Time.time + firerate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		}

		// Moves paddle when key is pressed or held down
		if (Input.GetKeyDown ("i")) {
			rigidbody2D.velocity = new Vector2(0.0f, speed);
		} else if (Input.GetKeyDown ("k")) {
			rigidbody2D.velocity = new Vector2(0.0f, -speed);
		}

		// Stops the paddle when key isn't held down anymore
		if (Input.GetKeyUp ("i") || Input.GetKeyUp ("k")) {
			rigidbody2D.velocity = new Vector2 (0.0f, 0.0f);
		}

		// Sets the paddles position to its max when it passes the border
		if (transform.position.y > yMax) {
			transform.position = new Vector2(transform.position.x, yMax);
		} else if (transform.position.y < yMin) {
			transform.position = new Vector2(transform.position.x, yMin);
		}
	}
}