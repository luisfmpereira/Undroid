using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class buttonCheat : MonoBehaviour {

	public Text buttonText;


	void Awake(){
		buttonText = this.GetComponentInChildren<Text> ();
	}

	void Update(){

		if(PlayerPrefs.GetInt("CheatLife") == 1)
			buttonText.text = "Life Cheat On";

		if(PlayerPrefs.GetInt("CheatLife") == 0)
			buttonText.text = "Life Cheat Off";


	}

}
