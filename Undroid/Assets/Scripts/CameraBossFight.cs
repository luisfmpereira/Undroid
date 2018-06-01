using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraBossFight : MonoBehaviour {


	public GameObject mainCamera;
	public float originalCamSize;
	public float newCamSize;
	public GameObject bossHealthPanel;
	public GameObject boss;

	void Awake(){
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		originalCamSize = mainCamera.GetComponent<Camera> ().orthographicSize;
	}

	void OnTriggerEnter2D(Collider2D hit){
		if (hit.gameObject.CompareTag ("Player")) {
			boss.GetComponent<Boss> ().turnBossOn = true;
			mainCamera.GetComponent<Camera> ().orthographicSize = newCamSize;


		}

	}
	void OntriggerEnter2D(Collider2D col){
		bossHealthPanel.SetActive (true);
	}


	void OnTriggerExit2D(Collider2D hit){
		if (hit.gameObject.CompareTag ("Player")) {
			boss.GetComponent<Boss> ().turnBossOn = false;
			mainCamera.GetComponent<Camera> ().orthographicSize = originalCamSize;
			bossHealthPanel.SetActive (false);
		}

	}
}
