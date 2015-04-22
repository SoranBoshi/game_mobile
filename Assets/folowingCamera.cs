using UnityEngine;
using System.Collections;

public class folowingCamera : MonoBehaviour {

	// Use this for initialization

	private CameraControler kamera;
	void Start () {
		kamera = FindObjectOfType<CameraControler> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter2D (Collider2D cldr)
	{
		if (cldr.name == "player_1")
		{
			kamera.isFolow = false;
		}
	}

	void OnTriggerExit2D (Collider2D cldr)
	{
		if (cldr.name == "player_1")
		{
			kamera.isFolow = true;
		}
	}
}
