using UnityEngine;
using System.Collections;

public class QnTChoice : MonoBehaviour {

	public GameObject identity;
	public int set;
	private char[] choice;
	[HideInInspector]
	public TextMesh[] textTyping;
	private int indexLocal = 0;
	QnT QnTScript;

	// Use this for initialization
	void Awake(){
		QnTScript = GameObject.Find ("QnT").GetComponent<QnT> ();
		textTyping = GetComponentsInChildren<TextMesh> ();
	}

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		choice = textTyping [1].text.ToCharArray ();
		PushESC (Game_Controller.ESC);
	}

	void LateUpdate(){
		if(QnTScript.setOfQuiz[1].Equals(textTyping[0].text)){
			Debug.Log("correct");
			GameObject correct = Instantiate(identity, gameObject.transform.position, Quaternion.identity) as GameObject;
			correct.transform.SetParent(gameObject.transform);
			QnTScript.correct = true;
			QnTScript.incorrect = false;
			indexLocal = 0;
		}else {
			Debug.Log("incorrect");
			QnTScript.incorrect = true;
			WordInstantiate();
		}
	}

	public void CheckWrongAll(char txt){
		if (Game_Controller.QnTMiniGame){
			if (Game_Controller.indexGlobal == indexLocal) {
				if (txt.Equals (choice [Game_Controller.indexGlobal])) {
					Game_Controller.QnTWrongAll = false;
				}
			}
		}
	}
	
	public void CheckLetter(char txt){
		if (Game_Controller.QnTMiniGame) {
			if (Game_Controller.indexGlobal == indexLocal) {
				if (txt.Equals (choice [Game_Controller.indexGlobal])) {
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

	public void WordInstantiate(){
		if(Game_Controller.indexGlobal == indexLocal){
			if(textTyping [1].text.Equals (textTyping [0].text)){
				GameObject incorrect = Instantiate(identity, gameObject.transform.position, Quaternion.identity) as GameObject;
				incorrect.transform.SetParent(gameObject.transform);
				textTyping[0].text = "";
				indexLocal = 0;
				Game_Controller.indexGlobal = 0;
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
}
