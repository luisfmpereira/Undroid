using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevel7 : Boss {

	public GameObject laser;
	public Animator animator;
	public Transform[] positions;
	public float moveSpeed = 2f;
	private int selectedPosition;
	private float angleToMultiply = 120 * Mathf.Deg2Rad;


	void Start(){
		animator = GetComponent<Animator> ();
		selectedPosition = 0;
		
	}

	void Update () {
		ShowLife ();
		animateDeath ();
		if (turnBossOn) {
			MoveEnemy ();
			Shooting ();

			if (bossHealth <= 0) {
				laser.SetActive (false);
			}
		}

	}


	void MoveEnemy(){
	
		this.transform.position = Vector2.MoveTowards(this.transform.position,positions[selectedPosition].position,moveSpeed*Time.deltaTime);
	
		if (this.transform.position == positions [selectedPosition].position) {
			selectedPosition = Random.Range (0, positions.Length - 1);
		}
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

