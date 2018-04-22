using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformUp : MonoBehaviour {

	public GameObject platform;

	void OnTriggerEnter2D(Collider2D hit){

		if (hit.gameObject.CompareTag ("Player")) {

			platform.GetComponent<BoxCollider2D> ().isTrigger = true;
		}

	}
	void OnTriggerExit2D (Collider2D hit){

		if (hit.gameObject.CompareTag ("Player")) {

			platform.GetComponent<BoxCollider2D> ().isTrigger = false;
		}
	}
}
