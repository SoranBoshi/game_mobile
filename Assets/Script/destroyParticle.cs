using UnityEngine;
using System.Collections;

public class destroyParticle : MonoBehaviour {

	// Use this for initialization
	private Level_Manager lvl_mng;
	void Start () 
	{
		lvl_mng = FindObjectOfType<Level_Manager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (lvl_mng.isRespawn) 
		{
			Destroy (gameObject);
			lvl_mng.isRespawn = false;
		}

	}
}
