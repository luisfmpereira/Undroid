using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionButtonManager : MonoBehaviour {
	public GameObject platform;
	private bool z;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		z = Input.GetButtonDown ("interaction");
	}

	void OnTriggerStay2D (Collider2D hit)
	{
		if (hit.gameObject.tag == "Player" && z == true) {
			platform.GetComponent<MovingPlatformManager> ().isPressed = true;
		}
	}
}
