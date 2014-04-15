using UnityEngine;
using System.Collections;

public class FreezeGame : MonoBehaviour {
	
	// Freezes all objects in game
	void freezeObjects() {
		// Gets all freezable objects currently in game
		Freeze[] freezableObjects = FindObjectsOfType(typeof(Freeze)) as Freeze[];
		
		// Goes through and calls their freeze script
		foreach (Freeze freeze in freezableObjects)
			freeze.freeze();
	}
	
	// Unfreezes all objects in game
	void unFreeze() {
		// Gets all freezable objects currently in game
		Freeze[] freezableObjects = FindObjectsOfType(typeof(Freeze)) as Freeze[];
		
		// Goes through and calls their unfreeze script
		foreach (Freeze freeze in freezableObjects)
			freeze.unFreeze();
	}
}
