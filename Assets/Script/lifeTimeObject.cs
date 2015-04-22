using UnityEngine;
using System.Collections;

public class lifeTimeObject : MonoBehaviour {

	// Use this for initialization
	public float time;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		time = time - Time.deltaTime;
		if (time < 0) 
		{
			Destroy (gameObject);
		}
	}
}
