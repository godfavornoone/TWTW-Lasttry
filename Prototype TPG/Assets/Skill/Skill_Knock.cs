using UnityEngine;
using System.Collections;

public class Skill_Knock : MonoBehaviour {

	Player_Skill skill;

	public int knockLVL = 1;
	public float coolDownSkillKnock = 10f;
	[HideInInspector]
	public float knockTimer;
	private float knockSpeed = 50f;
	public float knockLong = 1f;
    public float knockMana = 100;
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

        if (Game_Controller.playerInThisMap.SP < knockMana)
        {
            skill.skillTextTyping[0].color = Color.grey;
        }

        if (knockTimer >= coolDownSkillKnock){
			if(Game_Controller.playerInThisMap.SP >= knockMana){
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
            Debug.Log("knock Mana Cost is: " + knockMana);
            Game_Controller.playerInThisMap.SPReduce(knockMana);
        }
		nowKnock = false;
        
    }

	public void KnockSkillUp(){
		if(Game_Controller.playerInThisMap.skillPoint != 0){
			knockLVL++;
			coolDownSkillKnock -= 0.5f;
            knockMana += 20;
			Game_Controller.playerInThisMap.skillPoint--;
		}
	}

}
