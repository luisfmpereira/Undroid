using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionButtonManager : MonoBehaviour {
	public GameObject platform;
	private bool interacted;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		interacted = Input.GetButtonDown ("Fire1");
	}

	void OnTriggerStay2D (Collider2D hit)
	{
		if (hit.gameObject.tag == "Player" && interacted == true) {
			platform.GetComponent<MovingPlatformManager> ().isPressed = true;
		}
	}
}
