using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorController : MonoBehaviour {
	public float maxSpeed = 2f;
	public bool isrunning = false;
	public bool gotoright = false;
	private int direction;

	void Update(){
		if (gotoright)
			direction = 1;
		else if (!gotoright)
			direction = -1;

	}

	void OnTriggerStay2D(Collider2D hit){
		if (isrunning) {
			hit.transform.position = new Vector2 (hit.transform.position.x + Time.deltaTime * maxSpeed * direction, hit.transform.position.y);
		}
				
	}

}
