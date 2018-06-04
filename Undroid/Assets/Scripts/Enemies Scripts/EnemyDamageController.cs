using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageController : MonoBehaviour {

	public int enemyLife = 2;
	public bool movableEnemy = false;
	public Animator anim;
	private AudioManager audioManager;
	public GameObject enemy;

	void Awake(){
		anim = GetComponentInParent<Animator> ();
		anim.SetBool ("Die", false);
		audioManager = AudioManager.instance;
		if(!movableEnemy)
			enemy = this.transform.parent.gameObject.transform.parent.gameObject;
	}

	void Update() {

		if (enemyLife <= 0) {
			//audiomanager.PlaySound ("Explosion");
			anim.SetBool ("Die", true);
			if(!movableEnemy)
				enemy.GetComponent<EnemyController> ().heDied = true;

			}
			
	}


	void OnTriggerEnter2D (Collider2D hit){

		if (hit.gameObject.CompareTag ("PlayerBullet")) {
			Destroy (hit.gameObject);
			enemyLife--;
		}

		if (hit.gameObject.CompareTag ("WoodBox")) {
			Destroy (hit.gameObject);
			enemyLife--;
			audioManager.PlaySound ("WoodBreak");
		}

		if (hit.gameObject.CompareTag ("MetalBox")) {
			Destroy (hit.gameObject);
			enemyLife -= 2;
			audioManager.PlaySound ("MetalBreak");
		}

	}

}
