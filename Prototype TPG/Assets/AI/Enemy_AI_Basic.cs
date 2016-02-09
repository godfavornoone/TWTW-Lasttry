using UnityEngine;
using System.Collections;

public class Enemy_AI_Basic : MonoBehaviour {
	
	[HideInInspector]
	public bool struckPlayer = false;
	Enemy status;

	//Enemy Controller
	Transform player;
	Animator enemy_Anim;

//	public bool walk = true;
	private float nextAtk = 0f;

	void Awake(){
		status = GetComponent<Enemy>();
		//Call Animator of Enemy
		enemy_Anim = GetComponent<Animator> ();
	}

	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void Update(){
		Enemy_Movement (status.walk);
	}

	void OnTriggerEnter2D(Collider2D other){
		//		if (other.gameObject.tag == "Enemy") {
		//			if(Game_Controller.enemyStruckPlayer && walk){
		//				enemy_Anim.SetBool ("Walk_Left", false);
		//				enemy_Anim.SetBool ("Walk_Right", false);
		//				enemy_Anim.SetBool ("Walk_Down", false);
		//				enemy_Anim.SetBool ("Walk_Up", false);
		//				walk = false;
		//			}else if(Game_Controller.enemyStruckPlayer){
		//
		//			}
		//		}
		
//		if(other.gameObject.tag == "Arrow"){
//			if(status.textTypeMonsterArrow == status.textBeforeMonsterArrow){
//				Debug.Log(status.textTypeMonsterArrow);
//				Debug.Log(status.textBeforeMonsterArrow);
//				status.HpDown(Game_Controller.playerInThisMap.Atk);
//			}
//
//		}
	}
	
	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.tag == "Enemy") {
			//			if(Game_Controller.enemyStruckPlayer && walk && struckPlayer){
			//				enemy_Anim.SetBool ("Walk_Left", false);
			//				enemy_Anim.SetBool ("Walk_Right", false);
			//				enemy_Anim.SetBool ("Walk_Down", false);
			//				enemy_Anim.SetBool ("Walk_Up", false);
			//				walk = false;
			//			}
			//		}else 
			
			if (Game_Controller.enemyStruckPlayer && status.walk && !struckPlayer) {
				status.walk = true;
			}
		}
		if(other.gameObject.tag == "Trap"){
			status.HpDown(Skill_Controller.trapDmg);
			Destroy(other.gameObject);
		}
	}
	
	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.tag == "Enemy"){
			status.walk = true;
		}
	}
	
	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Player"){
			enemy_Anim.SetBool ("Walk_Left", false);
			enemy_Anim.SetBool ("Walk_Right", false);
			enemy_Anim.SetBool ("Walk_Down", false);
			enemy_Anim.SetBool ("Walk_Up", false);
			status.walk = false;
			Game_Controller.enemyStruckPlayer = true;
			struckPlayer = true;
		}
	}
	
	//Enemy Attack
	void OnCollisionStay2D(Collision2D other){
		if(other.gameObject.tag == "Player"){
			enemy_Anim.SetBool ("Walk_Left", false);
			enemy_Anim.SetBool ("Walk_Right", false);
			enemy_Anim.SetBool ("Walk_Down", false);
			enemy_Anim.SetBool ("Walk_Up", false);
			status.walk = false;
			Game_Controller.enemyStruckPlayer = true;
			struckPlayer = true;
			if(Time.time > nextAtk){
				nextAtk = Time.time + status.baseAspd;
				Game_Controller.playerInThisMap.EnemyAttacked(status.Attack);
			}
		}else if(other.gameObject.tag == "Enemy" && Game_Controller.enemyStruckPlayer && !struckPlayer){
			Debug.Log("test");
			enemy_Anim.SetBool ("Walk_Left", false);
			enemy_Anim.SetBool ("Walk_Right", false);
			enemy_Anim.SetBool ("Walk_Down", false);
			enemy_Anim.SetBool ("Walk_Up", false);
			status.walk = false;
		}
	}
	
	void OnCollisionExit2D(Collision2D other){
		if(other.gameObject.tag == "Player"){
			status.walk = true;
			Game_Controller.enemyStruckPlayer = false;
			struckPlayer = false;
		}else if(other.gameObject.tag == "Enemy"){
			status.walk = true;
		}
	}


	void Enemy_Movement(bool walk){
		
		if(walk){

			if(Mathf.Abs(status.distanceBetweenEVP.x) > Mathf.Abs(status.distanceBetweenEVP.y)){
				if(status.distanceBetweenEVP.x > 0){
					enemy_Anim.SetBool ("Walk_Left", true);
					enemy_Anim.SetBool ("Walk_Right", false);
					enemy_Anim.SetBool ("Walk_Down", false);
					enemy_Anim.SetBool ("Walk_Up", false);
					status.transform.position += (player.position - status.transform.position).normalized * status.runSpeed * Time.deltaTime;
				}else{
					enemy_Anim.SetBool ("Walk_Right", true);
					enemy_Anim.SetBool ("Walk_Left", false);
					enemy_Anim.SetBool ("Walk_Down", false);
					enemy_Anim.SetBool ("Walk_Up", false);
					
					status.transform.position += (player.position - status.transform.position).normalized * status.runSpeed * Time.deltaTime;
				}
			}else if(Mathf.Abs(status.distanceBetweenEVP.x) <= Mathf.Abs(status.distanceBetweenEVP.y)){
				if(status.distanceBetweenEVP.y > 0){
					enemy_Anim.SetBool ("Walk_Down", true);
					enemy_Anim.SetBool ("Walk_Left", false);
					enemy_Anim.SetBool ("Walk_Right", false);
					enemy_Anim.SetBool ("Walk_Up", false);
					status.transform.position += (player.position - status.transform.position).normalized * status.runSpeed * Time.deltaTime;
				}else{
					enemy_Anim.SetBool ("Walk_Up", true);
					enemy_Anim.SetBool ("Walk_Left", false);
					enemy_Anim.SetBool ("Walk_Right", false);
					enemy_Anim.SetBool ("Walk_Down", false);
					status.transform.position += (player.position - status.transform.position).normalized * status.runSpeed * Time.deltaTime;
				}
			}
		}
	}
}
