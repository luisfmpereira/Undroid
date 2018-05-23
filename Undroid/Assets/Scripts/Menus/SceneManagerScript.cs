#if UNITY_EDITOR
using UnityEditor;
#endif

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneManagerScript : MonoBehaviour {

	public bool useQuit;
	private float originalFixedTime;


	void Awake(){
		originalFixedTime = Time.fixedDeltaTime;

		if(useQuit)
			areYouSureQuit.SetActive (false);

	}

	public void LoadScene (string sceneName){

		SceneManager.LoadScene (sceneName);
		Time.timeScale = 1;
		Time.fixedDeltaTime = originalFixedTime;

	}

	//quitting methods
	public GameObject areYouSureQuit;



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
