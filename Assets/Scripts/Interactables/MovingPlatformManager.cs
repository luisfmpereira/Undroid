using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformManager : MonoBehaviour {
	
	public GameObject platform;
	public float moveSpeed;
	public Transform currentPoint;
	public Transform[] points;
	private int pointSelected = 0;


	public bool isPressed = false; 


	// Use this for initialization
	void Start () {
		currentPoint = points [pointSelected];

	}
	
	// Update is called once per frame
	void Update () {
		if(isPressed)
			movePlatform(); 
	}

	void movePlatform(){

		platform.transform.position = Vector3.MoveTowards (platform.transform.position, currentPoint.position, moveSpeed*Time.deltaTime);

		if (platform.transform.position == currentPoint.position)
			pointSelected++;

		if (pointSelected == points.Length)
			pointSelected = 0;

		currentPoint = points [pointSelected];

	}
	void OnCollisionEnter2D(Collision2D other)	{	
		if (other.gameObject.CompareTag ("Player"))
			other.transform.SetParent (platform.GetComponent<Transform>());
		}
	void OnCollisionExit2D (Collision2D hit)
	{
		if (hit.gameObject.CompareTag ("Player"))
			hit.transform.SetParent (null);
	}

}
