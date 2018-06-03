using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionButtonManager : MonoBehaviour {
	public GameObject platform;
	private bool interacted;
	public Sprite green;
	private AudioManager audiomanager;
	private GameObject player;


	void Awake(){
		cam = GameObject.FindGameObjectWithTag ("MainCamera");
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Start(){
		audiomanager = AudioManager.instance;
	}
	void Update () {
		interacted = Input.GetButtonDown ("Fire1");

		if(useFocus)
			FocusCameraOnPOI ();
	}

	void OnTriggerStay2D (Collider2D hit)
	{
		if (hit.gameObject.tag == "Player" && interacted == true) {
			if (!platform.GetComponent<MovingPlatformManager> ().isPressed) {
				audiomanager.PlaySound ("MovingPlatformOn");
				if(useFocus)
				cam.GetComponent<CameraFollow> ().isWorking = false;
				focusCamera = true;
				focusCounter = focusTime;
				gameObject.GetComponent<SpriteRenderer> ().sprite = green;
			}

			platform.GetComponent<MovingPlatformManager> ().isPressed = true;
		}
	}



	//focus variables
	public GameObject cam;
	public GameObject focusObject;
	private bool focusCamera = false;
	public float focusTime = 2f;
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
