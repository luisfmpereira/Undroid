using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBoxScript : MonoBehaviour {
	
	public string [] textsToDisplay;
	private int currentText;
	public GameObject dialogueBox;
	public Text dialogueText;
	public int dialogueTextSize = 50;
	private float originalFixedTime;


	private bool isShowing;


	void Awake() {
		originalFixedTime = Time.fixedDeltaTime;
		currentText = 0;
		dialogueText = dialogueBox.GetComponentInChildren<Text>();

	}


	void Update(){
		if (isShowing && Input.GetButtonDown ("Fire1")) {
			//unlock time
			//Time.timeScale = 1;
			//Time.fixedDeltaTime = originalFixedTime;

			if (textsToDisplay.Length == currentText + 1) {
				dialogueBox.SetActive (false);
				this.gameObject.SetActive (false);
			}
			else {
				currentText++;
				DisplayText (textsToDisplay[currentText]);
			}
		}

	}

	void DisplayText(string text){
		//lock time
		//Time.timeScale = 0;
		//Time.fixedDeltaTime = 0;

		//set new text
		isShowing = true;
		dialogueText.text = text;
		dialogueText.fontSize = dialogueTextSize;
		dialogueBox.SetActive (true);
	}


	void OnTriggerEnter2D(Collider2D hit){
		if(hit.gameObject.CompareTag("Player")){
			DisplayText (textsToDisplay[currentText]);
		}
	}
}
