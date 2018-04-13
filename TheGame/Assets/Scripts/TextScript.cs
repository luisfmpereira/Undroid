using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TextScript : MonoBehaviour
{
	public GameObject z;
	public GameObject textAD;
	public GameObject textZ;
	public GameObject textSPACE;
	private Transform trans;
	public float y = 0.2f;




	// Use this for initialization
	void Start ()
	{
		trans = GetComponent<Transform> ();

	}


	public void OnTriggerEnter2D (Collider2D col)
	{
		
		if (col.gameObject.tag == "Text1") {
		    z = GameObject.Instantiate (textAD, new Vector3(trans.transform.position.x, trans.transform.position.y + y, trans.transform.position.z), Quaternion.identity);
			z.transform.parent = trans.transform;

		}
		if (col.gameObject.tag == "Text2") {
			z = GameObject.Instantiate (textSPACE, new Vector3(trans.transform.position.x, trans.transform.position.y + y, trans.transform.position.z), Quaternion.identity);
			z.transform.parent = trans.transform;
		}
	}

	public void OnTriggerExit2D (Collider2D col)
	{
		if (col.gameObject.tag == "Text1" || col.gameObject.tag == "Text2") {
			z.transform.parent = null;
			GameObject.Destroy (z, 0);
		}

	}


}