using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour {

	public GameObject gate;
	public Transform endPoint;
	public GameObject cameraPos;
	public float speed = 0.5f;
	public bool gateTriggered = false;
	private bool interacted;
	public Vector2 newmaxXAndY;

	void Update(){
		interacted = Input.GetButtonDown ("Fire1");
		if (gateTriggered)
			gate.transform.position = Vector3.MoveTowards (gate.transform.position, endPoint.position, speed*Time.deltaTime);
	}

	void OnTriggerStay2D (Collider2D hit){
		if(hit.gameObject.tag == "Player" && interacted == true){
			gateTriggered = true;
			cameraPos.GetComponent<CameraFollow> ().maxXAndY = newmaxXAndY;
		}

	}
}
