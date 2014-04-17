using UnityEngine;
using System.Collections;

public class LevelSelectButton : MonoBehaviour {
	
	// Public variable so we can set level to go to in editor
	public int level;
	public Texture2D startImage;
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
		Application.LoadLevel(level);
	}
	
	// Not neccesary for this, but may come into play for fancier buttons
	void OnMouseDown() {
		renderer.material.color = Color.blue;
	}
	*/
	void OnGUI() {

		if(GUI.Button (new Rect(Screen.width/2 - 100, Screen.height - 150, 200, 100), startImage)) {
			Application.LoadLevel(level);
		}
		
	}

}
