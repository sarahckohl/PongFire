using UnityEngine;
using System.Collections;

public class PaddleButtons : MonoBehaviour {
	
	// We set the value this button should have
	public bool arcButton;
	
	// So we can go back to our base color
	private Color baseColor;
	
	// So we know that mouse is over object
	private bool hover;
	
	// Use this for initialization
	void Start () {
		baseColor = renderer.material.color;
	}
	
	void FixedUpdate() {
		if (ApplicationModel.isArc == arcButton || hover) renderer.material.color = Color.blue;
		else renderer.material.color = baseColor;
	}
	
	void OnMouseEnter() {
		if (ApplicationModel.isArc != arcButton) renderer.material.color = Color.blue;
		hover = true;
	}
	
	void OnMouseExit() {
		if (ApplicationModel.isArc != arcButton) renderer.material.color = baseColor;
		hover = false;
	}
	
	void OnMouseUp() {
		ApplicationModel.isArc = arcButton;
	}
}
