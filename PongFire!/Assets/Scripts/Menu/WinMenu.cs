using UnityEngine;
using System.Collections;

public class WinMenu : MonoBehaviour {

	// Array of texts, used to show or hide text
	public GameObject text;

	// Array of button, used to show or hide text
	public GameObject[] buttons = new GameObject[1];
	
	// Shows all the text and buttons
	public void show(string winner) {
		// Text
		text.renderer.enabled = true;
		
		// Change Text to reflect what we need
		text.GetComponent<TextMesh>().text = winner;
		
		// Buttons
		foreach(GameObject obj in buttons) {
			obj.renderer.enabled = true;
			obj.collider2D.enabled = true;
		}
	}
	
	// Hides all the text and buttons
	public void hide() {
		// Text
		text.renderer.enabled = false;
		
		// Buttons
		foreach(GameObject obj in buttons) {
			obj.renderer.enabled = false;
			obj.collider2D.enabled = false;
		}
	}
}
