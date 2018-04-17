using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TextScript : MonoBehaviour
{
	//components
	public GameObject z;
	public GameObject textAD;
	public GameObject textZ;
	public GameObject textSPACE;
	public GameObject textCTRLSPACE;
	private Transform trans;
	//variables
	public float y = 0.2f;




	// Use this for initialization
	void Start ()
	{
		trans = GetComponent<Transform> ();

	}

	//Instantiate the Sprite
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
		if (col.gameObject.tag == "Text3") {
			z = GameObject.Instantiate (textZ, new Vector3(trans.transform.position.x, trans.transform.position.y + y, trans.transform.position.z), Quaternion.identity);
			z.transform.parent = trans.transform;
		}
		if (col.gameObject.tag == "Text4") {
			z = GameObject.Instantiate (textCTRLSPACE, new Vector3(trans.transform.position.x, trans.transform.position.y + y, trans.transform.position.z), Quaternion.identity);
			z.transform.parent = trans.transform;
		}
	}

	//Destroy the Sprite
	public void OnTriggerExit2D (Collider2D col)
	{
		if (col.gameObject.tag == "Text1" || col.gameObject.tag == "Text2"|| col.gameObject.tag == "Text3"|| col.gameObject.tag == "Text4") {
			z.transform.parent = null;
			GameObject.Destroy (z, 0);
		}

	}


}