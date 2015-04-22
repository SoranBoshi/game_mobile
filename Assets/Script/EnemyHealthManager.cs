using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour {

	// Use this for initialization
	public int healthEnemy;

	public GameObject deatheffect;

	public int poinOfDeath;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (healthEnemy <= 0) 
		{
			Instantiate (deatheffect , transform.position , transform.rotation);
			Destroy (gameObject);
			Scoremanager.AddPoin(poinOfDeath);
		}
	}

	public void giveDamage (int dmg)
	{
		healthEnemy = healthEnemy - dmg;
	}
}
