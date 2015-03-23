using UnityEngine;
using System.Collections;

public class  GoRoundAI  :  MonoBehaviour {

	NavMeshAgent nav;	
	public GameObject[] MovePoints;
	int index = 0;
	bool IsReturn = true;
	GameObject CurrentObj;
	public bool roop ; 


	void  Start ()
	{
		CurrentObj = MovePoints [index];
		nav = GetComponent <NavMeshAgent> ();

	}
	
	void Update ()
	{	
		nav.SetDestination (CurrentObj.transform.position);
	}

	void OnTriggerEnter (Collider other)
	{	
		if(other.gameObject == CurrentObj)
		{
			if(index + 1 == MovePoints.Length)
			{
				IsReturn = true;
			}
			if(index == 0)
			{
				IsReturn = false;
			}
			GetNextpath();
		}
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
	
}