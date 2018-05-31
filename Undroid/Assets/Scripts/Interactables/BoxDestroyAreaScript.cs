using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDestroyAreaScript : MonoBehaviour {




	void OnTriggerEnter2D(Collider2D hit){
		if(hit.gameObject.CompareTag("WoodBox") || hit.gameObject.CompareTag("MetalBox")){
			Destroy (hit.gameObject);
		}

	}
}
