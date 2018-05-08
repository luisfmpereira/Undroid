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
		//test if player is crouching
		if (Input.GetButtonDown ("S") || Input.GetButtonDown ("Fire1"))  {
			dropCounter++;
		}



		//start timer if player has started dropping routine
		if(dropCounter>0)
			dropTimer -= Time.deltaTime;

		//reset dropping routine 
		if (dropTimer <= 0) {
			dropCounter = 0;
			dropTimer = maxDropTimer;
		}


	}

	void OnTriggerStay2D(Collider2D hit){

		if (hit.gameObject.CompareTag ("Player") && dropCounter >= 2 ){

			platform.GetComponent<BoxCollider2D> ().enabled = false;

			dropCounter = 0;
		}

	}


}
