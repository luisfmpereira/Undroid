using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorController : MonoBehaviour {
	public float maxSpeed = 2f;
	public bool isrunning = false;

	void OnTriggerStay2D(Collider2D hit){
		if (isrunning) {
			hit.transform.position = new Vector2 (hit.transform.position.x + Time.deltaTime * maxSpeed, hit.transform.position.y);
		}
				
	}

}
