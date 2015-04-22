using UnityEngine;
using System.Collections;

public class ChekPoints : MonoBehaviour {

	public Level_Manager leveMngr_class;
	// Use this for initialization
	void Start () {
		leveMngr_class = FindObjectOfType<Level_Manager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D cldr)
	{
		if (cldr.name == "player_1")
		{
			leveMngr_class.currentCheckPoint =  gameObject;
		}
	}
}
