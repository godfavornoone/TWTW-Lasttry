using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyText_Control : MonoBehaviour {

	public List<int> wordLengthDifficulty = new List<int>();
	public List<int> wordLevelDifficulty = new List<int>();
	private int wordLength;
	private int wordDifficult;
	private Typing_Input textCheck;
	private TextMesh[] textTyping;
	private char[] charStorage;
	public int indexLocal = 0;
	private float distance;
	public bool takedDMG = false;

	void Start () {
		textCheck = (Typing_Input)FindObjectOfType (typeof(Typing_Input));
		textTyping = GetComponentsInChildren<TextMesh> ();
//		calculateWord (0);
	}

	void Update(){
		charStorage = textTyping [1].text.ToCharArray ();
		EnableTyping ();
		PushESC (Game_Controller.ESC);
	}

	void LateUpdate(){
		WordInstantiate("baezy");
//		resetTyping();
	}

	public void CheckWrongAll(char txt){
		if (textTyping [1].color == Color.white){
			if (Game_Controller.indexGlobal == indexLocal) {
				if (txt.Equals (charStorage [Game_Controller.indexGlobal])) {
					Game_Controller.wrongAll = false;
				}
			}
		}
	}

	public void CheckLetter(char txt){
		if (textTyping [1].color == Color.white) {
			if (Game_Controller.indexGlobal == indexLocal) {
				if (txt.Equals (charStorage [Game_Controller.indexGlobal])) {
					textTyping [0].text += txt;
					indexLocal++;
				}else {
					textTyping [0].text = "";
					indexLocal = 0;
				}
			}
		}else {
			textTyping [0].text = "";
			indexLocal = 0;
		}
	}

	public void WordInstantiate(string word){
		if (Game_Controller.indexGlobal == indexLocal) {
			if (textTyping [1].text.Equals (textTyping [0].text)) {
//				Game_Controller.attackAble = true;
				takedDMG = true;
				textTyping [0].text = "";
				textTyping [1].text = word;
				indexLocal = 0;
				Game_Controller.indexGlobal = 0;
//				takedDMG = false;
//				Game_Controller.isEnemyDead = true;
			}
		} else {
			takedDMG = false;
		}
	}
//
//	public void resetTyping(){
//		if(Game_Controller.isEnemyDead){
//			textTyping[0].text = "";
//			indexLocal = 0;
//		}
//	}

	void calculateWord(int playerWordDifficulty){
		wordLength = wordLengthDifficulty [playerWordDifficulty];
		wordDifficult = wordLevelDifficulty [playerWordDifficulty];
	}

	public void EnableTyping(){
		distance = Vector2.Distance (gameObject.transform.position, GameObject.FindGameObjectWithTag ("Player").transform.position);
		if (distance < 1 && Player_Controller.isSword) {
			textTyping [1].color = Color.white;
		} else if (distance < 3 && !Player_Controller.isSword) {
			textTyping [1].color = Color.white;
		} else {
			textTyping [1].color = Color.grey;
		}
	}

	void PushESC(bool esc){
		if (esc) {
			textTyping[0].text = "";
			indexLocal = 0;
			Game_Controller.indexGlobal = 0;
		}
	}

}
