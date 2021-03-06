﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

	public GameObject movableEnemyPrefab;
	public float cooldown = 5f;
	private float timer;
	public bool turnOn;
	public int lifeRange;

	public bool forEnemies = true;
	
	void Awake(){
		timer = cooldown;
	}

	void Update () {

		timer -= Time.deltaTime;

		if (turnOn) {
			if (timer <= 0) {
				GameObject newEnemy = Instantiate (movableEnemyPrefab, this.transform.position, Quaternion.identity);
				if(forEnemies){
					newEnemy.GetComponent<EnemyMovable> ().moveCooldown = Random.Range (3f, 6f);//randomize movement cooldown
					newEnemy.GetComponentInChildren<EnemyDamageController> ().enemyLife = Random.Range (2,lifeRange);//randomize life amount
					newEnemy.GetComponent<EnemyMovable> ().shootingCooldown = Random.Range (2f, 4f);//randomize movement cooldown
				}

				timer = cooldown;

			}
		}
		
	}
}
