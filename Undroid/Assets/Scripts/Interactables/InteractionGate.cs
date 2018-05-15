﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionGate : MonoBehaviour {

	public GameObject gate;
	public Transform endPoint;
	public GameObject cameraPos;
	public float speed = 0.5f;
	public bool gateTriggered = false;
	private bool interacted;
	public Vector2 newmaxXAndY;

	void FixedUpdate(){
		interacted = Input.GetButtonDown ("Fire1");
		if (gateTriggered)
			gate.transform.position = Vector3.MoveTowards (gate.transform.position, endPoint.position, speed*Time.deltaTime);

		if(useFocus)
			FocusCameraOnPOI ();

	}

	void OnTriggerStay2D (Collider2D hit){
		if(hit.gameObject.tag == "Player" && interacted == true){
			if (!gateTriggered) {
				focusCamera = true;
				focusCounter = focusTime;
			}


			gateTriggered = true;
			cameraPos.GetComponent<CameraFollow> ().maxXAndY = newmaxXAndY;
		}

	}


	//focus variables
	public GameObject cam;
	public GameObject focusObject;
	private bool focusCamera = false;
	public float focusTime = 3f;
	private float focusCounter = 0;
	public float camMoveSpeed = 0.5f;

	public bool useFocus = true;


	void Awake(){
		cam = GameObject.FindGameObjectWithTag ("MainCamera");
	}

	void FocusCameraOnPOI(){

		//camera focusing on POI
		if (focusCamera) {
			cam.transform.position = Vector3.MoveTowards( cam.transform.position, new Vector3(focusObject.transform.position.x, focusObject.transform.position.y, -10), camMoveSpeed);
			focusCounter -= Time.deltaTime;
		}

		if (focusCounter <= 0 && focusCamera) {
			
			cam.transform.position = Vector3.MoveTowards( cam.transform.position, new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x, GameObject.FindGameObjectWithTag("Player").transform.position.y, -10), camMoveSpeed);
			focusCamera = false;
		}


	}



}
