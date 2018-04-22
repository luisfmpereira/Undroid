using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public GameObject enemy;
	public float enemyMoveSpeed;
	public Transform enemyCurrentLocation;
	public Transform[] enemyLocations;
	private int locationSelected = 0;

	// Use this for initialization
	void Start () {
		enemyCurrentLocation = enemyLocations [locationSelected];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
