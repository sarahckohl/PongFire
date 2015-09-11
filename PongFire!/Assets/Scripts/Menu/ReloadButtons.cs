﻿using UnityEngine;
using System.Collections;

public class ReloadButtons : MonoBehaviour {
	
	// We set the value this button should have
	public bool reload;


	// So we can go back to our base color
	private Color baseColor;
	
	// So we know that mouse is over object
	private bool hover;
	
	// Use this for initialization
	void Start () {
		baseColor = GetComponent<Renderer>().material.color;
	}
	
	void FixedUpdate() {
		if (ApplicationModel.reload == reload || hover) GetComponent<Renderer>().material.color = Color.blue;
		else GetComponent<Renderer>().material.color = baseColor;
	}
	
	void OnMouseEnter() {
		if (ApplicationModel.reload != reload) GetComponent<Renderer>().material.color = Color.blue;
		hover = true;
	}
	
	void OnMouseExit() {
		if (ApplicationModel.reload != reload) GetComponent<Renderer>().material.color = baseColor;
		hover = false;
	}
	
	void OnMouseUp() {
		ApplicationModel.reload = reload;
	}


		
}
