using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionConveyorBelt : MonoBehaviour {
	public GameObject conveyorBelt;
	private bool interacted = false;




	void FixedUpdate(){
		//checks if player has pressed button
		interacted = Input.GetButtonDown ("Fire1");

		if(useFocus)
			FocusCameraOnPOI ();

	}

	void OnTriggerStay2D (Collider2D hit){
		if (hit.gameObject.CompareTag ("Player") && interacted) {

			//set camera focus for the first time
			if (!conveyorBelt.GetComponent<ConveyorController> ().isrunning) {
				focusCamera = true;
				focusCounter = focusTime;
			}

			//activate conveyor belt
			conveyorBelt.GetComponent<ConveyorController> ().isrunning = true;

		}
	}

	void Awake(){
		cam = GameObject.FindGameObjectWithTag ("MainCamera");
	}

	//focus variables
	public GameObject cam;
	public GameObject focusObject;
	private bool focusCamera = false;
	public float focusTime = 5f;
	private float focusCounter = 0;
	public float camMoveSpeed = 0.5f;

	public bool useFocus = true;

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
