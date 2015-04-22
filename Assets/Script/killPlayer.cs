using UnityEngine;
using System.Collections;

public class killPlayer : MonoBehaviour {

	private Level_Manager leveMngr_class;
	private LifeManager lifesistem;
	// Use this for initialization
	void Start () {
		leveMngr_class = FindObjectOfType<Level_Manager> ();
		lifesistem = FindObjectOfType<LifeManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D cldr)
	{
		if (cldr.name == "player_1")
		{

			lifesistem.TakeLife();
			leveMngr_class.RespawnPlayer();

		}
	}
}
