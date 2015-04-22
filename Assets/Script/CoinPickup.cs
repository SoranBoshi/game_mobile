using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour {

	// kelas ini gunanya untuk memicu pada objek koin kena , maka
	// poin akan ditambahkan


	public int PoinAdd;

	void OnTriggerEnter2D (Collider2D other)
	{
		// jika tidak ada objek yg kena maka do nothing.
		if (other.GetComponent<player_control> () == null) 
		{
			return;
		}

		// tambahkan point.
		Scoremanager.AddPoin (PoinAdd);

		// koin akan menghilang.
		Destroy (gameObject);
	}

}
