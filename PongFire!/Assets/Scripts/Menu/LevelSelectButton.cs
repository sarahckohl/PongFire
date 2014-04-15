using UnityEngine;
using System.Collections;

public class LevelSelectButton : MonoBehaviour {
	
	// Public variable so we can set level to go to in editor
	public int level;
	
	// So we can go back to our base color
	private Color baseColor;
	
	void Start() {
		baseColor = renderer.material.color;
	}
	
	void OnMouseEnter() {
		renderer.material.color = Color.blue;
	}
	
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
}
