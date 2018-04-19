using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour {

	public GameObject gate;
	public Transform endPoint;
	public float speed = 0.5f;
	public bool gateTriggered = false;


	// Use this for initialization
	void Start () {
		
	}

	void Update(){
		if (gateTriggered)
			gate.transform.position = Vector3.MoveTowards (gate.transform.position, endPoint.position, speed*Time.deltaTime);
	}

	void OnTriggerEnter2D (Collider2D hit){
		if(hit.gameObject.tag == "Player" && Input.GetButton("interaction")){
			gateTriggered = true;
		}

	}
}
