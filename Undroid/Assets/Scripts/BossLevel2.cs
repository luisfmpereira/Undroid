using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevel2 : Boss {
	
	public float jumpForce;
	public float jumpCooldown = 5f;
	private float jumpTimer;
	private Rigidbody2D bossRB;

	void Awake(){
		bossRB = GetComponent<Rigidbody2D> ();
		jumpTimer = jumpCooldown;
	}


	void Update(){
		
		jumpTimer -= Time.deltaTime;

		KillBoss ();

		JumpAndShoot ();

	}



	void JumpAndShoot(){

		if (jumpTimer <= 0) {
			jumpTimer = jumpCooldown;
			bossRB.AddForce (new Vector2 (0, jumpForce));
		}

	}

}
