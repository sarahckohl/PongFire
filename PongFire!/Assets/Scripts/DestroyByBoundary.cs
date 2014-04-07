using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

	void OnTriggerExit2D(Collider2D other) {
		// Destroy anything that exits the boundary
		Destroy (other.gameObject);
	}
}
