using UnityEngine;
using System.Collections;
//using UnitySampleAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {
	
	public  float speed = 3; 
	private Vector3 direction = Vector3.zero;
	private CharacterController playerController;
	private Animator animator;
	private Vector3  movement;
	private Rigidbody  playerRigidbody;
		
	void  Start (){
		playerController = GetComponent< CharacterController >();
//		animator = GetComponentInChildren< Animator >();
	}
		
	void  Update (){
		if( playerController.isGrounded ) {
			// 上下キーが押されたら
			if(Input.GetAxis("Vertical") != 0){
				float varticalMove= Input.GetAxis("Vertical");
//				animator.SetFloat("Speed" , varticalMove);
					
				direction = new Vector3(0 , 0 , varticalMove);
				direction = transform.TransformDirection(direction);
				direction *= speed;
			}
				
			// 左右キーが押されたら
			if(Input.GetAxis("Horizontal") != 0){
				transform.Rotate(0 , 100 * Time.deltaTime * Input.GetAxis("Horizontal") , 0);
			}
		}
		direction.y += Physics.gravity.y * Time.deltaTime;
		playerController.Move( direction * Time.deltaTime ); 
	}

	void Move(float h, float v)
	{
		movement.Set (h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;
		playerRigidbody.MovePosition (transform.position + movement);
		
	}

}
	