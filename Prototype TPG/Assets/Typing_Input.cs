using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using System.Globalization;
using System;

public class Typing_Input : MonoBehaviour {

	public AudioClip[] audioClip;

	AudioSource error;

	[HideInInspector]
	public string textFieldString;

	private char textFieldChar;

    public textManager textManagerScript;

    public static double timer=0;
    public bool check=false;

    void Start()
    {
        textManagerScript = GameObject.Find("TextManager").GetComponent<textManager>();
    }

	void Update () {

        if(check==true)
        {
            timer += Time.deltaTime;
        }

        if (Game_Controller.indexGlobal >= 1)
        {
            check = true;
        }
        else
        {
            check = false;
            timer = 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape)){
			Game_Controller.ESC = true;

		}else if (!Input.GetKeyDown(KeyCode.LeftShift) && !Input.GetKeyDown(KeyCode.Tab) && !Input.GetKeyDown(KeyCode.Mouse0) && Input.anyKeyDown && !Input.GetKeyDown(KeyCode.DownArrow) && !Input.GetKeyDown(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.LeftArrow) && !Input.GetKeyDown(KeyCode.RightArrow)) {

            //ตอนแรกมัน GetKeyDown LeftShift อ่ะ

			PlaySound(0);
            Game_Controller.ESC = false;
			textFieldString = Input.inputString;
            //textFieldChar = textFieldString[0]; อันนี้ของเก่า
            textFieldChar = Char.ToLower(textFieldString [0]);
            /*
            Debug.Log(Char.ToLower(textFieldString[0]));
			Debug.Log(textFieldChar);
            */

			foreach (Player_Skill skill in Skill_Controller.Allskill){
				skill.CheckWrongAllSkill(textFieldChar);
			}

			foreach(Treasure treasure in Game_Controller.treasureMinigame){
				treasure.CheckWrongAll(textFieldChar);
			}

			foreach(QnTChoice QuiznType in Game_Controller.QuizNTypeMinigame){
				QuiznType.CheckWrongAll(textFieldChar);
			}

			foreach(Enemy enemy in Game_Controller.enemyInThisMap){
				if(enemy.gameObject.activeInHierarchy && enemy.gameObject.activeSelf){
					enemy.CheckWrongAll(textFieldChar);
				}
			}
//			

			if(Input.GetKeyDown(KeyCode.LeftShift) && !Input.GetKeyDown(KeyCode.Space) && !Input.GetKeyDown(KeyCode.Tab) && !Input.GetKeyDown(KeyCode.Mouse0) && !Input.GetKeyDown(KeyCode.Return) && Game_Controller.chestWrongAll && Game_Controller.wrongAll && Skill_Controller.checkWrongAllSkillInPanel && Game_Controller.QnTWrongAll){
				PlaySound(1);
			}else if(!Game_Controller.chestWrongAll || !Game_Controller.wrongAll || !Skill_Controller.checkWrongAllSkillInPanel || !Game_Controller.QnTWrongAll){

				foreach(QnTChoice monQnT in Game_Controller.QuizNTypeMinigame){
					monQnT.CheckLetter(textFieldChar);
				}

				foreach(Player_Skill skill in Skill_Controller.Allskill){
					skill.CheckSkill(textFieldChar);
				}
				
				foreach(Enemy enemy in Game_Controller.enemyInThisMap){
					if(enemy.gameObject.activeInHierarchy && enemy.gameObject.activeSelf && Skill_Controller.checkWrongAllSkillInPanel){
						enemy.CheckLetter(textFieldChar);
					}
				}
				
				foreach(Treasure chest in Game_Controller.treasureMinigame){
					chest.CheckLetter(textFieldChar);
				}
				PlaySound(0);
				
				if (timer != 0)
				{
					textManagerScript.sendTimeData(textFieldChar, timer);
					timer = 0;
				}

				if(Skill_Controller.checkWrongAllSkillInPanel){
					Game_Controller.indexGlobal++;
					Game_Controller.chestWrongAll = true;
					Game_Controller.QnTWrongAll = true;
					Game_Controller.wrongAll = true;
				}else{
					Skill_Controller.indexSkillGlobal++;
					Skill_Controller.checkWrongAllSkillInPanel = true;
				}

			}
				
				//จะนับเมื่อตัวที่ 2 เป็นต้นไป
				
			//if wrongall = true kue mun pid mod we won't do down but if it is false we will do
			//it should get the result of true or false...if it is true then go to down...
		}
	}

	void PlaySound(int clip){
		AudioSource audio = GetComponent<AudioSource> ();
		audio.clip = audioClip [clip];
		audio.Play ();
	}
	
}
