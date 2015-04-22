using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scoremanager : MonoBehaviour 
{

	public static int score;

	Text teks;

	void Start()
	{
		// sepertinya script getComponen untuk set objek yang ditempeli oleh script.
		// sehingga nantinya variabel Text itu mengacunya ke objek Score Value yang kena tempel ama script ini
		teks = GetComponent<Text> ();

		score = PlayerPrefs.GetInt("ScoreCurrentLives");
	}

	// update scorenya , tampilin ke text.
	void Update()
	{
		if (score < 0) 
		{
			score =0;
		}
		teks.text = "" + score;
	}

	// method untuk nambahin poin score.
	public static void AddPoin (int poinAdd)
	{
		score = score + poinAdd;
		PlayerPrefs.SetInt ("ScoreCurrentLives", score);
	}

	// reset score ke 0
	public static void Reset()
	{
		score = 0;
		PlayerPrefs.SetInt ("ScoreCurrentLives", score);
	}
}
