using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{


	public float normSpeed = 4;
	public float jumpForce = 550;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	private bool isGrounded = false;

	public bool
		lookingRight = true;

	private Rigidbody2D rigidBody2D;
	private Animator animator;

	// Use this for initialization
	void Start ()
	{
		rigidBody2D = GetComponent<Rigidbody2D> ();
		animator = GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void FixedUpdate ()
	{
		float horizontal = Input.GetAxis ("Horizontal");
		bool inputMoveRight = (horizontal > 0);
		animator.SetFloat ("Speed", Mathf.Abs (horizontal));
		rigidBody2D.velocity = new Vector2 (horizontal * normSpeed, rigidBody2D.velocity.y);

		isGrounded = Physics2D.OverlapCircle (groundCheck.position, 0.15F, whatIsGround);
		animator.SetBool ("IsGrounded", isGrounded);

		if (inputMoveRight != lookingRight) 
			Flip ();
	}


	public void Flip ()
	{
		lookingRight = !lookingRight;
		Vector3 myScale = transform.localScale;
		myScale.x *= -1;
		transform.localScale = myScale;
	}
}
