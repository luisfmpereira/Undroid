using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMainKill : MonoBehaviour {
	private AudioManager audiomanager;

	void Awake(){
		audiomanager = AudioManager.instance;
	}
	public void KillEnemy(){
		Destroy (this.gameObject);
	}
}
