using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDrop : MonoBehaviour {

	public GameObject platform;

	public int dropCounter = 0;
	public float dropTimer;
	public float maxDropTimer = 0.5f;

	void Awake(){

		dropTimer = maxDropTimer;
	}


	void Update(){
		if (Input.GetButtonDown ("S")) {

			dropCounter++;


		}

		if(dropCounter>0)
			dropTimer -= Time.deltaTime;

		if (dropTimer <= 0) {
			dropCounter = 0;
			dropTimer = maxDropTimer;
		}


	}

	void OnTriggerStay2D(Collider2D hit){

		if ((hit.gameObject.CompareTag ("Player") && Input.GetKey (KeyCode.Space) && Input.GetKey (KeyCode.LeftControl)) || dropCounter >= 2 ){

			platform.GetComponent<BoxCollider2D> ().enabled = false;

			dropCounter = 0;
		}

	}


}
