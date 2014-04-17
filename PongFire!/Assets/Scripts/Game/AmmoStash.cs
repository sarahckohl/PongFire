using UnityEngine;
using System.Collections;

public class AmmoStash : MonoBehaviour {

	// Number of ammo it has
	public int ammoInStash;
	
	// Use this for initialization
	void Awake() {
		// If not inifite bullets, put initial num of bullets in
		ammoInStash = 28;
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		// If bullet enters, do something
		if (other.tag == "Bullet") {
			if (!ApplicationModel.infinite) ammoInStash++;
			Destroy (other.gameObject);
		}
	}
}
