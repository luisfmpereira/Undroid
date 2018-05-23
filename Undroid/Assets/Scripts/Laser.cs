using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	public Animator laseAnim;

	public void Finishanim(){
		laseAnim.SetBool ("start", false);
		laseAnim.SetBool ("finish", true);
	}
}
