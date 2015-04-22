using UnityEngine;
using System.Collections;

public class DestroyFinParticle : MonoBehaviour {

	// Use this for initialization
	private ParticleSystem thisParticle;
	void Start () 
	{
		thisParticle = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (thisParticle.isPlaying) 
		{
			return;
		}

		Destroy (gameObject);
	}

	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}
}
