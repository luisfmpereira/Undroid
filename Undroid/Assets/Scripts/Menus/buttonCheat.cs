using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class buttonCheat : MonoBehaviour {

	public Button theButton;
	public Sprite buttonNormal;
	public Sprite buttonOn;


	void Update(){

		if(PlayerPrefs.GetInt("CheatLife") ==1)
			theButton.GetComponent<Image>().sprite = buttonOn;

		if(PlayerPrefs.GetInt("CheatLife")==0)
			theButton.GetComponent<Image>().sprite = buttonNormal;


	}

}
