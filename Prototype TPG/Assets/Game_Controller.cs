using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Game_Controller : MonoBehaviour {

	public GameObject target;
	List<Vector3> playerStartPosition = new List<Vector3>();


	public static int indexGlobal = 0;
	public static bool wrongAll = true;
	public static int gameDifficult = 1;
	public static bool ESC = false;
	public static bool enemyStruckPlayer = false;
	public static List<Enemy> enemyInThisMap = new List<Enemy>();
	public static Player playerInThisMap;

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

    public List<GameObject> itemPrefab = new List<GameObject>();

	void Awake(){
		DontDestroyOnLoad(transform.gameObject);
		Instantiate (target, new Vector3(-7.0f,0.3f,0f),Quaternion.identity);
	}

	void Start(){
        conversation = GameObject.Find("Conversation");
        blackScene = GameObject.Find("BlackScene");
        displayGameObj = GameObject.Find("Display");
        NPCnameGameObj = GameObject.Find("Name");
        talkGameObj = GameObject.Find("Talk");
        continueButton = GameObject.Find("Continue");
        choice1 = GameObject.Find("Choice1");
        choice2 = GameObject.Find("Choice2");

        display = displayGameObj.GetComponent<Image>();
        NPCname = NPCnameGameObj.GetComponent<Text>();
        talk = talkGameObj.GetComponent<Text>();

        blackScene.SetActive(false);
        displayGameObj.SetActive(false);
        NPCnameGameObj.SetActive(false);
        talkGameObj.SetActive(false);
        continueButton.SetActive(false);
        choice1.SetActive(false);
        choice2.SetActive(false);
        conversation.SetActive(false);

		playerInThisMap = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		GameObject[] enemySpawn = GameObject.FindGameObjectsWithTag("Enemy");
		foreach(GameObject enemy in enemySpawn){
			enemyInThisMap.Add(enemy.GetComponent<Enemy>());
		}

        
    }
	

}
