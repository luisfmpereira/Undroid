	#if UNITY_EDITOR
	using UnityEditor;
	#endif

	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;
	using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour {

		public bool pause;
		private float originalFixedTime;
		public GameObject pauseMenu;



		public void Start(){
			pause = false;
			originalFixedTime = Time.fixedDeltaTime;
			pauseMenu.SetActive (false);
		}

		void Update(){
			if (Input.GetButtonDown ("Pause")) {
			pause = !pause;

			if (pause)
				PauseGame ();
			else {
				ResumeClick ();
				pause = !pause;
			}
			}
		}

		public void PauseGame (){
			pauseMenu.SetActive (true);

			//stop simulation
			Time.timeScale = 0;
			Time.fixedDeltaTime = 0;
		}


		public void ResumeClick (){
			pauseMenu.SetActive (false);
			pause = !pause;
			//stop simulation
			Time.timeScale = 1;
			Time.fixedDeltaTime = originalFixedTime;
		}

		public void ReloadClick (){
			//stop simulation
			Time.timeScale = 1;
			Time.fixedDeltaTime = originalFixedTime;

			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}

		public void QuitClick (){
			#if UNITY_EDITOR
			EditorApplication.isPlaying = false;
			#else
			Application.Quit();
			#endif
		}
	}
