using UnityEngine;
using System.Collections;

public class Skill_Slow : MonoBehaviour {

	Player_Skill skill;
	public bool useSlow = false;

	[HideInInspector]
	public float tmpSlowTime = 0;
	public int slowLVL = 1;
	public float coolDownSkillSlow = 10f;
	[HideInInspector]
	public float slowTimer;
	public float nowSlowTime = 3f;
    public float slowMana = 100;
//	[HideInInspector]
//	public bool nowSlow = false;

	void Awake(){
		skill = GetComponent<Player_Skill> ();
	}

	// Use this for initialization
	void Start () {
		slowTimer = coolDownSkillSlow;
	}
	
	// Update is called once per frame
	void Update () {
		EnableUseSlow ();
	}

	void LateUpdate(){
		SlowEnemy (nowSlowTime);
	}

	public void EnableUseSlow(){

        if(Game_Controller.playerInThisMap.SP < slowMana)
        {
            skill.skillTextTyping[0].color = Color.grey;
        }

		if(slowTimer >= coolDownSkillSlow){
			if(Game_Controller.playerInThisMap.SP >= slowMana){
				if(skill.skillTextTyping[0].text.Equals("3")){
					skill.skillTextTyping[0].color = Color.white;

					skill.UseSkill();
				}
			}
		}else{
			if(skill.skillTextTyping[0].text.Equals("3")){
				skill.skillTextTyping[0].color = Color.grey;
			}
			slowTimer += Time.deltaTime;
			skill.localIndexSkill = 0;
		}
	}

	void SlowEnemy(float timer){
		if(Skill_Controller.nowSlow){
			if(useSlow){
				Game_Controller.playerInThisMap.SPReduce(slowMana);
				useSlow = false;
			}
			if(!Skill_Controller.nowIce){
				foreach(Enemy enemy in Game_Controller.enemyInThisMap){
					if(enemy.gameObject.activeInHierarchy){
						enemy.runSpeed = enemy.baseRunSpeed * 0.6f;
					}
				}
				tmpSlowTime += Time.deltaTime;
				if(tmpSlowTime >= timer){
					foreach(Enemy enemy in Game_Controller.enemyInThisMap){
						enemy.runSpeed = enemy.baseRunSpeed;
					}
					Skill_Controller.nowSlow = false;
					//Skill now reduce mana here...It should be up there
					
				}
			}else{
				Skill_Controller.nowSlow = false;
			}
		}
	}

	public void SlowSkillUp(){
		if(Game_Controller.playerInThisMap.skillPoint != 0){
			slowLVL++;
			nowSlowTime += 0.5f;
            slowMana += 20;
			Game_Controller.playerInThisMap.skillPoint--;
		}
	}

}
