using UnityEngine;
using System.Collections;

public class MaiMenuScript : MonoBehaviour {


	public string startLevel;

	public GameObject credit_window;

	
	public int playerLive;

	void Update () 
	{

		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			credit_window.SetActive (false);
			
		}
	}

	public void New_Game()
	{
		StartCoroutine ("NewGame");
	}
	public IEnumerator NewGame()
	{
		float fadeTime = GameObject.Find ("fadingObject").GetComponent<fading>().BeginFade(1);
		yield return new WaitForSeconds (fadeTime);

		Application.LoadLevel (startLevel);
		PlayerPrefs.SetInt ("PlayerCurrentLives", playerLive);
		PlayerPrefs.SetInt ("ScoreCurrentLives",0);



	}


	public void QuitGame ()
	{
		Application.Quit();
	}

	public void credit_menu ()
	{
		credit_window.SetActive (true);
	}
}
