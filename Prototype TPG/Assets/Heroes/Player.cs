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

    //Current Sword/Bow/Boot/Cloth
    public Item currentSword = new Item();
    public Item currentBow = new Item();
    public Item currentBoot = new Item();
    public Item currentCloth = new Item();

    [HideInInspector]
    public float MaxHP;
    [HideInInspector]
	public float HP;
    [HideInInspector]
    public float MaxSP;
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

    public GameObject WeaponPanel;
    public HPBarScript HPScript;
    public SPBarScript SPScript;
    public EXPBarScript EXPScript;

	void Awake(){
		DontDestroyOnLoad(transform.gameObject);
		rbd2D = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	// Use this for initialization
	void Start () {
		realStatus ();
		aL = (Arrow_Launch)FindObjectOfType (typeof(Arrow_Launch));
        WeaponPanel = GameObject.Find("WeaponPanel");
        HPScript = GameObject.Find("HPBar").GetComponent<HPBarScript>();
        SPScript = GameObject.Find("SPBar").GetComponent<SPBarScript>();
        EXPScript = GameObject.Find("EXPBar").GetComponent<EXPBarScript>();
	}

	void FixedUpdate(){
		Player_Movement ();
	}

	// Update is called once per frame
	void Update () {
		Player_Attack ();
		SwapWeapon ();
        HPScript.updateplayerHP(HP/MaxHP);
        SPScript.updateplayerSP(SP / MaxSP);
        EXPScript.updateplayerEXP(((lvl*baselvlup)-lvlup) / (lvl * baselvlup));
        
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
            Atk = baseAtk + currentBow.damage;
            WeaponPanel.transform.GetChild(0).gameObject.SetActive(false);
            WeaponPanel.transform.GetChild(1).gameObject.SetActive(true);
            Debug.Log("Bow Damage is: " + Atk);
        }
        else if(Input.GetKeyDown (KeyCode.Tab) && weaponState == 1){
			isSword = true;
			weaponState = 0;
            Atk = baseAtk + currentSword.damage;
            WeaponPanel.transform.GetChild(0).gameObject.SetActive(true);
            WeaponPanel.transform.GetChild(1).gameObject.SetActive(false);
            Debug.Log("Sword Damage is: " + Atk);
        }
	}
	
	public void PlayerDeath(){
		Debug.Log("Death");
	}


	//Player Status
	void realStatus(){
		MaxHP = baseHP;
        HP = MaxHP;
		SP = baseSP;
        MaxSP = baseSP;
		Atk = baseAtk;
		lvl = baselvl; //เลเวลเริ่มต้น
		lvlup = baselvlup * lvl; //100*1
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
            Debug.Log("เคสนี้");
			lvlup = lvlup - exp;
            Debug.Log(lvlup);
		} else if (lvlup - exp < 0) { //อันนี้คือเวลอัพแล้วมันเกิน
			float tmp = exp - lvlup;
			lvl++;
			lvlup = baselvlup * lvl;
			lvlup = lvlup - tmp;
			StatusUp();
			Debug.Log("LVLUP");
		} else { //เวลอัพแล้วมันพอดีจ้า
            Debug.Log("Level ก่อนเพิ่ม: " + lvl);
			lvl++;
            Debug.Log("Level หลังเพิ่ม: " + lvl);
            lvlup = baselvlup * lvl;
            Debug.Log("lvl up ที่น่าจะ 200: " + lvlup);
            StatusUp();
			Debug.Log("LVLUP");
			Debug.Log(lvl);
		}

	}
	
	void StatusUp(){
        float temp = MaxHP - baseHP;
        baseHP = baseHP + 100;
        MaxHP = temp + baseHP;
        HP = MaxHP;

        float temp2 = MaxSP - baseSP;
        baseSP = baseSP + 50;
        MaxSP = temp + baseSP;
        SP = MaxSP;

        baseAtk = baseAtk + 50;
        
		Debug.Log("HP = " + MaxHP + " SP = " + MaxSP);
	}

    public void EquipCloth(Item cloth)
    {
        MaxHP = MaxHP - currentCloth.hitpoint;
        currentCloth = cloth;
        MaxHP = MaxHP + currentCloth.hitpoint; //คือถ้าเราใช้ BaseHP ตรงนี้นะ ไอ่ที่ตอน Level Up ได้ไรเพิ่มนี่ไม่เห็นผลเลย
        Debug.Log("After Equip Cloth!!: " + MaxHP);
    }

    public void EquipBoot(Item boot)
    {
        MaxHP = MaxHP - currentBoot.hitpoint;
        currentBoot = boot;
        MaxHP = MaxHP + currentBoot.hitpoint;
        Debug.Log("After Equip Boot!!: " + MaxHP);
    }

    public void EquipBow(Item bow)
    {
        currentBow = bow;
    }

    public void EquipSword(Item sword)
    {
        currentSword = sword;
    }

    void PlayerSkill(){ 

	}
}
