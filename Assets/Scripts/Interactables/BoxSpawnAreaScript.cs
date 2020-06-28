using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawnAreaScript : MonoBehaviour {

	public int boxCount;
	public GameObject WoodBox;
	public Transform[] locations;
	public float cd;


	void Start(){
		boxCount = 4;
	}

	void OnTriggerExit2D(Collider2D hit){
		if (hit.gameObject.CompareTag ("WoodBox")) {
			boxCount--;
		}

	}
//	void OnTriggerEnter2D(Collider2D hit){
//		if (hit.gameObject.CompareTag ("WoodBox")) {
//			boxCount++;
//		}
//
//	}
	void Update(){

		if (boxCount <= 0) {
			
			Instantiate (WoodBox, locations [1].position,Quaternion.identity);
			Instantiate (WoodBox, locations [2].position,Quaternion.identity);
			Instantiate (WoodBox, locations [3].position,Quaternion.identity);
			Instantiate (WoodBox, locations [0].position,Quaternion.identity);
			boxCount += 4;
		}
	}

}
