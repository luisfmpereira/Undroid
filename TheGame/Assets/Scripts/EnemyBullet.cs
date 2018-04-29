using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

	void OnCollisionEnter2D(){

		Destroy (this.gameObject); //destroy bullet in any collision
	}

	void Update(){

		Destroy (this.gameObject, 5); //destroy bullet after 5 seconds
	}
}
