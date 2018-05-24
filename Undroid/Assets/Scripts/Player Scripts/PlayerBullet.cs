using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

	public GameObject enemy;

	void OnTriggerEnter2D(Collider2D hit){
		
		if (hit.gameObject.CompareTag ("Enemy")) {
			hit.gameObject.GetComponentInChildren<EnemyDamageController>().enemyLife--;
			Destroy (this.gameObject);
		}

	}


	void Update(){

		Destroy (this.gameObject, 3);
	}
}
