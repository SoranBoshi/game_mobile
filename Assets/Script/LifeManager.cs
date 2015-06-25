using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour {

	// Use this for initialization

	private db_manager data_query;
	private int lifeCounter;
	private player_control player;
	private Text teks_life;
	public GameObject btnPikup;
	public GameObject btnShoot;

	void Start () 
	{
		teks_life = GetComponent<Text> ();
		data_query = FindObjectOfType<db_manager> ();
		lifeCounter = data_query.getLife ();
		player = FindObjectOfType<player_control> ();

		if (data_query.getLvl2 ()) 
		{
			btnPikup.SetActive(true);
		}
		
		if (data_query.getLvl3 ()) 
		{
			player.setDoubleJump = true;
		}
		
		if (data_query.getLvl4 ()) 
		{
			btnShoot.SetActive(true);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		teks_life.text = "x " + lifeCounter;
	}

	public void GiveLife ()
	{
		lifeCounter ++;
	}

	public void TakeLife ()
	{
		lifeCounter --;
		data_query.updateData (lifeCounter,0,1);
	}
}
