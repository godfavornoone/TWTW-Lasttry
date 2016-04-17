using UnityEngine;
using System.Collections;

public class PRG_ST : MonoBehaviour {

	public bool correct = false;
	private char[] sentence;
	public int set;
	[HideInInspector]
	public TextMesh[] textTyping;
	private int indexLocal = 0;
	Paragraph PRGScript;
	public Game_Controller gameScript;

	void Awake(){
		PRGScript = GameObject.Find ("Paragraph").GetComponent<Paragraph> ();
		textTyping = GetComponentsInChildren<TextMesh> ();
	}
	// Use this for initialization
	void Start () {
		gameScript = GameObject.Find("Game_Controller").GetComponent<Game_Controller>();
	}
	
	// Update is called once per frame
	void Update () {
		sentence = textTyping [1].text.ToCharArray ();
		EnableTyping ();
		ChangeSentence ();
		PushESC (Game_Controller.ESC);
	}

	void LatedUpdate(){

	}

	public void CheckWrongAll(char txt){
		if (Game_Controller.PRGMiniGame){
			if(textTyping[1].color == Color.white){
				if (Game_Controller.indexGlobal == indexLocal) {
					if (txt.Equals (sentence [Game_Controller.indexGlobal])) {
						Game_Controller.PRGWrongAll = false;
					}
				}
			}
		}
	}
	
	public void CheckLetter(char txt){
		if (Game_Controller.PRGMiniGame) {
			if(textTyping[1].color == Color.white){
				if (Game_Controller.indexGlobal == indexLocal) {
					if (txt.Equals (sentence [Game_Controller.indexGlobal])) {
						textTyping [0].text += txt;
						indexLocal++;
					}else {
						textTyping [0].text = "";
						indexLocal = 0;
					}
				}
			}
		}else {
			textTyping [0].text = "";
			indexLocal = 0;
		}
	}

	public void ChangeSentence(){
		if(Game_Controller.indexGlobal == indexLocal){
			if(textTyping [1].text.Equals (textTyping [0].text)){
				textTyping[0].text = "";
				textTyping[1].color = Color.red;
				indexLocal = 0;
				Game_Controller.indexGlobal = 0;
				PRGScript.count++;
				correct = true;
				if (PRGScript.count == 1) {
					PRGScript.ST4 = false;
					PRGScript.ST1 = true;
				} else if (PRGScript.count == 2) {
					PRGScript.ST1 = false;
					PRGScript.ST2 = true;
				} else if (PRGScript.count == 3) {
					PRGScript.ST2 = false;
					PRGScript.ST3 = true;
				} else if (PRGScript.count == 4) {
					PRGScript.ST3 = false;
					PRGScript.ST4 = true;
				}
			}
		}
	}
	
	void PushESC(bool esc){
		if (esc) {
			textTyping[0].text = "";
			indexLocal = 0;
			Game_Controller.indexGlobal = 0;
		}
	}

	void EnableTyping(){
		if(set == 1 && !PRGScript.ST1 && !correct){
			textTyping[1].color = Color.white;
		}else if(set == 2 && PRGScript.ST1 && !correct){
			textTyping[1].color = Color.white;
		}else if(set == 3 && PRGScript.ST2 && !correct){
			textTyping[1].color = Color.white;
		}else if(set == 4 && PRGScript.ST3 && !correct){
			textTyping[1].color = Color.white;
		}
	}

}
