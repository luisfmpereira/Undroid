using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressController : MonoBehaviour {

	public GameObject pressMachine;
	public Transform startPosition;
	public Transform endPosition;
	private Transform selectedPosition;
	public float downSpeed = 5;
	public float upSpeed = 3;


	void Awake(){
		selectedPosition = endPosition;
	}

	void Update () {

		MoveMachine (pressMachine, selectedPosition, endPosition, startPosition, downSpeed, upSpeed);

		if (pressMachine.transform.position == endPosition.transform.position)
			selectedPosition = startPosition;
		if (pressMachine.transform.position == startPosition.transform.position)
			selectedPosition = endPosition;


	}




	void MoveMachine(GameObject machine,Transform selectedPos, Transform endPos, Transform startPos, float downSpd, float upSpd){
		if (selectedPos.position == endPos.position) {
			machine.transform.position = Vector3.MoveTowards (machine.transform.position, endPos.position, downSpd*Time.deltaTime);
		} else if(selectedPos.position == startPos.position)
			machine.transform.position = Vector3.MoveTowards (machine.transform.position, startPos.position, upSpd*Time.deltaTime);
		}

}
