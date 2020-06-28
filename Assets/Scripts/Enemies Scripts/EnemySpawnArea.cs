using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnArea : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D hit){
		if(hit.gameObject.CompareTag("Player"))
			GetComponentInChildren<EnemySpawn> ().turnOn = true;
	}


	void OnTriggerExit2D(Collider2D hit){
		if(hit.gameObject.CompareTag("Player"))
			GetComponentInChildren<EnemySpawn> ().turnOn = false;
	}
}
