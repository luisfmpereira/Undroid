using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageController : MonoBehaviour {

	public int enemyLife = 2;
	public bool movableEnemy = false;
	public Animator anim;
	private AudioManager audiomanager;
	public GameObject enemy;

	void Awake(){
		anim = GetComponentInParent<Animator> ();
		anim.SetBool ("Die", false);
		audiomanager = AudioManager.instance;
		enemy = this.transform.parent.gameObject.transform.parent.gameObject;
	}

	void Update() {

		if (enemyLife <= 0) {
			audiomanager.PlaySound ("Explosion");
			enemy.GetComponent<EnemyController> ().heDied = true;
			anim.SetBool ("Die", true);
			}
			
	}


	void OnTriggerEnter2D (Collider2D hit){
		
		if (hit.gameObject.CompareTag ("WoodBox")) {
			Destroy (hit.gameObject);
			enemyLife--;
			audiomanager.PlaySound ("WoodBreak");
		}

		if (hit.gameObject.CompareTag ("MetalBox")) {
			Destroy (hit.gameObject);
			enemyLife -= 2;
			audiomanager.PlaySound ("MetalBreak");
		}

	}

}
