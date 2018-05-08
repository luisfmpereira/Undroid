using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl : MonoBehaviour {

	public GameObject activated;
	public BoxCollider2D collider;

	// Use this for initialization
	void Start () {
		collider = GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		collider.enabled = activated.gameObject.GetComponent<GateManager> ().gateTriggered;
	}
}
