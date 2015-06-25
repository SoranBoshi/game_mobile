using UnityEngine;
using System.Collections;

public class trampoline : MonoBehaviour {

	// Use this for initialization
	private player_control player;
	private float knockbackCount;
	public float knockbackLength;
	void Start () {
		player = FindObjectOfType<player_control> ();
		knockbackCount = -1;
	}
	
	// Update is called once per frame
	void Update () {
		if (knockbackCount >= 0) 
		{
			player.myrigidbody.velocity = new Vector2 (player.myrigidbody.velocity.x ,10.5f);
			knockbackCount = knockbackCount - Time.deltaTime;
		}

	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name == "player_1") 
		{
			knockbackCount = knockbackLength;
		}
	}
}
