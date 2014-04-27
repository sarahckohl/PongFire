using UnityEngine;
using System.Collections;

public class Puck : MonoBehaviour {
	
	// Which puck is it
	public bool redPuck;
	
	// Used to pause game when victory is met
	public FreezeGame freezeScript;





	void Update() {


		//float randX = Random.Range (0,.0f);

		transform.Translate(.01f, 0, 0,Space.Self); // move forward

		if (redPuck) {
						transform.Rotate (Vector3.back, Time.deltaTime * 60, Space.Self);
				} else {
						transform.Rotate (Vector3.forward, Time.deltaTime * 60, Space.Self);
				}


		//float randX = Random.Range (0,.05f);
		//float randY = Random.Range (0,.05f);
		//float randZ = Random.Range (0,.01f);

		//transform.Translate(randX, randY, 0,Space.Self);

		//transform.rotation = Quaternion.FromToRotation (Vector3.up, transform.forward);

		//transform.Rotate(Vector3.forward,Time.deltaTime*60,Space.Self); // turn a little

		//transform.Rotate (Vector3.forward, Time.deltaTime * 90, Space.World);
	}

	
	// Performs action when Collision happens
	void OnCollisionEnter2D(Collision2D collisionInfo) {
		audio.Play();
	
		if (redPuck) {
			if (collisionInfo.gameObject.tag == "Blue Goal") {
				freezeScript.freezeObjects("Red Wins");
			}
		} else {
		 	if (collisionInfo.gameObject.tag == "Red Goal") {
				freezeScript.freezeObjects("Blue Wins");
		 	}
		}		
	}
}
