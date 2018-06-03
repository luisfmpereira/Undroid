#if UNITY_EDITOR
using UnityEditor;
#endif

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
	[SerializeField]
	string click = "Click";
	[SerializeField]
	string select = "Select";
	public bool pause;
	private float originalFixedTime;
	public GameObject pauseMenu;
	private AudioManager audiomanager;



	public void Start ()
	{
		pause = false;
		originalFixedTime = Time.fixedDeltaTime;
		pauseMenu.SetActive (false);
	}

	public void Awake (){
		audiomanager = AudioManager.instance;
	}

	void Update ()
	{
		if (Input.GetButtonDown ("Pause")) {
			pause = !pause;

			if (pause) {
		
				PauseGame ();
			} else {
				ResumeClick ();
				pause = !pause;
			}
		}
	}

	public void PauseGame ()
	{
		audiomanager.StopSound ("Background");
		audiomanager.PlaySound ("MusicBGMenu");
		pauseMenu.SetActive (true);

		//stop simulation
		Time.timeScale = 0;
		Time.fixedDeltaTime = 0;
	}


	public void ResumeClick ()
	{
		audiomanager.PlaySound ("Background");
		audiomanager.StopSound ("MusicBGMenu");
		pauseMenu.SetActive (false);
		pause = !pause;
		//stop simulation
		Time.timeScale = 1;
		Time.fixedDeltaTime = originalFixedTime;
	}

	public void ReloadClick ()
	{
		//stop simulation
		Time.timeScale = 1;
		Time.fixedDeltaTime = originalFixedTime;

		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void QuitClick ()
	{
		#if UNITY_EDITOR
		EditorApplication.isPlaying = false;
		#else
			Application.Quit();
		#endif
	}

	public void playEnter ()
	{
		audiomanager.PlaySound (click);

	}

	public void playSelect ()
	{
		audiomanager.PlaySound (select);
	}
}
