using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {

	private bool playerInZone;
	public string LevelLoad;
	private player_control player;


	// Use this for initialization
	void Start () 
	{
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
