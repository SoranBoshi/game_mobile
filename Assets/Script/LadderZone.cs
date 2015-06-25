using UnityEngine;
using System.Collections;

public class LadderZone : MonoBehaviour {

	private player_control aPlayer;
	// Use this for initialization
	void Start () 
	{
		aPlayer = FindObjectOfType<player_control> ();
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other) 
	{
		if (other.name == "player_1") 
		{
			aPlayer.isLadder = true;
		}
	}

	void OnTriggerExit2D (Collider2D other) 
	{
		if (other.name == "player_1") 
		{
			aPlayer.isLadder = false;
		}
	}
}
