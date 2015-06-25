using UnityEngine;
using System.Collections;

public class player_control : MonoBehaviour {

	public float moveSpeed; // variabel untuk menentukan kecepatan bergerak.
	public float jumpHeight; // tinggi lompatannya berapa.

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

	private bool btnKanan; // variabel untuk penanda bahwa tombol kanan pada layar ditekan
	private bool btnKiri; // variabel untuk penanda bahwa tombol kiri pada layar ditekan
	private bool btnJump;
	private bool btnPU;

	public bool isLadder; // untuk mengecek apakah karakter ada di area tangga atau nggak
	public float climbSpeed;  // untuk menentukan kecepatan memanjat tangga
	private float climbVeloc;
	private float gravityStore; // variabel untuk menyimpan gravity untuk sementara (temporary)

	public Rigidbody2D  myrigidbody;
	public bool isWarp;
	private bool double_jump;
	public bool setDoubleJump;


	// inisialisasi
	void Start () 
	{
		myrigidbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		gravityStore = myrigidbody.gravityScale;
		transform.localScale = new Vector3(1f,1f,1f);

	}


	// Update is called once per frame
	void Update () 
	{
//================================================================================================
		// untuk mengontrol animasi karakternya , saat lompat atau tidak lompat.
		anim.SetBool ("Grounded",IsGround);
		IsGround = Physics2D.OverlapCircle (cekGround.position, groundRadius, whatGround);

		// jika tombol atas ditekan dan isground = true
		// dengan kata lain masih berpijak di tanah
		if (Input.GetKeyDown (KeyCode.UpArrow) && IsGround) 
		{ 

			// mengatur arah gerekan karakter dalam vektor 2 dimensi dengan satuan kecepatan
			// kecepatan arah sumbu x dan sumbu y.
			myrigidbody.velocity =  new Vector2(myrigidbody.velocity.x,jumpHeight);


			//dalam kasus ini nilai default velocity x adalah 0
			// sehingga hasilnya karakter akan loncat.
		} 

		if (Input.GetKeyDown (KeyCode.UpArrow) && !IsGround && double_jump) 
		{ 
			
			// mengatur arah gerekan karakter dalam vektor 2 dimensi dengan satuan kecepatan
			// kecepatan arah sumbu x dan sumbu y.
			myrigidbody.velocity =  new Vector2(myrigidbody.velocity.x,jumpHeight);
			double_jump = false;
			
			//dalam kasus ini nilai default velocity x adalah 0
			// sehingga hasilnya karakter akan loncat.
		} 
		if (IsGround) 
		{
			double_jump = setDoubleJump;
		}

//===============================================================================================
		// set ke 0 supaya kecepatan kembali default.
		if (Input.GetKey (KeyCode.LeftArrow) || btnKiri) 
		{
			moveVeloc = -moveSpeed ; // kec ke arah kiri
		}
		if (Input.GetKey (KeyCode.RightArrow) || btnKanan) 
		{
			moveVeloc =  moveSpeed ; // kec ke arah kanan
		}
//=================================================================================================
		// supaya pergerakannya lebih smooth
		// dan supaya karakter ga bergerak terus menerus. (analoginya seperti rem remnya)
		// kondisi ini dipenuhi saat tombol keyboard di lepas.
		if (Input.GetKeyUp (KeyCode.LeftArrow) || moveVeloc <=0) 
		{
			// script ini dipenuhi jika dia bergerak ke kiri , dan nilai kecepatannya x nya negatif
			// sehingga untuk mencapai kecepatan 0 , harus ditambah sampai mencapai 0
			moveVeloc = moveVeloc + (Time.deltaTime * 14f);
			if (moveVeloc >=0)
			{
				moveVeloc = 0f;
			}
		}
		// supaya pergerakannya lebih smooth
		if (Input.GetKeyUp (KeyCode.RightArrow) || moveVeloc >=0) 
		{
			// script ini dipenuhi jika dia bergerak ke kiri , dan nilai kecepatannya x nya positif.
			// sehingga untuk mencapai kecepatan 0 , harus kurangi sampai mencapai 0
			moveVeloc = moveVeloc - (Time.deltaTime * 14f);
			if (moveVeloc <=0)
			{
				moveVeloc = 0f;
			}
		}
//====================================================================================================
		// selama kondisi karakter tidak dalam knockback , maka
		// kondisi di dalam if ini akan selalu dieksekusi
		// sehingga karakter akan bergerak terus sesuai arah sumbu x dan y.
		if (knockBackCount <= 0) 
		{
			// script untuk bergerak sesuai arah kecepatan vektornya.
			myrigidbody.velocity = new Vector2 (moveVeloc , myrigidbody.velocity.y); 
		} 
		else 
		{ // script ini dieksekusi hanya jika kondisi karakter dalam status knock back
			if (knockRight) 
			{
				// knock back ke arah kanan , kecepatan sumbu x positif.
				myrigidbody.velocity = new Vector2 (knockBack,knockBack);
			}
			else// ke arah kiri
			{
				// knock back ke arah kiri , kecepatan sumbu x negatif.
				myrigidbody.velocity = new Vector2 (-knockBack,knockBack);
			}
			knockBackCount = knockBackCount - Time.deltaTime;
		}

		// baris ini untuk mengontrol animasinya
		// inputan adalah nilai kecepatan vektor x nya.
		// jika lebih dari 0.1 maka animasi berjalan dijalankan.
		// jika lebih kecil dari 0.1 maka animasi idle dijalankan
		anim.SetFloat ("Speed", Mathf.Abs(myrigidbody.velocity.x));
//=================================================================================================
		// untuk menentukan arah gerakannya ke kiri atau kanan
		if (myrigidbody.velocity.x > 0)  // saat kecepatanny apositif
		{
			// jika kec arah x nya positif , maka gerakan ke kanan
			// dan gambar karakternya akan kebalik
			transform.localScale = new Vector3(1f,1f,1f);
		} 
		else if (myrigidbody.velocity.x < 0) // saat negativ dia ke kiri
		{
			// jika kec arah x nya negatif , maka gerakan ke kiri
			transform.localScale = new Vector3(-1f,1f,1f);
		}
//==================================================================================================
				// tombol buat nembak
				if (Input.GetKeyDown (KeyCode.Z)) 
				{
					// bari ini untuk mengeluarkan shuriken dari titik tembaknya.
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
//=============================================================================================
							// kontrol saat kondisi ada di area tangga.
							// script saat karakter ada di area tangga
							if (isLadder) 
							{
								// sat di area tangga gravitynya menjadi 0 
								myrigidbody.gravityScale = 0f; 

									if (Input.GetKey(KeyCode.UpArrow) || btnJump)
									{
										climbVeloc =  climbSpeed;
									}
									
								if (Input.GetKey(KeyCode.DownArrow))
								{
									climbVeloc =  -climbSpeed;
								} 
								myrigidbody.velocity = new Vector2(myrigidbody.velocity.x , climbVeloc);
								climbVeloc = 0f;

							}
							// kondisi saat keluar dari area ladder.
							if (!isLadder) 
							{
								// jika keluar dari zona tangga , maka gravity kembali ke nilai awal.
								myrigidbody.gravityScale = gravityStore;
							}

//====================================================================================
	} // end of update procedure.

//======================================================================================
	/*
	 * area untuk fungsi bantuan. 
	 * 
	 *
	*/
	public void jump ()
	{
		isWarp = true;
		btnJump = true;
		if (IsGround) 
		{
			myrigidbody.velocity =  new Vector2(myrigidbody.velocity.x,jumpHeight);
		}

		if (!IsGround && double_jump) 
		{
			myrigidbody.velocity =  new Vector2(myrigidbody.velocity.x,jumpHeight);
			double_jump = false;
		}
	}

	public void noJump()
	{
		isWarp = false;
		btnJump = false;
	}

	public void Shoot()
	{
		Instantiate(srkn , firePoint.position , firePoint.rotation);
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

	public void btnPcUp()
	{
		btnPU = !btnPU;
	}

	public bool getPU()
	{
		return btnPU;
	}


	// kondisi saat karakter naik di platform
	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.transform.tag == "MovePlateform") 
		{
			// maka posisi pergerakan dari karakternya
			// akan mengikuti dari platformnya.
			transform.parent = other.transform;
		}

	}

	// kondisi saat karakter keluar dari platfrom
	void OnCollisionExit2D (Collision2D other)
	{
		if (other.transform.tag == "MovePlateform") 
		{
			// jika keluar dari platfrom pergerakan dari karakternya dibuat null.
			// dengan kata lain tidak akan terikat oleh platfromnya.
			transform.parent = null;
		}
	}
}
