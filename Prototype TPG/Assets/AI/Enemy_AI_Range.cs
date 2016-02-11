using UnityEngine;
using System.Collections;

public class Enemy_AI_Range : MonoBehaviour {
	
	Animator enemy_Anim;
	Enemy status;
	private float nextAtk = 3;
	float distanceAttack;
	Vampire_Attack vA;
	int attackHash = Animator.StringToHash("Damaged");

	void Awake(){
		status = GetComponent<Enemy> ();
		enemy_Anim = GetComponent<Animator> ();
	}
	// Use this for initialization
	void Start () {
		vA = (Vampire_Attack)FindObjectOfType (typeof(Vampire_Attack));
	}

	// Update is called once per frame
	void Update () {
		EnemyShootArrow ();
	}

	void EnemyShootArrow(){
		distanceAttack = Vector2.Distance (gameObject.transform.position, status.player.position);

		if (distanceAttack < 4) {
			CheckFace();
			status.walk = false;
			if(Time.time > nextAtk){
				nextAtk = Time.time + status.baseAspd;
				vA.ShootingBall(Game_Controller.playerInThisMap.transform);
			}

		} else {
			status.walk = true;
			Enemy_Movement(status.walk);
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
					status.transform.position += (status.player.position - status.transform.position).normalized * status.runSpeed * Time.deltaTime;
				}else{
					enemy_Anim.SetBool ("Walk_Right", true);
					enemy_Anim.SetBool ("Walk_Left", false);
					enemy_Anim.SetBool ("Walk_Down", false);
					enemy_Anim.SetBool ("Walk_Up", false);
					status.transform.position += (status.player.position - status.transform.position).normalized * status.runSpeed * Time.deltaTime;
				}
			}else if(Mathf.Abs(status.distanceBetweenEVP.x) <= Mathf.Abs(status.distanceBetweenEVP.y)){
				if(status.distanceBetweenEVP.y > 0){
					enemy_Anim.SetBool ("Walk_Down", true);
					enemy_Anim.SetBool ("Walk_Left", false);
					enemy_Anim.SetBool ("Walk_Right", false);
					enemy_Anim.SetBool ("Walk_Up", false);
					status.transform.position += (status.player.position - status.transform.position).normalized * status.runSpeed * Time.deltaTime;
				}else{
					enemy_Anim.SetBool ("Walk_Up", true);
					enemy_Anim.SetBool ("Walk_Left", false);
					enemy_Anim.SetBool ("Walk_Right", false);
					enemy_Anim.SetBool ("Walk_Down", false);
					status.transform.position += (status.player.position - status.transform.position).normalized * status.runSpeed * Time.deltaTime;
				}
			}
		}
	}

	void CheckFace(){
		enemy_Anim.SetBool ("Walk_Left", false);
		enemy_Anim.SetBool ("Walk_Right", false);
		enemy_Anim.SetBool ("Walk_Down", false);
		enemy_Anim.SetBool ("Walk_Up", false);
		if (Mathf.Abs (status.distanceBetweenEVP.x) < Mathf.Abs (status.distanceBetweenEVP.y)) {
			if (status.distanceBetweenEVP.y > 0) {
				enemy_Anim.SetBool ("Idle_Down", true);
				enemy_Anim.SetBool ("Idle_Up", false);
				enemy_Anim.SetBool ("Idle_Right", false);
				enemy_Anim.SetBool ("Idle_Left", false);
			} else {
				enemy_Anim.SetBool ("Idle_Up", true);
				enemy_Anim.SetBool ("Idle_Down", false);
				enemy_Anim.SetBool ("Idle_Right", false);
				enemy_Anim.SetBool ("Idle_Left", false);
			}
		} else if(Mathf.Abs (status.distanceBetweenEVP.x) >= Mathf.Abs (status.distanceBetweenEVP.y)){
			if (status.distanceBetweenEVP.x > 0) {
				enemy_Anim.SetBool ("Idle_Left", true);
				enemy_Anim.SetBool ("Idle_Down", false);
				enemy_Anim.SetBool ("Idle_Right", false);
				enemy_Anim.SetBool ("Idle_Up", false);
			} else {
				enemy_Anim.SetBool ("Idle_Right", true);
				enemy_Anim.SetBool ("Idle_Up", false);
				enemy_Anim.SetBool ("Idle_Down", false);
				enemy_Anim.SetBool ("Idle_Left", false);
			}
		}
	}

}
