using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevel3 : Boss {


	public Rigidbody2D bossRB;
	public SpriteRenderer bossSR;
	public float moveSpeed = 10;
	private bool move = true;


	void Start(){
		bossRB = GetComponent<Rigidbody2D> ();
		bossSR = GetComponent<SpriteRenderer> ();

	}

	void Update(){
		KillBoss ();
		if (move)
			MoveBoss ();

		if (Mathf.Abs( bossRB.velocity.x ) <= 0.01 && !move) {
			bossSR.flipX = !bossSR.flipX;
			moveSpeed *= -1;
			move = true;

		}
		
	}

	void OnTriggerEnter2D(Collider2D hit){
		DamageByPlayer(hit);
	}
		
	void MoveBoss(){

		bossRB.velocity = new Vector2(moveSpeed,0);

		move = false;


			
	}
}
