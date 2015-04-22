using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {


	public string mainMenu;
	public bool isPause;

	public GameObject pauseMenu;
	 	

	// Use this for initialization
		
	// Update is called once per frame
	void Update () {
		if (isPause) 
		{

			pauseMenu.SetActive (true);


			Time.timeScale = 0f;

		} 
		else 
		{
			pauseMenu.SetActive(false);
			Time.timeScale = 1f;

		}

		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			isPause = !isPause;

		}
	}

	public IEnumerator QuitButon()
	{

		float fadeTime = GameObject.Find ("fadingObject").GetComponent<fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		Application.LoadLevel(mainMenu);
	}

	public void Resume ()
	{
		isPause = false;
	}

	public void Quit()
	{
		isPause = false;
		StartCoroutine ("QuitButon");
	}
}
