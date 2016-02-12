using UnityEngine;
using System.Collections;

public class Skill_Heal : MonoBehaviour {

	Player_Skill skill;

	public int healLVL = 1 ;
	public float coolDownSkillHeal = 10f;
	[HideInInspector]
	public float healTimer;
	public float healDMG = 200f;
    public float healMana = 100;
	[HideInInspector]
	public bool nowHeal = false;

	void Awake(){
		skill = GetComponent<Player_Skill> ();
	}

	// Use this for initialization
	void Start () {
		healTimer = coolDownSkillHeal;
	}
	
	// Update is called once per frame
	void Update () {
		EnableUseHeal ();
	}

	void LateUpdate(){
		HealPlayer (healDMG);
	}

	public void EnableUseHeal(){

        if (Game_Controller.playerInThisMap.SP < healMana)
        {
            skill.skillTextTyping[0].color = Color.grey;
        }

        if (healTimer >= coolDownSkillHeal){
			if(Game_Controller.playerInThisMap.SP >= healMana){
				if(skill.skillTextTyping[0].text.Equals("heal")){
					skill.skillTextTyping[0].color = Color.white;
					skill.UseSkill();
				}
			}
		}else{
			if(skill.skillTextTyping[0].text.Equals("heal")){
				skill.skillTextTyping[0].color = Color.grey;
			}
			healTimer += Time.deltaTime;
			skill.localIndexSkill = 0;
		}
	}
	
	void HealPlayer(float heal){
		if(nowHeal){
            if(Game_Controller.playerInThisMap.HP+heal > Game_Controller.playerInThisMap.MaxHP)
            {
                Game_Controller.playerInThisMap.HP = Game_Controller.playerInThisMap.MaxHP;
            }
            else
            {
                Game_Controller.playerInThisMap.HP += heal;
            }

            Game_Controller.playerInThisMap.SPReduce(healMana);
		}
		nowHeal = false;
	}

	public void HealSkillUp(){
		if(Game_Controller.playerInThisMap.skillPoint != 0){
			healLVL++;
			healDMG += 50f;
            healMana += 20;
			Game_Controller.playerInThisMap.skillPoint--;
		}
	}

}
