//using UnityEngine;
//using System.Collections;
//
//public class Enemy_AI_Basic : MonoBehaviour {
//
//	//Enemy Controller
//	Transform player;
//	Animator enemy_Anim;
//
//	public bool walk = true;
//	private float nextAtk = 0f;
//
//	void Awake(){
//		//Call Animator of Enemy
//		enemy_Anim = GetComponent<Animator> ();
//	}
//
//	//Check enemy walk
//	void OnTriggerEnter2D(Collider2D other){
//		if (other.gameObject.tag == "Enemy") {
//			if(Game_Controller.enemyStruckPlayer && walk){
//				enemy_Anim.SetBool ("Walk_Left", false);
//				enemy_Anim.SetBool ("Walk_Right", false);
//				enemy_Anim.SetBool ("Walk_Down", false);
//				enemy_Anim.SetBool ("Walk_Up", false);
//				walk = false;
//			}
//		}
//		
//		if(other.gameObject.tag == "Arrow"){
//			HpDown(Game_Controller.playerInThisMap.Atk);
//		}
//	}
//	
//	void OnTriggerStay2D(Collider2D other){
//		if (other.gameObject.tag == "Enemy") {
//			if(Game_Controller.enemyStruckPlayer && walk){
//				enemy_Anim.SetBool ("Walk_Left", false);
//				enemy_Anim.SetBool ("Walk_Right", false);
//				enemy_Anim.SetBool ("Walk_Down", false);
//				enemy_Anim.SetBool ("Walk_Up", false);
//				walk = false;
//			}else if(!walk){
//				walk = false;
//			}
//		}
//		if(other.gameObject.tag == "Trap"){
//			hitPoint = hitPoint - Skill_Controller.trapDmg;
//			Destroy(other.gameObject, 0.5f);
//		}
//	}
//	
//	void OnTriggerExit2D(Collider2D other){
//		if(other.gameObject.tag == "Enemy"){
//			walk = true;
//		}
//	}
//	
//	void OnCollisionEnter2D(Collision2D other){
//		if(other.gameObject.tag == "Player"){
//			enemy_Anim.SetBool ("Walk_Left", false);
//			enemy_Anim.SetBool ("Walk_Right", false);
//			enemy_Anim.SetBool ("Walk_Down", false);
//			enemy_Anim.SetBool ("Walk_Up", false);
//			walk = false;
//			Game_Controller.enemyStruckPlayer = true;
//		}
//	}
//	
//	//Enemy Attack
//	void OnCollisionStay2D(Collision2D other){
//		if(other.gameObject.tag == "Player"){
//			if(Time.time > nextAtk){
//				nextAtk = Time.time + baseAspd;
//				Game_Controller.playerInThisMap.EnemyAttacked(Attack);
//			}
//		}
//	}
//	
//	void OnCollisionExit2D(Collision2D other){
//		if(other.gameObject.tag == "Player"){
//			walk = true;
//			Game_Controller.enemyStruckPlayer = false;
//		}
//	}
//
//
//	void Enemy_Movement(bool walk){
//		
//		if(walk){
//
//			if(Mathf.Abs(distanceBetweenEVP.x) > Mathf.Abs(distanceBetweenEVP.y)){
//				if(distanceBetweenEVP.x > 0){
//					enemy_Anim.SetBool ("Walk_Left", true);
//					enemy_Anim.SetBool ("Walk_Right", false);
//					enemy_Anim.SetBool ("Walk_Down", false);
//					enemy_Anim.SetBool ("Walk_Up", false);
//					transform.position += (player.position - transform.position).normalized * runSpeed * Time.deltaTime;
//				}else{
//					enemy_Anim.SetBool ("Walk_Right", true);
//					enemy_Anim.SetBool ("Walk_Left", false);
//					enemy_Anim.SetBool ("Walk_Down", false);
//					enemy_Anim.SetBool ("Walk_Up", false);
//					
//					transform.position += (player.position - transform.position).normalized * runSpeed * Time.deltaTime;
//				}
//			}else if(Mathf.Abs(distanceBetweenEVP.x) <= Mathf.Abs(distanceBetweenEVP.y)){
//				if(distanceBetweenEVP.y > 0){
//					enemy_Anim.SetBool ("Walk_Down", true);
//					enemy_Anim.SetBool ("Walk_Left", false);
//					enemy_Anim.SetBool ("Walk_Right", false);
//					enemy_Anim.SetBool ("Walk_Up", false);
//					transform.position += (player.position - transform.position).normalized * runSpeed * Time.deltaTime;
//				}else{
//					enemy_Anim.SetBool ("Walk_Up", true);
//					enemy_Anim.SetBool ("Walk_Left", false);
//					enemy_Anim.SetBool ("Walk_Right", false);
//					enemy_Anim.SetBool ("Walk_Down", false);
//					transform.position += (player.position - transform.position).normalized * runSpeed * Time.deltaTime;
//				}
//			}
//		}
//	}
//}
