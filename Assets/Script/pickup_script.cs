using UnityEngine;
using System.Collections;

public class pickup_script : MonoBehaviour {

	// Use this for initialization
	public GameObject carrier;
	private player_control player;

	private bool areaPick;
	private bool isCarying;
	private bool isThrow;

	void Start () 
	{
		player = FindObjectOfType<player_control> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.getPU () && areaPick) 
		{
			isCarying = true;
		} 
		if (isCarying) 
		{
			gameObject.rigidbody2D.mass = 0.05f;
			gameObject.transform.position = new Vector3 (carrier.transform.position.x, carrier.transform.position.y + 0.33f, carrier.transform.position.z);
		    if (!player.getPU())
			{
				isCarying = false;
				isThrow = true;
			}
		}

		if (isThrow) 
		{
			gameObject.rigidbody2D.velocity = new Vector2(6f,0); 

		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name == "player_1")
		{
			areaPick = true;
		}

		if (other.tag == "destroy_obj") 
		{
			Destroy(other);
			Destroy(gameObject);
		}

	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.name == "player_1")
		{
			areaPick = false;
		}
	}

	
}
