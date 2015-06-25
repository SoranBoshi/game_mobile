using UnityEngine;
using System.Collections;

public class getSkill : MonoBehaviour {

	// Use this for initialization
	public string current_level;
	private db_manager data_query;

	void Start () 
	{
		data_query = FindObjectOfType<db_manager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D (Collider2D cldr)
	{
		// jika player mengambil object ini maka , 
		if (cldr.name == "player_1") 
		{
			if (current_level.Equals ("level_1")) 
			{
				data_query.updateData(1,0,6); // membuka level 2	
			} 
			else if (current_level.Equals ("level_2")) 
			{
				data_query.updateData(1,0,7); // membuka level 3	
			} 
			else if (current_level.Equals ("level_3")) 
			{
				data_query.updateData(1,0,8); // membuka level 4	
			}

			Destroy(gameObject);
		}
	}

}
