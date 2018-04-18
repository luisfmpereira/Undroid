using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour {

	private Vector3 posB;
	public Transform finalPos;
	public float speed;
	public bool gateTriggered = false;


	// Use this for initialization
	void Start () {
		posB = finalPos.localPosition;

		speed = 0.5f;
	}

	void Update(){
		if (gateTriggered)
		transform.localPosition = Vector3.MoveTowards(transform.localPosition, posB, speed * Time.deltaTime);
	}

	void OnTriggerEnter2D (Collider2D hit){
		if(hit.gameObject.tag == "Player" && Input.GetButton("Z")) {
			gateTriggered = true;
		}

	}
}
