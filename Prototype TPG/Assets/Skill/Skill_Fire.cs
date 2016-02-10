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
		FireEnemy (fireDMG);
	}

	public void EnableUseFire(){
		if (fireTimer >= coolDownSkillFire) {
			if (Game_Controller.playerInThisMap.SP >= 100f) {
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
					enemy.HpDown(fireDMG);
				}
			}
		}
		nowFire = false;
	}

	public void FireSkillUp(){
		if(Game_Controller.playerInThisMap.skillPoint != 0){
			fireLVL++;
			fireDMG += 20f;
			Game_Controller.playerInThisMap.skillPoint--;
		}
	}
}
