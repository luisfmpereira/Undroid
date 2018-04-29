using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
	public bool grounded = false;
	private bool doubleJumped; //if has double jumped
	public Transform groundCheck; //ground check GO
	public Transform ceilCheck; //ceiling check GO
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	public bool isJumping;

	//double jump
	public bool allowDoubleJump = true; //unlock double jump
	public float doubleJumpModifier = 1.0f; //add extra force to double jump

	//life
	public Image[] hearts;
	private int currentHeart;

	private SpriteRenderer spriteRenderer;

	// usar isso no collisionenter quando tomar dano


	// usar isso quando ganhar vida 

	//			Destroy (hit.gameObject);
	//			currentHeart++;
	//			if (currentHeart < hearts.Length) {
	//				hearts [currentHeart].enabled = true;
	//			} else {
	//				currentHeart--;
	//			}
	//		}

	void Awake() {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		currentHeart = hearts.Length - 1;
	}

	void Start () {

		playerRB = GetComponent<Rigidbody2D> ();
		playerSR = GetComponent<SpriteRenderer> ();
		playerAnim = GetComponent<Animator> ();

		//crouching properties
		stand.enabled = true;
		crouch.enabled = false; 


	}

	void FixedUpdate(){

		playerMove (); //call move function

		if(!isCrouching)
			playerJump (); //call jump function

		playerCrouch (); // call crouch function
	
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

	void OnCollisionEnter2D(Collision2D hit){

		if (currentHeart < 0) 
			SceneManager.LoadScene (0);

		if (hit.gameObject.CompareTag ("EnemyBullet")) {
			Destroy (hit.gameObject);
			hearts [currentHeart].enabled = false;
			currentHeart--;
		
		}
			if(hit.gameObject.CompareTag("Enemy")) {
				hearts [currentHeart].enabled = false;
				currentHeart--;
		}
	

	}
}
