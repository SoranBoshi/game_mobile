using UnityEngine;
using System.Collections;

public class enemyStomp : MonoBehaviour {

	// Use this for initialization
	public int dmg;

	public float bounceValue;
	
	private Rigidbody2D myrigidBody;

	void Start () {
		// dapetin variabel rigid2D dari parentnyya.
		myrigidBody = transform.parent.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Enemy") 
		{
			other.GetComponent<EnemyHealthManager> ().giveDamage(dmg);
			myrigidBody.velocity = new Vector2 (myrigidBody.velocity.x , bounceValue);
		}
	}
}
