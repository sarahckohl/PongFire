using UnityEngine;
using System.Collections;

// This is used to keep values between levels
public class ApplicationModel : MonoBehaviour {
	// Reload based
	public static bool reload = false;
	
	// The bullets mode
	// Whether there are infinite bulletes in the game or a limited number
	public static bool infinite = true;
	
	// Number of bullets in clip and in game if reload and limited
	public static int ammoPerClip = 5;
	public static int numberOfBullets = 20;
	public static float reloadTime = 1;
	
	void Awake() {
		GetComponent<AudioSource>().Play();
		DontDestroyOnLoad(gameObject);
	}
}
