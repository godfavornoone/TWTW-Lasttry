using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Game_Controller : MonoBehaviour {

	public static float bowCri;

	public GameObject target;
	List<Vector3> playerStartPosition = new List<Vector3>();
	public static List<Treasure> treasureMinigame = new List<Treasure> ();
	public static List<GameObject> enemySpawnInMap = new List<GameObject> ();
	public static bool oneEnemyWordChange = false;
	public static bool chestWrongAll = true;
	public static bool playerInMinigame = false;

//	public Text_Outline setStroke;
	public static int indexGlobal = 0;
	public static bool wrongAll = true;
	public static bool ESC = false;
	public static bool enemyStruckPlayer = false;
	public static List<Enemy> enemyInThisMap = new List<Enemy>();
	public static Player playerInThisMap;
	public static string nowScene;

    //for story
    public static GameObject conversation;
    public static GameObject displayGameObj;
    public static GameObject NPCnameGameObj;
    public static GameObject talkGameObj;
    public static Image display;
    public static Text NPCname;
    public static Text talk;
    public static GameObject continueButton;
    public static GameObject blackScene;
    public static GameObject choice1;
    public static GameObject choice2;
    public static Text choice1Text;
    public static Text choice2Text;

    //for SkillPanel
    public static GameObject SkillPanel;
    public static GameObject SkillToolTip;


    public static Text detail;

    public Sprite playerFace;
    public static string playerName = "Fiana";

    public List<GameObject> itemPrefab = new List<GameObject>();

    public static int world = 1;
    public static int gameDiff=1;
    public static int wordDiff=0;

    public static GameObject LoadScene;
    public static bool checkInLoadText;
    public static LoadText loadSceneScript;

    //for Main menu
    public static GameObject mainMenu;
    public static GameObject changeDiffMenu;
    public static GameObject LoadSaveCloseButton;

    //for TypingProgress
    public static GameObject typingProgressMenu;

    public textManager a;

    public static GameObject ClearGameScene;
    public static GameObject clearButton;

    //all Detail of player
    public static GameObject playerStatus;
    public static GameObject weaponPanel;
    public static GameObject skillPanel;
    public static GameObject typingProgressButton;
    public static GameObject skillButton;
    public static GameObject inventoryButton;
    public static GameObject optionButton;
    public static GameObject objectivePanel;

    public static GameObject newGameButton;
    public static GameObject loadGameButton;
    public static GameObject exitGameButton;

    public static GameObject startPicture;

    //For All Script of Skill
    public static Skill_Fire skillFire;
    public static Skill_Ice skillIce;
    public static Skill_Slow skillSlow;
    public static Skill_Heal skillHeal;
    public static Skill_Knock skillKnock;
    public static Skill_Trap skillTrap;

    //For All Text in Main Menu
    public static Text characterLevel;
    public static Text characterWorld;
    public static Text characterStory;
    public static Text wordDifficultyChar;
    public static Text gameDifficultyChar;
    public static Text currentGameDifficulty;
    public static Text TypingProgressDetail;

    public static int tempGameDiff;

    public GameObject inventoryItem;
    public Inventory inv;
    public SwordPanel swordPanel;
    public BowPanel bowPanel;
    public ClothPanel clothPanel;
    public BootPanel bootPanel;
    

	void Awake(){
		DontDestroyOnLoad(transform.gameObject);
//		Instantiate (target, new Vector3(-7.0f,0.3f,0f),Quaternion.identity);
	}

	void Start(){
        swordPanel = GameObject.Find("SwordPanel").GetComponent<SwordPanel>();
        bowPanel = GameObject.Find("BowPanel").GetComponent<BowPanel>();
        clothPanel = GameObject.Find("ClothPanel").GetComponent<ClothPanel>();
        bootPanel = GameObject.Find("BootPanel").GetComponent<BootPanel>();
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        TypingProgressDetail = GameObject.Find("TypingProgressDetail").GetComponent<Text>();
        currentGameDifficulty = GameObject.Find("currentGameDifficulty").GetComponent<Text>();
        characterLevel = GameObject.Find("CharacterLevel").GetComponent<Text>();
        characterWorld = GameObject.Find("CharacterWorld").GetComponent<Text>();
        characterStory = GameObject.Find("CharacterStory").GetComponent<Text>();
        wordDifficultyChar = GameObject.Find("WordDifficultyChar").GetComponent<Text>();
        gameDifficultyChar = GameObject.Find("GameDifficultyChar").GetComponent<Text>();
        skillFire = GameObject.Find("FireSkillPanel").GetComponent<Skill_Fire>();
        skillIce = GameObject.Find("IceSkillPanel").GetComponent<Skill_Ice>();
        skillSlow = GameObject.Find("SlowSkillPanel").GetComponent<Skill_Slow>();
        skillHeal = GameObject.Find("HealSkillPanel").GetComponent<Skill_Heal>();
        skillKnock = GameObject.Find("KnockSkillPanel").GetComponent<Skill_Knock>();
        skillTrap = GameObject.Find("TrapSkillPanel").GetComponent<Skill_Trap>();

        startPicture = GameObject.Find("StartPicture");
        clearButton = GameObject.Find("ClearButton");
        playerStatus = GameObject.Find("PlayerStatus");
        weaponPanel = GameObject.Find("WeaponPanel");
        skillPanel = GameObject.Find("SkillUse");
        typingProgressButton = GameObject.Find("TypingProgressButton");
        skillButton = GameObject.Find("SkillButton");
        inventoryButton = GameObject.Find("InventoryButton");
        optionButton = GameObject.Find("Option");
        objectivePanel = GameObject.Find("QuestDetail");

        newGameButton = GameObject.Find("Start Game");
        loadGameButton = GameObject.Find("Load Game");
        exitGameButton = GameObject.Find("Exit");

        ClearGameScene = GameObject.Find("ClearGameScene");
        LoadSaveCloseButton = GameObject.Find("CloseOfLoadSave");
        a = GameObject.Find("TextManager").GetComponent<textManager>();
        typingProgressMenu = GameObject.Find("TypingProgressPanel");
        mainMenu = GameObject.Find("LoadSavePanel");
        changeDiffMenu = GameObject.Find("ChangeDifficultyMenu");
        LoadScene = GameObject.Find("LoadScene");
        loadSceneScript = LoadScene.transform.GetChild(0).GetComponent<Text>().GetComponent<LoadText>();
        //checkInLoadText = LoadScene.transform.GetChild(0).GetComponent<Text>().GetComponent<LoadText>().check;
        SkillToolTip = GameObject.Find("SkillToolTip");
        SkillPanel = GameObject.Find("SkillPanel");
        detail = GameObject.Find("Detail").GetComponent<Text>();
        conversation = GameObject.Find("Conversation");
        blackScene = GameObject.Find("BlackScene");
        displayGameObj = GameObject.Find("Character");
        NPCnameGameObj = GameObject.Find("NPCTitle");
        talkGameObj = GameObject.Find("Talk");
        continueButton = GameObject.Find("Continue");
        choice1 = GameObject.Find("Choice1");
        choice2 = GameObject.Find("Choice2");

        display = displayGameObj.GetComponent<Image>();
        NPCname = NPCnameGameObj.transform.GetChild(0).GetComponent<Text>();
        talk = talkGameObj.GetComponent<Text>();
        choice1Text = choice1.transform.GetChild(0).GetComponent<Text>();
        choice2Text = choice2.transform.GetChild(0).GetComponent<Text>();

        
        playerStatus.SetActive(false);
        weaponPanel.SetActive(false);
        skillPanel.SetActive(false);
        typingProgressButton.SetActive(false);
        skillButton.SetActive(false);
        inventoryButton.SetActive(false);
        objectivePanel.SetActive(false);

        clearButton.SetActive(false);
        ClearGameScene.SetActive(false);
        typingProgressMenu.SetActive(false);
        changeDiffMenu.SetActive(false);
        mainMenu.SetActive(false);
        blackScene.SetActive(false);
        displayGameObj.SetActive(false);
        NPCnameGameObj.SetActive(false);
        talkGameObj.SetActive(false);
        continueButton.SetActive(false);
        choice1.SetActive(false);
        choice2.SetActive(false);
        conversation.SetActive(false);
        SkillPanel.SetActive(false);
        SkillToolTip.SetActive(false);
        LoadScene.SetActive(false);

		playerInThisMap = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		GameObject[] enemySpawn = GameObject.FindGameObjectsWithTag("Enemy");
		GameObject[] treasureInMap = GameObject.FindGameObjectsWithTag("Treasure");

		foreach(GameObject enemy in enemySpawn){
			enemyInThisMap.Add(enemy.GetComponent<Enemy>());
		}

		foreach(GameObject enemy in enemySpawn){
			enemy.SetActive(false);
		}


        playerInThisMap.gameObject.SetActive(false);

		foreach (GameObject chest in treasureInMap) {

			treasureMinigame.Add (chest.GetComponent<Treasure>());
		}

    }
	
	void Update(){
		foreach(Enemy enemy in enemyInThisMap){
			if(enemy.set == 0 && !playerInMinigame){
				enemy.DistanceToBorn();	
			}else if(playerInMinigame){
				enemy.DisableInMinigame();
			}
		}

	}

    public void SkillOpen()
    {
        blackScene.SetActive(true);
        SkillPanel.SetActive(true);
    }

    public void SkillClose()
    {
        blackScene.SetActive(false);
        SkillPanel.SetActive(false);
    }

    public void TypingProgressOpen()
    {
        //แล้วถ้ากดตั้งแต่ยังไม่มีข้อมูลอ่ะ =3= แบบยังมะได้ Save เลยยยยย
        int index = SaveData.Load("indexOfHistoryTyping",1,true);
        TypingProgressDetail.text = "";
        int temp = index;

        for (int i = 0; i < index; i++)
        {
            string key = "WPM" + i;
            string key2 = "Weakness" + i;

            int WPM = SaveData.Load(key, 1,true);
            string Weakness = SaveData.Load(key2, "yaha",true);
            char[] characters = Weakness.ToCharArray();

            //เริ่มที่ ช่อง 0 หรอ ของใหม่อยู่ช่องท้ายสุดอ่ะ
            
            TypingProgressDetail.text = temp + ". WPM is: " + WPM + " Weaknesses are: " +characters[0] + ", " + characters[1] + ", "+ characters[2] + "\n" +TypingProgressDetail.text;
            temp--;
        }

        typingProgressMenu.SetActive(true);
        blackScene.SetActive(true);

    }

    public void TypingProgressClose()
    {
        typingProgressMenu.SetActive(false);
        blackScene.SetActive(false);

    }

    public void mainMenuOpen()
    {/*
            public static Text characterLevel;
    public static Text characterWorld;
    public static Text characterStory;
    public static Text wordDifficultyChar;
    public static Text gameDifficultyChar;
    */
     /*
         SaveData.Save("currentLevel", Game_Controller.playerInThisMap.lvl);
         SaveData.Save("currentScene", "Town");
         SaveData.Save("currentGameDifficulty", (Game_Controller.gameDiff + 1));
         SaveData.Save("currentWordDifficulty", a.computeWordDiff(WPM));
         SaveData.Save("currentParallelWorld", 1);
 */
        //Debug.Log("ของพี่เค้า " + SaveData.Load("currentLevel", 1.5f, true));

        characterLevel.text = "Lv. " + SaveData.Load("currentLevel", 1.5f, true).ToString();
        
        if(PlayerPrefs.GetInt("currentParallelWorld")==0)
        {
            characterWorld.text = "\"Alpha\"";
        }
        else if (PlayerPrefs.GetInt("currentParallelWorld") == 1)
        {
            characterWorld.text = "\"Beta\"";
        }

        characterStory.text = "\"" + PlayerPrefs.GetString("currentScene") + "\"";

        //me 0-4 WORD DIFF
        if(SaveData.Load("currentWordDifficulty", 1, true) == 0)
        {
            wordDifficultyChar.text = "\"Newbie\"";
        }
        else if(SaveData.Load("currentWordDifficulty", 1, true) == 1)
        {
            wordDifficultyChar.text = "\"Beginner\"";
        }
        else if (SaveData.Load("currentWordDifficulty", 1, true) == 2)
        {
            wordDifficultyChar.text = "\"Advanced\"";
        }
        else if (SaveData.Load("currentWordDifficulty", 1, true) == 3)
        {
            wordDifficultyChar.text = "\"Master\"";
        }
        else if (SaveData.Load("currentWordDifficulty", 1, true) == 4)
        {
            wordDifficultyChar.text = "\"Expert\"";
        }

        //GameDiff
        if (SaveData.Load("maxGameDifficulty", 1, true) == 1)
        {
            gameDifficultyChar.text = "\"Normal\"";
            currentGameDifficulty.text = "\"Normal\"";
            tempGameDiff = 1;
        }
        else if (SaveData.Load("maxGameDifficulty", 1, true) == 2)
        {
            gameDifficultyChar.text = "\"Hard\"";
            currentGameDifficulty.text = "\"Hard\"";
            tempGameDiff = 2;
        }
        else if (SaveData.Load("maxGameDifficulty", 1, true) == 3)
        {
            gameDifficultyChar.text = "\"Very Hard\"";
            currentGameDifficulty.text = "\"Very Hard\"";
            tempGameDiff = 3;
        }
        else if (SaveData.Load("maxGameDifficulty", 1, true) == 4)
        {
            gameDifficultyChar.text = "\"Insane\"";
            currentGameDifficulty.text = "\"Insane\"";
            tempGameDiff = 4;
        }
        else if (SaveData.Load("maxGameDifficulty", 1, true) == 5)
        {
            gameDifficultyChar.text = "\"Nightmare\"";
            currentGameDifficulty.text = "\"Nightmare\"";
            tempGameDiff = 5;
        }
        else
        {
            int woohoo = SaveData.Load("maxGameDifficulty", 1, true) - 5;
            gameDifficultyChar.text = "\"Nightmare+" + woohoo.ToString() + "\"";
            currentGameDifficulty.text = "\"Nightmare+" + woohoo.ToString() + "\"";
            tempGameDiff = SaveData.Load("maxGameDifficulty", 1, true);
        }

        //ได้เวลาโหลดค่ากันแล้ววววววว หรือไม่ดี -..- ไว้โหลดตอนกด Resume เลยเหรอ =3= ดังนั้น....เอ่อ งั้นก็....แค่โชว์ผลป้ะ 555

        mainMenu.SetActive(true);
        blackScene.SetActive(true);
    }

    public void increaseButton()
    {
        int limit = SaveData.Load("maxGameDifficulty", 1, true); //อันนี้ล่ะ max ของเค้าแน่!!!

        if(tempGameDiff < limit)
        {
            tempGameDiff++;

            if (tempGameDiff == 1)
            {
                gameDifficultyChar.text = "\"Normal\"";
                currentGameDifficulty.text = "\"Normal\"";
            }
            else if (tempGameDiff == 2)
            {
                gameDifficultyChar.text = "\"Hard\"";
                currentGameDifficulty.text = "\"Hard\"";
            }
            else if (tempGameDiff == 3)
            {
                gameDifficultyChar.text = "\"Very Hard\"";
                currentGameDifficulty.text = "\"Very Hard\"";
            }
            else if (tempGameDiff == 4)
            {
                gameDifficultyChar.text = "\"Insane\"";
                currentGameDifficulty.text = "\"Insane\"";
            }
            else if (tempGameDiff == 5)
            {
                gameDifficultyChar.text = "\"Nightmare\"";
                currentGameDifficulty.text = "\"Nightmare\"";
            }
            else
            {
                int woohoo = tempGameDiff - 5;
                gameDifficultyChar.text = "\"Nightmare+" + woohoo.ToString() + "\"";
                currentGameDifficulty.text = "\"Nightmare+" + woohoo.ToString() + "\"";
            }
        }
    }

    public void decreaseButton()
    {
        if(tempGameDiff>1)
        {
            tempGameDiff--;

            if (tempGameDiff == 1)
            {
                gameDifficultyChar.text = "\"Normal\"";
                currentGameDifficulty.text = "\"Normal\"";
            }
            else if (tempGameDiff == 2)
            {
                gameDifficultyChar.text = "\"Hard\"";
                currentGameDifficulty.text = "\"Hard\"";
            }
            else if (tempGameDiff == 3)
            {
                gameDifficultyChar.text = "\"Very Hard\"";
                currentGameDifficulty.text = "\"Very Hard\"";
            }
            else if (tempGameDiff == 4)
            {
                gameDifficultyChar.text = "\"Insane\"";
                currentGameDifficulty.text = "\"Insane\"";
            }
            else if (tempGameDiff == 5)
            {
                gameDifficultyChar.text = "\"Nightmare\"";
                currentGameDifficulty.text = "\"Nightmare\"";
            }
            else
            {
                int woohoo = tempGameDiff - 5;
                gameDifficultyChar.text = "\"Nightmare+" + woohoo.ToString() + "\"";
                currentGameDifficulty.text = "\"Nightmare+" + woohoo.ToString() + "\"";
            }
        }
    }

    public void mainMenuClose()
    {
        mainMenu.SetActive(false);
        blackScene.SetActive(false);
    }

    public void changeDiffOpen()
    {
        changeDiffMenu.SetActive(true);
        blackScene.SetActive(true);
        LoadSaveCloseButton.SetActive(false);
    }

    public void changeDiffClose()
    {
        changeDiffMenu.SetActive(false);
        blackScene.SetActive(false);
        LoadSaveCloseButton.SetActive(true);
    }

    public void resumeButtonPressed()
    {
        resumeGame();
    }

    public void resumeGame()
    {
        Game_Controller.mainMenu.SetActive(false);
        Game_Controller.blackScene.SetActive(false);
        Game_Controller.LoadScene.SetActive(true);
        //playerInThisMap.gameObject.transform.position = new Vector3(-1827f, -1542f, 0f);

        gameDiff = tempGameDiff;
        wordDiff = SaveData.Load("currentWordDifficulty", 1, true);

        string Weaknesses = SaveData.Load("top3Weakness", "yaha",true);
        char[] characters = Weaknesses.ToCharArray();
        a.chartop1 = ""+characters[0];
        a.chartop2 = "" + characters[1];
        a.chartop3 = "" + characters[2];
        a.getVocab(a.vocab, a.ingameVocabEasy, a.checkVocabEasy);
        a.getVocab(a.vocabHard, a.ingameVocabHard, a.checkVocabHard);
        a.chartop1 = "";
        a.chartop2 = "";
        a.chartop3 = "";

        int index = SaveData.Load("indexOfHistoryTyping",1,true);

        for (int i = 0; i < index; i++)
        {
            string key = "WPM" + i;
            string key2 = "Weakness" + i;

            playerInThisMap.historyWPM.Add(SaveData.Load(key, 1, true));
            playerInThisMap.historyWeaknesses.Add(SaveData.Load(key2, "yaha", true));
        }

        playerInThisMap.lvl = SaveData.Load("currentLevel", 1.5f, true);
        playerInThisMap.lvlup = SaveData.Load("EXPLeft", 1.5f, true);
        playerInThisMap.MaxHP = SaveData.Load("maxHP", 1.5f, true);
        playerInThisMap.MaxSP = SaveData.Load("maxSP", 1.5f, true);
        playerInThisMap.HP = SaveData.Load("currentHP", 1.5f, true);
        playerInThisMap.SP = SaveData.Load("currentSP", 1.5f, true);
        playerInThisMap.skillPoint = SaveData.Load("currentSkillPoint", 1, true);
        playerInThisMap.BowAtk = SaveData.Load("BowAtk", 1.5f, true);
        playerInThisMap.SwordAtk = SaveData.Load("SwordAtk", 1.5f, true);
        playerInThisMap.baseHP = SaveData.Load("baseHP", 1.5f, true);
        playerInThisMap.baseSP = SaveData.Load("baseSP", 1.5f, true);
        playerInThisMap.baseAtk = SaveData.Load("baseAtk", 1.5f, true);

        skillTrap.trapLVL =SaveData.Load("trapLVL", 1,true);
        skillTrap.trapMana =SaveData.Load("trapMana", 1.5f,true);
        Skill_Controller.trapDmg =SaveData.Load("trapDMG", 1.5f, true);

        skillKnock.knockLVL=SaveData.Load("knockLVL", 1, true);
        skillKnock.coolDownSkillKnock=SaveData.Load("cooldownSkillKnock", 1.5f, true);
        skillKnock.knockMana=SaveData.Load("KnockMana", 1.5f, true);

        skillHeal.healLVL=SaveData.Load("HealLVL", 1, true);
        skillHeal.healDMG=SaveData.Load("HealDMG", 1.5f, true);
        skillHeal.healMana=SaveData.Load("HealMana", 1.5f, true);

        skillSlow.slowLVL=SaveData.Load("SlowLVL", 1, true);
        skillSlow.nowSlowTime=SaveData.Load("nowSlowTime", 1.5f, true);
        skillSlow.slowMana=SaveData.Load("SlowMana", 1.5f, true);

        skillIce.iceLVL=SaveData.Load("IceLVL", 1, true);
        skillIce.nowIceTime=SaveData.Load("nowIceTime", 1.5f, true);
        skillIce.iceMana=SaveData.Load("IceMana", 1.5f, true);

        skillFire.fireLVL=SaveData.Load("FireLVL", 1, true);
        skillFire.fireDMG=SaveData.Load("fireDMG", 1.5f, true);
        skillFire.fireMana=SaveData.Load("fireMana", 1.5f, true);

        world = SaveData.Load("currentParallelWorld", 1, true);
        nowScene = SaveData.Load("currentScene", "yaha", true);

        //มันต้องไปใส่ให้จริงๆไง -...- คราวนี้มันจะแยกเป็น 2 เคส ตอน NEW ใหม่เลย กับ คนที่เล่นจบรอบแรกแล้วกลับมา Load Game (เกมไม่ล้าง ของจะยังอยู่)
        if(SaveData.Load("HasSword",true,true)) //จะเข้าทำเมื่อเป็น true
        {
            if(inv.currentSword.transform.childCount!=0)
            {
                Debug.Log("TONG ME NEE");
                Destroy(inv.currentSword.transform.GetChild(0).gameObject);
            }
            List<int> option = new List<int>();
            option.Add(SaveData.Load("SwordOption1", 1, true));
            option.Add(SaveData.Load("SwordOption2", 1, true));
            option.Add(SaveData.Load("SwordOption3", 1, true));
            option.Add(SaveData.Load("SwordOption4", 1, true));
            List<int> optionChance = new List<int>();
            optionChance.Add(SaveData.Load("SwordOption1Chance", 1, true));
            optionChance.Add(SaveData.Load("SwordOption2Chance", 1, true));
            optionChance.Add(SaveData.Load("SwordOption3Chance", 1, true));
            optionChance.Add(SaveData.Load("SwordOption4Chance", 1, true));
            Item itemToAdd = new Item(SaveData.Load("SwordDamage",1,true),Resources.Load<Sprite>(SaveData.Load("SwordImage","yaha",true)),SaveData.Load("SwordType","yaha", true),SaveData.Load("SwordTitle","yaha",true),option,optionChance,SaveData.Load("SwordHitpoint",1, true));
            GameObject itemObj = Instantiate(inventoryItem);
            itemObj.GetComponent<ItemData>().item = itemToAdd; 
            itemObj.GetComponent<ItemData>().slot = 1001;
            itemObj.GetComponent<Image>().sprite = Resources.Load<Sprite>(SaveData.Load("SwordImage", "yaha", true));
            itemObj.transform.SetParent(inv.currentSword.transform);
            itemObj.transform.position = inv.currentSword.transform.position;
            inv.itemSword = itemToAdd;
            playerInThisMap.currentSword = itemToAdd;
            swordPanel.isInside = true;
        }
        if (SaveData.Load("HasBow", true, true)) //จะเข้าทำเมื่อเป็น true
        {
            if (inv.currentBow.transform.childCount != 0)
            {
                Debug.Log("TONG ME NEE");
                Destroy(inv.currentBow.transform.GetChild(0).gameObject);
            }
            List<int> option = new List<int>();
            option.Add(SaveData.Load("BowOption1", 1, true));
            option.Add(SaveData.Load("BowOption2", 1, true));
            option.Add(SaveData.Load("BowOption3", 1, true));
            option.Add(SaveData.Load("BowOption4", 1, true));
            List<int> optionChance = new List<int>();
            optionChance.Add(SaveData.Load("BowOption1Chance", 1, true));
            optionChance.Add(SaveData.Load("BowOption2Chance", 1, true));
            optionChance.Add(SaveData.Load("BowOption3Chance", 1, true));
            optionChance.Add(SaveData.Load("BowOption4Chance", 1, true));
            Item itemToAdd = new Item(SaveData.Load("BowDamage", 1, true), Resources.Load<Sprite>(SaveData.Load("BowImage", "yaha", true)), SaveData.Load("BowType", "yaha", true), SaveData.Load("BowTitle", "yaha", true), option, optionChance, SaveData.Load("BowHitpoint", 1, true));
            GameObject itemObj = Instantiate(inventoryItem);
            itemObj.GetComponent<ItemData>().item = itemToAdd;
            itemObj.GetComponent<ItemData>().slot = 1000;
            itemObj.GetComponent<Image>().sprite = Resources.Load<Sprite>(SaveData.Load("BowImage", "yaha", true));
            itemObj.transform.SetParent(inv.currentBow.transform);
            itemObj.transform.position = inv.currentBow.transform.position;
            inv.itemBow = itemToAdd;
            playerInThisMap.currentBow = itemToAdd;
            bowPanel.isInside = true;

        }
        if (SaveData.Load("HasCloth", true, true)) //จะเข้าทำเมื่อเป็น true
        {
            if (inv.currentCloth.transform.childCount != 0)
            {
                Debug.Log("TONG ME NEE");
                Destroy(inv.currentCloth.transform.GetChild(0).gameObject);
            }
            List<int> option = new List<int>();
            option.Add(SaveData.Load("ClothOption1", 1, true));
            option.Add(SaveData.Load("ClothOption2", 1, true));
            option.Add(SaveData.Load("ClothOption3", 1, true));
            option.Add(SaveData.Load("ClothOption4", 1, true));
            List<int> optionChance = new List<int>();
            optionChance.Add(SaveData.Load("ClothOption1Chance", 1, true));
            optionChance.Add(SaveData.Load("ClothOption2Chance", 1, true));
            optionChance.Add(SaveData.Load("ClothOption3Chance", 1, true));
            optionChance.Add(SaveData.Load("ClothOption4Chance", 1, true));
            Item itemToAdd = new Item(SaveData.Load("ClothDamage", 1, true), Resources.Load<Sprite>(SaveData.Load("ClothImage", "yaha", true)), SaveData.Load("ClothType", "yaha", true), SaveData.Load("ClothTitle", "yaha", true), option, optionChance, SaveData.Load("ClothHitpoint", 1, true));
            GameObject itemObj = Instantiate(inventoryItem);
            itemObj.GetComponent<ItemData>().item = itemToAdd;
            itemObj.GetComponent<ItemData>().slot = 1003;
            itemObj.GetComponent<Image>().sprite = Resources.Load<Sprite>(SaveData.Load("ClothImage", "yaha", true));
            itemObj.transform.SetParent(inv.currentCloth.transform);
            itemObj.transform.position = inv.currentCloth.transform.position;
            inv.itemCloth = itemToAdd;
            playerInThisMap.currentCloth = itemToAdd;
            clothPanel.isInside = true;

        }
        if (SaveData.Load("HasBoot", true, true)) //จะเข้าทำเมื่อเป็น true
        {
            if (inv.currentBoot.transform.childCount != 0)
            {
                Debug.Log("TONG ME NEE");
                Destroy(inv.currentBoot.transform.GetChild(0).gameObject);
            }
            List<int> option = new List<int>();
            option.Add(SaveData.Load("BootOption1", 1, true));
            option.Add(SaveData.Load("BootdOption2", 1, true));
            option.Add(SaveData.Load("BootOption3", 1, true));
            option.Add(SaveData.Load("BootOption4", 1, true));
            List<int> optionChance = new List<int>();
            optionChance.Add(SaveData.Load("BootOption1Chance", 1, true));
            optionChance.Add(SaveData.Load("BootOption2Chance", 1, true));
            optionChance.Add(SaveData.Load("BootOption3Chance", 1, true));
            optionChance.Add(SaveData.Load("BootOption4Chance", 1, true));
            Item itemToAdd = new Item(SaveData.Load("BootDamage", 1, true), Resources.Load<Sprite>(SaveData.Load("BootImage", "yaha", true)), SaveData.Load("BootType", "yaha", true), SaveData.Load("BootTitle", "yaha", true), option, optionChance, SaveData.Load("BootHitpoint", 1, true));
            GameObject itemObj = Instantiate(inventoryItem);
            itemObj.GetComponent<ItemData>().item = itemToAdd;
            itemObj.GetComponent<ItemData>().slot = 1002;
            itemObj.GetComponent<Image>().sprite = Resources.Load<Sprite>(SaveData.Load("BootImage", "yaha", true));
            itemObj.transform.SetParent(inv.currentBoot.transform);
            itemObj.transform.position = inv.currentBoot.transform.position;
            inv.itemBoot = itemToAdd;
            playerInThisMap.currentBoot = itemToAdd;
            bootPanel.isInside = true;

        }

        for(int i = 0; i < inv.slotAmount;i++)
        {
            string key = "Slot" + i;

            if(PlayerPrefs.HasKey(key + "Image"))
            {
                if(inv.slots[i].transform.childCount!=0)
                {
                    Debug.Log("Tong me nee");
                    Destroy(inv.slots[i].transform.GetChild(0).gameObject);
                }
                inv.checkSlot[i] = 0;
                List<int> option = new List<int>();
                option.Add(SaveData.Load(key + "Option1", 1, true));
                option.Add(SaveData.Load(key + "Option2", 1, true));
                option.Add(SaveData.Load(key + "Option3", 1, true));
                option.Add(SaveData.Load(key + "Option4", 1, true));
                List<int> optionChance = new List<int>();
                optionChance.Add(SaveData.Load(key + "Option1Chance", 1, true));
                optionChance.Add(SaveData.Load(key + "Option2Chance", 1, true));
                optionChance.Add(SaveData.Load(key + "Option3Chance", 1, true));
                optionChance.Add(SaveData.Load(key + "Option4Chance", 1, true));
                Item itemToAdd = new Item(SaveData.Load(key+"Damage", 1, true), Resources.Load<Sprite>(SaveData.Load(key+"Image", "yaha", true)), SaveData.Load(key+"Type", "yaha", true), SaveData.Load(key+"Title", "yaha", true), option, optionChance, SaveData.Load(key+"Hitpoint", 1, true));
                inv.items[i] = itemToAdd;
                GameObject itemObj = Instantiate(inventoryItem);
                itemObj.GetComponent<ItemData>().item = itemToAdd; //เหมือนเก็บใน Script ด้วยจ้า
                itemObj.GetComponent<ItemData>().slot = i;
                itemObj.GetComponent<Image>().sprite = Resources.Load<Sprite>(SaveData.Load(key + "Image", "yaha", true));
                itemObj.transform.SetParent(inv.slots[i].transform); //item ก็จะเป็นลูกของ Slot ไงจ้ะ
                itemObj.transform.GetComponent<RectTransform>().localPosition = new Vector2(0, 0);
            }
        }

        playerInThisMap.gameObject.SetActive(true);

        playerStatus.SetActive(true);
        weaponPanel.SetActive(true);
        skillPanel.SetActive(true);
        typingProgressButton.SetActive(true);
        skillButton.SetActive(true);
        inventoryButton.SetActive(true);
        objectivePanel.SetActive(true);

        startPicture.SetActive(false);
        newGameButton.SetActive(false);
        loadGameButton.SetActive(false);
        exitGameButton.SetActive(false);


        Application.LoadLevel(nowScene); 
    }

    

}
