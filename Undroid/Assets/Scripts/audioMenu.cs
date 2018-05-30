using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioMenu : MonoBehaviour {
	private AudioManager audioManager;
	[SerializeField]
	string click = "Click";
	[SerializeField]
	string select = "Select";
	// Use this for initialization
	void Awake () {
		audioManager = AudioManager.instance;
	}
	public void playEnter(){
		audioManager.PlaySound (click);
	}

	public void playSelect(){
		audioManager.PlaySound (select);
	}

}
