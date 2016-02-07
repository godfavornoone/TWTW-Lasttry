using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {

	//Enemy Controller
	Transform player;
	Animator enemy_Anim;
	[HideInInspector]
	public Vector3 distanceBetweenEVP;
//	private Enemy_Status spd;
	private bool walk = true;
	private bool struckPlayer = false;
	private float nextAtk = 0f;

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

	//Enemy Text Controller
	public List<int> wordLengthDifficulty = new List<int>();
	public List<int> wordLevelDifficulty = new List<int>();
	private int wordLength;
	private int wordDifficult;
	private Typing_Input textCheck;
	private TextMesh[] textTyping;
	private char[] charStorage;
	private int indexLocal = 0;
	private float distanceAttack;
	[HideInInspector]
	public bool takedDMG = false;

	void Awake(){
		//Call Animator of Enemy
		enemy_Anim = GetComponent<Animator> ();
		//Call Script typing
		textCheck = (Typing_Input)FindObjectOfType (typeof(Typing_Input));
		//Calculate new Enemy Status
		realStatus (2);
		textTyping = GetComponentsInChildren<TextMesh> ();
	}

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void FixedUpdate(){
		Enemy_Movement (walk);
	}

	// Update is called once per frame
	void Update () {
		charStorage = textTyping [1].text.ToCharArray ();
		EnableTyping ();
		PushESC (Game_Controller.ESC);
	}


	void LateUpdate(){
		WordInstantiate("baezy");
	}


	//Check enemy walk
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Enemy") {
			if(struckPlayer && !walk){
				enemy_Anim.SetBool ("Walk_Left", false);
				enemy_Anim.SetBool ("Walk_Right", false);
				enemy_Anim.SetBool ("Walk_Down", false);
				enemy_Anim.SetBool ("Walk_Up", false);
				walk = false;
			}
		}
		
		if(other.gameObject.tag == "Arrow"){
			HpDown(Game_Controller.playerInThisMap.Atk);
		}
	}
	
	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.tag == "Enemy") {
			if(struckPlayer && !walk){
				enemy_Anim.SetBool ("Walk_Left", false);
				enemy_Anim.SetBool ("Walk_Right", false);
				enemy_Anim.SetBool ("Walk_Down", false);
				enemy_Anim.SetBool ("Walk_Up", false);
				walk = false;
			}
		}
	}
	
	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.tag == "Enemy"){
			walk = true;
		}
	}
	
	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Player"){
			enemy_Anim.SetBool ("Walk_Left", false);
			enemy_Anim.SetBool ("Walk_Right", false);
			enemy_Anim.SetBool ("Walk_Down", false);
			enemy_Anim.SetBool ("Walk_Up", false);
			walk = false;
			struckPlayer = true;
		}
	}

	//Enemy Attack
	void OnCollisionStay2D(Collision2D other){
		if(other.gameObject.tag == "Player"){
			if(Time.time > nextAtk){
				nextAtk = Time.time + baseAspd;
				Game_Controller.playerInThisMap.EnemyAttacked(Attack);
			}
		}
	}
	
	void OnCollisionExit2D(Collision2D other){
		if(other.gameObject.tag == "Player"){
			walk = true;
			struckPlayer = false;
		}
	}

	//Enemy Controller
	void Enemy_Movement(bool walk){
		
		if(walk){
			distanceBetweenEVP = player.InverseTransformPoint (transform.position);
			
			if(Mathf.Abs(distanceBetweenEVP.x) > Mathf.Abs(distanceBetweenEVP.y)){
				if(distanceBetweenEVP.x > 0){
					enemy_Anim.SetBool ("Walk_Left", true);
					enemy_Anim.SetBool ("Walk_Right", false);
					enemy_Anim.SetBool ("Walk_Down", false);
					enemy_Anim.SetBool ("Walk_Up", false);
					transform.position += (player.position - transform.position).normalized * baseRunSpeed * Time.deltaTime;
				}else{
					enemy_Anim.SetBool ("Walk_Right", true);
					enemy_Anim.SetBool ("Walk_Left", false);
					enemy_Anim.SetBool ("Walk_Down", false);
					enemy_Anim.SetBool ("Walk_Up", false);
					
					transform.position += (player.position - transform.position).normalized * baseRunSpeed * Time.deltaTime;
				}
			}else if(Mathf.Abs(distanceBetweenEVP.x) < Mathf.Abs(distanceBetweenEVP.y)){
				if(distanceBetweenEVP.y > 0){
					enemy_Anim.SetBool ("Walk_Down", true);
					enemy_Anim.SetBool ("Walk_Left", false);
					enemy_Anim.SetBool ("Walk_Right", false);
					enemy_Anim.SetBool ("Walk_Up", false);
					transform.position += (player.position - transform.position).normalized * baseRunSpeed * Time.deltaTime;
				}else{
					enemy_Anim.SetBool ("Walk_Up", true);
					enemy_Anim.SetBool ("Walk_Left", false);
					enemy_Anim.SetBool ("Walk_Right", false);
					enemy_Anim.SetBool ("Walk_Down", false);
					transform.position += (player.position - transform.position).normalized * baseRunSpeed * Time.deltaTime;
				}
			}
		}
	}
	

	//Enemy Status
	void realStatus(int gameDifficult){
		hitPoint = baseHP * gameDifficult;
		Attack = baseAttack * gameDifficult;
		EXP = baseEXP * gameDifficult;
		dropRate = baseDropRate * gameDifficult * 0.8f;
	}
	
	public void HpDown(float dmg){
		hitPoint = hitPoint - dmg;
		if(hitPoint <= 0){
			Game_Controller.playerInThisMap.PlayerLVLUp(EXP);
			Debug.Log ("recieve = " + EXP);
			Game_Controller.enemyInThisMap.Remove(gameObject.GetComponent<Enemy>());
			Destroy(gameObject);
		}
		Debug.Log (gameObject.name + " = " +hitPoint);
	}


	//Enemy Controller
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
