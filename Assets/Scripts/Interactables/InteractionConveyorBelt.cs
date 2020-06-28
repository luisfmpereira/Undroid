using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionConveyorBelt : MonoBehaviour {
	public GameObject conveyorBelt;
	private bool interacted = false;
	public Sprite green;
	private GameObject player;




	void Update(){
		//checks if player has pressed button
		interacted = Input.GetButton ("Fire1");

		if(useFocus)
			FocusCameraOnPOI ();

	}

	void OnTriggerStay2D (Collider2D hit){
		if (hit.gameObject.CompareTag ("Player") && interacted) {

			//set camera focus for the first time
			if (!conveyorBelt.GetComponent<ConveyorController> ().isrunning) {
				if(useFocus)
				cam.GetComponent<CameraFollow> ().isWorking = false;
				gameObject.GetComponent<SpriteRenderer> ().sprite = green;
				focusCamera = true;
				focusCounter = focusTime;

				}

			//activate conveyor belt
			conveyorBelt.GetComponent<ConveyorController> ().isrunning = true;
			conveyorBelt.transform.GetChild (0).GetComponent<turnOnConveyor> ().turnon = true;
			conveyorBelt.transform.GetChild (1).GetComponent<turnOnConveyor> ().turnon = true;

		}
	}

	void Awake(){
		cam = GameObject.FindGameObjectWithTag ("MainCamera");
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	//focus variables
	public GameObject cam;
	public GameObject focusObject;
	private bool focusCamera = false;
	public float focusTime = 5f;
	private float focusCounter = 0;
	public float camMoveSpeed = 10;

	public bool useFocus = true;

	void FocusCameraOnPOI(){

		//camera focusing on POI
		if (focusCamera) {
			cam.transform.position = Vector3.MoveTowards( cam.transform.position, new Vector3(focusObject.transform.position.x, focusObject.transform.position.y, -10), camMoveSpeed * Time.deltaTime);
			focusCounter -= Time.deltaTime;
			player.GetComponent<PlayerController> ().canMove = false;
		}

		if (focusCounter <= 0 && focusCamera) {
			cam.transform.position = Vector3.MoveTowards( cam.transform.position, new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x, GameObject.FindGameObjectWithTag("Player").transform.position.y, -10), camMoveSpeed * Time.deltaTime);
			focusCamera = false;
			cam.GetComponent<CameraFollow> ().isWorking = true;
			player.GetComponent<PlayerController> ().canMove = true;
		}


	}
}
