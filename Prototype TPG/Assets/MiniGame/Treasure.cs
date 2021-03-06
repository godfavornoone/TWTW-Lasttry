using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Treasure : MonoBehaviour {

	public Text_Outline setStroke;

	Animator treasureOpen;
	public Transform player;
    public float baseDropRate;

    public float baseTimeHP;
	[HideInInspector]
	public float maxTimeHP;
	[HideInInspector]
	public float timeHP;

	public List<int> wordLengthDifficulty = new List<int>();
	public List<int> wordLevelDifficulty = new List<int>();
	private int wordLength;
	private int wordDifficult;
	private Typing_Input textCheck;
	[HideInInspector]
	public TextMesh[] textTyping;
	private char[] charStorage;
	private int indexLocal = 0;

    [HideInInspector]
    public float dropRate;

    private float distanceAttack;

	public Game_Controller gameScript;
	public textManager textManagerScript;
	public HPEnemy HPEnemyScript;

	void Awake(){
		treasureOpen = GetComponent<Animator> ();
		textCheck = (Typing_Input)FindObjectOfType (typeof(Typing_Input));
		realStatus (Game_Controller.gameDiff);
		calculateWord(Game_Controller.wordDiff);
		textTyping = GetComponentsInChildren<TextMesh> ();
	}

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		gameScript = GameObject.Find("Game_Controller").GetComponent<Game_Controller>();
		textManagerScript = GameObject.Find("TextManager").GetComponent<textManager>();
		textTyping[1].text = textManagerScript.sendText(wordLength,wordDifficult);
		HPEnemyScript = transform.GetChild(2).GetChild(0).GetComponent<HPEnemy>();
	}
	
	// Update is called once per frame
	void Update () {
		charStorage = textTyping [1].text.ToCharArray ();
		PushESC (Game_Controller.ESC);
		TimeOut ();
	}

	void LateUpdate(){
		if(Game_Controller.playerInMinigame){
			timeHP -= Time.deltaTime;
		}
		HPEnemyScript.updateenemyHP(timeHP /maxTimeHP);
		if (textTyping[1].text.Equals(textTyping[0].text))
		{
			WordInstantiate();
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Player"){

            foreach (Enemy enemy in Game_Controller.enemyInThisMap)
            {
                enemy.textTyping[0].text = "";
                enemy.indexLocal = 0;
            }

            Game_Controller.indexGlobal = 0;

            textTyping [1].color = Color.white;
			Game_Controller.playerInMinigame = true;


		}
	}

	void OnTriggerStay2D(Collider2D other){
		if(other.gameObject.tag == "Player"){
			textTyping [1].color = Color.white;
			Game_Controller.playerInMinigame = true;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.tag == "Player"){
			textTyping[1].color = Color.grey;
			Game_Controller.playerInMinigame = false;

            
            textTyping[0].text = "";
            indexLocal = 0;
            
            Game_Controller.indexGlobal = 0;

        }
	}
	

	void realStatus(int gameDifficult){
		timeHP = baseTimeHP;
		maxTimeHP = timeHP;
        dropRate = baseDropRate + (gameDifficult * 2);
	}

	public void CheckWrongAll(char txt){
		if (textTyping [1].color == Color.white){
			if (Game_Controller.indexGlobal == indexLocal) {
				if (txt.Equals (charStorage [Game_Controller.indexGlobal])) {
					Game_Controller.chestWrongAll = false;
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

	public void WordInstantiate(){
		if(Game_Controller.indexGlobal == indexLocal){
			if(textTyping [1].text.Equals (textTyping [0].text)){
				textTyping[0].text = "";
				textTyping[1].text = textManagerScript.sendText(wordLength, wordDifficult);

                int dropchance = Random.Range(0, 100);
                //Debug.Log("dropChance is: " + dropchance);
                //Debug.Log("dropRate is: " + dropRate);
                if (dropchance <= dropRate)
                {
                    //Debug.Log("YEEEEE");
                    int item = Random.Range(0, 20);
                    Instantiate(gameScript.itemPrefab[item], this.transform.position, Quaternion.identity);

                }
                indexLocal = 0;
				Game_Controller.indexGlobal = 0;
			}
		}
	}

	void calculateWord(int playerWordDifficulty){
		wordLength = wordLengthDifficulty [playerWordDifficulty];
		wordDifficult = wordLevelDifficulty [playerWordDifficulty];
	}

	void PushESC(bool esc){
		if (esc) {
			textTyping[0].text = "";
			indexLocal = 0;
			Game_Controller.indexGlobal = 0;
		}
	}

	//input item drop here
	void TimeOut(){
		if(timeHP <= 0){
			treasureOpen.SetBool("Open", true);
			textTyping[1].text = "";
			textTyping[0].text = " ";
            Game_Controller.indexGlobal = 0;
            Invoke("CloseChest", 3f);
            
        }
	}

	void CloseChest(){
		
		Game_Controller.playerInMinigame = false;
		gameObject.SetActive(false);
	}
}
