﻿using UnityEngine;
using System.Collections;

public class RestartLevel : MonoBehaviour {
	public Texture2D restartImage;
	/*
	// So we can go back to our base color
	private Color baseColor;
	
	// Sets base color based on original text color
	void Start() {
		baseColor = renderer.material.color;
	}
	
	// Changes the color of button when mouse enters
	void OnMouseEnter() {
		renderer.material.color = Color.blue;
	}
	
	// Changes color back to base when mouse is not in button anymore
	void OnMouseExit() {
		renderer.material.color = baseColor;
	}
	
	// Change button back to other color once pressed and loads level
	// May not be neccessary to change color
	void OnMouseUp() {
		renderer.material.color = baseColor;
		Application.LoadLevel(Application.loadedLevel);
	}
	
	// Not neccesary for this, but may come into play for fancier buttons
	void OnMouseDown() {
		renderer.material.color = Color.blue;
	}
*/


	void OnGUI() {
		if (WinMenu.showMenu == true) {
			if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2, 200, 100), restartImage)) {
				WinMenu.showMenu = false;
				Application.LoadLevel (2);
			}
		}
	}

}
