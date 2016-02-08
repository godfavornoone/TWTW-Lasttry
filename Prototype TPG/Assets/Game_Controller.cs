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

    public List<GameObject> itemPrefab = new List<GameObject>();

	void Awake(){
		DontDestroyOnLoad(transform.gameObject);
		Instantiate (target, new Vector3(-7.0f,0.3f,0f),Quaternion.identity);
	}

	void Start(){
		playerInThisMap = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		GameObject[] enemySpawn = GameObject.FindGameObjectsWithTag("Enemy");
		foreach(GameObject enemy in enemySpawn){
			enemyInThisMap.Add(enemy.GetComponent<Enemy>());
		}

        //ใส่ Prefab ของ Item
        /*
        itemPrefab.Add(GameObject.Find("sword1"));
        itemPrefab.Add(GameObject.Find("sword2"));
        itemPrefab.Add(GameObject.Find("sword3"));
        itemPrefab.Add(GameObject.Find("sword4"));
        itemPrefab.Add(GameObject.Find("sword5"));

        itemPrefab.Add(GameObject.Find("bow1"));
        itemPrefab.Add(GameObject.Find("bow2"));
        itemPrefab.Add(GameObject.Find("bow3"));
        itemPrefab.Add(GameObject.Find("bow4"));
        itemPrefab.Add(GameObject.Find("bow5"));

        itemPrefab.Add(GameObject.Find("cloth1"));
        itemPrefab.Add(GameObject.Find("cloth2"));
        itemPrefab.Add(GameObject.Find("cloth3"));
        itemPrefab.Add(GameObject.Find("cloth4"));
        itemPrefab.Add(GameObject.Find("cloth5"));

        itemPrefab.Add(GameObject.Find("boot1"));
        itemPrefab.Add(GameObject.Find("boot2"));
        itemPrefab.Add(GameObject.Find("boot3"));
        itemPrefab.Add(GameObject.Find("boot4"));
        itemPrefab.Add(GameObject.Find("boot5"));
        */
    }
	

}
