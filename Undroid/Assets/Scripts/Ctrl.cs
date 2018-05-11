using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl : MonoBehaviour {

	public GameObject activated;
	public BoxCollider2D textCol;

	// Use this for initialization
	void Start () {
		textCol = GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		textCol.enabled = activated.gameObject.GetComponent<GateManager> ().gateTriggered;
	}
}
