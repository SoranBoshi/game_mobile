using UnityEngine;
using System.Collections;

public class Level_Manager : MonoBehaviour {

	// Use this for initialization

	public GameObject currentCheckPoint;
	private player_control player;

	public GameObject deathPart; // efek animasi tewas
	public GameObject respawnPart; // efek animasi respawn

	public float repawnDelay; // delay dari respawn
	private CameraControler cam;

	private float gravityTemp; // temporary untuk save value gravity.

	public bool isRespawn;
	void Start () {
		player = FindObjectOfType<player_control> ();
		cam = FindObjectOfType<CameraControler> ();
		isRespawn = false;
		player.transform.position = currentCheckPoint.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RespawnPlayer()
	{
		StartCoroutine ("respawnPlayerCo");
	}

	public IEnumerator respawnPlayerCo()
	{

		//saat player tewas muncul animasi partikel sesuai lokasi player itu berada.
		Instantiate (deathPart, player.transform.position, player.transform.rotation);
		player.enabled = false; // pas mati ga bisa diapa2in
		player.renderer.enabled = false; // pas mati ga bisa diapa2in
		cam.isFolow = false;

		float fadeTime = GameObject.Find ("fadingObject").GetComponent<fading> ().BeginFade (1);
		
		yield return new WaitForSeconds (fadeTime);
		

		// area sebelum respawn.
		// area setelah respawn.

		//player.transform.position = currentCheckPoint.transform.position;
		//isRespawn = true;
		//cam.isFolow = true;
		//player.knockBackCount = 0;
		//player.enabled = true;
		//player.renderer.enabled = true;

		Application.LoadLevel("level_1");
		// saat player respawn muncul animasi respawn di checkpoinnya.

		//Instantiate (respawnPart, currentCheckPoint.transform.position, currentCheckPoint.transform.rotation);

		//fadeTime = GameObject.Find ("fadingObject").GetComponent<fading> ().BeginFade (-1);
		
		//yield return new WaitForSeconds (fadeTime);


	}
}
