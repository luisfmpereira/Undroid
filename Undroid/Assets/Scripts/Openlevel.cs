﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Openlevel : MonoBehaviour {
	private bool interaction;
	private Animator anim;
	public int level;

	void Awake(){
		anim = GetComponent<Animator>();
	}

	void Update(){
		interaction = Input.GetButtonDown ("Fire1");
	}

	void OnTriggerStay2D(Collider2D hit){
		if (hit.gameObject.CompareTag ("Player") && interaction) {
			anim.SetBool ("doorIsOpen", true);
		}
	}

	public void LoadScene(){
		SceneManager.LoadScene(level);
	}
}