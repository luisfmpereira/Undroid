using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {


	public int bossHealth = 3;

	public Rigidbody2D bulletPrefab;
	public float bulletForce = 300;
	public float shootCooldown = 2f;
	protected float shootTimer;
	public int BossLevel;
	public GameObject PowerUpDropBoss;
	public Transform spawnPU;
	protected void KillBoss(){
		if (bossHealth <= 0) {
			if (BossLevel == 2) {
				Instantiate (PowerUpDropBoss, spawnPU);
			}
			Destroy (this.gameObject);
		}
	}


	protected void DamageByBoxes(Collider2D hit){
		//damage by wood box
		if (hit.gameObject.CompareTag ("WoodBox")) {
			Destroy (hit.gameObject);
			bossHealth--;
		}
		//damage by metal box
		if (hit.gameObject.CompareTag ("MetalBox")) {
			Destroy (hit.gameObject);
			bossHealth-=2;
		}

	}

	protected void DamageByPlayer(Collision2D hit){

		//damage by player bullet
		if (hit.gameObject.CompareTag ("PlayerBullet")) {
			bossHealth--;
		}
	}
		
}
