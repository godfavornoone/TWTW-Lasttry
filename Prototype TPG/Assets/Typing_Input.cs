using UnityEngine;
using System.Collections;

public class Typing_Input : MonoBehaviour {

	[HideInInspector]
	public string textFieldString;

	private char textFieldChar;

	void Update () {

		if(Input.GetKeyDown(KeyCode.Escape)){
			Game_Controller.ESC = true;
		}else if (!Input.GetKeyDown(KeyCode.LeftShift) && !Input.GetKeyDown(KeyCode.Tab) && Input.anyKeyDown) {
			Game_Controller.ESC = false;
			textFieldString = Input.inputString;
			textFieldChar = textFieldString [0];
			Debug.Log(textFieldChar);

			foreach(Player_Skill skill in Skill_Controller.Allskill){
				skill.CheckWrongAllSkill(textFieldChar);
				Debug.Log(Skill_Controller.checkWrongAllSkillInPanel);
			}

			foreach(Enemy enemy in Game_Controller.enemyInThisMap){
				enemy.CheckWrongAll(textFieldChar);
			}
			
			if(!Game_Controller.wrongAll || !Skill_Controller.checkWrongAllSkillInPanel){

				foreach(Player_Skill skill in Skill_Controller.Allskill){
					skill.CheckSkill(textFieldChar);
				}

				foreach(Enemy enemy in Game_Controller.enemyInThisMap){
					enemy.CheckLetter(textFieldChar);
				}
				Game_Controller.indexGlobal++;
				Game_Controller.wrongAll = true;
				Skill_Controller.checkWrongAllSkillInPanel = true;
			}
			//if wrongall = true kue mun pid mod we won't do down but if it is false we will do
			//it should get the result of true or false...if it is true then go to down...
		}
	}
}
