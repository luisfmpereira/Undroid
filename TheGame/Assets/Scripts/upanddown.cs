using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upanddown : MonoBehaviour
{	
	//components & variables
	public GameObject platform;
	public LayerMask groundLayer;
	private SpriteRenderer player;
	private bool platbool = false;

	// Use this for initialization
	void Start ()
	{
		player = GetComponent<SpriteRenderer> ();
		platform = GameObject.FindGameObjectWithTag ("Platform");

	}
	
	// Update is called once per frame
	void Update ()
	{
		up ();
		if(platbool == true)
		down ();
	}

	//habilita a o trigger para ficar na plataforma
	private void up ()
	{
		if (Physics2D.Raycast (this.transform.position, Vector2.up, (player.size.y) / 1, groundLayer.value)) {
			platform.GetComponent<BoxCollider2D> ().isTrigger = true;
			platbool = false;
		} else
			platform.GetComponent<BoxCollider2D> ().isTrigger = false;
            platbool = true;
		
	}
	//desabilita o trigger para sair da plataforma
	private void down ()
	{
		if (Input.GetKey (KeyCode.LeftControl) && Input.GetKey (KeyCode.Space)) {
			platform.GetComponent<BoxCollider2D> ().isTrigger = true;
		}

	}
}
