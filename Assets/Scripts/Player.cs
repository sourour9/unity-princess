using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{  public Animator playerAnim;
	public Rigidbody playerRigid;
	public float w_speed, wb_speed, olw_speed, rn_speed, ro_speed;
	public bool walking;
	public Transform playerTrans;
		void FixedUpdate(){
			Update();
		if(Input.GetKey(KeyCode.S)){
			playerRigid.velocity = transform.forward * w_speed * Time.deltaTime;
			
		}
		if(Input.GetKey(KeyCode.W)){
			playerRigid.velocity = -transform.forward * wb_speed * Time.deltaTime;
		}
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.W)){
			Console.WriteLine("here");
			playerAnim.ResetTrigger("idle");
			playerAnim.SetTrigger("walk");
			walking = true;
		}
		if(Input.GetKeyUp(KeyCode.W)){
			playerAnim.SetTrigger("idle");
			playerAnim.ResetTrigger("walk");
			walking = false;
		}
	
		if(Input.GetKey(KeyCode.A)){
			playerTrans.Rotate(0, -ro_speed * Time.deltaTime, 0);
		}
		if(Input.GetKey(KeyCode.D)){
			playerTrans.Rotate(0, ro_speed * Time.deltaTime, 0);
		}
		if(walking == true){				
			if(Input.GetKeyDown(KeyCode.J)){
				w_speed = w_speed + rn_speed;
				playerAnim.SetTrigger("jump");
				playerAnim.ResetTrigger("walk");
			}
			if(Input.GetKeyUp(KeyCode.J)){

				w_speed = olw_speed;
				playerAnim.ResetTrigger("jump");
				playerAnim.SetTrigger("walk");
			}
		}
	}
}