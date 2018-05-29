using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageController : MonoBehaviour {

	public int enemyLife = 2;
	public bool movableEnemy = false;

	void Update() {

		if (enemyLife <= 0) {
			if (!movableEnemy) {
				GameObject enemyParent = (this.transform.parent.gameObject).transform.parent.gameObject;
				Destroy (enemyParent.gameObject);
			}

			if(movableEnemy)
				Destroy (this.transform.parent.gameObject);
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
