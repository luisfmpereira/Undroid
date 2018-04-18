using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D hit){

		if (hit.gameObject.CompareTag ("Box")) {
			GameObject.FindGameObjectWithTag("Platform").GetComponent<PlatformButton> ().ispressed = true;
		


		} else {
			GameObject.FindGameObjectWithTag("Platform").GetComponent<PlatformButton> ().ispressed = false;
		}

	}
}
