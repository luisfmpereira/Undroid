using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPU : MonoBehaviour {
	private bool interaction;

	void Update(){
		interaction = Input.GetButtonDown ("Fire1");
	}

	void OnTriggerStay2D(Collider2D hit){
		if (hit.gameObject.CompareTag ("Player") && interaction) {
			hit.gameObject.GetComponent<PlayerController> ().allowDoubleJump = true;
			gameObject.SetActive (false);
		}
	}
}
