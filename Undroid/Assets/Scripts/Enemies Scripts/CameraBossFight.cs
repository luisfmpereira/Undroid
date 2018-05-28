using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraBossFight : MonoBehaviour {


	public GameObject mainCamera;
	public float originalCamSize;
	public GameObject bossHealthPanel;

	void Awake(){
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		originalCamSize = mainCamera.GetComponent<Camera> ().orthographicSize;
	}

	void OnTriggerStay2D(Collider2D hit){
		if (hit.gameObject.CompareTag ("Player")) {
		
			mainCamera.GetComponent<Camera> ().orthographicSize = originalCamSize*2;
			bossHealthPanel.SetActive (true);

		}

	}


	void OnTriggerExit2D(Collider2D hit){
		if (hit.gameObject.CompareTag ("Player")) {

			mainCamera.GetComponent<Camera> ().orthographicSize = originalCamSize;
			bossHealthPanel.SetActive (false);
		}

	}
}
