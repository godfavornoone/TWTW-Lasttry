using UnityEngine;
using System.Collections;

public class Skill_Trap : MonoBehaviour {

	Player_Skill skill;
	public GameObject trapPlayer;

	public int trapLVL = 1;
	public float coolDownSkillTrap = 10f;
	[HideInInspector]
	public float trapTimer;
	[HideInInspector]
	public bool nowTrap = false;

	void Awake(){
		skill = GetComponent<Player_Skill> ();
	}
	// Use this for initialization
	void Start () {
		trapTimer = coolDownSkillTrap;
	}
	
	// Update is called once per frame
	void Update () {
		EnableUseTrap ();
	}

	void LateUpdate() {
		TrapEnemy ();
	}
	
	public void EnableUseTrap(){
		if (trapTimer >= coolDownSkillTrap) {
			if (Game_Controller.playerInThisMap.SP >= 100f) {
				if(skill.skillTextTyping[0].text.Equals("trap")){
					skill.skillTextTyping [0].color = Color.white;
					skill.UseSkill ();
				}
			}
		} else {
			if(skill.skillTextTyping[0].text.Equals("trap")){
				skill.skillTextTyping[0].color = Color.grey;
			}
			trapTimer += Time.deltaTime;
			skill.localIndexSkill = 0;
		}
	}

	void TrapEnemy(){
		if(nowTrap){
			Instantiate(trapPlayer, Game_Controller.playerInThisMap.transform.position, Quaternion.identity);
		}
		nowTrap = false;
	}

	void TrapSkillUp(){
		if(Game_Controller.playerInThisMap.skillPoint != 0){
			trapLVL++;
			Skill_Controller.trapDmg += 20f;
			Game_Controller.playerInThisMap.skillPoint--;
		}
	}
}
