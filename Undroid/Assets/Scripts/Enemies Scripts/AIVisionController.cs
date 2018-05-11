using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIVisionController : MonoBehaviour {

	public GameObject enemy;

	void OnTriggerEnter2D (Collider2D hit) {

		if (hit.gameObject.CompareTag ("Player"))
			enemy.GetComponent<EnemyController> ().isShooting = true;
	}

	void OnTriggerExit2D (Collider2D hit) {

		if (hit.gameObject.CompareTag ("Player"))
			enemy.GetComponent<EnemyController> ().isShooting = false;
	}
}
