using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevel4 : Boss{

	public GameObject movableEnemyPrefab;
	public Transform[] positions;
	public float moveSpeed = 2f;
	private int selectedPosition;
	public float chanceToSpawnNewEnemy;
	public GameObject laser;

	// Use this for initialization
	void Start () {
		selectedPosition = 0;
	}

	void Update () {
		ShowLife ();
		if (turnBossOn) {
			MoveEnemy ();
			KillBoss ();

			if (bossHealth == 0) {
				laser.SetActive (false);
			}
		}

	}

	void MoveEnemy(){

		this.transform.position = Vector2.MoveTowards(this.transform.position,positions[selectedPosition].position,moveSpeed*Time.deltaTime);

		if (this.transform.position == positions [selectedPosition].position) {
			selectedPosition = Random.Range (0, positions.Length - 1);

			if(Random.Range (0f, 1f) < chanceToSpawnNewEnemy)
				SpawnNewEnemy ();
		}
	}




	void SpawnNewEnemy(){

		GameObject newEnemy = Instantiate (movableEnemyPrefab, this.transform.position, Quaternion.identity);
		newEnemy.GetComponent<EnemyMovable> ().moveCooldown = Random.Range (3f, 6f);//randomize movement cooldown
		newEnemy.GetComponentInChildren<EnemyDamageController> ().enemyLife = Random.Range (2, 5);
		newEnemy.GetComponent<EnemyMovable> ().shootingCooldown = Random.Range (2f, 4f);//randomize movement cooldown
		newEnemy.GetComponent<EnemyMovable> ().brokenEnemy =false;//randomize movement cooldown
		newEnemy.GetComponent<EnemyMovable> ().allowedToShoot = true;//randomize movement cooldown


	}


	void OnTriggerEnter2D(Collider2D hit){
		DamageByPlayer(hit);
	}


}
