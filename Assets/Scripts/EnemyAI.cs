using UnityEngine;
using System.Collections;

[RequireComponent(typeof (GoRoundAI))]
public class EnemyAI : MonoBehaviour {
	
	Transform player;
	Transform _transform;
	NavMeshAgent nav;
	float squareFarRange = 200f;
	GoRoundAI  goRoundAI;

	
	void Start(){
		_transform = GetComponent<Transform>();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent <NavMeshAgent> ();
		goRoundAI = GetComponent <GoRoundAI> ();
	}
	
	void Update (){
		if (AIFunction ()) {
			goRoundAI.enabled = false;
			nav.SetDestination (player.position);
//			Debug .Log("###########GO");
		} 
		else 
		{
			goRoundAI.enabled = true;
//			Debug .Log("###########STOP");
		}
	}
	
	bool AIFunction(){
		Debug.Log ("$$$$$$$$:" +  (_transform.position - player.position));
		Debug.Log ("########:" + (_transform.position - player.position).sqrMagnitude);
		if ((_transform.position - player.position).sqrMagnitude < squareFarRange) {
			return true;
		} 
		else 
		{
			return false;
		}
	}
}