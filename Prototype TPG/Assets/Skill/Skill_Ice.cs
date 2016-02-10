using UnityEngine;
using System.Collections;

public class Skill_Ice : MonoBehaviour {

	Player_Skill skill;

	[HideInInspector]
	public float tmpIceTime = 0;
	public int iceLVL =1;
	public float coolDownSkillIce = 10f;
	[HideInInspector]
	public float iceTimer;
	public float nowIceTime = 3f;
	[HideInInspector]
	public bool nowIce = false;
	private float tmpspd;

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
		if(iceTimer >= coolDownSkillIce){
			if(Game_Controller.playerInThisMap.SP >= 100f){
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
			foreach(Enemy enemy in Game_Controller.enemyInThisMap){
				if(enemy.gameObject.activeInHierarchy && enemy.gameObject.activeSelf){
					tmpspd = enemy.baseRunSpeed;
					enemy.runSpeed = 0;
				}
			}
			tmpIceTime += Time.deltaTime;
			if(tmpIceTime >= timer){
				foreach(Enemy enemy in Game_Controller.enemyInThisMap){
					if(enemy.gameObject.activeInHierarchy && enemy.gameObject.activeSelf){
						enemy.runSpeed = enemy.baseRunSpeed;
					}
				}
				nowIce = false;
			}
		}
	}

	public void IceSkillUp(){
		if(Game_Controller.playerInThisMap.skillPoint != 0){
			iceLVL++;
			nowIceTime += 0.5f;
			Game_Controller.playerInThisMap.skillPoint--;
		}
	}
}
