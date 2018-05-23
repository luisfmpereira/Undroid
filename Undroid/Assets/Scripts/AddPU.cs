﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPU : MonoBehaviour {
	private bool interaction;
	public bool powerUpBoot = false;
	public bool powerUpShoot = false;
	public bool powerUpDash = false;

	public RuntimeAnimatorController Player2;

	void Update(){
		interaction = Input.GetButtonDown ("Fire1");
	}

	void OnTriggerStay2D(Collider2D hit){
		if (hit.gameObject.CompareTag ("Player") && interaction) {
			if (powerUpBoot) {
				hit.gameObject.GetComponent<PlayerController> ().allowDoubleJump = true;
				hit.gameObject.GetComponent<Animator> ().runtimeAnimatorController = Player2;
			}
			else if (powerUpShoot) {
				hit.gameObject.GetComponent<PlayerController> ().allowShooting = true;
				hit.gameObject.GetComponent<Animator> ().runtimeAnimatorController = Player2;
			}
			else if (powerUpDash) {
				hit.gameObject.GetComponent<PlayerController> ().allowDash = true;
				hit.gameObject.GetComponent<Animator> ().runtimeAnimatorController = Player2;
			}
			gameObject.SetActive (false);
		}
	}
}
