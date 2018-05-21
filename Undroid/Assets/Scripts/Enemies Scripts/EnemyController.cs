using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public GameObject enemy;
	public float enemyMoveSpeed;
	public Transform[] enemyLocations;

	private int locationSelected = 0;
	private Transform enemyLocationSelected;
	private float timer;

	public float shootingCooldown = 3f;
	public bool isShooting = false;
	public bool staticEnemy;//defines if enemy is static or not
	public bool startShootingRight;
	public bool canShoot = true;


	private SpriteRenderer enemySR;
	private CircleCollider2D AIVision;
	public Rigidbody2D bulletPrefab;



	private Vector3 direction;
	private int bulletDirection;
	public bool heFlip = false;



	void Awake(){
		bulletDirection = startShootingRight ? 1 : -1;
	}

	void Start () {
		enemyLocationSelected = enemyLocations [locationSelected];
		enemySR = GetComponentInChildren<SpriteRenderer> ();
		AIVision = GetComponentInChildren<CircleCollider2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (staticEnemy) {
			StaticEnemyShooting ();
		}

		else if (isShooting && canShoot) {
			EnemyShooting ();

		} else if(!staticEnemy)
			MoveEnemy ();


	}

	public void MoveEnemy (){
		//move enemy towards next point
		enemy.transform.position = Vector3.MoveTowards (enemy.transform.position, enemyLocationSelected.position, enemyMoveSpeed * Time.deltaTime);


		//change next point according to array
		if (enemy.transform.position == enemyLocationSelected.position) 
			locationSelected++;
		//reset points if array ended
		if (locationSelected == enemyLocations.Length) 
			locationSelected = 0;

		//reassign current selected point
		enemyLocationSelected = enemyLocations [locationSelected];

		//calculate enemy direction using the next location
		direction = enemyLocationSelected.position - enemy.transform.position;

		//flip enemy sprite and AI
		flipSprite (enemySR, direction.x, AIVision);

	}


	void EnemyShooting(){

		if (timer >= shootingCooldown) {
			Rigidbody2D bullet = Instantiate (bulletPrefab, enemy.transform.position, Quaternion.identity) as Rigidbody2D;
			if (direction.x > 0)
				bulletDirection = 1;
			else
				bulletDirection = -1;
			

			bullet.AddForce (new Vector2 (bulletDirection, 0) * 300);

			timer = 0; 
		} else {
			timer += Time.deltaTime;
		}
			

	}

	void StaticEnemyShooting(){
		if(heFlip)
		flipSprite (enemySR, bulletDirection, AIVision); //flips sprite according to next shot


		if (timer >= shootingCooldown) {
			Rigidbody2D bullet = Instantiate (bulletPrefab, enemy.transform.position, Quaternion.identity) as Rigidbody2D; //instantiate bullet
			bullet.AddForce (new Vector2 (bulletDirection, 0) * 300); //add force to the prefab
			timer = 0; //reset cooldown
			if(heFlip)
				bulletDirection *= -1; //change direction
		} else {
			timer += Time.deltaTime;

		}

	}


	void flipSprite (SpriteRenderer SR, float direction, CircleCollider2D AI){

		if (direction > 0) {
			SR.flipX = false; //flip sprite
			AI.offset = new Vector2 (1.5f, AI.offset.y);  //flip AI Vision

		}
		if (direction < 0) {
			SR.flipX = true;
			AI.offset = new Vector2 (-1.5f, AI.offset.y);
		}
	}






}

