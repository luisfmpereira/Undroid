using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnOnConveyor : MonoBehaviour {

	public bool turnon = false;
	public bool Right = false;

	void Update()
	{
		if (turnon) {
			this.GetComponent<Animator> ().SetBool ("off", false);
		}

		if (Right) {
			this.GetComponent<Animator> ().SetBool ("RotateRight", true);
		} else {
			this.GetComponent<Animator> ().SetBool ("RotateLeft", true);
		}
	}
}
