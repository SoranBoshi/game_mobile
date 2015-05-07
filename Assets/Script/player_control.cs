using UnityEngine;
using System.Collections;

public class player_control : MonoBehaviour {

	public float moveSpeed;
	public float jumpHeight;

	private float moveVeloc; // untuk menhentikan pergeraka terus menerus

	// akibat dari set material.

	public Transform cekGround; // var untuk mengecek objek penanda pada player,penanda untuk interaksi dengan ground.
	public float groundRadius; // var untuk mengetahui berapa radius player dengan tanah
	public LayerMask whatGround; // layer untuk pijakan groundnya (tanahnya)
	private bool IsGround; // boolean untuk cek apakah nyentuh tanah atau nggak.

	private Animator anim;

	public Transform firePoint;
	public GameObject srkn;

	public float shotDelay;
	private float delayCounter;

	public float knockBack;
	public float knockBackCount;
	public float knockBackLength;
	public bool knockRight;

	private bool btnKanan;
	private bool btnKiri;

	public bool isLadder;
	public float climbSpeed;
	private float climbVeloc;
	private float gravityStore;

	private Rigidbody2D myrigidbody;
	public bool isWarp;

	// Use this for initialization
	void Start () 
	{
		myrigidbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		gravityStore = myrigidbody.gravityScale;
		transform.localScale = new Vector3(1f,1f,1f);
	}

	void FixedUpdate()
	{
		IsGround = Physics2D.OverlapCircle (cekGround.position, groundRadius, whatGround);
	}
	
	// Update is called once per frame
	void Update () 
	{

		anim.SetBool ("Grounded",IsGround);
		if (Input.GetKeyDown (KeyCode.UpArrow) && IsGround) 
		{ 
			myrigidbody.velocity =  new Vector2(myrigidbody.velocity.x,jumpHeight); 

		}

		 // set ke 0 supaya kecepatan kembali default.
		 

		if (Input.GetKey (KeyCode.LeftArrow) || btnKiri) 
		{
			moveVeloc = -moveSpeed ; // kec ke arah kiri
		}
		if (Input.GetKey (KeyCode.RightArrow) || btnKanan) 
		{
			moveVeloc =  moveSpeed ; // kec ke arah kanan
		}

		if (Input.GetKeyUp (KeyCode.LeftArrow) || moveVeloc <=0) 
		{
			moveVeloc = moveVeloc + (Time.deltaTime * 14f);
			if (moveVeloc >=0)
			{
				moveVeloc = 0f;
			}
		}

		if (Input.GetKeyUp (KeyCode.RightArrow) || moveVeloc >=0) 
		{
			moveVeloc = moveVeloc - (Time.deltaTime * 14f);
			if (moveVeloc <=0)
			{
				moveVeloc = 0f;
			}
		}


		if (knockBackCount <= 0) 
		{
			// script untuk bergerak sesuai arah kecepatan vektornya.
			myrigidbody.velocity = new Vector2 (moveVeloc , myrigidbody.velocity.y); 
		} 
		else 
		{
			if (knockRight) 
			{
				myrigidbody.velocity = new Vector2 (knockBack, knockBack);
			}
			else
			{
				myrigidbody.velocity = new Vector2 (-knockBack, knockBack);
			}
			knockBackCount = knockBackCount - Time.deltaTime;
		}
			
		anim.SetFloat ("Speed", Mathf.Abs(myrigidbody.velocity.x));


		if (myrigidbody.velocity.x > 0) 
		{
			transform.localScale = new Vector3(1f,1f,1f);
		} 
		else if (myrigidbody.velocity.x < 0) 
		{
			transform.localScale = new Vector3(-1f,1f,1f);
		}

		// tombol buat nembak
		if (Input.GetKeyDown (KeyCode.Z)) 
		{
			Instantiate(srkn , firePoint.position , firePoint.rotation);
			delayCounter = shotDelay;
		}

		// tombol buat nembak
		if (Input.GetKey (KeyCode.Z)) 
		{
			delayCounter = delayCounter - Time.deltaTime;
			if (delayCounter <=0)
			{
				delayCounter = shotDelay;
				Instantiate(srkn , firePoint.position , firePoint.rotation);
			}
		}

		if (isLadder) 
		{
			myrigidbody.gravityScale = 0f; 

				if (Input.GetKey(KeyCode.UpArrow))
				{
				climbVeloc =  climbSpeed * 1;
				}
				
			if (Input.GetKey(KeyCode.DownArrow))
			{
				climbVeloc =  climbSpeed * -1;
			} 
				

			myrigidbody.velocity = new Vector2(myrigidbody.velocity.x , climbVeloc);
			climbVeloc = 0f;

		}

		if (!isLadder) 
		{
			myrigidbody.gravityScale = gravityStore;
		}
	}

	public void jump ()
	{
		isWarp = true;
		if (IsGround) 
		{
			myrigidbody.velocity =  new Vector2(myrigidbody.velocity.x,jumpHeight);
		}
	}

	public void nowarp()
	{
		isWarp = false;
	}

	public void moveLeft ()
	{

		btnKiri = true; 

	}

	public void moveRight ()
	{
		btnKanan = true;
	}

	public void moveLeftEnd ()
	{
		btnKiri = false; 
	}
	
	public void moveRightEnd ()
	{
		btnKanan = false;
	}
}
