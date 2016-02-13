using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player_Skill : MonoBehaviour {
	
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
		PushESC (Game_Controller.ESC);
		if(Game_Controller.oneEnemyWordChange){
			skillTextTyping[1].text = "";
			localIndexSkill = 0;
			Game_Controller.oneEnemyWordChange = false;
		}
	}

	void LateUpdate(){

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
			fire.fireTimer = 0;
			fire.nowFire = true;
		}else if(skillName.Equals("ice")){
			ice.iceTimer = 0;
			ice.tmpIceTime = 0;
			ice.nowIce = true;
			ice.useIce = true;
		}else if(skillName.Equals("knock")){
			knock.knockTimer = 0;
			knock.nowKnock = true;
		}else if(skillName.Equals("slow")){
			slow.slowTimer = 0;
			slow.tmpSlowTime = 0;
			slow.nowSlow = true;
			slow.useSlow = true;
		}else if(skillName.Equals("heal")){
			heal.healTimer = 0;
			heal.nowHeal = true;
		}else if(skillName.Equals("trap")){
			trap.trapTimer = 0;
			trap.nowTrap = true;
		}
	}

	void PushESC(bool esc){
		if (esc) {
			skillTextTyping[1].text = "";
			localIndexSkill = 0;
			Game_Controller.indexGlobal = 0;
		}
	}

}
