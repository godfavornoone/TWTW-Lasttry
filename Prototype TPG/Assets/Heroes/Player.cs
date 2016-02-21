﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public GameObject attackedByEnemy;
	public GameObject swordAttack;
	textManager textscript;

	//Player Status
	public float baseHP;
	public float baseSP;
	public float baseRange;
	public float baseSpeed;
	public float baselvlup;
	public float baselvl;
    public float baseBowAtk;
    public float baseSwordAtk;
    //What you get when you Lvlup !!
    public float BonusSwordAtkperLevel;
    public float BonusBowAtkperLevel;
    public float BonusHPperLevel;
    public float BonusSPperLevel;

    public int skillPoint = 0;

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
	public float BowAtk;
    [HideInInspector]
    public float SwordAtk;



    //Player Controller
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

    public TextMesh notification;
    public GameObject notify;

    public List<int> historyWPM = new List<int>();
    public List<string> historyWeaknesses = new List<string>();

	void Awake(){
		DontDestroyOnLoad(transform.gameObject);
		rbd2D = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		textscript = GameObject.Find ("TextManager").GetComponent<textManager> ();
	}

	// Use this for initialization
	void Start () {
		aL = (Arrow_Launch)FindObjectOfType (typeof(Arrow_Launch));
        WeaponPanel = GameObject.Find("WeaponPanel");
        HPScript = GameObject.Find("HPBar").GetComponent<HPBarScript>();
        SPScript = GameObject.Find("SPBar").GetComponent<SPBarScript>();
        EXPScript = GameObject.Find("EXPBar").GetComponent<EXPBarScript>();
        notify = transform.GetChild(1).gameObject;
        notification = notify.GetComponentInChildren<TextMesh>();
        notify.SetActive(false);
        
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
				rbd2D.MovePosition (rbd2D.position + movement_vector * speed * Time.deltaTime);
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
				//Debug.Log(enemy.distanceBetweenEVP);
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

                //Here is the Option for Critical when using Sword

                int chanceCri;
                bool oneTimeOnly = true;
                float dmg = SwordAtk;

                //Debug.Log("Damage Before Cri: " + dmg);

                if (Game_Controller.playerInThisMap.currentBoot.hitpoint != 0 && oneTimeOnly)
                {

                    if (Game_Controller.playerInThisMap.currentBoot.option[3] != 0)
                    {
                        chanceCri = Random.Range(0, 100);
                        if (chanceCri <= Game_Controller.playerInThisMap.currentBoot.optionChance[3])
                        {
                            //Debug.Log("Cri by boot! in currentWP = sword");
                            dmg = dmg + dmg;
                            oneTimeOnly = false;
                        }
                    }
                }

                if (Game_Controller.playerInThisMap.currentCloth.hitpoint != 0 && oneTimeOnly)
                {

                    if (Game_Controller.playerInThisMap.currentCloth.option[3] != 0)
                    {
                        chanceCri = Random.Range(0, 100);
                        if (chanceCri <= Game_Controller.playerInThisMap.currentCloth.optionChance[3])
                        {
                            //Debug.Log("Cri by cloth! in currentWP = sword");
                            dmg = dmg + dmg;
                            oneTimeOnly = false;
                        }
                    }
                }

                if (Game_Controller.playerInThisMap.currentSword.damage != 0 && oneTimeOnly)
                {

                    if (Game_Controller.playerInThisMap.currentSword.option[3] != 0)
                    {
                        chanceCri = Random.Range(0, 100);
                        if (chanceCri <= Game_Controller.playerInThisMap.currentSword.optionChance[3])
                        {
                            //Debug.Log("Cri by sword! in currentWP = sword");
                            dmg = dmg + dmg;
                            oneTimeOnly = false;
                        }
                    }
                }

                if (Game_Controller.playerInThisMap.currentBow.damage != 0 && oneTimeOnly)
                {

                    if (Game_Controller.playerInThisMap.currentBow.option[3] != 0)
                    {
                        chanceCri = Random.Range(0, 100);
                        if (chanceCri <= Game_Controller.playerInThisMap.currentBow.optionChance[3])
                        {
                            //Debug.Log("Cri by bow! in currentWP = sword");
                            dmg = dmg + dmg;
                            oneTimeOnly = false;
                        }
                    }
                }

                //Debug.Log("Damage After Cri: " + dmg);
                SPIncrease(10 * lvl);

				foreach(Enemy enemySplashBySword in Game_Controller.enemySplash){
					if(enemySplashBySword.textTyping[1].color == Color.white){
						enemySplashBySword.HpDown (dmg);
						Instantiate(swordAttack, enemySplashBySword.transform.position, Quaternion.identity);
					}
					if(enemySplashBySword.takedDMG && enemySplashBySword.hitPoint > 0){
						enemySplashBySword.WordInstantiate();
					}
					enemySplashBySword.takedDMG = false;
				}
              	

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

				int chanceCri;
				bool oneTimeOnly = true;
				float dmg = Game_Controller.playerInThisMap.BowAtk;
				
				//Debug.Log("Damage Before Cri: " + dmg);
				
				if (Game_Controller.playerInThisMap.currentBoot.hitpoint != 0 && oneTimeOnly)
				{
					
					if (Game_Controller.playerInThisMap.currentBoot.option[3] != 0)
					{
						chanceCri = Random.Range(0, 100);
						if (chanceCri <= Game_Controller.playerInThisMap.currentBoot.optionChance[3])
						{
							//Debug.Log("Cri by boot! in currentWP = bow");
							dmg = dmg + dmg;
							oneTimeOnly = false;
						}
					}
				}
				
				if (Game_Controller.playerInThisMap.currentCloth.hitpoint != 0 && oneTimeOnly)
				{
					
					if (Game_Controller.playerInThisMap.currentCloth.option[3] != 0)
					{
						chanceCri = Random.Range(0, 100);
						if (chanceCri <= Game_Controller.playerInThisMap.currentCloth.optionChance[3])
						{
							//Debug.Log("Cri by cloth! in currentWP = bow");
							dmg = dmg + dmg;
							oneTimeOnly = false;
						}
					}
				}
				
				if (Game_Controller.playerInThisMap.currentSword.damage != 0 && oneTimeOnly)
				{
					
					if (Game_Controller.playerInThisMap.currentSword.option[3] != 0)
					{
						chanceCri = Random.Range(0, 100);
						if (chanceCri <= Game_Controller.playerInThisMap.currentSword.optionChance[3])
						{
							//Debug.Log("Cri by sword! in currentWP = bow");
							dmg = dmg + dmg;
							oneTimeOnly = false;
						}
					}
				}
				
				if (Game_Controller.playerInThisMap.currentBow.damage != 0 && oneTimeOnly)
				{
					
					if (Game_Controller.playerInThisMap.currentBow.option[3] != 0)
					{
						chanceCri = Random.Range(0, 100);
						if (chanceCri <= Game_Controller.playerInThisMap.currentBow.optionChance[3])
						{
							//Debug.Log("Cri by bow! in currentWP = bow");
							dmg = dmg + dmg;
							oneTimeOnly = false;
						}
					}
				}
				
				//Debug.Log("Damage After Cri: " + dmg);
                SPIncrease(10 * lvl);
                enemy.HpDown (dmg);
				if(enemy.takedDMG && enemy.hitPoint > 0){
					enemy.WordInstantiate();
				}
				enemy.takedDMG = false;
			}
		}
	}

	void SwapWeapon(){
		if (Input.GetKeyDown (KeyCode.Tab) && weaponState == 0) {
			isSword = false;
			weaponState = 1;
            WeaponPanel.transform.GetChild(0).gameObject.SetActive(false);
            WeaponPanel.transform.GetChild(1).gameObject.SetActive(true);
            //Debug.Log("Bow Damage is: " + BowAtk);
        }
        else if(Input.GetKeyDown (KeyCode.Tab) && weaponState == 1){
			isSword = true;
			weaponState = 0;
            WeaponPanel.transform.GetChild(0).gameObject.SetActive(true);
            WeaponPanel.transform.GetChild(1).gameObject.SetActive(false);
            //Debug.Log("Sword Damage is: " + SwordAtk);
        }
	}
	
	public void PlayerDeath(){
		textscript.clearAllVocab ();
		Game_Controller.indexGlobal = 0;
		//Debug.Log("Death");
	}

    
	//Player Status
	public void realStatus(){
		MaxHP = baseHP+BonusHPperLevel;
        HP = MaxHP;
        MaxSP = baseSP+BonusSPperLevel;
        SP = MaxSP;
		speed = baseSpeed;
        BowAtk = baseBowAtk+BonusBowAtkperLevel;
        SwordAtk = baseSwordAtk+BonusSwordAtkperLevel;
		lvl = baselvl; //เลเวลเริ่มต้น
		lvlup = baselvlup * lvl; //100*1
	}
    
	
	public void EnemyAttacked(float dmg){
		HP = HP - dmg;
		Instantiate (attackedByEnemy, transform.position, Quaternion.identity);
		if(HP <= 0){
			PlayerDeath();
			ReSceneWhenScene(Game_Controller.nowScene);
		}
	}

    public void SPReduce(float reduceSP)
    {
        SP = SP - reduceSP;
        //Debug.Log("SP Left is: " + SP);
    }

    public void SPIncrease(float increaseSP)
    {
        if(SP+increaseSP > MaxSP)
        {
            //Debug.Log("เกิน");
            SP = MaxSP;
        }
        else
        {
            //Debug.Log("ไม่เกิน");
            SP += increaseSP;
        }
    }
	
	public void PlayerLVLUp(float exp){
		if (lvlup - exp > 0) {
            //Debug.Log("เคสนี้");
			lvlup = lvlup - exp;
            //Debug.Log(lvlup);
            
        } else if (lvlup - exp < 0) { //อันนี้คือเวลอัพแล้วมันเกิน
			float tmp = exp - lvlup;
			lvl++;
			lvlup = baselvlup * lvl;
			lvlup = lvlup - tmp;
			StartCoroutine(StatusUp());
			skillPoint++;
			//Debug.Log("LVLUP");
		} else { //เวลอัพแล้วมันพอดีจ้า
            //Debug.Log("Level ก่อนเพิ่ม: " + lvl);
			lvl++;
            //Debug.Log("Level หลังเพิ่ม: " + lvl);
            lvlup = baselvlup * lvl;
            //Debug.Log("lvl up ที่น่าจะ 200: " + lvlup);
			skillPoint++;
            StartCoroutine(StatusUp());
			//Debug.Log("LVLUP");
			//Debug.Log(lvl);
            
        }

    }
	
	IEnumerator StatusUp(){


        MaxHP = MaxHP + BonusHPperLevel;
        HP = MaxHP;
        MaxSP = MaxSP + BonusSPperLevel;
        SP = MaxSP;

        SwordAtk = SwordAtk + BonusSwordAtkperLevel;
        BowAtk = BowAtk + BonusBowAtkperLevel;

        Game_Controller.playerInThisMap.notify.SetActive(true);
        Game_Controller.playerInThisMap.notification.text = "Level up!";
        yield return new WaitForSeconds(3);
        Game_Controller.playerInThisMap.notify.SetActive(false);

	}

    public void EquipCloth(Item cloth)
    {
        MaxHP = MaxHP - currentCloth.hitpoint;
        currentCloth = cloth;
        MaxHP = MaxHP + currentCloth.hitpoint; //คือถ้าเราใช้ BaseHP ตรงนี้นะ ไอ่ที่ตอน Level Up ได้ไรเพิ่มนี่ไม่เห็นผลเลย
        //Debug.Log("After Equip Cloth!!: " + MaxHP);
    }

    public void EquipBoot(Item boot)
    {
        MaxHP = MaxHP - currentBoot.hitpoint;
        currentBoot = boot;
        MaxHP = MaxHP + currentBoot.hitpoint;
        //Debug.Log("After Equip Boot!!: " + MaxHP);
    }

    public void EquipBow(Item bow)
    {
        BowAtk = BowAtk - currentBow.damage;
        currentBow = bow;
        BowAtk = BowAtk + currentBow.damage;
    }

    public void EquipSword(Item sword)
    {
        SwordAtk = SwordAtk - currentSword.damage;
        currentSword = sword;
        SwordAtk = SwordAtk + currentSword.damage;
    }

	void ReSceneWhenScene(string sName){
		if((Game_Controller.playerInThisMap.lvlup + (((Game_Controller.playerInThisMap.baselvlup * Game_Controller.playerInThisMap.lvl) - Game_Controller.playerInThisMap.lvlup)/2)) >= (Game_Controller.playerInThisMap.baselvlup * Game_Controller.playerInThisMap.lvl)){
			Game_Controller.playerInThisMap.lvlup = Game_Controller.playerInThisMap.baselvlup * Game_Controller.playerInThisMap.lvl;
		}else{
			//Debug.Log("sad");
			Game_Controller.playerInThisMap.lvlup += ((Game_Controller.playerInThisMap.baselvlup * Game_Controller.playerInThisMap.lvl) - Game_Controller.playerInThisMap.lvlup)/2;
		}
		Game_Controller.playerInThisMap.HP = (Game_Controller.playerInThisMap.MaxHP + Game_Controller.playerInThisMap.currentCloth.hitpoint + Game_Controller.playerInThisMap.currentBoot.hitpoint)/2;
		Application.LoadLevel (sName);
	}
	
}
