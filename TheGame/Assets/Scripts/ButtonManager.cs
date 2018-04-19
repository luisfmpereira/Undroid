using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour {
	
	public GameObject activated;

	void OnTriggerEnter2D(Collider2D hit){
		
		if (hit.gameObject.CompareTag ("Box")) {
			activated.GetComponent<MovingPlatformManager> ().isPressed = true;
		
		}
			

	}
	void OnTriggerExit2D(Collider2D hit){
		if (hit.gameObject.CompareTag ("Box")) {
			activated.GetComponent<MovingPlatformManager> ().isPressed = false;
		}
		
	}

}
