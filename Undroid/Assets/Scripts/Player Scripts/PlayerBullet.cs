using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

	public GameObject enemy;

	void OnCollisionEnter2D(Collision2D hit){

		if (hit.gameObject.CompareTag ("Enemy")) {
			enemy = hit.transform.parent.gameObject;
			Destroy (enemy.gameObject);
		}

		Destroy (this.gameObject);

	}


	void Update(){

		Destroy (this.gameObject, 3);
	}
}
