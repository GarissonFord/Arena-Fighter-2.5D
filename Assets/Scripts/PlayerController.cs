using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	public float jumpHeight;

	public float moveHorizontal, moveVertical;

	Animator animator;

	private Transform playerPosition;

	//for rotation
	public Vector3 eulerAngleVelocity;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		playerPosition = GetComponent<Transform> ();
		animator = GetComponent<Animator> ();
	}

	void FixedUpdate()
	{
		moveHorizontal = Input.GetAxis("Horizontal");
		moveVertical = Input.GetAxis ("Vertical") * jumpHeight;

		Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);

		if (moveHorizontal != 0.0f) 
		{
			animator.SetBool ("IsMoving", true);
		} else 
		{
			animator.SetBool ("IsMoving", false);
		}
			
		rb.velocity = movement * speed;
	}


	/*
	void FixedUpdate()
	{
		animator.SetBool ("IsMoving", false);

		float moveHorizontal = Input.GetAxisRaw ("Horizontal");

		Vector3 movement;
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			movement = new Vector3 (0f, jumpHeight, 0f);
			animator.SetBool ("IsJumped", true);
			rb.MovePosition (transform.position + movement);
			playerPosition.Rotate (0f, 0f, 0f, Space.Self);
		} 
		if (Input.GetKey (KeyCode.RightArrow) 
				||Input.GetKey (KeyCode.LeftArrow)
				|| Input.GetKey(KeyCode.A)
				|| Input.GetKey(KeyCode.D)
				) 
		{
			movement = new Vector3 (moveHorizontal, 0f, 0f);
			movement = movement * speed * Time.deltaTime;
			rb.MovePosition (transform.position + movement);
			animator.SetBool ("IsMoving", true);
		} 
	}
	*/
}
