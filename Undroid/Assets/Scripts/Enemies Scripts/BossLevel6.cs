using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevel6 : Boss {

	public GameObject laser;
	public Rigidbody2D bossRB;
	public SpriteRenderer bossSR;
	public Animator animator;
	public Rigidbody2D metalBox;
	public Rigidbody2D propToSpawn;
	public Transform muzzlePosition;
	private Vector2 muzzleRight;
	private Vector2 muzzleLeft;

	public float dashSpeed;
	private float moveTimer;
	public float moveCooldown;
	private bool hasFlipped;


	void Start(){
		bossRB = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		bossSR = GetComponent<SpriteRenderer> ();
		muzzleRight = new Vector2(0.8f,0f);
		muzzleLeft = new Vector2(-0.8f,0f);
	}

	void Update () {
		ShowLife ();
		animateDeath ();

		if (bossHealth <= 0)
			laser.SetActive (false);

		if (turnBossOn) {
			moveTimer -= Time.deltaTime;

			if (Mathf.Abs (bossRB.velocity.x) <= 0) {
				Shooting ();
				FlipOnce();

			}

			if (moveTimer <= 0)
				MoveEnemy ();
	
		}

	}

	void MoveEnemy(){

		bossRB.velocity = new Vector2(dashSpeed,0);
		hasFlipped = false;
		moveTimer = moveCooldown;
	}


	void FlipOnce(){
		if (!hasFlipped) {
			bossSR.flipX = !bossSR.flipX;

			if (bossSR.flipX) {
				muzzlePosition.localPosition = muzzleRight;
				bulletForce = 300;
				dashSpeed = 16;
			}
			if (!bossSR.flipX) {
				muzzlePosition.localPosition = muzzleLeft;
				bulletForce = -300;
				dashSpeed = -16;
			}

			hasFlipped = true;
		}

	}

	void Shooting(){
		shootTimer -= Time.deltaTime;

		if (shootTimer <= 0) {
			if (Random.Range (0f, 10f) < 5)
				propToSpawn = bulletPrefab;
			else
				propToSpawn = metalBox;
			
			Instantiate (propToSpawn, muzzlePosition.position, Quaternion.identity).AddForce(new Vector2(bulletForce,0));
			shootTimer = shootCooldown;
		}
		
	}
}
