using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public GameObject enemy;
	public float enemyMoveSpeed;
	public Transform enemyLocationSelected;
	public Transform[] enemyLocations;
	private int locationSelected = 0;

	private SpriteRenderer enemySR;
	private Rigidbody2D enemyRB2D;
	public CircleCollider2D AIVision;
	public Rigidbody2D bulletPrefab;
	public bool isShooting = false;
	private float timer;
	public float shootingCooldown = 5f;

	private Vector3 direction;
	private int bulletDirection;

	// Use this for initialization
	void Start () {
		enemyLocationSelected = enemyLocations [locationSelected];
		enemySR = GetComponentInChildren<SpriteRenderer> ();
		enemyRB2D = GetComponentInChildren <Rigidbody2D> ();
		AIVision = GetComponentInChildren<CircleCollider2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if (isShooting) {
			EnemyShooting ();

		} else {
			MoveEnemy ();

		}

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

		direction = enemyLocationSelected.position - enemy.transform.position;

		flipSprite (enemySR, direction.x, AIVision);

	}


	void EnemyShooting(){

		if (timer >= shootingCooldown) {
			Rigidbody2D bullet = Instantiate (bulletPrefab, enemy.transform.position, Quaternion.identity) as Rigidbody2D;
			if (direction.x > 0)
				bulletDirection = 1;
			else 
				bulletDirection = -1;
			

			bullet.AddForce (new Vector2(bulletDirection,0) * 300);

			timer = 0; 
		}
		else
			timer += Time.deltaTime;
			

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

