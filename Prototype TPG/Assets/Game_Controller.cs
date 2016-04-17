using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Game_Controller : MonoBehaviour {

	public static float bowCri;

	public GameObject target;
	List<Vector3> playerStartPosition = new List<Vector3>();
	public static List<Treasure> treasureMinigame = new List<Treasure> ();
	public static List<QnTChoice> QuizNTypeMinigame = new List<QnTChoice> ();
	public static List<GameObject> enemySpawnInMap = new List<GameObject> ();
	public static List<Enemy> enemySplash = new List<Enemy> ();
	public static List<PRG_ST> ParagraphMinigame = new List<PRG_ST> ();
	public static bool oneEnemyWordChange = false;
	public static bool chestWrongAll = true;
	public static bool QnTWrongAll = true;
	public static bool QnTMiniGame = false;
	public static bool PRGWrongAll = true;
	public static bool PRGMiniGame = false;
	public static bool playerInMinigame = false;
	public static bool oneEnemyDie = false;
	public static GameObject cameraFirst;

//	public Text_Outline setStroke;
	public static int indexGlobal = 0;
	public static bool wrongAll = true;
	public static bool ESC = false;
	public static bool enemyStruckPlayer = false;
	public static List<Enemy> enemyInThisMap = new List<Enemy>();
	public static Player playerInThisMap;
	public static string nowScene="";

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

    public static textManager a;

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

    public static GameObject OptionPanel;
    public static GameObject CreditPanel;
    public static GameObject DisclaimerPanel;

    public static GameObject noData;

    public GameObject damageOutput;
    public GameObject criticalOutput;

    public static Game_Controller gameController;
    public static GameObject levelUp;
    public static GameObject inventoryFull;
    public static GameObject fireNoti;
    public static GameObject iceNoti;
    public static GameObject slowNoti;
    public static GameObject knockNoti;
    public static GameObject healNoti;
    public static GameObject trapNoti;
    public static GameObject sameLetterNoti;
    public static GameObject sameWordNoti;
    public static GameObject oneLetterNoti;

    public static NotiController levelUpScript;
    public static NotiController inventoryFullScript;
    public static NotiController fireNotiScript;
    public static NotiController iceNotiScript;
    public static NotiController slowNotiScript;
    public static NotiController knockNotiScript;
    public static NotiController healNotiScript;
    public static NotiController trapNotiScript;
    public static NotiController sameLetterNotiScript;
    public static NotiController sameWordNotiScript;
    public static NotiController oneLetterNotiScript;

    void Awake(){
		DontDestroyOnLoad(transform.gameObject);
//		Instantiate (target, new Vector3(-7.0f,0.3f,0f),Quaternion.identity);
	}

	void Start(){
        levelUp = GameObject.Find("levelUp");
        inventoryFull = GameObject.Find("inventoryFull");
        fireNoti = GameObject.Find("fireNoti");
        iceNoti = GameObject.Find("iceNoti");
        slowNoti = GameObject.Find("slowNoti");
        knockNoti = GameObject.Find("knockNoti");
        healNoti = GameObject.Find("healNoti");
        trapNoti = GameObject.Find("trapNoti");
        sameLetterNoti = GameObject.Find("sameLetterNoti");
        sameWordNoti = GameObject.Find("sameWordNoti");
        oneLetterNoti = GameObject.Find("oneLetterNoti");

        levelUpScript = levelUp.GetComponent<NotiController>();
        inventoryFullScript = inventoryFull.GetComponent<NotiController>();
        fireNotiScript = fireNoti.GetComponent<NotiController>();
        iceNotiScript = iceNoti.GetComponent<NotiController>();
        slowNotiScript = slowNoti.GetComponent<NotiController>();
        knockNotiScript = knockNoti.GetComponent<NotiController>();
        healNotiScript = healNoti.GetComponent<NotiController>();
        trapNotiScript = trapNoti.GetComponent<NotiController>();
        sameLetterNotiScript = sameLetterNoti.GetComponent<NotiController>();
        sameWordNotiScript = sameWordNoti.GetComponent<NotiController>();
        oneLetterNotiScript = oneLetterNoti.GetComponent<NotiController>();

        gameController = GameObject.Find("Game_Controller").GetComponent<Game_Controller>();
        noData = GameObject.Find("Nodata");
        OptionPanel = GameObject.Find("OptionPanel");
        CreditPanel = GameObject.Find("CreditPanel");
        DisclaimerPanel = GameObject.Find("DisclaimerPanel");
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

        levelUp.SetActive(false);
        inventoryFull.SetActive(false);
        fireNoti.SetActive(false);
        iceNoti.SetActive(false);
        slowNoti.SetActive(false);
        knockNoti.SetActive(false);
        healNoti.SetActive(false);
        trapNoti.SetActive(false);
        sameLetterNoti.SetActive(false);
        sameWordNoti.SetActive(false);
        oneLetterNoti.SetActive(false);

        noData.SetActive(false);
        OptionPanel.SetActive(false);
        DisclaimerPanel.SetActive(false);
        CreditPanel.SetActive(false);
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
		if (!nowScene.Equals ("Town")) {
			foreach(Enemy enemy in enemyInThisMap){
				if(enemy.set == 0 && !playerInMinigame && !QnTMiniGame){
					enemy.DistanceToBorn();	
				}else if(playerInMinigame || QnTMiniGame){
					enemy.DisableInMinigame();
				}
			}
		}
//		foreach(Enemy enemy in enemySplash){
//			Debug.Log(enemy.name);
//		}
	}

    public void noDataClose()
    {
        noData.SetActive(false);
        blackScene.SetActive(false);
    }

    public void SkillOpen()
    {
        Time.timeScale = 0;
        blackScene.SetActive(true);
        SkillPanel.SetActive(true);
    }

    public void SkillClose()
    {
        Time.timeScale = 1;
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
            string key3 = "AverageTime" + i;

            int WPM = SaveData.Load(key, 1,true);
            Debug.Log(key + WPM);
            string Weakness = SaveData.Load(key2, "yaha",true);
            Debug.Log(key2 + Weakness);
            char[] characters = Weakness.ToCharArray();
            string Average = SaveData.Load(key3, "yaha", true);
            string[] parts = Average.Split('-');

            //เริ่มที่ ช่อง 0 หรอ ของใหม่อยู่ช่องท้ายสุดอ่ะ

            TypingProgressDetail.text = temp + ". WPM is: " + WPM + " Weaknesses are:" +"\n" + "Letter " + characters[0] + " average time: " + parts[0] + "\n" + "Letter " + characters[1] + " average time: " + parts[1] + "\n" + "Letter " + characters[2] + " average time: " + parts[2] + "\n" +TypingProgressDetail.text;
            Debug.Log(TypingProgressDetail.text);
            temp--;
        }

       
        Time.timeScale = 0;
        typingProgressMenu.SetActive(true);
        blackScene.SetActive(true);

    }

    public void TypingProgressClose()
    {
        Time.timeScale = 1;
        typingProgressMenu.SetActive(false);
        blackScene.SetActive(false);

    }

    public void optionOpen()
    {
        Time.timeScale = 0;
        OptionPanel.SetActive(true);
        blackScene.SetActive(true);

    }

    public void optionClose()
    {
        Time.timeScale = 1;
        OptionPanel.SetActive(false);
        blackScene.SetActive(false);

    }

    public void creditOpen()
    {
        Time.timeScale = 0;
        CreditPanel.SetActive(true);

    }

    public void creditClose()
    {
        Time.timeScale = 1;
        CreditPanel.SetActive(false);

    }

    public void disclaimerOpen()
    {
        Time.timeScale = 0;
        DisclaimerPanel.SetActive(true);

    }

    public void disclaimerClose()
    {

        Time.timeScale = 1;
        DisclaimerPanel.SetActive(false);
    }

    public void pressExitGame()
    {
        //ถ้าผู้เล่นพึ่ง Start Game แล้ว Exit เลย ? จะเปนยังไงอ่ะ

        //ตรงนี้น่ากลัวอยู่
        //ตอนแรกสุดอ่ะ มันจะมีแต่ Letter ปัญหาทั้ง 3 นะ ดังนั้นถ

        //Analysis แมพสุดท้ายอ่ะจ้ะ...
        a.Analysis();
        string b = a.computeWeakness();
        string c = a.computeAverageTimeOfWeakness();
        int WPM = a.computeWPM();

        if(b.Length<3)
        {
            b = "abc";
        }

        //อย่าลืมไปใส่อีกที่ แต่นั่นไม่น่าเกิด เพราะน่าจะตายรัวๆอ่ะ -....-
        if(WPM!=0)
        {
            Game_Controller.playerInThisMap.historyWeaknesses.Add(b);
            Game_Controller.playerInThisMap.historyWPM.Add(WPM);
            Game_Controller.playerInThisMap.historyAverageTime.Add(c);
        }
        
        
        //เอาไอ่บ้านี้ไว้ดึงศัพท์นะ...
        SaveData.Save("top3Weakness", b);

        //ดาบ

        //ก็ถ้ามันไม่มีดาบ มันก็จะไม่มีชื่อ =3=
        //มีตัวแปรชื่อ haveCurrentSword ไรงี้มะ ถ้าไม่มี ก็ไม่ต้องยุ่งอะไรกับ Key ของ Sword ตรงนี้ทั้งหมด
        //ถ้ามีค่อยยุ่งไรงี้ ??
        if (Game_Controller.playerInThisMap.currentSword.damage != 0)
        {
            SaveData.Save("HasSword", true);
            SaveData.Save("SwordImage", Game_Controller.playerInThisMap.currentSword.image.name);
            SaveData.Save("SwordDamage", Game_Controller.playerInThisMap.currentSword.damage);
            SaveData.Save("SwordType", Game_Controller.playerInThisMap.currentSword.type);
            SaveData.Save("SwordTitle", Game_Controller.playerInThisMap.currentSword.title);
            SaveData.Save("SwordHitpoint", Game_Controller.playerInThisMap.currentSword.hitpoint);
            SaveData.Save("SwordOption1", Game_Controller.playerInThisMap.currentSword.option[0]);
            SaveData.Save("SwordOption2", Game_Controller.playerInThisMap.currentSword.option[1]);
            SaveData.Save("SwordOption3", Game_Controller.playerInThisMap.currentSword.option[2]);
            SaveData.Save("SwordOption4", Game_Controller.playerInThisMap.currentSword.option[3]);
            SaveData.Save("SwordOption1Chance", Game_Controller.playerInThisMap.currentSword.optionChance[0]);
            SaveData.Save("SwordOption2Chance", Game_Controller.playerInThisMap.currentSword.optionChance[1]);
            SaveData.Save("SwordOption3Chance", Game_Controller.playerInThisMap.currentSword.optionChance[2]);
            SaveData.Save("SwordOption4Chance", Game_Controller.playerInThisMap.currentSword.optionChance[3]);
        }
        else
        {
            SaveData.Save("HasSword", false);
        }

        if (Game_Controller.playerInThisMap.currentBow.damage != 0)
        {
            SaveData.Save("HasBow", true);
            //ธนู
            SaveData.Save("BowImage", Game_Controller.playerInThisMap.currentBow.image.name);
            SaveData.Save("BowDamage", Game_Controller.playerInThisMap.currentBow.damage);
            SaveData.Save("BowType", Game_Controller.playerInThisMap.currentBow.type);
            SaveData.Save("BowTitle", Game_Controller.playerInThisMap.currentBow.title);
            SaveData.Save("BowHitpoint", Game_Controller.playerInThisMap.currentBow.hitpoint);
            SaveData.Save("BowOption1", Game_Controller.playerInThisMap.currentBow.option[0]);
            SaveData.Save("BowOption2", Game_Controller.playerInThisMap.currentBow.option[1]);
            SaveData.Save("BowOption3", Game_Controller.playerInThisMap.currentBow.option[2]);
            SaveData.Save("BowOption4", Game_Controller.playerInThisMap.currentBow.option[3]);
            SaveData.Save("BowOption1Chance", Game_Controller.playerInThisMap.currentBow.optionChance[0]);
            SaveData.Save("BowOption2Chance", Game_Controller.playerInThisMap.currentBow.optionChance[1]);
            SaveData.Save("BowOption3Chance", Game_Controller.playerInThisMap.currentBow.optionChance[2]);
            SaveData.Save("BowOption4Chance", Game_Controller.playerInThisMap.currentBow.optionChance[3]);
        }
        else
        {
            SaveData.Save("HasBow", false);
        }

        if (Game_Controller.playerInThisMap.currentCloth.hitpoint != 0)
        {
            SaveData.Save("HasCloth", true);
            //เสื้อ
            SaveData.Save("ClothImage", Game_Controller.playerInThisMap.currentCloth.image.name);
            SaveData.Save("ClothDamage", Game_Controller.playerInThisMap.currentCloth.damage);
            SaveData.Save("ClothType", Game_Controller.playerInThisMap.currentCloth.type);
            SaveData.Save("ClothTitle", Game_Controller.playerInThisMap.currentCloth.title);
            SaveData.Save("ClothHitpoint", Game_Controller.playerInThisMap.currentCloth.hitpoint);
            SaveData.Save("ClothOption1", Game_Controller.playerInThisMap.currentCloth.option[0]);
            SaveData.Save("ClothOption2", Game_Controller.playerInThisMap.currentCloth.option[1]);
            SaveData.Save("ClothOption3", Game_Controller.playerInThisMap.currentCloth.option[2]);
            SaveData.Save("ClothOption4", Game_Controller.playerInThisMap.currentCloth.option[3]);
            SaveData.Save("ClothOption1Chance", Game_Controller.playerInThisMap.currentCloth.optionChance[0]);
            SaveData.Save("ClothOption2Chance", Game_Controller.playerInThisMap.currentCloth.optionChance[1]);
            SaveData.Save("ClothOption3Chance", Game_Controller.playerInThisMap.currentCloth.optionChance[2]);
            SaveData.Save("ClothOption4Chance", Game_Controller.playerInThisMap.currentCloth.optionChance[3]);
        }
        else
        {
            SaveData.Save("HasCloth", false);
        }

        if (Game_Controller.playerInThisMap.currentBoot.hitpoint != 0)
        {
            SaveData.Save("HasBoot", true);
            //รองเท้า
            SaveData.Save("BootImage", Game_Controller.playerInThisMap.currentBoot.image.name);
            SaveData.Save("BootDamage", Game_Controller.playerInThisMap.currentBoot.damage);
            SaveData.Save("BootType", Game_Controller.playerInThisMap.currentBoot.type);
            SaveData.Save("BootTitle", Game_Controller.playerInThisMap.currentBoot.title);
            SaveData.Save("BootHitpoint", Game_Controller.playerInThisMap.currentBoot.hitpoint);
            SaveData.Save("BootOption1", Game_Controller.playerInThisMap.currentBoot.option[0]);
            SaveData.Save("BootOption2", Game_Controller.playerInThisMap.currentBoot.option[1]);
            SaveData.Save("BootOption3", Game_Controller.playerInThisMap.currentBoot.option[2]);
            SaveData.Save("BootOption4", Game_Controller.playerInThisMap.currentBoot.option[3]);
            SaveData.Save("BootOption1Chance", Game_Controller.playerInThisMap.currentBoot.optionChance[0]);
            SaveData.Save("BootOption2Chance", Game_Controller.playerInThisMap.currentBoot.optionChance[1]);
            SaveData.Save("BootOption3Chance", Game_Controller.playerInThisMap.currentBoot.optionChance[2]);
            SaveData.Save("BootOption4Chance", Game_Controller.playerInThisMap.currentBoot.optionChance[3]);

        }
        else
        {
            SaveData.Save("HasBoot", false);
        }




        //ถ้าไม่มีของในช่องนั้นต้องลบ Key นั้นออกไปด้วยอ่ะ....ไม่งั้นนะ มันจะวุ่นมั้ง
        for (int i = 0; i < inv.slotAmount; i++)
        {
            string key = "Slot" + i;

            if (inv.checkSlot[i] != -1) //เอาช่องที่ไม่ว่าง ช่องนี้มีของนะจ้ะ
            {
                SaveData.Save(key + "Image", inv.slots[i].transform.GetChild(0).GetComponent<ItemData>().item.image.name);
                SaveData.Save(key + "Damage", inv.slots[i].transform.GetChild(0).GetComponent<ItemData>().item.damage);
                SaveData.Save(key + "Type", inv.slots[i].transform.GetChild(0).GetComponent<ItemData>().item.type);
                SaveData.Save(key + "Title", inv.slots[i].transform.GetChild(0).GetComponent<ItemData>().item.title);
                SaveData.Save(key + "Hitpoint", inv.slots[i].transform.GetChild(0).GetComponent<ItemData>().item.hitpoint);
                SaveData.Save(key + "Option1", inv.slots[i].transform.GetChild(0).GetComponent<ItemData>().item.option[0]);
                SaveData.Save(key + "Option2", inv.slots[i].transform.GetChild(0).GetComponent<ItemData>().item.option[1]);
                SaveData.Save(key + "Option3", inv.slots[i].transform.GetChild(0).GetComponent<ItemData>().item.option[2]);
                SaveData.Save(key + "Option4", inv.slots[i].transform.GetChild(0).GetComponent<ItemData>().item.option[3]);
                SaveData.Save(key + "Option1Chance", inv.slots[i].transform.GetChild(0).GetComponent<ItemData>().item.optionChance[0]);
                SaveData.Save(key + "Option2Chance", inv.slots[i].transform.GetChild(0).GetComponent<ItemData>().item.optionChance[1]);
                SaveData.Save(key + "Option3Chance", inv.slots[i].transform.GetChild(0).GetComponent<ItemData>().item.optionChance[2]);
                SaveData.Save(key + "Option4Chance", inv.slots[i].transform.GetChild(0).GetComponent<ItemData>().item.optionChance[3]);
            }
            else
            {
                PlayerPrefs.DeleteKey(key + "Image");
                PlayerPrefs.DeleteKey(key + "Damage");
                PlayerPrefs.DeleteKey(key + "Type");
                PlayerPrefs.DeleteKey(key + "Title");
                PlayerPrefs.DeleteKey(key + "Hitpoint");
                PlayerPrefs.DeleteKey(key + "Option1");
                PlayerPrefs.DeleteKey(key + "Option2");
                PlayerPrefs.DeleteKey(key + "Option3");
                PlayerPrefs.DeleteKey(key + "Option4");
                PlayerPrefs.DeleteKey(key + "Option1Chance");
                PlayerPrefs.DeleteKey(key + "Option2Chance");
                PlayerPrefs.DeleteKey(key + "Option3Chance");
                PlayerPrefs.DeleteKey(key + "Option4Chance");
            }
        }

        //สมมติว่า 5 เงี้ย มันก็จะวิ่งตั้งแต่ 0 - 4 นะ
        SaveData.Save("indexOfHistoryTyping", Game_Controller.playerInThisMap.historyWeaknesses.Count);

        for (int i = 0; i < Game_Controller.playerInThisMap.historyWeaknesses.Count; i++)
        {
            string key = "WPM" + i;
            string key2 = "Weakness" + i;
            string key3 = "AverageTime" + i;

            SaveData.Save(key, Game_Controller.playerInThisMap.historyWPM[i]);
            SaveData.Save(key2, Game_Controller.playerInThisMap.historyWeaknesses[i]);
            SaveData.Save(key3, Game_Controller.playerInThisMap.historyAverageTime[i]);
        }

        SaveData.Save("currentLevel", Game_Controller.playerInThisMap.lvl);
        SaveData.Save("EXPLeft", Game_Controller.playerInThisMap.lvlup);
        SaveData.Save("maxHP", Game_Controller.playerInThisMap.MaxHP);
        SaveData.Save("maxSP", Game_Controller.playerInThisMap.MaxSP);
        SaveData.Save("currentHP", Game_Controller.playerInThisMap.HP);
        SaveData.Save("currentSP", Game_Controller.playerInThisMap.SP);
        SaveData.Save("currentSpeed", Game_Controller.playerInThisMap.speed);
        SaveData.Save("currentSkillPoint", Game_Controller.playerInThisMap.skillPoint);
        SaveData.Save("BowAtk", Game_Controller.playerInThisMap.BowAtk);
        SaveData.Save("SwordAtk", Game_Controller.playerInThisMap.SwordAtk);

        //สกิลละ
        SaveData.Save("trapLVL", Game_Controller.skillTrap.trapLVL);
        SaveData.Save("trapMana", Game_Controller.skillTrap.trapMana);
        SaveData.Save("trapDMG", Skill_Controller.trapDmg);

        SaveData.Save("knockLVL", Game_Controller.skillKnock.knockLVL);
        SaveData.Save("cooldownSkillKnock", Game_Controller.skillKnock.coolDownSkillKnock);
        SaveData.Save("KnockMana", Game_Controller.skillKnock.knockMana);

        SaveData.Save("HealLVL", Game_Controller.skillHeal.healLVL);
        SaveData.Save("HealDMG", Game_Controller.skillHeal.healDMG);
        SaveData.Save("HealMana", Game_Controller.skillHeal.healMana);

        SaveData.Save("SlowLVL", Game_Controller.skillSlow.slowLVL);
        SaveData.Save("nowSlowTime", Game_Controller.skillSlow.nowSlowTime);
        SaveData.Save("SlowMana", Game_Controller.skillSlow.slowMana);

        SaveData.Save("IceLVL", Game_Controller.skillIce.iceLVL);
        SaveData.Save("nowIceTime", Game_Controller.skillIce.nowIceTime);
        SaveData.Save("IceMana", Game_Controller.skillIce.iceMana);

        SaveData.Save("FireLVL", Game_Controller.skillFire.fireLVL);
        SaveData.Save("fireDMG", Game_Controller.skillFire.fireDMG);
        SaveData.Save("fireMana", Game_Controller.skillFire.fireMana);


        //แถวๆนี้โคตรน่าระวัง เพราะนี่คือการเคลียเกมนะ gameDiff มันเลยจะ +1 ตลอดอ่ะ
        if (!PlayerPrefs.HasKey("maxGameDifficulty"))
        {
            SaveData.Save("maxGameDifficulty", 1);
        }

        SaveData.Save("currentWordDifficulty", a.computeWordDiff(WPM));

        //ถ้าตอนจบอ่ะจะสลับโลกคู่ขนานให้ละกัน ซึ่งถ้าไม่ใช่เคลีย ต้องไม่ใช่แบบนี้อ่ะ
        SaveData.Save("currentParallelWorld", Game_Controller.world);


        //ไอ่บ้านี่อ่ะมันจะ FIX ให้ไปที่ Town นะ
        //ถ้าปกติก็ควรจะ Game_Controller.nowScene
        ////Debug.Log("YAHA PEN NGI: " + string.IsNullOrEmpty(Game_Controller.nowScene));

        if(string.IsNullOrEmpty(Game_Controller.nowScene))
        {
            Game_Controller.nowScene = "StartField";
        }

        SaveData.Save("currentScene", Game_Controller.nowScene);
        //ล้างข้อมูล Quest อันนี้น่าจะต้องทำทุกอันนะ 55555555555+
        Game_Controller.detail.text = "";


        Application.Quit();
    }

    public void deleteAll()
    {
        Debug.Log("Delete Already");
        PlayerPrefs.DeleteAll();
    }

    public void mainMenuOpen()
    {
        if(!PlayerPrefs.HasKey("currentParallelWorld"))
        {
            Debug.Log("Not here");
            noData.SetActive(true);
            blackScene.SetActive(true);
        }
        else
        {
            characterLevel.text = "Lv. " + SaveData.Load("currentLevel", 1.5f, true).ToString();

            Debug.Log("Current level Before is: " + SaveData.Load("currentLevel", 1.5f, true));

            if (PlayerPrefs.GetInt("currentParallelWorld") == 0)
            {
                characterWorld.text = "\"Alpha\"";
            }
            else if (PlayerPrefs.GetInt("currentParallelWorld") == 1)
            {
                characterWorld.text = "\"Beta\"";
            }

            characterStory.text = "\"" + PlayerPrefs.GetString("currentScene") + "\"";

            //me 0-4 WORD DIFF
            if (SaveData.Load("currentWordDifficulty", 1, true) == 0)
            {
                wordDifficultyChar.text = "\"Newbie\"";
            }
            else if (SaveData.Load("currentWordDifficulty", 1, true) == 1)
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

        playerInThisMap.historyWPM.Clear();
        playerInThisMap.historyWeaknesses.Clear();
        playerInThisMap.historyAverageTime.Clear();

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
            string key3 = "AverageTime" + i;

            playerInThisMap.historyWPM.Add(SaveData.Load(key, 1, true));
            playerInThisMap.historyWeaknesses.Add(SaveData.Load(key2, "yaha", true));
            playerInThisMap.historyAverageTime.Add(SaveData.Load(key3, "yaha", true));
        }

        //characterLevel.text = "Lv. " + SaveData.Load("currentLevel", 1.5f, true).ToString();

        Debug.Log("Current level After is: " + SaveData.Load("currentLevel", 1.5f, true));

        playerInThisMap.lvl = SaveData.Load("currentLevel", 1.5f, true);

        Debug.Log("Fuck Level is: " + playerInThisMap.lvl);

        Debug.Log("Current level After2 is: " + SaveData.Load("currentLevel", 1.5f, true));
        playerInThisMap.lvlup = SaveData.Load("EXPLeft", 1.5f, true);
        playerInThisMap.MaxHP = SaveData.Load("maxHP", 1.5f, true);
        playerInThisMap.MaxSP = SaveData.Load("maxSP", 1.5f, true);
        playerInThisMap.HP = SaveData.Load("currentHP", 1.5f, true);
        playerInThisMap.SP = SaveData.Load("currentSP", 1.5f, true);
        playerInThisMap.skillPoint = SaveData.Load("currentSkillPoint", 1, true);
        playerInThisMap.speed = SaveData.Load("currentSpeed", 1.5f, true);
        playerInThisMap.BowAtk = SaveData.Load("BowAtk", 1.5f, true);
        playerInThisMap.SwordAtk = SaveData.Load("SwordAtk", 1.5f, true);

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
