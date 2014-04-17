using UnityEngine;
using System.Collections;

// This is used to keep values between levels
public class ApplicationModel : MonoBehaviour {
	
	// The paddle mode
	// Whether it should be arcing
	public static bool isArc = false;
	
	// Reload based
	public static bool reload = false;
	
	// The bullets mode
	// Whether there are infinite bulletes in the game or a limited number
	public static bool infinite = false;
}
