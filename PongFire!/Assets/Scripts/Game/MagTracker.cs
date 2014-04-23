using UnityEngine;
using System.Collections;

public class MagTracker : MonoBehaviour {
	
	public Sprite[] magSprite;
	
	void Start() {
		updateAmmo (5);
	}
	
	// Updates ammo text
	public void updateAmmo(int ammoInMag) {
		if (ApplicationModel.reload) {
			GetComponent<SpriteRenderer>().sprite = magSprite[ammoInMag];
		} else {
			GetComponent<SpriteRenderer>().sprite = magSprite[5];
		}
	}
}
