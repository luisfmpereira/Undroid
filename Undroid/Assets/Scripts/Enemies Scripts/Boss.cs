﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour {


	public int bossHealth = 3;
	protected float bossMaxHealth;

	public Rigidbody2D bulletPrefab;
	public float bulletForce = 300;
	public float shootCooldown = 2f;
	protected float shootTimer;
	public GameObject PowerUpDropBoss;
	public Image bossHealthBar;

	public bool turnBossOn;

	void Awake(){
		bossMaxHealth = bossHealth;
	}

	protected void KillBoss(){
		if (bossHealth <= 0) {
			PowerUpDropBoss.SetActive (true);
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

	protected void DamageByPlayer(Collider2D hit){
		//damage by player bullet
		if (hit.gameObject.CompareTag ("PlayerBullet")) {
			bossHealth--;
			Destroy (hit.gameObject);
		}
	}

	protected void ShowLife(){
		
		bossHealthBar.fillAmount = bossHealth / bossMaxHealth;
	}
		
}
