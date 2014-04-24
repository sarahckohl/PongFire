using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour {
	public float timeMade;
	
	public Sprite[] bulletSprite;
	public float lifeTime;	// Time before it loses power

	// Variable to set rotation and shot speed
	public float rotSpeed, speed;

	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer>().sprite = bulletSprite[0];
	
		// Allows us to know when the object was made
		timeMade = Time.time;
	
		// Gives the shot a rotation
		rigidbody2D.angularVelocity = rotSpeed;

		// Gives forward velocity to shot when fired
		rigidbody2D.velocity = transform.right * speed;
	}
	
	void Update() {
		if (timeMade + lifeTime < Time.time) {
			GetComponent<SpriteRenderer>().sprite = bulletSprite[1];
			gameObject.layer = LayerMask.NameToLayer("Powerless Bullet");
			rigidbody2D.angularVelocity = rotSpeed/2;
			rigidbody2D.velocity = new Vector2((transform.position.x/Mathf.Abs(transform.position.x)) * speed/2, rigidbody2D.velocity.y/2);
		}
	}
}
