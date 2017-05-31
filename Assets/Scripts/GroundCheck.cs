using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

	//Figure this shit out later 

	Animator animator;

	void Start()
	{
		animator = GetComponentInParent<Animator> ();
	}

	void OnCollisionEnter(Collider other)
	{
		if (other.tag == "Ground") 
		{
			animator.SetBool ("IsGrounded", true);
		}
	}
}
