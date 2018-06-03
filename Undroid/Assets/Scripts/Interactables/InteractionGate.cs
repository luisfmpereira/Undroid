using System.Collections;
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
	public Sprite green;
	public GameObject button;
	private GameObject player;

	void Update(){
		interacted = Input.GetButtonDown ("Fire1");
		if (gateTriggered)
			gate.transform.position = Vector3.MoveTowards (gate.transform.position, endPoint.position, speed*Time.deltaTime);

		if(useFocus)
			FocusCameraOnPOI ();

	}

	void OnTriggerStay2D (Collider2D hit){
		if(hit.gameObject.tag == "Player" && interacted == true){
			if (!gateTriggered) {
				if(useFocus)
				cam.GetComponent<CameraFollow> ().isWorking = false;
				focusCamera = true;
				focusCounter = focusTime;
				button.gameObject.GetComponent<SpriteRenderer> ().sprite = green;

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
	public float camMoveSpeed = 10;

	public bool useFocus = true;


	void Awake(){
		cam = GameObject.FindGameObjectWithTag ("MainCamera");
		player = GameObject.FindGameObjectWithTag ("Player");
	}

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
