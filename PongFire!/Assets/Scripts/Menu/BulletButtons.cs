using UnityEngine;
using System.Collections;

public class BulletButtons : MonoBehaviour {
	
	// We set the value this button should have
	public int bullet;
	
	// So we can go back to our base color
	private Color baseColor;
	
	// So we know that mouse is over object
	private bool hover;
	
	// Use this for initialization
	void Start () {
		baseColor = renderer.material.color;
	}
	
	void FixedUpdate() {
		if (ApplicationModel.bulletMode == bullet || hover) renderer.material.color = Color.blue;
		else renderer.material.color = baseColor;
	}
	
	void OnMouseEnter() {
		if (ApplicationModel.bulletMode != bullet) renderer.material.color = Color.blue;
		hover = true;
	}
	
	void OnMouseExit() {
		if (ApplicationModel.bulletMode != bullet) renderer.material.color = baseColor;
		hover = false;
	}
	
	void OnMouseUp() {
		ApplicationModel.bulletMode = bullet;
	}
}
