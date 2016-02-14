using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Skill_Fire : MonoBehaviour {

	Player_Skill skill;

	public int fireLVL = 1;
	public float coolDownSkillFire = 10f;
	[HideInInspector]
	public float fireTimer;
	public float fireDMG = 50;
    public float fireMana = 100;
	[HideInInspector]
	public bool nowFire = false;

	void Awake(){
		skill = GetComponent<Player_Skill> ();
	}
	// Use this for initialization
	void Start () {
		fireTimer = coolDownSkillFire;
	}
	
	// Update is called once per frame
	void Update () {
		EnableUseFire ();
    }

	void LateUpdate(){
        FireEnemy(fireDMG);
    }

	public void EnableUseFire(){


        if (Game_Controller.playerInThisMap.SP < fireMana)
        {
            skill.skillTextTyping[0].color = Color.grey;
        }

        if (fireTimer >= coolDownSkillFire) {
			if (Game_Controller.playerInThisMap.SP >= fireMana) {
				if(skill.skillTextTyping[0].text.Equals("fire")){
					skill.skillTextTyping [0].color = Color.white;
					skill.UseSkill ();
				}
			}
		} else {
			if(skill.skillTextTyping[0].text.Equals("fire")){
				skill.skillTextTyping [0].color = Color.grey;
			}
			fireTimer += Time.deltaTime;
			skill.localIndexSkill = 0;
		}
	}

	void FireEnemy(float dmg){
		if(nowFire){
			foreach(Enemy enemy in Game_Controller.enemyInThisMap){
				if(enemy.gameObject.activeInHierarchy && enemy.gameObject.activeSelf){
                    Debug.Log("Use Fire Skill with DMG: " + fireDMG);
					enemy.HpDown(fireDMG);
				}
			}
            Game_Controller.playerInThisMap.SPReduce(fireMana);
        }
        
        nowFire = false;
	}

	public void FireSkillUp(){
		if(Game_Controller.playerInThisMap.skillPoint != 0){
			fireLVL++;
			fireDMG += 20f;
            fireMana += 20;
			Game_Controller.playerInThisMap.skillPoint--;
		}
	}
}
