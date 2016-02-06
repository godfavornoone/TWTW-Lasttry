using UnityEngine;
using System.Collections;

public class Player_Controller : MonoBehaviour {
	
	public static bool attackTrigger = false;
	Enemy_Controller directEnemy;
	Player_Status pStatus;
	Arrow_Launch aL;
	Rigidbody2D rbd2D;
	Animator anim;
	int attackHash = Animator.StringToHash("Attack");
	public static bool isSword = true;
	private int weaponState = 0;
	private GameObject[] enemySpawn;

	// Use this for initialization
	void Start () {
		rbd2D = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		aL = (Arrow_Launch)FindObjectOfType (typeof(Arrow_Launch));
		directEnemy = (Enemy_Controller)FindObjectOfType (typeof(Enemy_Controller));
		pStatus = (Player_Status)FindObjectOfType (typeof(Player_Status));
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
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

	void Update(){
		enemySpawn = GameObject.FindGameObjectsWithTag ("Enemy");
		foreach (GameObject enemy in enemySpawn) {
			EnemyText_Control enemyDamaged = (EnemyText_Control)enemy.GetComponent(typeof(EnemyText_Control));
			Enemy_Status enemyHpDown = (Enemy_Status)enemy.GetComponent(typeof(Enemy_Status));
			Enemy_Controller enemyTmp = enemy.GetComponent<Enemy_Controller>();
			if(enemyDamaged.takedDMG && isSword){
				anim.SetBool("Arrow_Right", false);
				anim.SetBool("Arrow_Left", false);
				anim.SetBool("Arrow_Up", false);
				anim.SetBool("Arrow_Down", false);
				if(Mathf.Abs(enemyTmp.distance.x) > Mathf.Abs(enemyTmp.distance.y)){
					if(enemyTmp.distance.x > 0){
						anim.SetBool("Sword_Right", true);
						anim.SetBool("Sword_Left", false);
						anim.SetBool("Sword_Up", false);
						anim.SetBool("Sword_Down", false);
						anim.SetTrigger (attackHash);
					}else if(enemyTmp.distance.x < 0){
						anim.SetBool("Sword_Left", true);
						anim.SetBool("Sword_Right", false);
						anim.SetBool("Sword_Up", false);
						anim.SetBool("Sword_Down", false);
						anim.SetTrigger (attackHash);
					}
				}else if(Mathf.Abs(enemyTmp.distance.x) <= Mathf.Abs(enemyTmp.distance.y)){
					if(enemyTmp.distance.y > 0){
						anim.SetBool("Sword_Up", true);
						anim.SetBool("Sword_Right", false);
						anim.SetBool("Sword_Left", false);
						anim.SetBool("Sword_Down", false);
						anim.SetTrigger (attackHash);
					}else if(enemyTmp.distance.y < 0){
						anim.SetBool("Sword_Down", true);
						anim.SetBool("Sword_Right", false);
						anim.SetBool("Sword_Left", false);
						anim.SetBool("Sword_Up", false);
						anim.SetTrigger (attackHash);
					}
				}
				enemyDamaged.takedDMG = false;
				enemyHpDown.HpDown(pStatus.Atk);
			}else if(enemyDamaged.takedDMG && !isSword){
				anim.SetBool("Sword_Down", false);
				anim.SetBool("Sword_Right", false);
				anim.SetBool("Sword_Left", false);
				anim.SetBool("Sword_Up", false);
				if(enemyTmp.distance.x > 0){
					anim.SetBool("Arrow_Right", true);
					anim.SetBool("Arrow_Left", false);
					anim.SetBool("Arrow_Up", false);
					anim.SetBool("Arrow_Down", false);
					anim.SetTrigger (attackHash);
					if(enemyTmp.distance.y > 0){
						float angletmp = Mathf.Atan2(Mathf.Abs(enemyTmp.distance.y), Mathf.Abs(enemyTmp.distance.x)) * Mathf.Rad2Deg;
						aL.ShootingArrow(enemy.transform, angletmp, enemy.name);
					}else{
						float angletmp = - Mathf.Atan2(Mathf.Abs(enemyTmp.distance.y), Mathf.Abs(enemyTmp.distance.x)) * Mathf.Rad2Deg;
						aL.ShootingArrow(enemy.transform, angletmp, enemy.name);
					}
				}else if(enemyTmp.distance.x < 0){
					anim.SetBool("Arrow_Left", true);
					anim.SetBool("Arrow_Right", false);
					anim.SetBool("Arrow_Up", false);
					anim.SetBool("Arrow_Down", false);
					anim.SetTrigger (attackHash);
					if(enemyTmp.distance.y > 0){
						float angletmp = 180 - Mathf.Atan2(Mathf.Abs(enemyTmp.distance.y), Mathf.Abs(enemyTmp.distance.x)) * Mathf.Rad2Deg;
						aL.ShootingArrow(enemy.transform, angletmp, enemy.name);
					}else{
						float angletmp = 180 + Mathf.Atan2(Mathf.Abs(enemyTmp.distance.y), Mathf.Abs(enemyTmp.distance.x)) * Mathf.Rad2Deg;
						aL.ShootingArrow(enemy.transform, angletmp, enemy.name);
					}
				}else if(enemyTmp.distance.y > 0){
					anim.SetBool("Arrow_Up", true);
					anim.SetBool("Arrow_Right", false);
					anim.SetBool("Arrow_Left", false);
					anim.SetBool("Arrow_Down", false);
					anim.SetTrigger (attackHash);
					if(enemyTmp.distance.x > 0){
						float angletmp = Mathf.Atan2(Mathf.Abs(enemyTmp.distance.y), Mathf.Abs(enemyTmp.distance.x)) * Mathf.Rad2Deg;
						aL.ShootingArrow(enemy.transform, angletmp, enemy.name);
					}else{
						float angletmp = 180 - Mathf.Atan2(Mathf.Abs(enemyTmp.distance.y), Mathf.Abs(enemyTmp.distance.x)) * Mathf.Rad2Deg;
						aL.ShootingArrow(enemy.transform, angletmp, enemy.name);
					}
				}else if(enemyTmp.distance.y < 0){
					anim.SetBool("Arrow_Down", true);
					anim.SetBool("Arrow_Right", false);
					anim.SetBool("Arrow_Left", false);
					anim.SetBool("Arrow_Up", false);
					anim.SetTrigger (attackHash);
					if(enemyTmp.distance.x > 0){
						float angletmp = - Mathf.Atan2(Mathf.Abs(enemyTmp.distance.y), Mathf.Abs(enemyTmp.distance.x)) * Mathf.Rad2Deg;
						aL.ShootingArrow(enemy.transform, angletmp, enemy.name);
					}else{
						float angletmp = 180 + Mathf.Atan2(Mathf.Abs(enemyTmp.distance.y), Mathf.Abs(enemyTmp.distance.x)) * Mathf.Rad2Deg;
						aL.ShootingArrow(enemy.transform, angletmp, enemy.name);
					}
				}
				enemyDamaged.takedDMG = false;
				enemyHpDown.HpDown(pStatus.Atk);
			}

		}
//		Game_Controller.attackAble = false;
//		if (Game_Controller.attackAble) {
//			anim.SetTrigger (attackHash);
//
//		}
//		Game_Controller.attackAble = false;
		SwapWeapon ();
	}

	public void SwapWeapon(){
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

}
