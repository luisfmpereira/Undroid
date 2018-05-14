using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformUp : MonoBehaviour {
	public GameObject platform;


	private void OnTriggerEnter2D(Collider2D hit){

		if (hit.gameObject.CompareTag ("Player")) {

			platform.GetComponent<BoxCollider2D> ().enabled = false;

		}
	}

	private void OnTriggerExit2D (Collider2D hit){

		if (hit.gameObject.CompareTag ("Player")) {

			platform.GetComponent<BoxCollider2D> ().enabled = true;

		}
	}




}
