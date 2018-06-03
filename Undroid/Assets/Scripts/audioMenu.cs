using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioMenu : MonoBehaviour {
	public AudioManager audioManager;
	[SerializeField]
	string click = "Click";
	[SerializeField]
	string select = "Select";
	// Use this for initialization

	public void playEnter(){
		audioManager.PlaySound (click);
	}

	public void playSelect(){
		audioManager.PlaySound (select);
	}

}
