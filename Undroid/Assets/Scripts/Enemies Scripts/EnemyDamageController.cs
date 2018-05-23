using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageController : MonoBehaviour {

	public int enemyLife = 2;

	void Update() {

		if (enemyLife <= 0) {
			GameObject enemyParent = (this.transform.parent.gameObject).transform.parent.gameObject;
			Destroy (enemyParent.gameObject);
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
