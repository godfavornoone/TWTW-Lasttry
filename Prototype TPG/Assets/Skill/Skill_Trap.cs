using UnityEngine;
using System.Collections;

public class Skill_Trap : MonoBehaviour {

	Player_Skill skill;
	public GameObject trapPlayer;

	public int trapLVL = 1;
	public float coolDownSkillTrap = 10f;
	[HideInInspector]
	public float trapTimer;
    public float trapMana = 100;
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

        if(Game_Controller.playerInThisMap.SP < trapMana)
        {
            skill.skillTextTyping[0].color = Color.grey;
        }

        if (trapTimer >= coolDownSkillTrap) {
			if (Game_Controller.playerInThisMap.SP >= trapMana) {
				if(skill.skillTextTyping[0].text.Equals("6")){
					skill.skillTextTyping [0].color = Color.white;
					skill.UseSkill (); //มันมี Reset Cooldown ตรงนี้ด้วยเฮ้ย -_____- คือ trapTimer = 0 ณ ตรงนี้อ่ะ..
				}
			}
            
		} else { //นี่คือตอนมันใช้ สกิล อ่ะ
			if(skill.skillTextTyping[0].text.Equals("6")){
				skill.skillTextTyping[0].color = Color.grey;
			}
			trapTimer += Time.deltaTime;
			skill.localIndexSkill = 0;
		}
	}

    void TrapEnemy(){
		if(nowTrap){
			Instantiate(trapPlayer, Game_Controller.playerInThisMap.transform.position, Quaternion.identity);
            Game_Controller.playerInThisMap.SPReduce(trapMana);
        }
		nowTrap = false;
	}

	public void TrapSkillUp(){
		if(Game_Controller.playerInThisMap.skillPoint != 0){
			trapLVL++;
			Skill_Controller.trapDmg += 20f;
            trapMana += 10;
			Game_Controller.playerInThisMap.skillPoint--;
		}
	}
}
