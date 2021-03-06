﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocusOnPOI : MonoBehaviour {

	private bool camTriggered = false;
	private GameObject player;
	//focus variables
	public GameObject cam;
	public GameObject focusObject;
	private bool focusCamera = false;
	public float focusTime = 2f;
	private float focusCounter = 0;
	public float camMoveSpeed = 10;

	private float originalCamSize = 5f;
	public float newCamSize = 6f;

	public bool useFocus = true;

	void Awake(){
		cam = GameObject.FindGameObjectWithTag ("MainCamera");
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void FixedUpdate(){

		if(useFocus)
			FocusCameraOnPOI ();
	}



	void OnTriggerStay2D (Collider2D hit){
		if(hit.gameObject.tag == "Player"){
			if (!camTriggered) {
				focusCamera = true;
				focusCounter = focusTime;
			}
				
			camTriggered = true;
		}

	}
		
	void FocusCameraOnPOI(){

		//camera focusing on POI
		if (focusCamera) {
			cam.transform.position = Vector3.MoveTowards( cam.transform.position, new Vector3(focusObject.transform.position.x, focusObject.transform.position.y, -10), camMoveSpeed * Time.deltaTime);
			focusCounter -= Time.deltaTime;
			cam.GetComponent<Camera>().orthographicSize = Mathf.Lerp(originalCamSize,newCamSize,5f);
			player.GetComponent<PlayerController> ().canMove = false;

		}

		if (focusCounter <= 0 && focusCamera) {
			cam.transform.position = Vector3.MoveTowards( cam.transform.position, new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x, GameObject.FindGameObjectWithTag("Player").transform.position.y, -10), camMoveSpeed * Time.deltaTime);
			focusCamera = false;
			cam.GetComponent<Camera>().orthographicSize = Mathf.Lerp(newCamSize,originalCamSize,5f);
			player.GetComponent<PlayerController> ().canMove = true;

		}


	}
}