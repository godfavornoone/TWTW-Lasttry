using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {

	public int set;

	public GameObject deadSprite;

	[HideInInspector]
	public Vector3 positionBorn;

	[HideInInspector]
	public bool struckPlayer = false;

	public Transform player;
	Animator enemy_Anim;
	Enemy enemyScript;

	public Text_Outline setStroke;

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
    public float maxhitPoint;
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
	[HideInInspector]
	public int wordLength;
	[HideInInspector]
	public int wordDifficult;
	private Typing_Input textCheck;
	[HideInInspector]
	public TextMesh[] textTyping;
	private char[] charStorage;
	private int indexLocal = 0;
	private float distanceAttack;
	[HideInInspector]
	public bool takedDMG = false;
    public bool optionWord = false;

    public Game_Controller gameScript;
    public textManager textManagerScript;

    public HPEnemy HPEnemyScript;

    void Awake(){
//		setStroke = GetComponent<Text_Outline> ();
		enemyScript = GetComponent<Enemy> ();
		//Call Animator of Enemy
		enemy_Anim = GetComponent<Animator> ();
		//Call Script typing
		textCheck = (Typing_Input)FindObjectOfType (typeof(Typing_Input));
		//Calculate new Enemy Status
		realStatus (Game_Controller.gameDiff);
        calculateWord(Game_Controller.wordDiff);
		textTyping = GetComponentsInChildren<TextMesh> ();
		positionBorn = gameObject.transform.position;
	}
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
        gameScript = GameObject.Find("Game_Controller").GetComponent<Game_Controller>();
        textManagerScript = GameObject.Find("TextManager").GetComponent<textManager>();
        textTyping[1].text = textManagerScript.sendText(wordLength,wordDifficult);
        HPEnemyScript = transform.GetChild(2).GetChild(0).GetComponent<HPEnemy>();
    }
	
	void FixedUpdate(){
		distanceBetweenEVP = player.InverseTransformPoint (transform.position);
//		Enemy_Movement (walk);
	}
	
	// Update is called once per frame
	void Update () {
        charStorage = textTyping [1].text.ToCharArray ();
		EnableTyping ();
//		if (textTyping[1].text.Equals(textTyping[0].text))
//		{
//			takedDMG = true;
//		}
//		if(Game_Controller.oneEnemyDie){
//			textTyping[0].text = "";
//			Game_Controller.oneEnemyDie = false;
//		}

		PushESC (Game_Controller.ESC);
	}
	
	
	void LateUpdate(){
        HPEnemyScript.updateenemyHP(hitPoint / maxhitPoint);
        //takeDMG();
        if (textTyping[1].text.Equals(textTyping[0].text))
        {
			takedDMG = true;
//			WordInstantiate();
        }
	}
	
	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.tag == "Enemy") {
			if (Game_Controller.enemyStruckPlayer && !struckPlayer && walk) {
				walk = true;
			}else if(!Game_Controller.enemyStruckPlayer && !walk){
				walk = true;
			}
		}
		if(other.gameObject.tag == "Trap"){
			HpDown(Skill_Controller.trapDmg);
			Destroy(other.gameObject);
		}
	}
	
	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.tag == "Enemy"){
			walk = true;
		}
	}
	
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player") {
			enemy_Anim.SetBool ("Walk_Left", false);
			enemy_Anim.SetBool ("Walk_Right", false);
			enemy_Anim.SetBool ("Walk_Down", false);
			enemy_Anim.SetBool ("Walk_Up", false);
			walk = false;
			Game_Controller.enemyStruckPlayer = true;
			struckPlayer = true;
		} else if(other.gameObject.tag == "Enemy"){
			walk = false;
		}
	}
	
	//Enemy Attack
	void OnCollisionStay2D(Collision2D other){
		if(other.gameObject.tag == "Player"){
			enemy_Anim.SetBool ("Walk_Left", false);
			enemy_Anim.SetBool ("Walk_Right", false);
			enemy_Anim.SetBool ("Walk_Down", false);
			enemy_Anim.SetBool ("Walk_Up", false);
			 walk = false;
			Game_Controller.enemyStruckPlayer = true;
			struckPlayer = true;
			if(Time.time > nextAtk){
				nextAtk = Time.time +  baseAspd;
				Game_Controller.playerInThisMap.EnemyAttacked( Attack);
			}
		}else if(other.gameObject.tag == "Enemy" && Game_Controller.enemyStruckPlayer && !struckPlayer){
			enemy_Anim.SetBool ("Walk_Left", false);
			enemy_Anim.SetBool ("Walk_Right", false);
			enemy_Anim.SetBool ("Walk_Down", false);
			enemy_Anim.SetBool ("Walk_Up", false);
			 walk = false;
		}else if(other.gameObject.tag == "Enemy" && !Game_Controller.enemyStruckPlayer && !struckPlayer){
			 walk = true;
		}
	}
	
	void OnCollisionExit2D(Collision2D other){
		if(other.gameObject.tag == "Player"){
			 walk = true;
			Game_Controller.enemyStruckPlayer = false;
			struckPlayer = false;
		}else if(other.gameObject.tag == "Enemy"){
			 walk = true;
		}
	}

	//Enemy Status
	void realStatus(int gameDifficult){
        maxhitPoint = baseHP * gameDifficult;
		hitPoint = baseHP * gameDifficult;
		Attack = baseAttack * gameDifficult;
		EXP = baseEXP * gameDifficult;
		dropRate = baseDropRate + (gameDifficult*2);
		runSpeed = baseRunSpeed;
	}
	
	public void HpDown(float dmg){
        
        hitPoint = hitPoint - dmg;

        if (!optionWord)
        {
            //Debug.Log("return Text complete" + " text is: " + textTyping[1].text);
            textManagerScript.returnText(textTyping[1].text, wordDifficult);
        }

        if (hitPoint <= 0){
			Game_Controller.enemyStruckPlayer = false;
//			Game_Controller.oneEnemyDie = true;
//			Game_Controller.oneEnemyWordChange = true;

			foreach(Enemy enemy in Game_Controller.enemyInThisMap){
				enemy.textTyping[0].text = "";
				enemy.indexLocal = 0;
			}
			foreach(Player_Skill skill in Skill_Controller.Allskill){
				skill.skillTextTyping[1].text = "";
				skill.localIndexSkill = 0;
			}

			walk = false;
			runSpeed = 0;

			Game_Controller.indexGlobal = 0;
			textTyping[0].text = "";
			textTyping[1].text = "";
            //Game_Controller.indexGlobal = 0;
            
			Game_Controller.playerInThisMap.PlayerLVLUp(EXP);
            
//			Debug.Log ("recieve = " + EXP);
            //การ Drop ไอเทมละ
            int dropchance = Random.Range(0, 100);
//            Debug.Log("dropChance is: " + dropchance);
//            Debug.Log("dropRate is: " + dropRate);
            if (dropchance<=dropRate)
            {
//                Debug.Log("YEEEEE");
                int item = Random.Range(0, 20);
                Instantiate(gameScript.itemPrefab[item], this.transform.position, Quaternion.identity);

            }
			Game_Controller.enemyInThisMap.Remove(gameObject.GetComponent<Enemy>());
			Game_Controller.enemyStruckPlayer = false;

            //Because even enemy die, they still ask for Text, so we have to return it!

            /*
            if(!optionWord)
            {
                //Debug.Log("in HPDown");
                //Debug.Log("return Text complete" + " text is: " + textTyping[1].text);
                textManagerScript.returnText(textTyping[1].text, wordDifficult);
            }
            */
//			Instantiate (deadSprite, transform.position, Quaternion.identity);
			Invoke("DelayDead", 0.1f);
			Invoke("DelayDestroyForEffect", 0.2f);


//			Destroy(gameObject);



            //Game_Controller.indexGlobal = 0; //Even Enemy Die The Word Will Pop Out...So If you can type...I Clear IndexGlobal Here!
		}
        
        
//		//Debug.Log (gameObject.name + " = " +hitPoint);

        
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
	void DelayDead(){
		Instantiate (deadSprite, transform.position, Quaternion.identity);
	}


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
	public void WordInstantiate(){
		if (Game_Controller.indexGlobal == indexLocal) {
			if (textTyping [1].text.Equals (textTyping [0].text)){

                indexLocal = 0;
                Game_Controller.indexGlobal = 0;

                Game_Controller.oneEnemyWordChange = true;
                

                if (optionWord) //start here if it false go ELSE
                {
//                    Debug.Log("no return text");
                    optionWord = false;
                }
                else
                {
//                    Debug.Log("return Text complete" + " text is: " + textTyping[1].text);
                    textManagerScript.returnText(textTyping[1].text, wordDifficult);
                }
                
//				takedDMG = true;
				textTyping [0].text = "";

                //Start with One Letter Option
                int chance;
                bool oneOptiononly = true;

                if (Game_Controller.playerInThisMap.currentBoot.hitpoint != 0 && oneOptiononly)
                {
                    if (Game_Controller.playerInThisMap.currentBoot.option[0] != 0)
                    {
                        chance = Random.Range(0, 100);
                        if (chance <= Game_Controller.playerInThisMap.currentBoot.optionChance[0])
                        {
//                            //Debug.Log("one Letter option from Boot");

                            char tmp = textTyping[1].text[0];
                            string tmp2;

//                            //Debug.Log("first char of last string is: " + tmp);

                            tmp2 = "" + tmp;


                            textTyping[1].text = tmp2;
                            optionWord = true;
                            oneOptiononly = false;
                            
                        }
                    }
                }

                if (Game_Controller.playerInThisMap.currentCloth.hitpoint != 0 && oneOptiononly)
                {
                    if (Game_Controller.playerInThisMap.currentCloth.option[0] != 0)
                    {
                        chance = Random.Range(0, 100);
                        if (chance <= Game_Controller.playerInThisMap.currentCloth.optionChance[0])
                        {
//                            //Debug.Log("one Letter option from cloth");

                            char tmp = textTyping[1].text[0];
                            string tmp2;

//                            //Debug.Log("first char of last string is: " + tmp);

                            tmp2 = "" + tmp;


                            textTyping[1].text = tmp2;

                            optionWord = true;
                            oneOptiononly = false;
                           
                        }
                    }
                }

                if (Game_Controller.playerInThisMap.currentSword.damage != 0 && oneOptiononly)
                {
                    if (Game_Controller.playerInThisMap.currentSword.option[0] != 0)
                    {
                        
                        chance = Random.Range(0, 100);
                        if (chance <= Game_Controller.playerInThisMap.currentSword.optionChance[0])
                        {
//                            //Debug.Log("one Letter option from sword");

                            char tmp = textTyping[1].text[0];
                            string tmp2;

//                            //Debug.Log("first char of last string is: " + tmp);

                            tmp2 = "" + tmp;


                            textTyping[1].text = tmp2;

                            optionWord = true;
                            oneOptiononly = false;
                            
                        }
                    }
                }

                if (Game_Controller.playerInThisMap.currentBow.damage != 0 && oneOptiononly)
                {
                    if(Game_Controller.playerInThisMap.currentBow.option[0] != 0)
                {
                        chance = Random.Range(0, 100);
                        if (chance <= Game_Controller.playerInThisMap.currentBow.optionChance[0])
                        {
//                            //Debug.Log("one Letter option from bow");

                            char tmp = textTyping[1].text[0];
                            string tmp2;

//                            //Debug.Log("first char of last string is: " + tmp);

                            tmp2 = "" + tmp;


                            textTyping[1].text = tmp2;

                            optionWord = true;
                            oneOptiononly = false;
                            
                        }
                    }
                }
                //END with one Letter Option
                //Start with sameLetter Option
                if(Game_Controller.playerInThisMap.currentBoot.hitpoint!=0 && oneOptiononly)
                {
                    if (Game_Controller.playerInThisMap.currentBoot.option[1] != 0)
                    {
                        chance = Random.Range(0, 100);
                        if (chance <= Game_Controller.playerInThisMap.currentBoot.optionChance[1])
                        {
//                            //Debug.Log("same Letter option from boot");

                            char tmp = textTyping[1].text[0];
                            string tmp2;
                            string tmp3 = "";

//                            //Debug.Log("first char of last string is: " + tmp);

                            tmp2 = "" + tmp;

//                            //Debug.Log("tmp2 before is: " + tmp2);

                            for(int i =0;i<textTyping[1].text.Length;i++)
                            {
                                tmp3 += tmp2;
                            }

//                            //Debug.Log("tmp2 after is: " + tmp2);

                            textTyping[1].text = tmp3;

                            optionWord = true;
                            oneOptiononly = false;

                        }
                    }
                }

                if(Game_Controller.playerInThisMap.currentCloth.hitpoint!=0&&oneOptiononly)
                {
                    if (Game_Controller.playerInThisMap.currentCloth.option[1] != 0)
                    {
                        chance = Random.Range(0, 100);
                        if (chance <= Game_Controller.playerInThisMap.currentCloth.optionChance[1])
                        {
//                            //Debug.Log("same Letter option from cloth");

                            char tmp = textTyping[1].text[0];
                            string tmp2;
                            string tmp3="";

//                            //Debug.Log("first char of last string is: " + tmp);

                            tmp2 = "" + tmp;

//                            //Debug.Log("tmp2 before is: " + tmp2);

                            for (int i = 0; i < textTyping[1].text.Length; i++)
                            {
                                tmp3 += tmp2;
                            }

                            //Debug.Log("tmp2 after is: " + tmp2);

                            textTyping[1].text = tmp3;

                            optionWord = true;
                            oneOptiononly = false;

                        }
                    }
                }

                if(Game_Controller.playerInThisMap.currentSword.damage!=0&&oneOptiononly)
                {
                    if (Game_Controller.playerInThisMap.currentSword.option[1] != 0)
                    {
                        chance = Random.Range(0, 100);
                        if (chance <= Game_Controller.playerInThisMap.currentSword.optionChance[1])
                        {


                            //Debug.Log("same Letter option from sword");

                            char tmp = textTyping[1].text[0];
                            string tmp2;
                            string tmp3 = "";

                            //Debug.Log("first char of last string is: " + tmp);

                            tmp2 = "" + tmp;

                            //Debug.Log("tmp2 before is: " + tmp2);

                            for (int i = 0; i < textTyping[1].text.Length; i++)
                            {
                                tmp3 += tmp2;
                            }

                            //Debug.Log("tmp2 after is: " + tmp2);

                            textTyping[1].text = tmp3;

                            optionWord = true;
                            oneOptiononly = false;

                        }
                    }
                }

                if(Game_Controller.playerInThisMap.currentBow.damage!=0&&oneOptiononly)
                {
                    if (Game_Controller.playerInThisMap.currentBow.option[1] != 0)
                    {
                        chance = Random.Range(0, 100);
                        if (chance <= Game_Controller.playerInThisMap.currentBow.optionChance[1])
                        {
                            //Debug.Log("same Letter option from bow");

                            char tmp = textTyping[1].text[0];
                            string tmp2;
                            string tmp3 = "";

                            //Debug.Log("first char of last string is: " + tmp);

                            tmp2 = "" + tmp;

                            //Debug.Log("tmp2 before is: " + tmp2);

                            for (int i = 0; i < textTyping[1].text.Length; i++)
                            {
                                tmp3 += tmp2;
                            }

                            //Debug.Log("tmp2 after is: " + tmp2);

                            textTyping[1].text = tmp3;

                            optionWord = true;
                            oneOptiononly = false;

                        }
                    }
                }
                //END of sameLetter Option
                //Start the SameWord Option
                if(Game_Controller.playerInThisMap.currentBoot.hitpoint!=0 && oneOptiononly)
                {
                    if (Game_Controller.playerInThisMap.currentBoot.option[2] != 0)
                    {
                        chance = Random.Range(0, 100);
                        if (chance <= Game_Controller.playerInThisMap.currentBoot.optionChance[2])
                        {
                            //Debug.Log("same word on boot");
                            optionWord = true;
                            oneOptiononly = false;

                        }
                    }
                }

                if(Game_Controller.playerInThisMap.currentCloth.hitpoint!=0&&oneOptiononly)
                {
                    if (Game_Controller.playerInThisMap.currentCloth.option[2] != 0)
                    {

                        chance = Random.Range(0, 100);
                        if (chance <= Game_Controller.playerInThisMap.currentCloth.optionChance[2])
                        {
                            //Debug.Log("same word on cloth");
                            optionWord = true;
                            oneOptiononly = false;

                        }
                    }
                }

                if(Game_Controller.playerInThisMap.currentSword.damage!=0&&oneOptiononly)
                {
                    if (Game_Controller.playerInThisMap.currentSword.option[2] != 0)
                    {
                        chance = Random.Range(0, 100);
                        if (chance <= Game_Controller.playerInThisMap.currentSword.optionChance[2])
                        {
                            //Debug.Log("same word on sword");
                            optionWord = true;
                            oneOptiononly = false;

                        }
                    }
                }
                
                if(Game_Controller.playerInThisMap.currentBow.damage!=0&&oneOptiononly)
                {
                    if (Game_Controller.playerInThisMap.currentBow.option[2] != 0)
                    {
                        chance = Random.Range(0, 100);
                        if (chance <= Game_Controller.playerInThisMap.currentBow.optionChance[2])
                        {
                            //Debug.Log("same word on bow");
                            optionWord = true;
                            oneOptiononly = false;

                        }
                    }
                }

                if(!optionWord)
                {
                    //Debug.Log("Give new Text not from Option");
                    textTyping[1].text = textManagerScript.sendText(wordLength, wordDifficult);

                }

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
		if (distanceAttack < 3 && Game_Controller.playerInThisMap.isSword) {
			textTyping [1].color = Color.white;
			if(!Game_Controller.enemySplash.Contains(enemyScript)){
				Game_Controller.enemySplash.Add(enemyScript);
			}
		} else if (distanceAttack < 6 && !Game_Controller.playerInThisMap.isSword) {
			textTyping [1].color = Color.white;
			Game_Controller.enemySplash.Clear();
		} else {
			textTyping [1].color = Color.grey;
			if(Game_Controller.enemySplash.Contains(enemyScript)){
				Game_Controller.enemySplash.Remove(enemyScript);
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

	public void DistanceToBorn(){
		float distance = Vector2.Distance (Game_Controller.playerInThisMap.transform.position, gameObject.transform.position);
		if(distance < 15){
			gameObject.SetActive(true);
		}
	}

	public void DisableInMinigame(){
		if (Game_Controller.playerInMinigame) {
			gameObject.SetActive (false);
		} else {
			gameObject.SetActive(true);
		}
	}

	void DelayDestroyForEffect(){
		if(Game_Controller.enemySplash.Contains(enemyScript)){
			Game_Controller.enemySplash.Remove(enemyScript);
		}
		gameObject.SetActive(false);
		gameObject.transform.position = positionBorn;
	}

}
