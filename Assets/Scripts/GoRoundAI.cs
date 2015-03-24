using UnityEngine;
using System.Collections;

public class  GoRoundAI  :  MonoBehaviour {

	NavMeshAgent nav;	
	Transform _transform;
	public GameObject[] MovePoints;
	int index = 0;
	bool IsReturn = true;
	GameObject CurrentObj;
	public bool roop ; 
	public int squareFarRange = 10;
		

	void  Start ()
	{
		CurrentObj = MovePoints [index];
		nav = GetComponent <NavMeshAgent> ();
		_transform = GetComponent<Transform>();

	}
	
	void Update ()
	{	
		if (ISHit()) {
			MovePath();
		}
		nav.SetDestination (CurrentObj.transform.position);
	}

	
	void GetNextpath()
	{
		if (roop)
		{
			RoopMove ();
		}
		else
		{
			ReturnMove() ;
		}
		CurrentObj = MovePoints [index];
	}

	void RoopMove()
	{
		if (!IsReturn) 
		{
			index++ ;
		} 
		else 
		{
			index = 0;
		}
	}

	void ReturnMove()
	{
		if (!IsReturn) 
		{
			index++ ;
		} 
		else 
		{
			index--;
		}
		
	}

	bool ISHit(){
		if ((_transform.position - CurrentObj.transform.position).sqrMagnitude < squareFarRange) {
			return true;
		} else {
			return  false;
		}

	}

	void MovePath(){

		if (index + 1 == MovePoints.Length) {
				IsReturn = true;
		}
		if (index == 0) {
				IsReturn = false;
		}
		GetNextpath ();
	}

	
}