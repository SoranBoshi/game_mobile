using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour {

	// Use this for initialization


	private int lifeCounter;

	private Text teks_life;

	void Start () 
	{
		teks_life = GetComponent<Text> ();

		lifeCounter = PlayerPrefs.GetInt("PlayerCurrentLives");
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
		PlayerPrefs.SetInt ("PlayerCurrentLives", lifeCounter);
	}
}
