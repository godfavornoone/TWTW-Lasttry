using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Game_Controller : MonoBehaviour {

	public GameObject target;
	List<Vector3> playerStartPosition = new List<Vector3>();
	

//	public Text_Outline setStroke;
	public static int indexGlobal = 0;
	public static bool wrongAll = true;
	public static int gameDifficult = 1;
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
    public static string playerName = "Yaha";

    public List<GameObject> itemPrefab = new List<GameObject>();

    public static int world = 1;
    public static int gameDiff=2;
    public static int wordDiff = 0;

	void Awake(){
		DontDestroyOnLoad(transform.gameObject);
//		Instantiate (target, new Vector3(-7.0f,0.3f,0f),Quaternion.identity);
	}

	void Start(){
        SkillToolTip = GameObject.Find("SkillToolTip");
        SkillPanel = GameObject.Find("SkillPanel");
        detail = GameObject.Find("Detail").GetComponent<Text>();
        conversation = GameObject.Find("Conversation");
        blackScene = GameObject.Find("BlackScene");
        displayGameObj = GameObject.Find("Character");
        NPCnameGameObj = GameObject.Find("Title");
        talkGameObj = GameObject.Find("Talk");
        continueButton = GameObject.Find("Continue");
        choice1 = GameObject.Find("Choice1");
        choice2 = GameObject.Find("Choice2");

        display = displayGameObj.GetComponent<Image>();
        NPCname = NPCnameGameObj.transform.GetChild(0).GetComponent<Text>();
        talk = talkGameObj.GetComponent<Text>();
        choice1Text = choice1.transform.GetChild(0).GetComponent<Text>();
        choice2Text = choice2.transform.GetChild(0).GetComponent<Text>();

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

		playerInThisMap = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		GameObject[] enemySpawn = GameObject.FindGameObjectsWithTag("Enemy");
		foreach(GameObject enemy in enemySpawn){
			enemyInThisMap.Add(enemy.GetComponent<Enemy>());
		}

		foreach(GameObject enemy in enemySpawn){
			enemy.SetActive(false);
		}

    }
	
	void Update(){
		foreach(Enemy enemy in enemyInThisMap){
			if(enemy.set == 0){
				enemy.DistanceToBorn();	
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

}
