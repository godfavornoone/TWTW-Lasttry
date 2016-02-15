using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Skill_Fire : MonoBehaviour {

	public GameObject fireSprite;

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
					if(enemy.hitPoint - fireDMG > 0){
						//Debug.Log(enemy.name + " = fire");
						Instantiate(fireSprite, enemy.transform.position, Quaternion.identity);
						enemy.hitPoint -= fireDMG;
					}else if(enemy.hitPoint - fireDMG <= 0){

						enemy.hitPoint -= fireDMG;

						if (!enemy.optionWord)
						{
							//Debug.Log("return Text complete" + " text is: " + enemy.textTyping[1].text);
							enemy.textManagerScript.returnText(enemy.textTyping[1].text, enemy.wordDifficult);
						}
						
						if (enemy.hitPoint <= 0){
							Game_Controller.enemyStruckPlayer = false;
							Game_Controller.oneEnemyDie = true;
							
							enemy.walk = false;
							enemy.runSpeed = 0;
							
							Game_Controller.indexGlobal = 0;
							enemy.textTyping[0].text = "";
							enemy.textTyping[1].text = "";
							//Game_Controller.indexGlobal = 0;
							
							Game_Controller.oneEnemyWordChange = true;
							Game_Controller.playerInThisMap.PlayerLVLUp(enemy.EXP);
							
							//Debug.Log ("recieve = " + enemy.EXP);
							//การ Drop ไอเทมละ
							int dropchance = Random.Range(0, 100);
							//Debug.Log("dropChance is: " + dropchance);
							//Debug.Log("dropRate is: " + enemy.dropRate);
							if (dropchance<=enemy.dropRate)
							{
								//Debug.Log("YEEEEE");
								int item = Random.Range(0, 20);
								Instantiate(enemy.gameScript.itemPrefab[item], this.transform.position, Quaternion.identity);
								
							}
							Game_Controller.enemyInThisMap.Remove(gameObject.GetComponent<Enemy>());
							Game_Controller.enemyStruckPlayer = false;

							enemy.transform.position = enemy.positionBorn;
							enemy.gameObject.SetActive(false);
						}
					}
				}
			}
			nowFire = false;
            Game_Controller.playerInThisMap.SPReduce(fireMana);
        }
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
