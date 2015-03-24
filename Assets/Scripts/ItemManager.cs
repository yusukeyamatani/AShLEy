using UnityEngine;
using System.Collections;

public class ItemManager : MonoBehaviour {

	public int scoreValue;
	
	void Start () {
	}
	
	
	void OnTriggerEnter(Collider other)
	{		
		Debug.Log (other.tag);
		if (other.tag == "Player") {
			ScoreManager.score += scoreValue;
			Destroy (gameObject);
		}
	}
}