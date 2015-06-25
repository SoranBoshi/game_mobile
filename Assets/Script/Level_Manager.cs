using UnityEngine;
using System.Collections;

public class Level_Manager : MonoBehaviour {

	// Use this for initialization

	public GameObject currentCheckPoint;
	private player_control player;
	private db_manager data_query;

	public GameObject deathPart; // efek animasi tewas
	public GameObject respawnPart; // efek animasi respawn

	public float repawnDelay; // delay dari respawn
	private CameraControler cam;
	public string curent_level;
	private float gravityTemp; // temporary untuk save value gravity.

	public bool isRespawn;


	void Start () {
		data_query = FindObjectOfType<db_manager> ();
		player = FindObjectOfType<player_control> ();
		cam = FindObjectOfType<CameraControler> ();
		isRespawn = false;

		player.transform.position = new Vector3(data_query.getX_pos(),data_query.getY_pos(),0);

	}
	
	// Update is called once per frame
	void Update () 
	{
	
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

		Application.LoadLevel(curent_level);

	}
}
