using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformManager : MonoBehaviour {


	public GameObject platform;
	public float moveSpeed;
	public Transform currentPoint;
	public Transform[] points;
	private int pointSelection = 0;

	public bool isPressed = false; 


	// Use this for initialization
	void Start () {
		currentPoint = points [pointSelection];

	}
	
	// Update is called once per frame
	void Update () {
		if(isPressed)
			movePlatform(); 
	}

	void movePlatform(){

		platform.transform.position = Vector3.MoveTowards (platform.transform.position, currentPoint.position, moveSpeed*Time.deltaTime);

		if (platform.transform.position == currentPoint.position)
			pointSelection++;

		if (pointSelection == points.Length)
			pointSelection = 0;

		currentPoint = points [pointSelection];

	}

}
