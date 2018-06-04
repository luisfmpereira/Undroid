using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableLaser : MonoBehaviour
{

	public GameObject laserobj;
	public Sprite Green;
	public AudioManager audiomanager;
	private bool interacted;
	void Awake()
	{
		audiomanager = AudioManager.instance;
	}
	void Update ()
	{
		interacted = Input.GetButtonDown ("Fire1");
	}

	void OnTriggerStay2D (Collider2D hit)
	{
		if (hit.gameObject.tag == "Player" && interacted) {
			//audiomanager.PlaySound ("LaserOff");
			gameObject.GetComponent<SpriteRenderer> ().sprite = Green;
			laserobj.SetActive (false);
		}
	}
}