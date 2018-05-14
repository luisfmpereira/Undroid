using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runningmachine : MonoBehaviour {
	public float maxSpeed = 2f;
	public bool isrunning = false;

	void OnCollisionStay2D(Collision2D hit){
		if (hit.gameObject && isrunning) {
			hit.rigidbody.position = new Vector2 (hit.rigidbody.position.x + Time.deltaTime * maxSpeed, hit.rigidbody.position.y);
		}
				
	}

}
