using UnityEngine;
using System.Collections;

public class CameraControler : MonoBehaviour {

	public player_control player;

	public bool isFolow;

	public float xoffset;
	public float yoffset;
	public int nativY;
	public float posY;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<player_control> ();

	}
	
	// Update is called once per frame
	void Update ()  
	{
		if (isFolow) 
		{
			transform.position = new Vector3(player.transform.position.x+xoffset,(player.transform.position.y+yoffset) * nativY + posY,-10);
		}
		// 3.38
		//if (transform.position.x - player.transform.position.x  < 3.38) 
		//{
	//		isFolow = true;
	//	}
	}
}
