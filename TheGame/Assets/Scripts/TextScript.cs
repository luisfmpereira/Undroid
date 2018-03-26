using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TextScript : MonoBehaviour {
	public GameObject textAD;
	public GameObject textZ;
	public GameObject textSPACE;
	private Transform trans;




	// Use this for initialization
	void Start () {
		trans = GetComponent<Transform> ();
	}

	public void OnCollisionStay2D(Collision2D col)
	{
		if(col.gameObject.tag == "Text1")
			{
			Debug.Log ("tocando");
			GameObject z = GameObject.Instantiate (textAD, trans.position, Quaternion.identity);
			}
		if(col.gameObject.tag == "Text2")
		{
			GameObject z = GameObject.Instantiate (textZ, trans.position, Quaternion.identity);
		}
	}
}