using UnityEngine;
using System.Collections;

public class enemyPatrol : MonoBehaviour {

	public float moveSpeed; // kecepatan gerak musuh
	public bool isRight; // control untuk pergerakan kiri / kanan

	public Transform cekWall; // var untuk mengecek objek penanda pada musuh,penanda untuk interaksi dengan ground.
	public float wallRadius; // var untuk mengetahui berapa radius musuh dengan tembok
	public LayerMask whatWall; // layer untuk pijakan wallnya (temboknya)
	private bool IsWall; // boolean untuk cek apakah nyentuh wall atau nggak.

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		IsWall = Physics2D.OverlapCircle (cekWall.position, wallRadius, whatWall);

		if (IsWall) 
		{
			isRight = !isRight;
		}

		if (isRight) 
		{ // jika dia bergerak ke kanan maka gerak ke arah kanan
			transform.localScale = new Vector3(-1f,1f,1f);
			rigidbody2D.velocity = new Vector2 (moveSpeed, rigidbody2D.velocity.y);
		} 
		else 
		{// jika dia bergerak ke arah kiri , maka kecepatan berlawanan ke negativ
			transform.localScale = new Vector3(1f,1f,1f);
			rigidbody2D.velocity = new Vector2 (-moveSpeed, rigidbody2D.velocity.y);
		}
	}
}
