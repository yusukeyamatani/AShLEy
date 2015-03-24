using UnityEngine;
using System.Collections;

[RequireComponent(typeof (GoRoundAI))]
public class EnemyAI : MonoBehaviour {
	
	GameObject player;
	Transform _transform;
	NavMeshAgent nav;
	GoRoundAI  goRoundAI;
	public float angle = 90f;
	bool IshHt = false;
	RaycastHit hit;

	
	void Start(){
		_transform = GetComponent<Transform>();
		player = GameObject.FindGameObjectWithTag ("Player");
		nav = GetComponent <NavMeshAgent> ();
		goRoundAI = GetComponent <GoRoundAI> ();
	}


	void OnTriggerStay (Collider other)
	{
		if  (other.gameObject == player && !IshHt){
			if (Vector3.Angle(player.transform.position - _transform.position, transform.forward) < angle){
				goRoundAI.enabled = false;
				nav.SetDestination (player.transform.position - new Vector3(5.0f, 0.0f, 0.0f));
				IshHt = true ;
			}
		}
		else if (other.gameObject == player && IshHt)
		{
			nav.SetDestination (player.transform.position - new Vector3(5.0f, 0.0f, 0.0f));
		}

	}


	void OnTriggerExit (Collider other)
	{		
		if (other.gameObject == player) {
			goRoundAI.enabled = true;
			IshHt = false;
		}
			
	} 
		
}