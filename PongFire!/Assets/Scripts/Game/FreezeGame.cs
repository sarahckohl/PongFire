using UnityEngine;
using System.Collections;

public class FreezeGame : MonoBehaviour {
	
	// Used to show menu
	public WinMenu menu;
	
	// Freezes all objects in game
	public void freezeObjects(string text) {
		// Gets all freezable objects currently in game
		Freeze[] freezableObjects = FindObjectsOfType(typeof(Freeze)) as Freeze[];
		
		// Goes through and calls their freeze script
		foreach (Freeze freeze in freezableObjects)
			freeze.freeze();
		
		// Renders the transparent foreground
		renderer.enabled = true;
		
		// Shows text
		menu.show (text);
	}
	
	// Unfreezes all objects in game
	public void unFreeze() {
		// Gets all freezable objects currently in game
		Freeze[] freezableObjects = FindObjectsOfType(typeof(Freeze)) as Freeze[];
		
		// Goes through and calls their unfreeze script
		foreach (Freeze freeze in freezableObjects)
			freeze.unFreeze();
		
		// Disables the transparent foreground
		renderer.enabled = false;
		
		// Hides text
		menu.hide ();
	}
}
