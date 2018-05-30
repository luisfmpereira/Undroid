using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Player controller.
/// 
/// Fire 1 = JoyY = e - interact
/// Fire 2 = JoyB = s - crouch
/// Fire 3 = JoyRB = x - fire
/// Jump = JoyA = space - jump
/// Dash = JoyX = shift = dash
///  
/// </summary>


public class PlayerController : MonoBehaviour
{

	//components
	private Rigidbody2D playerRB;
	private SpriteRenderer playerSR;
	public SpriteRenderer playerArm;
	private Animator playerAnim;
	public CapsuleCollider2D playerCollider;

	//capsule collider modifications for crouching/standing
	private Vector2 crouchSizeColl = new Vector2(0.4f,0.8f);
	private Vector2 crouchOffColl = new Vector2(0f,-0.33f);
	private Vector2 standSizeColl = new Vector2(0.4f,1.5f);
	private Vector2 standOffColl = new Vector2(0f,0f);

	//movement variables
	public float maxSpeed = 3f;
	private int moveDirection;

	//jump variables
	public Transform groundCheck;
	//ground check GO
	public Transform ceilCheck;
	//ceiling check GO
	public LayerMask whatIsGround;
	public float jumpVelocity;
	public float maxGroundedTimer = 0.5f;
	private float groundCheckRadius;
	private float groundedTimer;
	private int jumpCounter;
	public bool grounded;

	//double jump
	public bool allowDoubleJump;
	//unlock double jump
	public float doubleJumpModifier = 1.0f;
	//add extra force to double jump
	private bool doubleJumped;
	//if has double jumped

	//shooting variables
	public Rigidbody2D playerBulletPrefab;
	public bool allowShooting;
	public float bulletSpeed;
	public Transform muzzlePos;


	//life
	public Image[] hearts;
	private int currentHeart;
	public string currentSceneName;

	//dash
	public bool allowDash;
	public float dashSpeed = 6f;
	private float dashTimer;
	public float dashCooldown = 1f;
	public float dashTimerAnim;
	public float dashCdAnim = 1;

	//audio
	public AudioManager audioManager;
	public string Die = "Die";
	public string Hurt = "Hurt";

	//shoot
	public float shootTimer;
	public float shootCd = 0.2f;


	void Awake ()
	{
		
		playerRB = GetComponent<Rigidbody2D> ();
		playerSR = GetComponent<SpriteRenderer> ();
		playerAnim = GetComponent<Animator> ();
		playerCollider = GetComponent<CapsuleCollider2D>();

		playerCollider.size = standSizeColl;
		playerCollider.offset = standOffColl;

		moveDirection = 1;
		transform.parent = null; //remove player from platform children if he dies while connected

		currentHeart = hearts.Length - 1; //reset player hearts

		groundCheckRadius = 0.1f; //radius for grounded

	}

	void Start (){
		audioManager = AudioManager.instance;
	}
		
	void Update ()
	{

		playerMove (); //call move function

		playerJump (); //call jump function

		playerCrouch (); // call crouch function

		playerShoot ();

		playerDash ();
	

		//restart level if all lives are lost
		if (currentHeart < 0) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}

		//dash cooldown
		if (allowDash && dashTimer > 0) {
			dashTimer -= Time.deltaTime;
		}

