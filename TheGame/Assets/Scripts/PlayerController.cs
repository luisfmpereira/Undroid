using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	//get components
	private Rigidbody2D playerRB;
	private SpriteRenderer playerSR;
	private Animator playerAnim;

	//movement variables
	public float maxSpeed = 5f;
	public bool grounded = false;

	//jump variables
	public float jumpVelocity;
	public LayerMask groundLayer; 
	private int doubleJumpCount = 0; //double jump counter
	public float doubleJumpModifier; //add extra force to double jump
	private bool allowDoubleJump = true; //unlock double jump


	// Use this for initialization
	void Start () {

		playerRB = GetComponent<Rigidbody2D> ();
		playerSR = GetComponent<SpriteRenderer> ();
		playerAnim = GetComponent<Animator> ();

		//set jump forces
		jumpVelocity = 5f;
		doubleJumpModifier = 1.2f;
		
	}


	void FixedUpdate () {

		move (); //call move function
		jump (); //call jump function


	}



	//control player movement
	public void move(){

		float xMove = Input.GetAxis ("Horizontal"); //get player input for the movement
		playerAnim.SetFloat ("Speed", Mathf.Abs (xMove)); //set "Speed" float on animator controller to start running
		playerRB.position = new Vector2 (playerRB.position.x + xMove * maxSpeed * Time.deltaTime, playerRB.position.y); //set new player position

		flipSprite (playerSR, xMove); //control sprite direction

	}


	public void jump(){
		
		//raycast test to grounded variable
		if (Physics2D.Raycast (this.transform.position, Vector2.down, (playerSR.size.y) / 2 + 0.2f, groundLayer.value)) {
			grounded = true;
			playerAnim.SetBool ("Jumping", false); //animation variables
			doubleJumpCount = 1; //allow double jump once grounded
		} else
			grounded = false; //if not grounded, no jumping allowed
		
		if (Input.GetButtonDown ("Jump"))
			
		//regular jump
			if (grounded) {
			playerRB.velocity = (Vector2.up * jumpVelocity);
		}
		//double jump
			else if (allowDoubleJump && doubleJumpCount == 1) {
			playerRB.velocity = (Vector2.up * jumpVelocity * doubleJumpModifier);
			doubleJumpCount = 0;
		}

		if (playerRB.velocity.y > 0)
			
			playerAnim.SetBool ("Jumping", true); //set animation
	}


	//function for flipping spirte
	public void flipSprite(SpriteRenderer SR, float direction) {

		if (direction < 0)
			SR.flipX = true;

		if (direction > 0)
			SR.flipX = false;
	}
}
