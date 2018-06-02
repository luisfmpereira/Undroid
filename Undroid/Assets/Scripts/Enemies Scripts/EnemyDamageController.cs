using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageController : MonoBehaviour {

	public int enemyLife = 2;
	public bool movableEnemy = false;
	public Animator anim;

	void Awake(){
		anim = GetComponentInParent<Animator> ();
		anim.SetBool ("Die", false);
	}

	void Update() {

		if (enemyLife <= 0) {
			anim.SetBool ("Die", true);
		}
			
	}


	void OnTriggerEnter2D (Collider2D hit){
		
		if (hit.gameObject.CompareTag ("WoodBox")) {
			Destroy (hit.gameObject);
			enemyLife--;
		}

		if (hit.gameObject.CompareTag ("MetalBox")) {
			Destroy (hit.gameObject);
			enemyLife -= 2;
		}

	}

}
