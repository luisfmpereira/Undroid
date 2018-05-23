using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawnAreaScript : MonoBehaviour {

	public int boxCount;
	public GameObject WoodBox;
	public Transform[] locations;

	void OnTriggerEnter2D(Collider2D hit){
		if (hit.gameObject.CompareTag ("WoodBox")) {
			boxCount++;
		}

	}

	void OnTriggerExit2D(Collider2D hit){
		if (hit.gameObject.CompareTag ("WoodBox")) {
			boxCount--;
		}

	}

	void Update(){
		if (boxCount <= 0) {
			Instantiate (WoodBox, locations [Random.Range (0, locations.Length)].position,Quaternion.identity);
		}
	}

}
