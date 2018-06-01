using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; //used to compare multiple tags

public class ConveyorController : MonoBehaviour {
	public float maxSpeed = 2f;
	public bool isrunning = false;
	public bool goRight;
	private int direction;


	string[] movableTags = { "Player", "WoodBox", "MetalBox", "MovableEnemy" };

	void Update(){
		if (goRight)
			direction = 1;
		else if (!goRight)
			direction = -1;

	}

	void OnTriggerStay2D(Collider2D hit){
		if (isrunning && movableTags.Contains(hit.gameObject.tag)){
			hit.transform.position = new Vector2 (hit.transform.position.x + Time.deltaTime * maxSpeed * direction, hit.transform.position.y);
		}
				
	}

}
