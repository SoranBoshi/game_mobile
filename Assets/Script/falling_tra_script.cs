using UnityEngine;
using System.Collections;

public class falling_tra_script : MonoBehaviour {

	// Use this for initialization
	public string object_name;
	public float speed;
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D (Collider2D cldr)
	{
		if (cldr.name == "player_1")
		{
		    GameObject.Find(object_name).rigidbody2D.gravityScale = speed;
		}
	}

	void OnTriggerExit2D (Collider2D cldr)
	{
		if (cldr.name == "player_1")
		{
			Destroy(gameObject);
		}
	}
}
