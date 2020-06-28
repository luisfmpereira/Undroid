using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changecp : MonoBehaviour {
	public Sprite newS;
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.CompareTag("Player")){
			this.GetComponent<SpriteRenderer>().sprite = newS;
		}
	}

}
