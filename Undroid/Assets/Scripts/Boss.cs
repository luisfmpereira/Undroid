using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {


	public int bossHealth = 3;

	public void KillBoss(){
		if (bossHealth <= 0) {
			Destroy (this.gameObject);
		}
	}


	void OnTriggerEnter2D(Collider2D hit){
		//damage by wood box
		if (hit.gameObject.CompareTag ("WoodBox")) {
			Destroy (hit.gameObject);
			bossHealth--;
		}
		//damage by metal box
		if (hit.gameObject.CompareTag ("MetalBox")) {
			Destroy (hit.gameObject);
			bossHealth-=2;
		}

	}

	void OnCollisionEnter2D(Collision2D hit){

		//damage by player bullet
		if (hit.gameObject.CompareTag ("PlayerBullet")) {
			bossHealth--;
		}
	}



}
