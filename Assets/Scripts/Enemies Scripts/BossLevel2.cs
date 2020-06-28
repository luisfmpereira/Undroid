using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossLevel2 : Boss {
	
	private Rigidbody2D bossRB;
	private SpriteRenderer bossSR;
	private SpriteRenderer bulletSR;

	public float jumpForce;
	public float jumpCooldown = 5f;
	private float jumpTimer;

	private float angleToMultiply = 30 * Mathf.Deg2Rad;


	void Start(){
		bossRB = GetComponent<Rigidbody2D> ();
		bossSR = GetComponent<SpriteRenderer> ();
		jumpTimer = jumpCooldown;
		bulletSR = bulletPrefab.gameObject.GetComponent<SpriteRenderer> ();
		bulletSR.flipX = true;
	}


	void Update(){

		ShowLife ();
		animateDeath ();

		if (turnBossOn) {
			
			shootTimer -= Time.deltaTime;
			if (bossRB.velocity.y <= 0.1)
				jumpTimer -= Time.deltaTime;
			JumpAndShoot ();
		}
	}



	void JumpAndShoot(){

		if (jumpTimer <= 0) {
			jumpTimer = jumpCooldown;
			bossRB.AddForce (new Vector2 (0, jumpForce));
		}

		if (shootTimer <= 0) {
			shootTimer = shootCooldown;
			Flip ();
			ShootTriple ();
			

		}

	}

	void ShootTriple(){

		Instantiate (bulletPrefab, this.transform.position, Quaternion.identity).AddForce(new Vector2(bulletForce,0));
		Instantiate (bulletPrefab, this.transform.position, Quaternion.Euler(0,0,30)).AddForce(new Vector2(bulletForce*Mathf.Cos(angleToMultiply),bulletForce*Mathf.Sin(angleToMultiply)));
		Instantiate (bulletPrefab, this.transform.position, Quaternion.Euler(0,0,-30)).AddForce(new Vector2(bulletForce*Mathf.Cos(angleToMultiply),-bulletForce*Mathf.Sin(angleToMultiply)));
		Instantiate (bulletPrefab, this.transform.position, Quaternion.Euler(0,0,15)).AddForce(new Vector2(bulletForce*Mathf.Cos(angleToMultiply/2),bulletForce*Mathf.Sin(angleToMultiply/2)));
		Instantiate (bulletPrefab, this.transform.position, Quaternion.Euler(0,0,-15)).AddForce(new Vector2(bulletForce*Mathf.Cos(angleToMultiply/2),-bulletForce*Mathf.Sin(angleToMultiply/2)));
	}

	void Flip(){
		bossSR.flipX = !bossSR.flipX;
		bulletForce *= -1;
		bulletSR.flipX = !bulletSR.flipX;
	}


	void OnTriggerEnter2D(Collider2D hit){

		DamageByBoxes (hit);
		DamageByPlayer (hit);
	}
		
}
