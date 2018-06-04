using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class animationScript : MonoBehaviour {
	private AudioManager audioManager;
	[SerializeField]
	string start = "Background";

	private float originalFixedTime;

	void Awake(){
		audioManager = AudioManager.instance;
		originalFixedTime = Time.fixedDeltaTime;
	}

	void Update(){
		if (Input.anyKeyDown) {
			startGame ("Level1");
		}
	}
	public void startGame(string sceneName){
		SceneManager.LoadScene (sceneName);
		Time.timeScale = 1;
		Time.fixedDeltaTime = originalFixedTime;
		audioManager.StopSound ("Intro");
		audioManager.PlaySound (start);
	}
}
