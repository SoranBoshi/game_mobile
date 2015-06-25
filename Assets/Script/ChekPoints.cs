using UnityEngine;
using System.Collections;

public class ChekPoints : MonoBehaviour {

	public Level_Manager leveMngr_class;
	private db_manager data_query;
	// Use this for initialization
	void Start () {
		leveMngr_class = FindObjectOfType<Level_Manager> ();
		data_query = FindObjectOfType<db_manager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D cldr)
	{
		if (cldr.name == "player_1")
		{
			leveMngr_class.currentCheckPoint =  gameObject;
			data_query.updateData(0,gameObject.transform.position.x,3);
			data_query.updateData(0,gameObject.transform.position.y,4);

			gameObject.transform.localScale = new Vector3(-0.3f,0.3f,0.3f);
		}
	}
}
