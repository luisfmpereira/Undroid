using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageController : MonoBehaviour {
	
	void OnTriggerEnter2D (Collider2D hit){

		if (hit.gameObject.CompareTag ("WoodBox")) {
			Destroy (hit.gameObject);
		}

		if (hit.gameObject.CompareTag ("MetalBox")) {
			GameObject enemyParent = this.transform.parent.gameObject;
			Destroy (hit.gameObject);
			Destroy (enemyParent.gameObject);
		}

	}
}
