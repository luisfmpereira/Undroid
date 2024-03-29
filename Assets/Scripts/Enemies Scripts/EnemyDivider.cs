﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDivider : MonoBehaviour {

	public bool newBrokenEnemy;
	public float movement = 0.1f;
	public bool selectOnlyBroken;
	public bool selectOnlyWorking;
	public bool brokenGoLeft;

	void Awake(){
		if (brokenGoLeft)
			movement *= -1;
	}


	void OnTriggerEnter2D(Collider2D hit){
		if (hit.gameObject.CompareTag ("MovableEnemy")) {
			if (!selectOnlyBroken && !selectOnlyWorking)
				newBrokenEnemy = !newBrokenEnemy;
			else if (!selectOnlyWorking)
				newBrokenEnemy = true;
			else if (selectOnlyWorking)
				newBrokenEnemy = false;
		}
	}

	void OnTriggerStay2D(Collider2D hit){
		
		if (hit.CompareTag ("MovableEnemy")) {
			if (newBrokenEnemy)
				hit.gameObject.transform.position = new Vector2 (hit.gameObject.transform.position.x + movement * Time.deltaTime, hit.gameObject.transform.position.y);

			if (!newBrokenEnemy) {
				hit.gameObject.transform.position = new Vector2 (hit.gameObject.transform.position.x - movement * Time.deltaTime, hit.gameObject.transform.position.y);
			}
		}
	}

	void OnTriggerExit2D(Collider2D hit){

		if (hit.gameObject.CompareTag ("MovableEnemy") && !newBrokenEnemy) {
			hit.GetComponent<EnemyMovable> ().brokenEnemy = false;
			hit.GetComponent<EnemyMovable> ().allowedToShoot = true;
		}
	}
}
