using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	public float jumpHeight;

	public float moveHorizontal, moveVertical;

	Animator animator;

	//Variables to check for jump and double-jump
	public bool grounded, jumped;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		animator = GetComponent<Animator> ();
	}

	void FixedUpdate()
	{
		//Gets input from arrow keys, A-D, or space bar
		moveHorizontal = Input.GetAxis ("Horizontal");
		moveVertical = Input.GetAxis ("Vertical");

		//Allows fluid movement but fall speed is stilltoo slow 
		Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);

		//Updates animator
		if (moveHorizontal != 0.0f) 
		{
			animator.SetBool ("IsMoving", true);
		} 
		else 
		{
			animator.SetBool ("IsMoving", false);
		}

		//Checks for jump
		if (moveVertical != 0.0f) 
		{
			grounded = false;
			jumped = true;
			animator.SetBool ("IsJumped", true);
		}

		if (jumped) 
		{
			rb.velocity = new Vector3 (movement.x, jumpHeight, 0.0f);;
		}

		//Updates movement
		rb.velocity = movement * speed;
	}

	//Checks if the player is touching the ground
	void OnTriggerEnter(Collider other) 
	{
		if (other.CompareTag ("Ground")) 
		{
			//Booleans and animations are updated accordingly 
			grounded = true;
			jumped = false;
			animator.SetBool ("IsGrounded", true);
			animator.SetBool ("IsJumped", false);
		}
	}
}
