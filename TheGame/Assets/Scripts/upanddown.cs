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
	public float plusy;

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
		if (Physics2D.Raycast (new Vector3(this.transform.position.x,this.transform.position.y + plusy, this.transform.position.z), Vector2.up, player.size.y, groundLayer.value)) {
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
