using UnityEngine;
using System.Collections;

public class Skill_Knock : MonoBehaviour {

	Player_Skill skill;

	public int knockLVL = 1;
	public float coolDownSkillKnock = 10f;
	[HideInInspector]
	public float knockTimer;
	private float knockSpeed = 50f;
	private float knockLong = 1f;
	[HideInInspector]
	public bool nowKnock = false;

	void Awake(){
		skill = GetComponent<Player_Skill> ();
	}

	// Use this for initialization
	void Start () {
		knockTimer = coolDownSkillKnock;
	}
	
	// Update is called once per frame
	void Update () {
		EnableUseKnock ();
	}

	void LateUpdate(){
		KnockEnemy ();
	}

	public void EnableUseKnock(){
		if(knockTimer >= coolDownSkillKnock){
			if(Game_Controller.playerInThisMap.SP >= 100f){
				if(skill.skillTextTyping[0].text.Equals("knock")){
					skill.skillTextTyping[0].color = Color.white;
					skill.UseSkill();
				}
			}
		}else{
			if(skill.skillTextTyping[0].text.Equals("knock")){
				skill.skillTextTyping[0].color = Color.grey;
			}
			knockTimer += Time.deltaTime;
			skill.localIndexSkill = 0;
		}
	}

	void KnockEnemy(){
		if(nowKnock){
			foreach(Enemy enemy in Game_Controller.enemyInThisMap){
				if(enemy.gameObject.activeInHierarchy && enemy.gameObject.activeSelf){
					if(enemy.distanceBetweenEVP.x == 0){
						if(enemy.distanceBetweenEVP.y > 0){
							enemy.transform.position += new Vector3(0,knockLong,0).normalized * knockSpeed * Time.deltaTime;
						}else{
							enemy.transform.position += new Vector3(0,-knockLong,0).normalized * knockSpeed * Time.deltaTime;
						}
					}else if(enemy.distanceBetweenEVP.y == 0){
						if(enemy.distanceBetweenEVP.x > 0){
							enemy.transform.position += new Vector3(knockLong,0,0).normalized * knockSpeed * Time.deltaTime;
						}else{
							enemy.transform.position += new Vector3(-knockLong,0,0).normalized * knockSpeed * Time.deltaTime;
						}
					}else if(enemy.distanceBetweenEVP.x > 0){
						if(enemy.distanceBetweenEVP.y > 0){
							enemy.transform.position += new Vector3(knockLong,knockLong,0).normalized * knockSpeed * Time.deltaTime;
						}else{
							enemy.transform.position += new Vector3(knockLong,-knockLong,0).normalized * knockSpeed * Time.deltaTime;
						}
					}else if(enemy.distanceBetweenEVP.x < 0){
						if(enemy.distanceBetweenEVP.y > 0){
							enemy.transform.position += new Vector3(-knockLong,knockLong,0).normalized * knockSpeed * Time.deltaTime;
						}else{
							enemy.transform.position += new Vector3(-knockLong,-knockLong,0).normalized * knockSpeed * Time.deltaTime;
						}
					}
				}
			}
		}
		nowKnock = false;
	}

	public void KnockSkillUp(){
		if(Game_Controller.playerInThisMap.skillPoint != 0){
			knockLVL++;
			coolDownSkillKnock -= 1f;
			Game_Controller.playerInThisMap.skillPoint--;
		}
	}

}
