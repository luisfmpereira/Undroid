#if UNITY_EDITOR
using UnityEditor;
#endif

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneManagerScript : MonoBehaviour {

	public void LoadScene (string sceneName){

		SceneManager.LoadScene (sceneName);

	}

	//quitting methods
	public GameObject areYouSureQuit;


	void Awake(){
		areYouSureQuit.SetActive (false);

	}

	public void SureQuit(){
		areYouSureQuit.SetActive (true);
	}

	public void SureQuitNo(){
		areYouSureQuit.SetActive (false);
	}

	public void QuitGame(){
		#if UNITY_EDITOR
		EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}

}
