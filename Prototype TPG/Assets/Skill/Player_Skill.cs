using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player_Skill : MonoBehaviour {
	
	private Text[] skillTextTyping;
	Typing_Input textCheck;
	private char[] skillStorage;
	private int localIndexSkill = 0;
	private float coolDownSkillFire = 3f;
	private float fireTimer = 3;

	void Awake(){
		skillTextTyping = GetComponentsInChildren<Text> ();
		textCheck = (Typing_Input)FindObjectOfType (typeof(Typing_Input));
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		skillStorage = skillTextTyping[0].text.ToCharArray();

		EnableUseSkill ();

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
	
	public void EnableUseSkill(){

		if (fireTimer >= coolDownSkillFire) {
			if(Game_Controller.playerInThisMap.SP > 100f){
				skillTextTyping[0].color = Color.white;
				UseSkill();
			}
		} else {
			fireTimer += Time.deltaTime;
			skillTextTyping[0].color = Color.grey;
			localIndexSkill = 0;
			Debug.Log (fireTimer);
		}
	}

	public void UseSkill(){
		if (Game_Controller.indexGlobal == localIndexSkill) {
			if (skillTextTyping[0].text.Equals (skillTextTyping [1].text)) {
				SkillActive(skillTextTyping[1].text);
				skillTextTyping [1].text = "";
				localIndexSkill = 0;
				Game_Controller.indexGlobal = 0;
				fireTimer = 0;
			}
		}
	}

	public void SkillActive(string skillName){
		if(skillName.Equals("fire")){
			foreach(Enemy enemy in Game_Controller.enemyInThisMap){
				enemy.HpDown(50);
			}
		}
	}
}
