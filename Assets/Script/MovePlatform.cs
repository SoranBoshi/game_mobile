using UnityEngine;
using System.Collections;

public class MovePlatform : MonoBehaviour {

	public GameObject platform;
	public float moveSpeed;
	public Transform lokasiSekarang;
	public Transform[] point;
	public int poinIndex;


	public bool player_up;
	void Start () 
	{
		player_up = false;
		lokasiSekarang = point [poinIndex];
	}
	
	// Update is called once per frame
	void Update () 
	{
		platform.transform.position = Vector3.MoveTowards (platform.transform.position, lokasiSekarang.position, Time.deltaTime * moveSpeed);
	

		if (platform.transform.position == lokasiSekarang.position) 
		{
			poinIndex++;
			poinIndex = poinIndex % 2;
			if ((platform.transform.position == point [1].position) && (player_up)) 
			{
				poinIndex = 2;
				moveSpeed = 12f;
			}
		}

			lokasiSekarang = point [poinIndex];

	}


}
