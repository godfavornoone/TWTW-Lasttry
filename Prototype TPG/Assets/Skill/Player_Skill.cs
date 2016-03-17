using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player_Skill : MonoBehaviour {

	public AudioClip[] audioClip;

	[HideInInspector]
	public Text[] skillTextTyping;
	Typing_Input textCheck;
	private char[] skillStorage;
	[HideInInspector]
	public int localIndexSkill = 0;

	Skill_Fire fire;
	Skill_Ice ice;
	Skill_Knock knock;
	Skill_Slow slow;
	Skill_Heal heal;
	Skill_Trap trap;

	void Awake(){
		skillTextTyping = GetComponentsInChildren<Text> ();
		textCheck = (Typing_Input)FindObjectOfType (typeof(Typing_Input));
		fire = GetComponent<Skill_Fire> ();
		ice = GetComponent<Skill_Ice> ();
		knock = GetComponent<Skill_Knock> ();
		slow = GetComponent<Skill_Slow> ();
		heal = GetComponent<Skill_Heal> ();
		trap = GetComponent<Skill_Trap> ();
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		skillStorage = skillTextTyping[0].text.ToCharArray();
//		PushESC (Game_Controller.ESC);
//		if(Game_Controller.oneEnemyWordChange){
//			skillTextTyping[1].text = "";
//			localIndexSkill = 0;
//			Game_Controller.oneEnemyWordChange = false;
//		}
	}

	public void CheckWrongAllSkill(char txt){
		if (skillTextTyping[0].color == Color.white){
			if (Skill_Controller.indexSkillGlobal == localIndexSkill) {
				if (txt.Equals (skillStorage [Skill_Controller.indexSkillGlobal])) {
					Skill_Controller.checkWrongAllSkillInPanel = false;
				}
			}
		}
	}

	public void CheckSkill(char txt){
		if (skillTextTyping[0].color == Color.white) {
			if (Skill_Controller.indexSkillGlobal == localIndexSkill) {
				if (txt.Equals (skillStorage [Skill_Controller.indexSkillGlobal])) {
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

	public void UseSkill(){
		if (Skill_Controller.indexSkillGlobal == localIndexSkill) {
			if (skillTextTyping[0].text.Equals (skillTextTyping [1].text)) {
				SkillActive(skillTextTyping[1].text);
				skillTextTyping [1].text = "";
				localIndexSkill = 0;
				Skill_Controller.indexSkillGlobal = 0;
			}
		}
	}

	public void SkillActive(string skillName){
		if(skillName.Equals("1")){
            Game_Controller.levelUp.SetActive(false);
            Game_Controller.inventoryFull.SetActive(false);
            Game_Controller.fireNoti.SetActive(true);
            Game_Controller.iceNoti.SetActive(false);
            Game_Controller.slowNoti.SetActive(false);
            Game_Controller.knockNoti.SetActive(false);
            Game_Controller.healNoti.SetActive(false);
            Game_Controller.trapNoti.SetActive(false);
            Game_Controller.sameLetterNoti.SetActive(false);
            Game_Controller.sameWordNoti.SetActive(false);
            Game_Controller.oneLetterNoti.SetActive(false);
            //StartCoroutine(Game_Controller.fireNotiScript.waitForDisappear());
			PlaySound(0);
            fire.fireTimer = 0;
			fire.nowFire = true;
		}else if(skillName.Equals("2")){
            Game_Controller.levelUp.SetActive(false);
            Game_Controller.inventoryFull.SetActive(false);
            Game_Controller.fireNoti.SetActive(false);
            Game_Controller.iceNoti.SetActive(true);
            Game_Controller.slowNoti.SetActive(false);
            Game_Controller.knockNoti.SetActive(false);
            Game_Controller.healNoti.SetActive(false);
            Game_Controller.trapNoti.SetActive(false);
            Game_Controller.sameLetterNoti.SetActive(false);
            Game_Controller.sameWordNoti.SetActive(false);
            Game_Controller.oneLetterNoti.SetActive(false);
            //StartCoroutine(Game_Controller.iceNotiScript.waitForDisappear());
            PlaySound(0);
			ice.iceTimer = 0;
			ice.tmpIceTime = 0;
			Skill_Controller.nowIce = true;
			ice.useIce = true;
		}else if(skillName.Equals("5")){
            Game_Controller.levelUp.SetActive(false);
            Game_Controller.inventoryFull.SetActive(false);
            Game_Controller.fireNoti.SetActive(false);
            Game_Controller.iceNoti.SetActive(false);
            Game_Controller.slowNoti.SetActive(false);
            Game_Controller.knockNoti.SetActive(true);
            Game_Controller.healNoti.SetActive(false);
            Game_Controller.trapNoti.SetActive(false);
            Game_Controller.sameLetterNoti.SetActive(false);
            Game_Controller.sameWordNoti.SetActive(false);
            Game_Controller.oneLetterNoti.SetActive(false);
            //StartCoroutine(Game_Controller.knockNotiScript.waitForDisappear());
			PlaySound(0);
            knock.knockTimer = 0;
			knock.nowKnock = true;
		}else if(skillName.Equals("3")){
            Game_Controller.levelUp.SetActive(false);
            Game_Controller.inventoryFull.SetActive(false);
            Game_Controller.fireNoti.SetActive(false);
            Game_Controller.iceNoti.SetActive(false);
            Game_Controller.slowNoti.SetActive(true);
            Game_Controller.knockNoti.SetActive(false);
            Game_Controller.healNoti.SetActive(false);
            Game_Controller.trapNoti.SetActive(false);
            Game_Controller.sameLetterNoti.SetActive(false);
            Game_Controller.sameWordNoti.SetActive(false);
            Game_Controller.oneLetterNoti.SetActive(false);
            //StartCoroutine(Game_Controller.slowNotiScript.waitForDisappear());
			PlaySound(0);
            slow.slowTimer = 0;
			slow.tmpSlowTime = 0;
			Skill_Controller.nowSlow = true;
			slow.useSlow = true;
		}else if(skillName.Equals("4")){
            Game_Controller.levelUp.SetActive(false);
            Game_Controller.inventoryFull.SetActive(false);
            Game_Controller.fireNoti.SetActive(false);
            Game_Controller.iceNoti.SetActive(false);
            Game_Controller.slowNoti.SetActive(false);
            Game_Controller.knockNoti.SetActive(false);
            Game_Controller.healNoti.SetActive(true);
            Game_Controller.trapNoti.SetActive(false);
            Game_Controller.sameLetterNoti.SetActive(false);
            Game_Controller.sameWordNoti.SetActive(false);
            Game_Controller.oneLetterNoti.SetActive(false);
            //StartCoroutine(Game_Controller.healNotiScript.waitForDisappear());
            PlaySound(0);
			heal.healTimer = 0;
			heal.nowHeal = true;
		}else if(skillName.Equals("6")){
            Game_Controller.levelUp.SetActive(false);
            Game_Controller.inventoryFull.SetActive(false);
            Game_Controller.fireNoti.SetActive(false);
            Game_Controller.iceNoti.SetActive(false);
            Game_Controller.slowNoti.SetActive(false);
            Game_Controller.knockNoti.SetActive(false);
            Game_Controller.healNoti.SetActive(false);
            Game_Controller.trapNoti.SetActive(true);
            Game_Controller.sameLetterNoti.SetActive(false);
            Game_Controller.sameWordNoti.SetActive(false);
            Game_Controller.oneLetterNoti.SetActive(false);
            //StartCoroutine(Game_Controller.trapNotiScript.waitForDisappear());
			PlaySound(0);
            trap.trapTimer = 0;
			trap.nowTrap = true;
		}
	}

//	void PushESC(bool esc){
//		if (esc) {
//			skillTextTyping[1].text = "";
//			localIndexSkill = 0;
//			Game_Controller.indexGlobal = 0;
//		}
//	}

	void PlaySound(int clip){
		AudioSource audio = GetComponent<AudioSource> ();
		audio.clip = audioClip[clip];
		audio.Play ();
	}
	
}
