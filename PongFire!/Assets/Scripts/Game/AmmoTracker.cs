using UnityEngine;
using System.Collections;

public class AmmoTracker : MonoBehaviour {
	
	// Whether it's left or right paddle
	public bool leftPaddle;
	public PaddleControlLeft left;
	public PaddleControlRight right;
	
	// Ammo stash, to see how much ammo is in it
	public AmmoStash stashed;
	
	// Values to print
	private string stash, mag;
	
	void Start() {
		updateAmmo ();
	}
	
	// Updates ammo text
	public void updateAmmo() {
		if (ApplicationModel.infinite) {
			stash = Mathf.Infinity.ToString();
			if (!ApplicationModel.reload) {
				mag = Mathf.Infinity.ToString();
			} else {
				if (leftPaddle) mag = left.ammoInMag.ToString();
				else mag = right.ammoInMag.ToString();
			}
		} else {
			stash = stashed.ammoInStash.ToString();
			if (!ApplicationModel.reload) {
				mag = stash;
			} else {
				if (leftPaddle) mag = left.ammoInMag.ToString();
				else mag = right.ammoInMag.ToString();
			}
		}
		
		updateText ();
	}
	
	// Updates Text to reflect the ammo
	void updateText() {
		GetComponent<TextMesh>().text = mag + "/" + stash;
	}
}
