using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractRunningMachine : MonoBehaviour {
	private bool interacted = false;

	public GameObject conveyorBelt;


	void Update(){
			interacted = Input.GetButtonDown ("Fire1");

	}

	void OnTriggerStay2D (Collider2D hit){
		if (hit.gameObject.CompareTag ("Player") && interacted) {
			conveyorBelt.GetComponent<ConveyorController> ().isrunning = true;
		}
	}
}
