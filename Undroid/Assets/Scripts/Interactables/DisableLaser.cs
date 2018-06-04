using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableLaser : MonoBehaviour
{

	public GameObject laserobj;
	public Sprite Green;
	private bool interacted;
	private GameObject player;
	private bool alreadyDisable;
	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	void Update ()
	{
		interacted = Input.GetButtonDown ("Fire1");
	}

	void OnTriggerStay2D (Collider2D hit)
	{
		if (hit.gameObject.tag == "Player" && interacted && !alreadyDisable) {
			alreadyDisable = true;
			player.GetComponent<PlayerController> ().LaserOffSound ();
			gameObject.GetComponent<SpriteRenderer> ().sprite = Green;
			laserobj.SetActive (false);
		}
	}
}