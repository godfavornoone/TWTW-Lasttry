using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	//Player Status
	public float baseHP;
	public float baseSP;
	public float baseAtk;
	public float baseRange;
	public float baseSpeed;
	public float baselvlup;
	public float baselvl;
	
	[HideInInspector]
	public float HP;
	[HideInInspector]
	public float SP;
	[HideInInspector]
	public float range;
	[HideInInspector]
	public float speed;
	[HideInInspector]
	public float lvlup;
	[HideInInspector]
	public float lvl;
	[HideInInspector]
	public float Atk;

	//Player Controller
	public static bool attackTrigger = false;
//	Player_Status pStatus;
	Arrow_Launch aL;
	Rigidbody2D rbd2D;
	Animator anim;
	int attackHash = Animator.StringToHash("Attack");
	[HideInInspector]
	public bool isSword = true;
	private int weaponState = 0;


	void Awake(){
		DontDestroyOnLoad(transform.gameObject);
		rbd2D = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	// Use this for initialization
	void Start () {
		realStatus ();
		aL = (Arrow_Launch)FindObjectOfType (typeof(Arrow_Launch));
	}

	void FixedUpdate(){
		Player_Movement ();
	}

	// Update is called once per frame
	void Update () {
		Player_Attack ();
		SwapWeapon ();
	}

	void LateUpdate(){

	}

	//Player Controller
	void Player_Movement(){
		Vector2 movement_vector = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		if (Input.GetKey (KeyCode.LeftShift)) {
			if (movement_vector != Vector2.zero) {
				anim.SetBool ("Walking", true);
				anim.SetFloat ("SpeedX", movement_vector.x);
				anim.SetFloat ("SpeedY", movement_vector.y);
				rbd2D.MovePosition (rbd2D.position + movement_vector * Time.deltaTime);
			}else{
				anim.SetBool ("Walking", false);
			}
		} else {
			anim.SetBool ("Walking", false);
		}
	}

	void Player_Attack(){
		foreach (Enemy enemy in Game_Controller.enemyInThisMap) {
			if (enemy.takedDMG && isSword) {
				anim.SetBool ("Arrow_Right", false);
				anim.SetBool ("Arrow_Left", false);
				anim.SetBool ("Arrow_Up", false);
				anim.SetBool ("Arrow_Down", false);
				if (Mathf.Abs (enemy.distanceBetweenEVP.x) > Mathf.Abs (enemy.distanceBetweenEVP.y)) {
					if (enemy.distanceBetweenEVP.x > 0) {
						anim.SetBool ("Sword_Right", true);
						anim.SetBool ("Sword_Left", false);
						anim.SetBool ("Sword_Up", false);
						anim.SetBool ("Sword_Down", false);
						anim.SetTrigger (attackHash);
					} else if (enemy.distanceBetweenEVP.x < 0) {
						anim.SetBool ("Sword_Left", true);
						anim.SetBool ("Sword_Right", false);
						anim.SetBool ("Sword_Up", false);
						anim.SetBool ("Sword_Down", false);
						anim.SetTrigger (attackHash);
					}
				} else if (Mathf.Abs (enemy.distanceBetweenEVP.x) <= Mathf.Abs (enemy.distanceBetweenEVP.y)) {
					if (enemy.distanceBetweenEVP.y > 0) {
						anim.SetBool ("Sword_Up", true);
						anim.SetBool ("Sword_Right", false);
						anim.SetBool ("Sword_Left", false);
						anim.SetBool ("Sword_Down", false);
						anim.SetTrigger (attackHash);
					} else if (enemy.distanceBetweenEVP.y < 0) {
						anim.SetBool ("Sword_Down", true);
						anim.SetBool ("Sword_Right", false);
						anim.SetBool ("Sword_Left", false);
						anim.SetBool ("Sword_Up", false);
						anim.SetTrigger (attackHash);
					}
				}
				enemy.takedDMG = false;
				enemy.HpDown (Atk);
			} else if (enemy.takedDMG && !isSword) {
				anim.SetBool ("Sword_Down", false);
				anim.SetBool ("Sword_Right", false);
				anim.SetBool ("Sword_Left", false);
				anim.SetBool ("Sword_Up", false);
				if (Mathf.Abs (enemy.distanceBetweenEVP.x) <= Mathf.Abs (enemy.distanceBetweenEVP.y)) {
					if (enemy.distanceBetweenEVP.y > 0) {
						anim.SetBool ("Arrow_Up", true);
						anim.SetBool ("Arrow_Right", false);
						anim.SetBool ("Arrow_Left", false);
						anim.SetBool ("Arrow_Down", false);
						anim.SetTrigger (attackHash);
						if (enemy.distanceBetweenEVP.x > 0) {
							float angletmp = Mathf.Atan2 (Mathf.Abs (enemy.distanceBetweenEVP.y), Mathf.Abs (enemy.distanceBetweenEVP.x)) * Mathf.Rad2Deg;
							aL.ShootingArrow (enemy.transform, angletmp, enemy.name);
						} else {
							float angletmp = 180 - Mathf.Atan2 (Mathf.Abs (enemy.distanceBetweenEVP.y), Mathf.Abs (enemy.distanceBetweenEVP.x)) * Mathf.Rad2Deg;
							aL.ShootingArrow (enemy.transform, angletmp, enemy.name);
						}
					} else if (enemy.distanceBetweenEVP.y < 0) {
						anim.SetBool ("Arrow_Down", true);
						anim.SetBool ("Arrow_Right", false);
						anim.SetBool ("Arrow_Left", false);
						anim.SetBool ("Arrow_Up", false);
						anim.SetTrigger (attackHash);
						if (enemy.distanceBetweenEVP.x > 0) {
							float angletmp = - Mathf.Atan2 (Mathf.Abs (enemy.distanceBetweenEVP.y), Mathf.Abs (enemy.distanceBetweenEVP.x)) * Mathf.Rad2Deg;
							aL.ShootingArrow (enemy.transform, angletmp, enemy.name);
						} else {
							float angletmp = 180 + Mathf.Atan2 (Mathf.Abs (enemy.distanceBetweenEVP.y), Mathf.Abs (enemy.distanceBetweenEVP.x)) * Mathf.Rad2Deg;
							aL.ShootingArrow (enemy.transform, angletmp, enemy.name);	
						}
					}
				} else if (Mathf.Abs (enemy.distanceBetweenEVP.x) > Mathf.Abs (enemy.distanceBetweenEVP.y)) {
					if (enemy.distanceBetweenEVP.x > 0) {
						anim.SetBool ("Arrow_Right", true);
						anim.SetBool ("Arrow_Left", false);
						anim.SetBool ("Arrow_Up", false);
						anim.SetBool ("Arrow_Down", false);
						anim.SetTrigger (attackHash);
						if (enemy.distanceBetweenEVP.y > 0) {
							float angletmp = Mathf.Atan2 (Mathf.Abs (enemy.distanceBetweenEVP.y), Mathf.Abs (enemy.distanceBetweenEVP.x)) * Mathf.Rad2Deg;
							aL.ShootingArrow (enemy.transform, angletmp, enemy.name);
						} else {
							float angletmp = - Mathf.Atan2 (Mathf.Abs (enemy.distanceBetweenEVP.y), Mathf.Abs (enemy.distanceBetweenEVP.x)) * Mathf.Rad2Deg;
							aL.ShootingArrow (enemy.transform, angletmp, enemy.name);
						}
					}else if (enemy.distanceBetweenEVP.x < 0) {
						anim.SetBool ("Arrow_Left", true);
						anim.SetBool ("Arrow_Right", false);
						anim.SetBool ("Arrow_Up", false);
						anim.SetBool ("Arrow_Down", false);
						anim.SetTrigger (attackHash);
						if (enemy.distanceBetweenEVP.y > 0) {
							float angletmp = 180 - Mathf.Atan2 (Mathf.Abs (enemy.distanceBetweenEVP.y), Mathf.Abs (enemy.distanceBetweenEVP.x)) * Mathf.Rad2Deg;
							aL.ShootingArrow (enemy.transform, angletmp, enemy.name);
						} else {
							float angletmp = 180 + Mathf.Atan2 (Mathf.Abs (enemy.distanceBetweenEVP.y), Mathf.Abs (enemy.distanceBetweenEVP.x)) * Mathf.Rad2Deg;
							aL.ShootingArrow (enemy.transform, angletmp, enemy.name);
						}
					}
				}
				enemy.takedDMG = false;
			}
		}
	}

	void SwapWeapon(){
		if (Input.GetKeyDown (KeyCode.Tab) && weaponState == 0) {
			isSword = false;
			weaponState = 1;
		}else if(Input.GetKeyDown (KeyCode.Tab) && weaponState == 1){
			isSword = true;
			weaponState = 0;
		}
	}
	
	public void PlayerDeath(){
		Debug.Log("Death");
	}


	//Player Status
	void realStatus(){
		HP = baseHP;
		SP = baseSP;
		Atk = baseAtk;
		lvl = baselvl;
		lvlup = baselvlup * lvl;
	}
	
	public void EnemyAttacked(float dmg){
		HP = HP - dmg;
		if(HP <= 0){
			PlayerDeath();
		}
		//		Debug.Log (HP);
	}
	
	public void PlayerLVLUp(float exp){
		if (lvlup - exp > 0) {
			lvlup = lvlup - exp;
		} else if (lvlup - exp < 0) {
			float tmp = exp - lvlup;
			lvl++;
			lvlup = lvlup * lvl;
			lvlup = lvlup - tmp;
			StatusUp(lvl);
			Debug.Log("LVLUP");
		} else {
			lvl++;
			lvlup = lvlup * lvl;
			StatusUp(lvl);
			Debug.Log("LVLUP");
			Debug.Log(lvl);
		}

	}
	
	void StatusUp(float currentlvl){
		HP = HP * ((100 + currentlvl) / 100);
		SP = SP * ((100 + currentlvl) / 100);
		Debug.Log("HP = " + HP + " SP = " + SP);
	}

	void PlayerSkill(){

	}
}
