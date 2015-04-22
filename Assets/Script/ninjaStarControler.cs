using UnityEngine;
using System.Collections;

public class ninjaStarControler : MonoBehaviour {

	// Use this for initialization
	public float speed;

	public player_control player;
	public GameObject deathParticleEnemy;

	public float rotationSpeed;
	void Start () 
	{
		player = FindObjectOfType<player_control> ();
		if (player.transform.localScale.x < 0) 
		{
			speed = - speed;
			rotationSpeed = - rotationSpeed;
		}
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody2D.velocity = new Vector2 (speed, rigidbody2D.velocity.y);
		rigidbody2D.angularVelocity = rotationSpeed;
	}

	// fungsi ini berarti objek yang ditempeli script
	// jika mengenai suatu objek
	// akan melakukan aksi . . .
	// dalam kasusu ini di destroy.
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Enemy") 
		{
			other.GetComponent<EnemyHealthManager>().giveDamage(1);
		}
		Destroy (gameObject);
	}
}
