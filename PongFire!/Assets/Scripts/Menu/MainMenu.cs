using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public int level;
	
	private enum MenuID {MainMenu, HowToPlay}
	
	private MenuID currentMenu = MenuID.MainMenu;
	
	private string playInstructions = "PongFire! is a PvP game where the goal is for each players to shoot their puck into the opponent's goal using bullets. \n" +
		"Each player uses the same keyboard. Whoever gets their puck into the opponent's goal first wins the game!\n\n" +
			"Controls for Player 1 are: \n" +
			"W to Move Up, S to Move Down\n" +
			"D to fire bullets, A to Reload\n" +
			"\n" +
			"Controls for Player 2 are: \n" +
			"I to Move Up, K to Move Down\n" +
			"J to fire bullets, L to reload\n" +
			"\n";
	
	// Use this for initialization
	void Start () {
		
	}
	
	void OnGUI() {
		switch (currentMenu) {
		case MenuID.MainMenu :
			//Main Menu is showing
			if(GUI.Button (new Rect(Screen.width/2 - 150, Screen.height - 150, 100, 50), "START")) {
				Application.LoadLevel(level);
			}
			if(GUI.Button (new Rect(Screen.width/2 + 150, Screen.height - 150, 100, 50), "HOWTOPLAY")) {
				currentMenu = MenuID.HowToPlay;
			}
			break;
		case MenuID.HowToPlay:
			GUI.Label (new Rect(0,0, Screen.width, Screen.height / 3), playInstructions);
			if(GUI.Button (new Rect(Screen.width/2 - 50, Screen.height - 150, 100, 50), "MAINMENU")) {
				currentMenu = MenuID.MainMenu;
			}
			break;
		}
	}

}
