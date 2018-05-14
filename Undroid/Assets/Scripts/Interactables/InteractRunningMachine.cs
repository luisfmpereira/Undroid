using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractRunningMachine : MonoBehaviour {
	private bool interacted = false;

	public GameObject runningmachine;


	void Update(){
			interacted = Input.GetButtonDown ("Fire1");

	}

	void OnCollisionStay2D (Collision2D hit){
		if (hit.gameObject.CompareTag ("Player") && interacted) {
			runningmachine.GetComponent<runningmachine> ().isrunning = true;
		}
	}
}
