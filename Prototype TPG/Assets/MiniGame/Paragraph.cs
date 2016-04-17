using UnityEngine;
using System.Collections;

public class Paragraph : MonoBehaviour {

	public int count = 0;

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
	Choice PRG_STSC;
	public string[] paragraph;
	public bool ST1 = false;
	public bool ST2 = false;
	public bool ST3 = false;
	public bool ST4 = false;
	public string sentence1 = "";
	public string sentence2 = "";
	public string sentence3 = "";
	public string sentence4 = "";

	public Game_Controller gameScript;
	public textManager textManagerScript;
	
	void Awake(){
		paragraph = Game_Controller.a.getParagraph();
		PRG_Controller = gameObject.GetComponentInChildren<Question> ();
		PRG_STSC = gameObject.GetComponentInChildren<Choice> ();
		textCheck = (Typing_Input)FindObjectOfType (typeof(Typing_Input));
		realStatus (Game_Controller.gameDiff);
		textTyping = GetComponentsInChildren<TextMesh> ();
	}
	
	// Use this for initialization
	void Start () {
		PRG_Controller.Close ();
		PRG_STSC.Close ();
		gameScript = GameObject.Find("Game_Controller").GetComponent<Game_Controller>();
		textManagerScript = GameObject.Find("TextManager").GetComponent<textManager>();
		HPEnemyScript = transform.GetChild(2).GetChild(0).GetComponent<HPEnemy>();
		textTyping [1].text = paragraph [0];
		sentence1 = textTyping [1].text;
		textTyping [3].text = paragraph [1];
		sentence2 = textTyping [1].text;
		textTyping [5].text = paragraph [2];
		sentence3 = textTyping [1].text;
		textTyping [7].text = paragraph [3];
		sentence4 = textTyping [1].text;
	}
	
	// Update is called once per frame
	void Update () {
		TimeOut ();
		if(ST4){
			gameObject.SetActive(false);
			Game_Controller.playerInThisMap.gameObject.SetActive(true);
			Game_Controller.cameraFirst.SetActive(true);
			Game_Controller.PRGMiniGame = false;
			Game_Controller.indexGlobal = 0;
		}
	}
	
	void LateUpdate(){
		if(Game_Controller.PRGMiniGame){
			timeHP -= Time.deltaTime;
		}
		HPEnemyScript.updateenemyHP(timeHP /maxTimeHP);

	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Player"){
			Game_Controller.cameraFirst.SetActive(false);
			PRG_Controller.Open();
			PRG_STSC.Open ();
			Game_Controller.PRGMiniGame = true;
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