		if (dashTimerAnim > 0) {
			dashTimerAnim -= Time.deltaTime;
		} 
		if (dashTimerAnim < 0) {
			playerAnim.SetBool ("Dash", false);
		}
		if(shootTimer > 0){
			shootTimer -= Time.deltaTime;
			} 
		if (shootTimer < 0) {
				playerAnim.SetBool ("Shooting", false);
			}
			
	}

	//control player movement
	public void playerMove ()
	{

		float xMove = Input.GetAxis ("Horizontal"); //get player input for the movement
		playerAnim.SetFloat ("Speed", Mathf.Abs (xMove)); //set "Speed" float on animator controller to start running
		playerRB.position = new Vector2 (playerRB.position.x + xMove * maxSpeed * Time.deltaTime, playerRB.position.y); //set new player position

		if (xMove > 0)
			moveDirection = 1;
		if (xMove < 0)
			moveDirection = -1;

		flipSprite (playerSR, xMove); //control sprite direction
		flipSprite (playerArm , xMove);

	}


	public void playerJump ()
	{

		// check if player is grounded and reset regular jump
		if (Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround)) {
			groundedTimer = maxGroundedTimer;
			jumpCounter = 0;//reset off-platform jump

		} else {
			groundedTimer -= Time.deltaTime;//countdown off-platform jump
		}

		//test if still under off-platform jump countdown or already jumped
		if (groundedTimer <= 0 || jumpCounter >= 1) { 
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

		if (grounded) {
			doubleJumped = false; //reset double jump
			playerAnim.SetBool ("Jumping", false); //set animation
		}

		if (Mathf.Abs (playerRB.velocity.y) > 0.0001)
			playerAnim.SetBool ("Jumping", true);//animation variables
		
		else
			playerAnim.SetBool ("Jumping", false);//animation variables


	}


	//function for flipping spirte
	public void flipSprite (SpriteRenderer SR, float direction)
	{

		if (direction < 0) 
			SR.flipX = true;

		if (direction > 0) 
			SR.flipX = false;
	}


	public void playerCrouch ()
	{

		if (Input.GetButton ("Fire2")) {
			playerCollider.size = crouchSizeColl;
			playerCollider.offset = crouchOffColl;
			maxSpeed = 2f;
			playerAnim.SetBool ("Crouching", true);
		} else if (!Physics2D.OverlapCircle (ceilCheck.position, groundCheckRadius, whatIsGround)) {
			//verify if ceiling above player
			playerCollider.size = standSizeColl;
			playerCollider.offset = standOffColl;
			maxSpeed = 3f;
			playerAnim.SetBool ("Crouching", false);
		}
	}

	public void playerShoot ()
	{
		if (allowShooting) {
			if (Input.GetButtonDown ("Fire3")) {
				Rigidbody2D bullet;
				bullet = Instantiate (playerBulletPrefab, muzzlePos.position, Quaternion.identity) as Rigidbody2D;
				//add force to bullet
				bullet.AddForce (new Vector2 (moveDirection, 0) * bulletSpeed);
				Destroy (bullet.gameObject, 3);
				playerAnim.SetBool ("Shooting", true);
				shootTimer = shootCd;
			}
		}
	}

	public void playerDash ()
	{
		if (allowDash) {
			if (Input.GetButtonDown ("Dash") && dashTimer <= 0) {
				playerRB.AddForce (new Vector2 (moveDirection * dashSpeed, 0));
				dashTimer = dashCooldown;
				dashTimerAnim = dashCdAnim;
				playerAnim.SetBool ("Dash", true);
			}

		}

	}



	//collisions
	void OnCollisionEnter2D (Collision2D hit)
	{

		//damage taken by enemy bullet
		if (hit.gameObject.CompareTag ("EnemyBullet")) {
			Destroy (hit.gameObject);
			hearts [currentHeart].enabled = false;
			currentHeart--;
			if (currentHeart >= 0)
				audioManager.PlaySound (Hurt);
			else
				audioManager.PlaySound (Die);
		}

		//damage taken by enemy contact
		if (hit.gameObject.CompareTag ("Enemy") || hit.gameObject.CompareTag ("Boss") || hit.gameObject.CompareTag ("MovableEnemy")) {
			hearts [currentHeart].enabled = false;
			currentHeart--;
			if (currentHeart >= 0)
				audioManager.PlaySound (Hurt);
			else
				audioManager.PlaySound (Die);
		}

		//transfer movement to player in contact
		if (hit.gameObject.CompareTag ("LaserDamage")) {

			hearts [currentHeart].enabled = false;
			currentHeart--;

			playerRB.AddForce (new Vector2 (moveDirection * 225 * -1, 0));

			if (currentHeart >= 0)
				audioManager.PlaySound (Hurt);
			else
				audioManager.PlaySound (Die);
		}

		//turn plyer child of the platform - used to smooth movement
		if (hit.gameObject.CompareTag ("Platform"))
			transform.parent = hit.transform;


	}

	void OnCollisionExit2D (Collision2D hit)
	{
		if (hit.gameObject.CompareTag ("Platform"))
			transform.parent = null;
	}



	void OnTriggerEnter2D (Collider2D hit)
	{
		if (hit.gameObject.CompareTag ("KillZone")) {
			currentHeart = -1;
			audioManager.PlaySound (Die);
		}
		if (hit.gameObject.CompareTag ("Life") && currentHeart < 2) {
			Destroy (hit.gameObject);
			currentHeart++;
			if (currentHeart < hearts.Length) {
				hearts [currentHeart].enabled = true;
			} else {
				currentHeart--;
			}
		}
		if (hit.gameObject.CompareTag ("Laser")) {
			hit.transform.GetChild(1).transform.GetComponent<Animator>().SetBool("start", true);
		}
	}
}
