using UnityEngine;
using System.Collections;

public class Typing_Input : MonoBehaviour {

	[HideInInspector]
	public string textFieldString;

	private char textFieldChar;
	private GameObject[] enemySpawn;

	void Update () {
		enemySpawn = GameObject.FindGameObjectsWithTag ("Enemy");

		if(Input.GetKeyDown(KeyCode.Escape)){
			Game_Controller.ESC = true;
		}else if (Input.anyKeyDown) {
			Game_Controller.ESC = false;
			textFieldString = Input.inputString;
//			Debug.Log (textFieldString);
			textFieldChar = textFieldString [0];
			
			foreach(GameObject enemy in enemySpawn){
				enemy.GetComponent<EnemyText_Control>().CheckWrongAll(textFieldChar);
			}
			
			if(!Game_Controller.wrongAll){
				foreach(GameObject enemy in enemySpawn){
					enemy.GetComponent<EnemyText_Control>().CheckLetter(textFieldChar);
				}
				Game_Controller.indexGlobal++;
				Game_Controller.wrongAll = true;

//				if(Game_Controller.isEnemyDead){
//					Game_Controller.isEnemyDead = false;
//				}
			}
			//if wrongall = true kue mun pid mod we won't do down but if it is false we will do
			//it should get the result of true or false...if it is true then go to down...
		}
	}
}
