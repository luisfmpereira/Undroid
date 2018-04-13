using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upanddown : MonoBehaviour {
	public GameObject platform;
	SpriteRenderer player;

	public float y2;
	public LayerMask groundLayer; 
	// Use this for initialization
	void Start () {
		player = GetComponent<SpriteRenderer> ();

	}
	
	// Update is called once per frame
	void Update () {
		y2 = platform.transform.position.y;
		print (y2);
		if (Physics2D.Raycast (this.transform.position, Vector2.up, (player.size.y)/2 + 0.2f, groundLayer.value)) {
			platform.GetComponent<BoxCollider2D>().isTrigger = true;
		}
		else 
			platform.GetComponent<BoxCollider2D>().isTrigger = false;

	}
}
