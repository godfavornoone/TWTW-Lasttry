﻿using UnityEngine;
using System.Collections;

public class Skill_Ice : MonoBehaviour {

	public GameObject iceSprite;

	Player_Skill skill;
	public bool useIce = false;

	[HideInInspector]
	public float tmpIceTime = 0;
	public int iceLVL =1;
	public float coolDownSkillIce = 10f;
	[HideInInspector]
	public float iceTimer;
	public float nowIceTime = 3f;
    public float iceMana = 100;
	[HideInInspector]
	public bool nowIce = false;
	private float tmpspd;
	public float tmpatk;

	void Awake(){
		skill = GetComponent<Player_Skill> ();
	}

	// Use this for initialization
	void Start () {
		iceTimer = coolDownSkillIce;
	}
	
	// Update is called once per frame
	void Update () {
		EnableUseIce ();
	}

	void LateUpdate(){
		IceEnemy (nowIceTime);
	}

	public void EnableUseIce(){

        if (Game_Controller.playerInThisMap.SP < iceMana)
        {
            skill.skillTextTyping[0].color = Color.grey;
        }

        if (iceTimer >= coolDownSkillIce){
			if(Game_Controller.playerInThisMap.SP >= iceMana){
				if(skill.skillTextTyping[0].text.Equals("ice")){
					skill.skillTextTyping[0].color = Color.white;
					skill.UseSkill();
				}
			}
		}else{
			if(skill.skillTextTyping[0].text.Equals("ice")){
				skill.skillTextTyping[0].color = Color.grey;
			}
			tmpIceTime += Time.deltaTime;
			iceTimer += Time.deltaTime;
			skill.localIndexSkill = 0;
		}
	}

	void IceEnemy(float timer){
		if(nowIce){
			if(useIce){
				Game_Controller.playerInThisMap.SPReduce(iceMana);
				foreach(Enemy enemy in Game_Controller.enemyInThisMap){
					if(enemy.gameObject.activeInHierarchy && enemy.gameObject.activeSelf){
						Instantiate(iceSprite, enemy.transform.position, Quaternion.identity);
						tmpspd = enemy.runSpeed;
						tmpatk = enemy.Attack;
					}
				}
				useIce = false;
			}
			foreach(Enemy enemy in Game_Controller.enemyInThisMap){
				if(enemy.gameObject.activeInHierarchy && enemy.gameObject.activeSelf){
					enemy.runSpeed = 0;
					enemy.Attack = 0;
				}
			}

			Invoke("ReturnStatus", nowIceTime);
//            if (tmpIceTime >= timer){
//				foreach(Enemy enemy in Game_Controller.enemyInThisMap){
//					if(enemy.gameObject.activeInHierarchy && enemy.gameObject.activeSelf){
//						enemy.runSpeed = tmpspd;
//						enemy.Attack = tmpatk;
//					}
//				}
//                
//                nowIce = false;
//                
//            }
            
		}
	}

	public void IceSkillUp(){
		if(Game_Controller.playerInThisMap.skillPoint != 0){
			iceLVL++;
			nowIceTime += 0.5f;
            iceMana += 20;
			Game_Controller.playerInThisMap.skillPoint--;
		}
	}

	void ReturnStatus(){
		foreach(Enemy enemy in Game_Controller.enemyInThisMap){
			if(enemy.gameObject.activeInHierarchy && enemy.gameObject.activeSelf){
				enemy.runSpeed = tmpspd;
				enemy.Attack = tmpatk;
			}
			nowIce = false;
		}
	}
}
