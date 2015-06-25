using UnityEngine;
using System.Collections;

public class faaling_move_plat : MonoBehaviour {

	// Use this for initialization
	private MovePlatform m_plat;
	void Start () {
		m_plat = FindObjectOfType<MovePlatform> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D cldr)
	{
		if (cldr.name == "player_1")
		{
			m_plat.player_up = true;
		}
	}

	void OnTriggerExit2D (Collider2D cldr)
	{
		if (cldr.name == "player_1")
		{
			m_plat.player_up = false;
		}
	}
}
