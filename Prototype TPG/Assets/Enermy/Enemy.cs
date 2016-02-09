using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {

	Transform player;
	Animator enemy_Anim;

	public string textBeforeMonsterArrow = "";
	public string textTypeMonsterArrow = "";
	public bool walk = true;
	private float nextAtk = 0f;
//	[HideInInspector]
//	public bool struckPlayer = false;
	[HideInInspector]
	public Vector3 distanceBetweenEVP;

	//Enemy_Status
	public float baseHP;
	public float baseAttack;
	public float baseRunSpeed;
	public float baseEXP;
	public float baseDropRate;
	public float baseAspd;
	
	[HideInInspector]
	public float hitPoint;
	[HideInInspector]
	public float Attack;
	[HideInInspector]
	public float EXP;
	[HideInInspector]
	public float dropRate;
	[HideInInspector]
	public float runSpeed;
	
	//Enemy Text Controller
	public List<int> wordLengthDifficulty = new List<int>();
	public List<int> wordLevelDifficulty = new List<int>();
	private int wordLength;
	private int wordDifficult;
	private Typing_Input textCheck;
	public TextMesh[] textTyping;
	private char[] charStorage;
	private int indexLocal = 0;
	private float distanceAttack;
	[HideInInspector]
	public bool takedDMG = false;

    public Game_Controller gameScript;
    public textManager textManagerScript;

	void Awake(){
		//Call Animator of Enemy
		enemy_Anim = GetComponent<Animator> ();
		//Call Script typing
		textCheck = (Typing_Input)FindObjectOfType (typeof(Typing_Input));
		//Calculate new Enemy Status
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
    }
	
	void FixedUpdate(){
		distanceBetweenEVP = player.InverseTransformPoint (transform.position);
//		Enemy_Movement (walk);
	}
	
	// Update is called once per frame
	void Update () {
        charStorage = textTyping [1].text.ToCharArray ();
		EnableTyping ();
		PushESC (Game_Controller.ESC);
	}
	
	
	void LateUpdate(){

        //takeDMG();
        
        if (textTyping[1].text.Equals(textTyping[0].text))
        {
            WordInstantiate(textManagerScript.sendText(wordLength, wordDifficult));
        }
        
            
	}
	
	
	//Check enemy walk
//	void OnTriggerEnter2D(Collider2D other){
////		if (other.gameObject.tag == "Enemy") {
////			if(Game_Controller.enemyStruckPlayer && walk){
////				enemy_Anim.SetBool ("Walk_Left", false);
////				enemy_Anim.SetBool ("Walk_Right", false);
////				enemy_Anim.SetBool ("Walk_Down", false);
////				enemy_Anim.SetBool ("Walk_Up", false);
////				walk = false;
////			}else if(Game_Controller.enemyStruckPlayer){
////
////			}
////		}
////		
////		if(other.gameObject.tag == "Arrow"){
////			HpDown(Game_Controller.playerInThisMap.Atk);
////		}
//	}
	
//	void OnTriggerStay2D(Collider2D other){
//		if (other.gameObject.tag == "Enemy") {
////			if(Game_Controller.enemyStruckPlayer && walk && struckPlayer){
////				enemy_Anim.SetBool ("Walk_Left", false);
////				enemy_Anim.SetBool ("Walk_Right", false);
////				enemy_Anim.SetBool ("Walk_Down", false);
////				enemy_Anim.SetBool ("Walk_Up", false);
////				walk = false;
////			}
////		}else 
//
//			if (Game_Controller.enemyStruckPlayer && walk && !struckPlayer) {
//				walk = true;
//			}
//		}
//		if(other.gameObject.tag == "Trap"){
//			HpDown(Skill_Controller.trapDmg);
//			Destroy(other.gameObject);
//		}
//	}
//	
//	void OnTriggerExit2D(Collider2D other){
//		if(other.gameObject.tag == "Enemy"){
//			walk = true;
//		}
//	}
//	
//	void OnCollisionEnter2D(Collision2D other){
//		if(other.gameObject.tag == "Player"){
//			enemy_Anim.SetBool ("Walk_Left", false);
//			enemy_Anim.SetBool ("Walk_Right", false);
//			enemy_Anim.SetBool ("Walk_Down", false);
//			enemy_Anim.SetBool ("Walk_Up", false);
//			walk = false;
//			Game_Controller.enemyStruckPlayer = true;
//			struckPlayer = true;
//		}
//	}
//
//	//Enemy Attack
//	void OnCollisionStay2D(Collision2D other){
//		if(other.gameObject.tag == "Player"){
//			enemy_Anim.SetBool ("Walk_Left", false);
//			enemy_Anim.SetBool ("Walk_Right", false);
//			enemy_Anim.SetBool ("Walk_Down", false);
//			enemy_Anim.SetBool ("Walk_Up", false);
//			walk = false;
//			Game_Controller.enemyStruckPlayer = true;
//			struckPlayer = true;
//			if(Time.time > nextAtk){
//				nextAtk = Time.time + baseAspd;
//				Game_Controller.playerInThisMap.EnemyAttacked(Attack);
//			}
//		}else if(other.gameObject.tag == "Enemy" && Game_Controller.enemyStruckPlayer && !struckPlayer){
//			Debug.Log("test");
//			enemy_Anim.SetBool ("Walk_Left", false);
//			enemy_Anim.SetBool ("Walk_Right", false);
//			enemy_Anim.SetBool ("Walk_Down", false);
//			enemy_Anim.SetBool ("Walk_Up", false);
//			walk = false;
//		}
//	}
//	
//	void OnCollisionExit2D(Collision2D other){
//		if(other.gameObject.tag == "Player"){
//			walk = true;
//			Game_Controller.enemyStruckPlayer = false;
//			struckPlayer = false;
//		}else if(other.gameObject.tag == "Enemy"){
//			walk = true;
//		}
//	}
	
//	Enemy Controller
//	void Enemy_Movement(bool walk){
//		
//		if(walk){
////			distanceBetweenEVP = player.InverseTransformPoint (transform.position);
//			
//			if(Mathf.Abs(distanceBetweenEVP.x) > Mathf.Abs(distanceBetweenEVP.y)){
//				if(distanceBetweenEVP.x > 0){
//					enemy_Anim.SetBool ("Walk_Left", true);
//					enemy_Anim.SetBool ("Walk_Right", false);
//					enemy_Anim.SetBool ("Walk_Down", false);
//					enemy_Anim.SetBool ("Walk_Up", false);
//					transform.position += (player.position - transform.position).normalized * runSpeed * Time.deltaTime;
//				}else{
//					enemy_Anim.SetBool ("Walk_Right", true);
//					enemy_Anim.SetBool ("Walk_Left", false);
//					enemy_Anim.SetBool ("Walk_Down", false);
//					enemy_Anim.SetBool ("Walk_Up", false);
//					transform.position += (player.position - transform.position).normalized * runSpeed * Time.deltaTime;
//				}
//			}else if(Mathf.Abs(distanceBetweenEVP.x) <= Mathf.Abs(distanceBetweenEVP.y)){
//				if(distanceBetweenEVP.y > 0){
//					enemy_Anim.SetBool ("Walk_Down", true);
//					enemy_Anim.SetBool ("Walk_Left", false);
//					enemy_Anim.SetBool ("Walk_Right", false);
//					enemy_Anim.SetBool ("Walk_Up", false);
//					transform.position += (player.position - transform.position).normalized * runSpeed * Time.deltaTime;
//				}else{
//					enemy_Anim.SetBool ("Walk_Up", true);
//					enemy_Anim.SetBool ("Walk_Left", false);
//					enemy_Anim.SetBool ("Walk_Right", false);
//					enemy_Anim.SetBool ("Walk_Down", false);
//					transform.position += (player.position - transform.position).normalized * runSpeed * Time.deltaTime;
//				}
//			}
//		}
//	}
	
	
	//Enemy Status
	void realStatus(int gameDifficult){
		hitPoint = baseHP * gameDifficult;
		Attack = baseAttack * gameDifficult;
		EXP = baseEXP * gameDifficult;
		dropRate = baseDropRate + (gameDifficult*2);
		runSpeed = baseRunSpeed;
	}
	
	public void HpDown(float dmg){
		hitPoint = hitPoint - dmg;
		if(hitPoint <= 0){
			Game_Controller.playerInThisMap.PlayerLVLUp(EXP);
			Debug.Log ("recieve = " + EXP);
            //การ Drop ไอเทมละ
            int dropchance = Random.Range(0, 100);
            if(dropchance<=dropRate)
            {
                int item = Random.Range(0, 20);
                Instantiate(gameScript.itemPrefab[item], this.transform.position, Quaternion.identity);

            }
			Game_Controller.enemyInThisMap.Remove(gameObject.GetComponent<Enemy>());
			Destroy(gameObject);
		}
        
        
		Debug.Log (gameObject.name + " = " +hitPoint);

        
    }

    /*
    public void takeDMG()
    {
        if (Game_Controller.indexGlobal == indexLocal)
        {
            if (textTyping[1].text.Equals(textTyping[0].text))
            {
                takedDMG = true;
            }
        }
        else
        {
            takedDMG = false;
        }
    }
    */
	
	
	//Enemy Text Controller
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

	//This method for change word when enemy taked dmg
    
	public void WordInstantiate(string word){
		if (Game_Controller.indexGlobal == indexLocal) {
			if (textTyping [1].text.Equals (textTyping [0].text)) {
                textManagerScript.returnText(textTyping[1].text, wordDifficult);
				takedDMG = true;
				textBeforeMonsterArrow = textTyping[1].text;
				textTypeMonsterArrow = textTyping[0].text;
				textTyping [0].text = "";
				textTyping [1].text = word;
				indexLocal = 0;
				Game_Controller.indexGlobal = 0;
			}
		} else {
			takedDMG = false;
		}
	}
    
    
	
	void calculateWord(int playerWordDifficulty){
		wordLength = wordLengthDifficulty [playerWordDifficulty];
		wordDifficult = wordLevelDifficulty [playerWordDifficulty];
	}
	
	public void EnableTyping(){
		distanceAttack = Vector2.Distance (gameObject.transform.position, player.position);
		if (distanceAttack < 1 && Game_Controller.playerInThisMap.isSword) {
			textTyping [1].color = Color.white;
		} else if (distanceAttack < 3 && !Game_Controller.playerInThisMap.isSword) {
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
