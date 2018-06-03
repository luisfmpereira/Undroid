using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevel3 : Boss {


	public Rigidbody2D bossRB;
	public SpriteRenderer bossSR;
	public Animator anim;
	public float moveSpeed = 10;
	private bool move = true;
	private bool flip;


	public float moveCooldown = 2f;
	private float moveTimer = 0f;


	void Start(){
		bossRB = GetComponent<Rigidbody2D> ();
		bossSR = GetComponent<SpriteRenderer> ();
		anim = GetComponent<Animator>();

	}

	void Update(){
		animateDeath ();
		ShowLife ();

		if (flip) {
			bossSR.flipX = !bossSR.flipX;
			flip = false;
		}

		if (move)
			MoveBoss ();

		if (Mathf.Abs( bossRB.velocity.x ) < 10 && !move) {
			
			moveTimer -= Time.deltaTime;
			anim.SetBool("running",false);
			anim.SetBool("decelerating",true);

			if (Mathf.Abs( bossRB.velocity.x) <= 2.5) {
				anim.SetBool("decelerating",false);
				anim.SetBool("idle",true);
			}
				
			if (moveTimer <= 0) {
				moveSpeed *= -1;
				move = true;
			}

		}
		
	}

	void OnTriggerEnter2D(Collider2D hit){
		DamageByPlayer(hit);
	}
		
	void MoveBoss(){

		bossRB.velocity = new Vector2(moveSpeed,0);
		anim.SetBool("idle",false);
		anim.SetBool("running",true);
		moveTimer = moveCooldown;
		move = false;
		flip = true;

			
	}

}
