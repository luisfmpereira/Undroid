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
	public GameObject Level71;
	public GameObject Level72;




	void Update () {


		TestInteraction ("Level2", Level2);
		TestInteraction ("Level3", Level3);
		TestInteraction ("Level4", Level4);
		TestInteraction ("Level5", Level5);
		TestInteraction ("Level6", Level6);
		TestInteraction ("Level7.1", Level71);
		TestInteraction ("Level7.1", Level72);
			
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
		PlayerPrefs.SetInt ("Level7.1", 1);
		PlayerPrefs.SetInt ("Level7.2", 1);

	}


}
