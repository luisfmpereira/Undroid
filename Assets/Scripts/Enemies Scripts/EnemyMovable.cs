using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovable : MonoBehaviour {


	public SpriteRenderer SR;
	public Rigidbody2D RB;
	public Transform transf;

	private float shootingTimer;
	public float shootingCooldown = 3f;
	public Rigidbody2D bulletPrefab;
	private Vector3 direction;
	private int bulletDirection = -1;
	public bool startShootingRight;
	public bool brokenEnemy;
	public float movement;
	public float moveCooldown = 3f;
	public bool allowedToShoot;
	float moveTimer;


	void Awake () {
		bulletDirection = startShootingRight ? 1 : -1;
		movement *= bulletDirection;

		moveTimer = moveCooldown;

		SR = GetComponent<SpriteRenderer> ();
		RB = GetComponent<Rigidbody2D> ();
		transf = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (!brokenEnemy)
			MoveEnemy ();

		if (allowedToShoot)
			EnemyShooting ();
	}

	void KillEnemy(){
		Destroy (this.gameObject);
	}

	void MoveEnemy(){
		moveTimer -= Time.deltaTime;

		transf.position = new Vector2 (transf.position.x + movement*Time.deltaTime, transf.position.y);

		if (moveTimer <= 0) {
			movement *= -1;
			bulletDirection *= -1;
			moveTimer = moveCooldown;
		}

		SR.flipX = movement > 0 ? false : true;

	}



	void EnemyShooting(){

		if (shootingTimer >= shootingCooldown) {
			Rigidbody2D bullet = Instantiate (bulletPrefab, this.transform.position, Quaternion.identity) as Rigidbody2D;

			bullet.AddForce (new Vector2 (bulletDirection, 0) * 300);

			shootingTimer = 0; 
		} else {
			shootingTimer += Time.deltaTime;
		}


	}

	void OnTriggerEnter2D(Collider2D hit){
		if (hit.gameObject.CompareTag ("KillZone")) {
			Destroy (this.gameObject);
		}
	}

}
