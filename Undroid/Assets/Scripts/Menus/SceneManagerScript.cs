#if UNITY_EDITOR
using UnityEditor;
#endif

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class SceneManagerScript : MonoBehaviour {

	public bool useQuit;
	private float originalFixedTime;
	public GameObject quitYes;
	public GameObject mainButton;
	private AudioManager audioManager;
	[SerializeField]
	string click = "Click";
	[SerializeField]
	string start = "Background";
	[SerializeField]
	string select = "Select";
	public bool started = false;


	void Awake(){
		audioManager = AudioManager.instance;
		originalFixedTime = Time.fixedDeltaTime;

		if(useQuit)
			areYouSureQuit.SetActive (false);
		
	}
	void Start(){
		started = true;
	}
	public void SelectFirst(){
		EventSystem.current.SetSelectedGameObject (mainButton);
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
		EventSystem.current.SetSelectedGameObject (quitYes);

	}

	public void SureQuitNo(){
		areYouSureQuit.SetActive (false);
		EventSystem.current.SetSelectedGameObject (mainButton);
	}

	public void QuitGame(){
		#if UNITY_EDITOR
		EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}

	public void playEnter(){
		audioManager.PlaySound (click);
		}

	public void playSelect(){
		audioManager.PlaySound (select);
	}

	public void playBackgroundMusic(){
		audioManager.PlaySound ("Intro");
	}

	public void ResetGame(){
		PlayerPrefs.SetInt ("Level2", 0);
		PlayerPrefs.SetInt ("Level3", 0);
		PlayerPrefs.SetInt ("Level4", 0);
		PlayerPrefs.SetInt ("Level5", 0);
		PlayerPrefs.SetInt ("Level6", 0);
		PlayerPrefs.SetInt ("Level7.1", 0);
		PlayerPrefs.SetInt ("Level7.2", 0);
		PlayerPrefs.SetInt ("CheatLife", 0);
	}

	public void CheatLife(){
		if(PlayerPrefs.GetInt ("CheatLife") == 1)
			PlayerPrefs.SetInt ("CheatLife", 0);
		
		else if(PlayerPrefs.GetInt ("CheatLife") == 0)
			PlayerPrefs.SetInt ("CheatLife", 1);
	}

	public void startMenu(){
		SceneManager.LoadScene ("MainMenu");
		Time.timeScale = 1;
		Time.fixedDeltaTime = originalFixedTime;
		audioManager.PlaySound ("MusicBGMenu");
	}

	public void startGame(string sceneName){
		SceneManager.LoadScene (sceneName);
		Time.timeScale = 1;
		Time.fixedDeltaTime = originalFixedTime;
		audioManager.StopSound ("MusicBGMenu");
	}
}
