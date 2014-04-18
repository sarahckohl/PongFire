using UnityEngine;
using System.Collections;

public class AmmoStash : MonoBehaviour {

	// Number of ammo it has
	public int ammoInStash;
	
	// To update ammo text
	public AmmoTracker track;
	
	// Use this for initialization
	void Awake() {
		// If not inifite bullets, put initial num of bullets in
		ammoInStash = ApplicationModel.numberOfBullets;
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		// If bullet enters, do something
		if (other.tag == "Bullet") {
			if (other.gameObject.GetComponent<ShotBehavior>().timeMade + .5 < Time.time) {
				if (!ApplicationModel.infinite)  {
					ammoInStash++;
					track.updateAmmo();
				}
				Destroy (other.gameObject);
			}
		}
	}
}
