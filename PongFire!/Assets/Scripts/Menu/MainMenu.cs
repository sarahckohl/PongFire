using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public int level;
	
	private enum MenuID {MainMenu, HowToPlay}
	
	private MenuID currentMenu = MenuID.MainMenu;

	public Texture2D startImage;
	public Texture2D howImage;
	public Texture2D mainMenuImage;
	public Texture2D instructions;
	
	// Use this for initialization
	void Start () {
		
	}
	
	void OnGUI() {
		switch (currentMenu) {
		case MenuID.MainMenu :
			//Main Menu is showing
			if(GUI.Button (new Rect(Screen.width/2 - 100, Screen.height - 300, 200, 100), startImage)) {
				Application.LoadLevel(level);
			}
			if(GUI.Button (new Rect(Screen.width/2 - 100, Screen.height - 150, 200, 100), howImage)) {
				currentMenu = MenuID.HowToPlay;
			}
			break;
		case MenuID.HowToPlay:
			GUI.Label (new Rect(15, 0, Screen.width, Screen.height), instructions);
			if(GUI.Button (new Rect(Screen.width/2 - 100, Screen.height - 150, 200, 100), mainMenuImage)) {
				currentMenu = MenuID.MainMenu;
			}
			break;
		}
	}

}
