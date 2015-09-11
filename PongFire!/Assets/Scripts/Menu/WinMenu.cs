using UnityEngine;
using System.Collections;

public class WinMenu : MonoBehaviour {
	public static bool showMenu = false;
	// Array of texts, used to show or hide text
	public GameObject text;

	// Array of button, used to show or hide text
	public GameObject[] buttons = new GameObject[1];
	
	// Shows all the text and buttons
	public void show(string winner) {
		showMenu = true;
		// Text
		text.GetComponent<Renderer>().enabled = true;
		
		// Change Text to reflect what we need
		text.GetComponent<TextMesh>().text = winner;
		
		// Buttons
		foreach(GameObject obj in buttons) {
			obj.GetComponent<Renderer>().enabled = true;
			//obj.collider2D.enabled = true;
		}
	}
	
	// Hides all the text and buttons
	public void hide() {
		showMenu = false;
		// Text
		text.GetComponent<Renderer>().enabled = false;
		
		// Buttons
		foreach(GameObject obj in buttons) {
			obj.GetComponent<Renderer>().enabled = false;
			obj.GetComponent<Collider2D>().enabled = false;
		}
	}
}
