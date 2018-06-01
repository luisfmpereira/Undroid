using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableLaser : MonoBehaviour
{
	private bool interacted;
	public GameObject laserobj;
	public Sprite Green;
	void Update ()
	{
		interacted = Input.GetButtonDown ("Fire1");
	}

	void OnTriggerStay2D (Collider2D hit)
	{
		if (hit.gameObject.tag == "Player" && interacted == true) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = Green;
			laserobj.SetActive (false);
		}
	}
}