using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour {

	public GameObject Level2;
	public GameObject Level3;
	public GameObject Level4;
	public GameObject Level5;
	public GameObject Level6;




	void Update () {


		TestInteraction ("Level2", Level2);
		TestInteraction ("Level3", Level3);
		TestInteraction ("Level4", Level4);
		TestInteraction ("Level5", Level5);
		TestInteraction ("Level6", Level6);
			
	}


	void TestInteraction(string LevelName, GameObject level){
		if (PlayerPrefs.GetInt (LevelName) == 1) {
			level.GetComponent<Button> ().interactable = true;
		} 

		else
			level.GetComponent<Button> ().interactable = false;
	}


	public void CheatCode(){
		PlayerPrefs.SetInt ("Level2", 1);
		PlayerPrefs.SetInt ("Level3", 1);
		PlayerPrefs.SetInt ("Level4", 1);
		PlayerPrefs.SetInt ("Level5", 1);
		PlayerPrefs.SetInt ("Level6", 1);
	}

	public void ResetGame(){
		PlayerPrefs.SetInt ("Level2", 0);
		PlayerPrefs.SetInt ("Level3", 0);
		PlayerPrefs.SetInt ("Level4", 0);
		PlayerPrefs.SetInt ("Level5", 0);
		PlayerPrefs.SetInt ("Level6", 0);
	}
}
