using UnityEngine;
using System.Collections;

public class QnT : MonoBehaviour {

	public bool correct = false;
	public bool incorrect = true;
	bool checkIndex = false;

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

	private char[] choice1;
	private char[] choice2;
	private char[] choice3;

	public Game_Controller gameScript;
	public textManager textManagerScript;
	Question QnTPn;
	Choice QnTPnC;
	public string[] setOfQuiz;

	void Awake(){
		setOfQuiz = Game_Controller.a.getQuestionAndAns();
		QnTPn = gameObject.GetComponentInChildren<Question> ();
		QnTPnC = gameObject.GetComponentInChildren<Choice> ();
		textCheck = (Typing_Input)FindObjectOfType (typeof(Typing_Input));
		realStatus (Game_Controller.gameDiff);
		textTyping = GetComponentsInChildren<TextMesh> ();
	}

	// Use this for initialization
	void Start () {
		QnTPn.Close ();
		QnTPnC.Close ();
		gameScript = GameObject.Find("Game_Controller").GetComponent<Game_Controller>();
		textManagerScript = GameObject.Find("TextManager").GetComponent<textManager>();
		HPEnemyScript = transform.GetChild(2).GetChild(0).GetComponent<HPEnemy>();
		textTyping [0].text = setOfQuiz [0];
		textTyping [2].text = setOfQuiz [2];
		textTyping [4].text = setOfQuiz [3];
		textTyping [6].text = setOfQuiz [1];
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
		if(correct){
			WordInstantiate();
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Player"){
			Game_Controller.cameraFirst.SetActive(false);
			QnTPn.Open();
			QnTPnC.Open();
			Game_Controller.QnTMiniGame = true;
			Game_Controller.playerInThisMap.gameObject.SetActive(false);
		}
	}

	void realStatus(int gameDifficult){
		timeHP = baseTimeHP * gameDifficult;
		maxTimeHP = timeHP;
		dropRate = baseDropRate + (gameDifficult * 2);
	}

	public void WordInstantiate(){
		textTyping [5].text = "";
		correct = false;
		setOfQuiz = Game_Controller.a.getQuestionAndAns();
		textTyping [0].text = setOfQuiz [0];
		textTyping [2].text = setOfQuiz [2];
		textTyping [4].text = setOfQuiz [3];
		textTyping [6].text = setOfQuiz [1];
		Game_Controller.indexGlobal = 0;
	}

	void TimeOut(){
		if(timeHP <= 0){
			gameObject.SetActive(false);
			Game_Controller.playerInThisMap.gameObject.SetActive(true);
			Game_Controller.cameraFirst.SetActive(true);
			Game_Controller.QnTMiniGame = false;
			Game_Controller.indexGlobal = 0;
		}
	}
}
