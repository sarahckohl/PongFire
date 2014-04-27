using UnityEngine;
using System.Collections;

public class AmmoTracker : MonoBehaviour {
	
	// Whether it's left or right paddle
	public bool bluePaddle;
	public PaddleControlBlue blue;
	public PaddleControlRed red;
	
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
			stash = "∞"; //Mathf.Infinity.ToString();
			if (!ApplicationModel.reload) {
				mag = "∞"; //Mathf.Infinity.ToString();
			} else {
				if (bluePaddle) mag = blue.ammoInMag.ToString();
				else mag = red.ammoInMag.ToString();
			}
		} else {
			stash = stashed.ammoInStash.ToString();
			if (!ApplicationModel.reload) {
				mag = stash;
			} else {
				if (bluePaddle) mag = blue.ammoInMag.ToString();
				else mag = red.ammoInMag.ToString();
			}
		}
		
		updateText ();
	}
	
	// Updates Text to reflect the ammo
	void updateText() {
		GetComponent<TextMesh>().text = mag + "/" + stash;
	}
}
