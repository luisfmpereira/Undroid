using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	//components
	private Rigidbody2D playerRB;
	private SpriteRenderer playerSR;
	private Animator playerAnim;
	public CapsuleCollider2D stand;
	public CapsuleCollider2D crouch;

	//movement variables
	public float maxSpeed = 3f;
	public bool crouching = false;
	public bool isCrouching = false;

	//jump variables
	public float jumpVelocity = 5f;
	private bool grounded = false;
	private bool doubleJumped; //if has double jumped
	public Transform groundCheck; //ground check GO
	public Transform ceilCheck; //ceiling check GO
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	public bool isJumping;

	public bool allowDoubleJump = true; //unlock double jump
	public float doubleJumpModifier = 1.0f; //add extra force to double jump

	//platform drop variables
	private bool platbool = false;
	public float plusy = 0.2f;
	public GameObject platform;


	// Use this for initialization
	void Start () {

		playerRB = GetComponent<Rigidbody2D> ();
		playerSR = GetComponent<SpriteRenderer> ();
		playerAnim = GetComponent<Animator> ();

		//crouching properties
		stand.enabled = true;
		crouch.enabled = false; 


		platform = GameObject.FindGameObjectWithTag ("Platform");

	}

	void FixedUpdate(){

		playerMove (); //call move function

		if(!isCrouching)
			playerJump (); //call jump function

		playerCrouch (); // call crouch function

		platformUp ();
		if(platbool == true)
			platformDown ();
	}


	void Update () {


		}


	//control player movement
	public void playerMove(){

		float xMove = Input.GetAxis ("Horizontal"); //get player input for the movement
		playerAnim.SetFloat ("Speed", Mathf.Abs (xMove)); //set "Speed" float on animator controller to start running
		playerRB.position = new Vector2 (playerRB.position.x + xMove * maxSpeed * Time.deltaTime, playerRB.position.y); //set new player position

		flipSprite (playerSR, xMove); //control sprite direction

	}


	public void playerJump(){
		
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);


		if (Input.GetButtonDown ("Jump") && grounded) {
			playerRB.velocity = (Vector2.up * jumpVelocity); //regular jump
			isJumping = true;
		}

		if (Input.GetButtonDown ("Jump") && !grounded && !doubleJumped && allowDoubleJump) {
			playerRB.velocity = (Vector2.up * jumpVelocity); //double jump
			doubleJumped = true;
		}

		if (grounded){
			doubleJumped = false; //reset double jump
			playerAnim.SetBool ("Jumping", false); //set animation
			isJumping = false;
		}


		if (Mathf.Abs(playerRB.velocity.y) > 0.1 )
			playerAnim.SetBool ("Jumping", true);//animation variables
		
		else
			playerAnim.SetBool ("Jumping", false);//animation variables


	}


	//function for flipping spirte
	public void flipSprite(SpriteRenderer SR, float direction) {

		if (direction < 0)
			SR.flipX = true;

		if (direction > 0)
			SR.flipX = false;
	}

	public void playerCrouch(){

		if (Input.GetKey (KeyCode.LeftControl)) {
			stand.enabled = false;
			crouch.enabled = true;
			maxSpeed = 2f;
			playerAnim.SetBool ("Crouching", true);
			isCrouching = true;
		} else if (!Physics2D.OverlapCircle(ceilCheck.position,groundCheckRadius,whatIsGround)){
			//verify if ceiling above player
			stand.enabled = true;
			crouch.enabled = false;
			maxSpeed = 3f;
			playerAnim.SetBool ("Crouching", false);
			isCrouching = false;
		}
	}


	//habilita a o trigger para ficar na plataforma
	private void platformUp ()
	{
		if (Physics2D.Raycast (new Vector3(this.transform.position.x,this.transform.position.y + plusy, this.transform.position.z), Vector2.up, playerSR.size.y, whatIsGround.value)) {
			platform.GetComponent<BoxCollider2D> ().isTrigger = true;
			platbool = false;
		} else
			platform.GetComponent<BoxCollider2D> ().isTrigger = false;
		platbool = true;

	}
	//desabilita o trigger para sair da plataforma
	private void platformDown ()
	{
		if (Input.GetKey (KeyCode.LeftControl) && Input.GetKey (KeyCode.Space)) {
			platform.GetComponent<BoxCollider2D> ().isTrigger = true;
		}

	}
}
