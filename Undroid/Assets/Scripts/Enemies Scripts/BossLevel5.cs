using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevel5 : Boss {

	public Transform[] positions;
	public float moveSpeed = 2f;
	private int selectedPosition;
	private float angleToMultiply = 120 * Mathf.Deg2Rad;
	public GameObject laser;
	public GameObject enemyKillingArea;

	void Start () {
		selectedPosition = 0;
		enemyKillingArea.GetComponent<BoxCollider2D>().enabled = false;
	}

	void Update () {
		ShowLife ();
		animateDeath ();
		if (bossHealth <= 0) {
			laser.SetActive (false);
			enemyKillingArea.GetComponent<BoxCollider2D> ().enabled = true;
		}

		if (turnBossOn) {
			
			MoveEnemy ();

			Shooting ();
		}
		
	}

	void MoveEnemy(){
		this.transform.position = Vector2.MoveTowards(this.transform.position,positions[selectedPosition].position,moveSpeed*Time.deltaTime);


		if (this.transform.position == positions [selectedPosition].position)
			selectedPosition++;

		if (selectedPosition == positions.Length)
			selectedPosition = 0;
	}


	void Shooting(){

		shootTimer -= Time.deltaTime;

		if (shootTimer <= 0) {
			Instantiate (bulletPrefab, this.transform.position, Quaternion.Euler (0, 0, -90)).AddForce (new Vector2 (0, -bulletForce));
			Instantiate (bulletPrefab, this.transform.position, Quaternion.Euler(0,0,-75)).AddForce(new Vector2(bulletForce*Mathf.Cos(angleToMultiply/2),-bulletForce*Mathf.Sin(angleToMultiply/2)));
			Instantiate (bulletPrefab, this.transform.position, Quaternion.Euler(0,0,-105)).AddForce(new Vector2(-bulletForce*Mathf.Cos(angleToMultiply/2),-bulletForce*Mathf.Sin(angleToMultiply/2)));
			shootTimer = Random.Range (1f, 4f);
		}
	}

	void OnTriggerEnter2D(Collider2D hit){
		DamageByPlayer (hit);
	}
}
