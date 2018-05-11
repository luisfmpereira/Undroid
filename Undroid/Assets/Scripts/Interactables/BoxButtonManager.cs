using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxButtonManager : MonoBehaviour {
	
	public GameObject activated;

	void OnTriggerStay2D(Collider2D hit){
		
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
