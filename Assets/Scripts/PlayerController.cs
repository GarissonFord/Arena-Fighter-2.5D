using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	public float jumpHeight;

	public float moveHorizontal, moveVertical;

	Animator animator;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		animator = GetComponent<Animator> ();
	}

	void FixedUpdate()
	{
		moveHorizontal = Input.GetAxis("Horizontal");
		moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);

		if (moveHorizontal != 0.0f) 
		{
			animator.SetBool ("IsMoving", true);
		} 
		else 
		{
			animator.SetBool ("IsMoving", false);
		}
			
		rb.velocity = movement * speed;
	}
}
