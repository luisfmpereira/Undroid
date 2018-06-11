using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogueBoxScript : MonoBehaviour {
	
	public string [] textsToDisplay;
	private int currentText;
	public GameObject dialogueBox;
	private Text dialogueText;
	private float textTimer;
	public float maxTextTimer = 3f;
	public GameObject player;
	private bool isShowing;

	//final decision only
	public bool finalDecision = false;
	public GameObject decisionPanel;
	public GameObject joinButton;


	private bool camTriggered = false;
	//focus variables
	public GameObject cam;
	public GameObject focusObject;
	private bool focusCamera = false;
	public float camMoveSpeed = 10;

	private float originalCamSize = 5f;
	public float newCamSize = 6f;

	public bool useFocus = true;




	void Awake() {
		currentText = 0;
		dialogueText = dialogueBox.GetComponentInChildren<Text>();

		cam = GameObject.FindGameObjectWithTag ("MainCamera");
		player = GameObject.FindGameObjectWithTag ("Player");


	}

	void FixedUpdate(){

		if(useFocus)
			FocusCameraOnPOI ();
	}

	void Update(){
		if (isShowing)
			textTimer -= Time.deltaTime;

		if (isShowing && (Input.GetButtonDown ("Fire1")||textTimer <= 0)){

			if (textsToDisplay.Length == currentText + 1) {
				dialogueBox.GetComponent<Animator>().SetBool("End",true);
				this.gameObject.SetActive (false);
				isShowing = false;
				if (finalDecision) {
					//set the decision panel active
					decisionPanel.SetActive (true);
					selectJoinButton ();
					PlayerPrefs.SetInt ("Level71", 1);
					PlayerPrefs.SetInt ("Level72", 1);

				}
					
			}
			else {
				currentText++;
				DisplayText (textsToDisplay[currentText]);
			}
		}

	}

	void DisplayText(string text){
		//set new text
		textTimer = maxTextTimer;
		isShowing = true;
		dialogueText.text = text;
		dialogueBox.SetActive (true);
		dialogueBox.GetComponent<Animator>().SetBool("Start",true);

	}


	void OnTriggerEnter2D(Collider2D hit){
		if(hit.gameObject.CompareTag("Player")){
			DisplayText (textsToDisplay[currentText]);
		}
	}

	public void selectJoinButton(){
		//used to reset click on the join button of the final decision
		EventSystem.current.SetSelectedGameObject (joinButton);
	}



	void OnTriggerStay2D (Collider2D hit){
		if(hit.gameObject.CompareTag("Player")){
			if (!camTriggered) {
				focusCamera = true;
			}

			camTriggered = true;
		}

	}

	void FocusCameraOnPOI(){

		//camera focusing on POI
		if (focusCamera) {
			cam.transform.position = Vector3.MoveTowards( cam.transform.position, new Vector3(focusObject.transform.position.x, focusObject.transform.position.y, -10), camMoveSpeed * Time.deltaTime);
			cam.GetComponent<Camera>().orthographicSize = Mathf.Lerp(originalCamSize,newCamSize,5f);
			player.GetComponent<PlayerController> ().canMove = false;

		}

		if (textsToDisplay.Length == currentText + 1 && focusCamera) {
			cam.transform.position = Vector3.MoveTowards( cam.transform.position, new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x, GameObject.FindGameObjectWithTag("Player").transform.position.y, -10), camMoveSpeed * Time.deltaTime);
			cam.GetComponent<Camera>().orthographicSize = Mathf.Lerp(newCamSize,originalCamSize,5f);
			player.GetComponent<PlayerController> ().canMove = true;

		}


	}







}
