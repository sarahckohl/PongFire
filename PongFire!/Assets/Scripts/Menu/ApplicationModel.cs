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
	// 0: infinite
	// 1: destroy after collision
	// 2: limited
	public static int bulletMode = 0;
}
