using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	public float jumpHeight;

	public Collider groundCheck;

	public float moveHorizontal, moveVertical;

	Animator animator;

	//Variables to check for jump and double-jump
	public bool grounded, jumped, jumpPress;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		animator = GetComponent<Animator> ();
	}

	void Update()
	{
		moveHorizontal = Input.GetAxis ("Horizontal");
		jumpPress = Input.GetButtonDown("Jump");

		//Updates animator
		if (moveHorizontal != 0.0f) 
		{
			animator.SetBool ("IsMoving", true);
		} 
		else 
		{
			animator.SetBool ("IsMoving", false);
		}

		//Rotate left
		if (moveHorizontal < 0) 
		{
			transform.eulerAngles = new Vector3 (transform.rotation.x, -90.0f, transform.rotation.z);
		}
		//Rotate right
		if (moveHorizontal > 0) 
		{
			transform.eulerAngles = new Vector3 (transform.rotation.x, 90.0f, transform.rotation.z);
		}
	}

	void FixedUpdate()
	{
		//Allows fluid movement but fall speed is still too slow 
		Vector3 movement = Vector3.zero;

		if (moveHorizontal < 0) 
		{
			movement = Vector3.left;
		} 

		if (moveHorizontal > 0) 
		{
			movement = Vector3.right;
		}

		if (jumpPress) 
		{
			movement = Vector3.up * jumpHeight;
			animator.SetBool ("IsJumped", true);
			grounded = false;
			jumped = true;
		}
			
		//Updates movement
		rb.velocity = movement * speed;
	}

	void Jump()
	{

	}

	//Checks if the player is touching the ground
	void OnCollisionEnter(Collision other) 
	{
		if(other.collider.CompareTag("Ground")) 
		{
			//Booleans and animations are updated accordingly 
			grounded = true;
			jumped = false;
			animator.SetBool ("IsGrounded", true);
			animator.SetBool ("IsJumped", false);
		}
	}
}
