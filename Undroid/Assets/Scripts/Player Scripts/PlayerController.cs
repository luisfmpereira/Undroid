using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



/// <summary>
/// Player controller.
/// 
/// Fire 1 = JoyA = e - interact
/// Fire 2 = JoyB = s - crouch
/// Fire 3 = JoyX = x or c - fire
/// Jump = JoyY = space - jump
///  
/// </summary>






public class PlayerController : MonoBehaviour {

	//components
	private Rigidbody2D playerRB;
	private SpriteRenderer playerSR;
	private Animator playerAnim;
	public CapsuleCollider2D stand;
	public CapsuleCollider2D crouch;

	//movement variables
	public float maxSpeed = 3f;
	private int moveDirection;

	//jump variables
	public Transform groundCheck; //ground check GO
	public Transform ceilCheck; //ceiling check GO
	public LayerMask whatIsGround;
	public float jumpVelocity;
	public float maxGroundedTimer = 0.5f;
	private float groundCheckRadius;
	private float groundedTimer;
	private int jumpCounter;
	public bool grounded;

	//double jump
	public bool allowDoubleJump; //unlock double jump
	public float doubleJumpModifier = 1.0f; //add extra force to double jump
	private bool doubleJumped; //if has double jumped

	//shooting variables
	public Rigidbody2D playerBulletPrefab;
	public bool allowShooting;
	public float bulletSpeed;
	public Transform muzzlePos;


	//life
	public Image[] hearts;
	private int currentHeart;
	public string currentSceneName;

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
		playerRB = GetComponent<Rigidbody2D> ();
		playerSR = GetComponent<SpriteRenderer> ();
		playerAnim = GetComponent<Animator> ();

		moveDirection = 1;
		transform.parent = null; //remove player from platform children if he dies while connected

		currentHeart = hearts.Length - 1; //reset player hearts
	}

	void Start () {
		
		//crouching properties
		stand.enabled = true;
		crouch.enabled = false;
		groundCheckRadius = 0.1f;

	}

	void FixedUpdate(){

		playerMove (); //call move function

		playerJump (); //call jump function

		playerCrouch (); // call crouch function

		playerShoot();
	
	}


	void Update () {

		//restart level if all lives are lost
		if (currentHeart < 0) {
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		}
	}

	//control player movement
	public void playerMove(){

		float xMove = Input.GetAxis ("Horizontal"); //get player input for the movement
		playerAnim.SetFloat ("Speed", Mathf.Abs (xMove)); //set "Speed" float on animator controller to start running
		playerRB.position = new Vector2 (playerRB.position.x + xMove * maxSpeed * Time.deltaTime, playerRB.position.y); //set new player position

		if (xMove > 0)
			moveDirection = 1;
		if (xMove < 0)
			moveDirection = -1;

		flipSprite (playerSR, xMove); //control sprite direction

	}


	public void playerJump(){

		// check if player is grounded and reset regular jump
		if (Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround) ) {
			groundedTimer = maxGroundedTimer;
			jumpCounter = 0;//reset off-platform jump

		} else {
			groundedTimer -= Time.deltaTime;//countdown off-platform jump
		}

		//test if still under off-platform jump countdown or already jumped
		if (groundedTimer <= 0 || jumpCounter >=1) { 
			grounded = false;
		} else
			grounded = true;

		if (Input.GetButtonDown ("Jump") && grounded) {
			playerRB.velocity = (Vector2.up * jumpVelocity); //regular jump
			jumpCounter++;
		}

		if (Input.GetButtonDown ("Jump") && !grounded && !doubleJumped && allowDoubleJump) {
			playerRB.velocity = (Vector2.up * jumpVelocity); //double jump
			doubleJumped = true;
		}

		if (grounded){
			doubleJumped = false; //reset double jump
			playerAnim.SetBool ("Jumping", false); //set animation
		}

		if (Mathf.Abs(playerRB.velocity.y) > 0.0001)
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

		if (Input.GetButton ("Fire2")) {
			stand.enabled = false;
			crouch.enabled = true;
			maxSpeed = 2f;
			playerAnim.SetBool ("Crouching", true);
		} else if (!Physics2D.OverlapCircle(ceilCheck.position,groundCheckRadius,whatIsGround)){
			//verify if ceiling above player
			stand.enabled = true;
			crouch.enabled = false;
			maxSpeed = 3f;
			playerAnim.SetBool ("Crouching", false);
		}
	}

	public void playerShoot(){
		if (allowShooting) {
			if (Input.GetButtonDown ("Fire3")) {
				Rigidbody2D bullet;
				bullet = Instantiate (playerBulletPrefab, muzzlePos.position, Quaternion.identity) as Rigidbody2D;
				//add force to bullet
				bullet.AddForce (new Vector2 (moveDirection, 0) * bulletSpeed);

				Destroy (bullet.gameObject, 3);

			}
		}
	}



	//collisions
	void OnCollisionEnter2D(Collision2D hit){

		//damage taken by enemy bullet
		if (hit.gameObject.CompareTag ("EnemyBullet")) {
			Destroy (hit.gameObject);
			hearts [currentHeart].enabled = false;
			currentHeart--;
		
		}

		//damage taken by enemy contact
			if(hit.gameObject.CompareTag("Enemy")) {
				hearts [currentHeart].enabled = false;
				currentHeart--;
		}

		//turn plyer child of the platform - used to smooth movement
		if (hit.gameObject.CompareTag ("Platform")) {

			transform.parent = hit.transform;
		}
	

	}

	void OnCollisionExit2D(Collision2D hit){


		if (hit.gameObject.CompareTag ("Platform")) {

			transform.parent = null;
		}

	}
}
