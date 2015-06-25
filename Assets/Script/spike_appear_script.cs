using UnityEngine;
using System.Collections;

public class spike_appear_script : MonoBehaviour {

	// Use this for initialization
	public GameObject spike;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D cldr)
	{
		if (cldr.name == "player_1")
		{
			
			spike.SetActive(true);
			
		}
	}
}
