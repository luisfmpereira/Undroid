using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Openlevel : MonoBehaviour {
	private bool interaction;
	private Animator anim;
	public string SceneName;

	void Awake(){
		anim = GetComponent<Animator>();
	}

	void Update(){
		interaction = Input.GetButton ("Fire1");
	}

	void OnTriggerStay2D(Collider2D hit){
		if (hit.gameObject.CompareTag ("Player") && interaction) {
			PlayerPrefs.SetInt (SceneName, 1);
			anim.SetBool ("doorIsOpen", true);

		}
	}

	public void LoadScene(){
		SceneManager.LoadScene(SceneName);
	}
}
