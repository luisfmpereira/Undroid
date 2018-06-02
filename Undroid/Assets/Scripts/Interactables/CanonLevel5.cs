using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonLevel5 : MonoBehaviour {

	public Rigidbody2D playerBullet;
	public GameObject muzzle;
	public float bulletSpeed;
	public bool interacted;
	private float timer;
	public float cooldown = 4f;

	public GameObject button;
	public Sprite greenButton;
	public Sprite redButton;

	void Update () {
		timer -= Time.deltaTime;
		interacted = Input.GetButtonDown ("Fire1");
		if (timer<=0)
			button.GetComponent<SpriteRenderer> ().sprite = greenButton;
	}


	void OnTriggerStay2D(Collider2D hit){
		if (hit.gameObject.CompareTag ("Player") && interacted && timer <= 0) {
			button.GetComponent<SpriteRenderer> ().sprite = redButton;
			Instantiate (playerBullet, muzzle.transform.position, Quaternion.Euler (0, 0, 90)).AddForce(new Vector2(0,bulletSpeed));
			timer = cooldown;
		}

	}
}
