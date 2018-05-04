using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

	public float destroyBulletTime = 5f;


	void OnCollisionEnter2D(){

		Destroy (this.gameObject);
	}


	void Update () {
		
		Destroy (this.gameObject, destroyBulletTime);
		
	}
}
