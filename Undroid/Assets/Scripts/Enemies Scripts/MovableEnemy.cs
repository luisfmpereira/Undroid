using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableEnemy : MonoBehaviour {


	public SpriteRenderer SR;
	public Rigidbody2D RB;
	public Transform transf;

	private float timer;
	public float shootingCooldown = 3f;
	public Rigidbody2D bulletPrefab;
	private Vector3 direction;
	private int bulletDirection;
	public bool startShootingRight;
	public bool brokenEnemy;


	void Start () {
		bulletDirection = startShootingRight ? 1 : -1;

		SR = GetComponent<SpriteRenderer> ();
		RB = GetComponent<Rigidbody2D> ();
		transf = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {

		EnemyShooting ();
	}



	void EnemyShooting(){

		if (timer >= shootingCooldown) {
			Rigidbody2D bullet = Instantiate (bulletPrefab, this.transform.position, Quaternion.identity) as Rigidbody2D;
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

	void MoveEnemy(){






	}


}
