using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalImageDecision : MonoBehaviour {


	private bool interacted;

	public GameObject button;
	public Sprite greenButton;
	public Sprite redButton;

	public GameObject finalImage;

	void Awake(){
		button.GetComponent<SpriteRenderer> ().sprite = greenButton;
	}

	void Update () {
		interacted = Input.GetButton("Fire1");
	}



	void OnTriggerStay2D(Collider2D hit){

		if (hit.gameObject.CompareTag ("Player") && interacted) {
			button.GetComponent<SpriteRenderer> ().sprite = redButton;
			finalImage.SetActive (true);
		}
	}


	void CallCredits(){

		SceneManager.LoadScene ("CreditScreen");
	}
}
