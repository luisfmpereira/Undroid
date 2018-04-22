using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDrop : MonoBehaviour {

	public GameObject platform;
	public GameObject player;


	void onTriggerStay2D(Collider2D hit){

		if (hit.gameObject.CompareTag ("Player") && player.GetComponent<PlayerController>().isJumping && player.GetComponent<PlayerController>().isCrouching) {

			print ("aqui");

			platform.GetComponent<BoxCollider2D> ().isTrigger = true;
		}

	}
}
