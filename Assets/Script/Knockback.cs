using UnityEngine;
using System.Collections;

public class Knockback : MonoBehaviour {

	// Use this for initialization
	private player_control player;


	void Start () {
		player = FindObjectOfType<player_control> ();



	}
	
	// Update is called once per frame
	void Update () {


	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name == "player_1") 
		{
			player.knockBackCount = player.knockBackLength;
			if (other.transform.position.x < transform.position.x)
			{
				player.knockRight = false;
			}
			else
			{
				player.knockRight = true;
			}
		}
	}
}
