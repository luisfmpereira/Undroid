using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraLimit : MonoBehaviour {
	public GameObject cam;
	public new Vector2 maxXY;
	public new Vector2 minXY;
	public bool changeMax;
	public bool changeMin;

	void Start () {
		cam = GameObject.FindGameObjectWithTag ("MainCamera");
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.CompareTag("Player")){
			if(changeMax)
			cam.GetComponent<CameraFollow> ().maxXAndY = maxXY;
			if(changeMin)
			cam.GetComponent<CameraFollow> ().minXAndY = minXY;
		}
	}

}
