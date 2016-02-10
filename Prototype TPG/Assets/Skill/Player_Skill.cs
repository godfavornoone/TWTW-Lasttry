using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player_Skill : MonoBehaviour {

	public GameObject trapPlayer;
	private float tmpIceTime = 0;
	private float tmpSlowTime = 0;

	private Text[] skillTextTyping;
	Typing_Input textCheck;
	private char[] skillStorage;
	private int localIndexSkill = 0;

	//FireSkill
	public int fireLVL = 1;
	public float coolDownSkillFire = 10f;
	private float fireTimer;
	public float fireDMG = 50;
	private bool nowFire = false;

	//IceSkill
	public int iceLVL =1;
	public float coolDownSkillIce = 10f;
	private float iceTimer;
	public float nowIceTime = 3f;
	private bool nowIce = false;

	//KnockSkill
	public int knockLVL = 1;
	public float coolDownSkillKnock = 10f;
	private float knockTimer;
	private float knockSpeed = 50f;
	private float knockLong = 1f;

	//SlowSkill
	public int slowLVL = 1;
	private bool nowKnock = false;
	public float coolDownSkillSlow = 10f;
	private float slowTimer;
	public float nowSlowTime = 3f;
	private bool nowSlow = false;

	//HealSkill
	public int healLVL = 1 ;
	public float coolDownSkillHeal = 10f;
	private float healTimer;
	public float healDMG = 200f;
	private bool nowHeal = false;

	//TrapSkill
	public int trapLVL = 1;
	public float coolDownSkillTrap = 10f;
	private float trapTimer;
//	private float trapDMG = 20f;
	private bool nowTrap = false;

	void Awake(){
		skillTextTyping = GetComponentsInChildren<Text> ();
		textCheck = (Typing_Input)FindObjectOfType (typeof(Typing_Input));
	}

	// Use this for initialization
	void Start () {
		fireTimer = coolDownSkillFire;
		iceTimer = coolDownSkillIce;
		knockTimer = coolDownSkillKnock;
		slowTimer = coolDownSkillSlow;
		healTimer = coolDownSkillHeal;
		trapTimer = coolDownSkillTrap;
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log (skillTextTyping [0].text);
		skillStorage = skillTextTyping[0].text.ToCharArray();
		EnableUseFire ();
		EnableUseIce ();
		EnableUseKnock ();
		EnableUseSlow ();
		EnableUseHeal ();
		EnableUseTrap ();
		PushESC (Game_Controller.ESC);
	}

	void LateUpdate(){
		FireEnemy (fireDMG);
		IceEnemy (nowIceTime);
		KnockEnemy ();
		SlowEnemy (nowSlowTime);
		HealPlayer (healDMG);
		TrapEnemy ();
		UpSkill ();
	}

	public void CheckWrongAllSkill(char txt){
		if (skillTextTyping[0].color == Color.white){
			if (Game_Controller.indexGlobal == localIndexSkill) {
				if (txt.Equals (skillStorage [Game_Controller.indexGlobal])) {
					Skill_Controller.checkWrongAllSkillInPanel = false;
				}
			}
		}
	}

	public void CheckSkill(char txt){
		if (skillTextTyping[0].color == Color.white) {
			if (Game_Controller.indexGlobal == localIndexSkill) {
				if (txt.Equals (skillStorage [Game_Controller.indexGlobal])) {
					skillTextTyping[1].text += txt;
					localIndexSkill++;
				} else {
					skillTextTyping[1].text = "";
					localIndexSkill = 0;
				}
			}
		} else {
			skillTextTyping[1].text = "";
			localIndexSkill = 0;
		}
	}
	
	public void EnableUseFire(){
		if (fireTimer >= coolDownSkillFire) {
			if (Game_Controller.playerInThisMap.SP >= 100f) {
				if(skillTextTyping[0].text.Equals("fire")){
					skillTextTyping [0].color = Color.white;
					UseSkill ();
				}
			}
		} else {
			if(skillTextTyping[0].text.Equals("fire")){
				skillTextTyping [0].color = Color.grey;
			}
			fireTimer += Time.deltaTime;
			localIndexSkill = 0;
			Debug.Log (fireTimer);
		}
	}

	public void EnableUseIce(){
		if(iceTimer >= coolDownSkillIce){
			if(Game_Controller.playerInThisMap.SP >= 100f){
				if(skillTextTyping[0].text.Equals("ice")){
					skillTextTyping[0].color = Color.white;
					UseSkill();
				}
			}
		}else{
			if(skillTextTyping[0].text.Equals("ice")){
				skillTextTyping[0].color = Color.grey;
			}
			tmpIceTime += Time.deltaTime;
			iceTimer += Time.deltaTime;
			localIndexSkill = 0;
		}
	}

	public void EnableUseKnock(){
		if(knockTimer >= coolDownSkillKnock){
			if(Game_Controller.playerInThisMap.SP >= 100f){
				if(skillTextTyping[0].text.Equals("knock")){
					skillTextTyping[0].color = Color.white;
					UseSkill();
				}
			}
		}else{
			if(skillTextTyping[0].text.Equals("knock")){
				skillTextTyping[0].color = Color.grey;
			}
			knockTimer += Time.deltaTime;
			localIndexSkill = 0;
		}
	}

	public void EnableUseSlow(){
		if(slowTimer >= coolDownSkillSlow){
			if(Game_Controller.playerInThisMap.SP >= 100f){
				if(skillTextTyping[0].text.Equals("slow")){
					skillTextTyping[0].color = Color.white;
					UseSkill();
				}
			}
		}else{
			if(skillTextTyping[0].text.Equals("slow")){
				skillTextTyping[0].color = Color.grey;
			}
			slowTimer += Time.deltaTime;
			localIndexSkill = 0;
		}
	}

	public void EnableUseHeal(){
		if(healTimer >= coolDownSkillHeal){
			if(Game_Controller.playerInThisMap.SP >= 100f){
				if(skillTextTyping[0].text.Equals("heal")){
					skillTextTyping[0].color = Color.white;
					UseSkill();
				}
			}
		}else{
			if(skillTextTyping[0].text.Equals("heal")){
				skillTextTyping[0].color = Color.grey;
			}
			healTimer += Time.deltaTime;
			localIndexSkill = 0;
		}
	}

	public void EnableUseTrap(){
		if (trapTimer >= coolDownSkillTrap) {
			if (Game_Controller.playerInThisMap.SP >= 100f) {
				if(skillTextTyping[0].text.Equals("trap")){
					skillTextTyping [0].color = Color.white;
					UseSkill ();
				}
			}
		} else {
			if(skillTextTyping[0].text.Equals("trap")){
				skillTextTyping[0].color = Color.grey;
			}
			trapTimer += Time.deltaTime;
			localIndexSkill = 0;
		}
	}

	public void UseSkill(){
		if (Game_Controller.indexGlobal == localIndexSkill) {
			if (skillTextTyping[0].text.Equals (skillTextTyping [1].text)) {
				SkillActive(skillTextTyping[1].text);
				skillTextTyping [1].text = "";
				localIndexSkill = 0;
				Game_Controller.indexGlobal = 0;

			}
		}
	}

	public void SkillActive(string skillName){
		if(skillName.Equals("fire")){
			fireTimer = 0;
			nowFire = true;
		}else if(skillName.Equals("ice")){
			iceTimer = 0;
			tmpIceTime = 0;
			nowIce = true;
		}else if(skillName.Equals("knock")){
			knockTimer = 0;
			nowKnock = true;
		}else if(skillName.Equals("slow")){
			slowTimer = 0;
			tmpSlowTime = 0;
			nowSlow = true;
		}else if(skillName.Equals("heal")){
			healTimer = 0;
			nowHeal = true;
		}else if(skillName.Equals("trap")){
			trapTimer = 0;
			nowTrap = true;
		}
	}

	void PushESC(bool esc){
		if (esc) {
			skillTextTyping[1].text = "";
			localIndexSkill = 0;
			Game_Controller.indexGlobal = 0;
		}
	}

	void FireEnemy(float dmg){
		if(nowFire){
			foreach(Enemy enemy in Game_Controller.enemyInThisMap){
				enemy.HpDown(fireDMG);
			}
		}
		nowFire = false;
	}

	void IceEnemy(float timer){
		if(nowIce){
			foreach(Enemy enemy in Game_Controller.enemyInThisMap){
				enemy.walk = false;
			}
			tmpIceTime += Time.deltaTime;
			if(tmpIceTime >= timer){
				foreach(Enemy enemy in Game_Controller.enemyInThisMap){
					enemy.walk = true;
				}
				nowIce = false;
			}
		}
	}
	
	void KnockEnemy(){
		if(nowKnock){
			foreach(Enemy enemy in Game_Controller.enemyInThisMap){
				if(enemy.distanceBetweenEVP.x == 0){
					if(enemy.distanceBetweenEVP.y > 0){
						enemy.transform.position += new Vector3(0,knockLong,0).normalized * knockSpeed * Time.deltaTime;
					}else{
						enemy.transform.position += new Vector3(0,-knockLong,0).normalized * knockSpeed * Time.deltaTime;
					}
				}else if(enemy.distanceBetweenEVP.y == 0){
					if(enemy.distanceBetweenEVP.x > 0){
						enemy.transform.position += new Vector3(knockLong,0,0).normalized * knockSpeed * Time.deltaTime;
					}else{
						enemy.transform.position += new Vector3(-knockLong,0,0).normalized * knockSpeed * Time.deltaTime;
					}
				}else if(enemy.distanceBetweenEVP.x > 0){
					if(enemy.distanceBetweenEVP.y > 0){
						enemy.transform.position += new Vector3(knockLong,knockLong,0).normalized * knockSpeed * Time.deltaTime;
					}else{
						enemy.transform.position += new Vector3(knockLong,-knockLong,0).normalized * knockSpeed * Time.deltaTime;
					}
				}else if(enemy.distanceBetweenEVP.x < 0){
					if(enemy.distanceBetweenEVP.y > 0){
						enemy.transform.position += new Vector3(-knockLong,knockLong,0).normalized * knockSpeed * Time.deltaTime;
					}else{
						enemy.transform.position += new Vector3(-knockLong,-knockLong,0).normalized * knockSpeed * Time.deltaTime;
					}
				}
			}
		}
		nowKnock = false;
	}

	void SlowEnemy(float timer){
		if(nowSlow){
			foreach(Enemy enemy in Game_Controller.enemyInThisMap){
				enemy.runSpeed = enemy.baseRunSpeed * 0.6f;
			}
			//Debug.Log(tmpSlowTime);
			tmpSlowTime += Time.deltaTime;
			if(tmpSlowTime >= timer){
				foreach(Enemy enemy in Game_Controller.enemyInThisMap){
					enemy.runSpeed = enemy.baseRunSpeed;
				}
				nowSlow = false;
			}
		}
	}

	void HealPlayer(float heal){
		if(nowHeal){
			Game_Controller.playerInThisMap.HP += heal;
		}
		nowHeal = false;
	}

	void TrapEnemy(){
		if(nowTrap){
			Instantiate(trapPlayer, Game_Controller.playerInThisMap.transform.position, Quaternion.identity);
		}
		nowTrap = false;
	}

	//Upskill
	void UpSkill(){
		if(Game_Controller.playerInThisMap.skillPoint != 0){
			//put your condition when you click mouse to up this skill
			if(true){
				fireLVL++;
				fireDMG += 20f;
				Game_Controller.playerInThisMap.skillPoint--;
			}else if(true){
				iceLVL++;
				nowIceTime += 0.5f;
				Game_Controller.playerInThisMap.skillPoint--;
			}else if(true){
				knockLVL++;
				coolDownSkillKnock -= 1f;
				Game_Controller.playerInThisMap.skillPoint--;
			}else if(true){
				slowLVL++;
				nowSlowTime += 0.5f;
				Game_Controller.playerInThisMap.skillPoint--;
			}else if(true){
				healLVL++;
				healDMG += 50f;
				Game_Controller.playerInThisMap.skillPoint--;
			}else if(true){
				trapLVL++;
				Skill_Controller.trapDmg += 20f;
				Game_Controller.playerInThisMap.skillPoint--;
			}
		}
	}

}
