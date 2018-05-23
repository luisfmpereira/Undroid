using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableLaser : MonoBehaviour
{
	private bool interacted;
	public GameObject laserobj;

	void Update ()
	{
		interacted = Input.GetButtonDown ("Fire1");
	}

	void OnTriggerStay2D (Collider2D hit)
	{
		if (hit.gameObject.tag == "Player" && interacted == true) {
			
			laserobj.SetActive (false);
		}
	}
}