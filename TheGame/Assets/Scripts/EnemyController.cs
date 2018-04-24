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

	private Vector3 direction;

	// Use this for initialization
	void Start () {
		enemyLocationSelected = enemyLocations [locationSelected];
		enemySR = GetComponentInChildren<SpriteRenderer> ();
		enemyRB2D = GetComponentInChildren <Rigidbody2D> ();
		//AIVision = GetComponentInChildren<CircleCollider2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {


		MoveEnemy ();
		flipSprite (enemySR, direction.x, AIVision);

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

	}

	void flipSprite (SpriteRenderer SR, float direction, CircleCollider2D AI){

		if (direction > 0) {
			SR.flipX = true; //flip sprite
			AI.offset = new Vector2 (1.5f, AI.offset.y);  //flip AI Vision

		}
		if (direction < 0) {
			SR.flipX = false;
			AI.offset = new Vector2 (-1.5f, AI.offset.y);
		}
	}
}

