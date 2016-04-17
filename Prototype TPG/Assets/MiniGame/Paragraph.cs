using UnityEngine;
using System.Collections;

public class Paragraph : MonoBehaviour {

	[HideInInspector]
	public float timeHP;
	[HideInInspector]
	public float maxTimeHP;
	public float baseDropRate;
	public float baseTimeHP;
	public HPEnemy HPEnemyScript;
	private Typing_Input textCheck;
	[HideInInspector]
	public TextMesh[] textTyping;
	[HideInInspector]
	public float dropRate;
	private int indexLocal = 0;
	Question PRG_Controller;
	string[] paragraph = Game_Controller.a.getParagraph();

	public Game_Controller gameScript;
	public textManager textManagerScript;
	
	void Awake(){
		textCheck = (Typing_Input)FindObjectOfType (typeof(Typing_Input));
		PRG_Controller = gameObject.GetComponentInChildren<Question> ();
		realStatus (Game_Controller.gameDiff);
		textTyping = GetComponentsInChildren<TextMesh> ();
	}
	
	// Use this for initialization
	void Start () {
		PRG_Controller.Close ();
		gameScript = GameObject.Find("Game_Controller").GetComponent<Game_Controller>();
		textManagerScript = GameObject.Find("TextManager").GetComponent<textManager>();
		HPEnemyScript = transform.GetChild(2).GetChild(0).GetComponent<HPEnemy>();
		textTyping [1].text = paragraph [0];
		textTyping [3].text = paragraph [1];
		textTyping [5].text = paragraph [2];
		textTyping [7].text = paragraph [3];
	}
	
	// Update is called once per frame
	void Update () {
		TimeOut ();
	}
	
	void LateUpdate(){
		if(Game_Controller.QnTMiniGame){
			timeHP -= Time.deltaTime;
		}
		HPEnemyScript.updateenemyHP(timeHP /maxTimeHP);
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Player"){
			Game_Controller.cameraFirst.SetActive(false);
			PRG_Controller.Open();
			Game_Controller.QnTMiniGame = true;
			Game_Controller.playerInThisMap.gameObject.SetActive(false);
		}
	}
	
	void realStatus(int gameDifficult){
		timeHP = baseTimeHP * gameDifficult;
		maxTimeHP = timeHP;
		dropRate = baseDropRate + (gameDifficult * 2);
	}
	
	void TimeOut(){
		if(timeHP <= 0){
			gameObject.SetActive(false);
			Game_Controller.playerInThisMap.gameObject.SetActive(true);
			Game_Controller.cameraFirst.SetActive(true);
			Game_Controller.PRGMiniGame = false;
			Game_Controller.indexGlobal = 0;
		}
	}
}
