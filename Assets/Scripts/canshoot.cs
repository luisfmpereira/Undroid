using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canshoot : MonoBehaviour {

	public GameObject shoot;

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.CompareTag ("Player")) {
			shoot.gameObject.GetComponent<EnemyController> ().canShoot = true;
		}
	}

}
