using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {

	private bool playerInZone;
	public string LevelLoad;
	private player_control player;
	db_manager data_query;

	// Use this for initialization
	void Start () 
	{
		data_query = FindObjectOfType<db_manager> ();
		player = FindObjectOfType<player_control> ();
		playerInZone = false;
		player.isWarp = false;

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (playerInZone && player.isWarp) 
		{
			StartCoroutine("LoadLvl");
		}
	}

	public IEnumerator LoadLvl()
	{

		float fadeTime = GameObject.Find ("fadingObject").GetComponent<fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		Application.LoadLevel(LevelLoad);

		if (LevelLoad.Equals ("level_1")) 
		{
			data_query.updateData(0,-0.2f,3);
			data_query.updateData(0,-0.2f,4);

		} 
		else if (LevelLoad.Equals ("level_2")) 
		{
			data_query.updateData(0,-0.53f,3);
			data_query.updateData(0,-0.28f,4);

			
		} 
		else if (LevelLoad.Equals ("level_3")) 
		{
			data_query.updateData(0,-0.3f,3);
			data_query.updateData(0,-0.02f,4);

		}
		else if (LevelLoad.Equals ("level_4")) 
		{
			data_query.updateData(0,-0.38f,3);
			data_query.updateData(0,-0.05f,4);

		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "player_1") 
		{
			playerInZone = true;

		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.name == "player_1") 
		{
			playerInZone = false;
		}
	}
	

}
