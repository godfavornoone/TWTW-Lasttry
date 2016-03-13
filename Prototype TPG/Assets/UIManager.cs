using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	public GameObject target;
	public Transform startPosition;


    string sName;

	void Awake(){
		DontDestroyOnLoad(transform.gameObject);

    }

	public void switchScene(string sceneName){ //This is for Start Game Button

        Game_Controller.LoadScene.SetActive(true);

        Game_Controller.playerInThisMap.gameObject.SetActive(true);
        //When It is all Start player's status is here !!!!
        Game_Controller.playerInThisMap.realStatus();

        Game_Controller.playerStatus.SetActive(true);
        Game_Controller.weaponPanel.SetActive(true);
        Game_Controller.skillPanel.SetActive(true);
        Game_Controller.typingProgressButton.SetActive(true);
        Game_Controller.skillButton.SetActive(true);
        Game_Controller.inventoryButton.SetActive(true);
        Game_Controller.objectivePanel.SetActive(true);

        Game_Controller.startPicture.SetActive(false);
        Game_Controller.newGameButton.SetActive(false);
        Game_Controller.loadGameButton.SetActive(false);
        Game_Controller.exitGameButton.SetActive(false);

        Application.LoadLevel(sceneName);
	}

	void OnLevelWasLoaded(int level)
	{
		//Debug.Log ("OnLevel work");

        //Debug.Log("hey");

        if (level == 1){

            Game_Controller.LoadScene.SetActive(false);
            NPCManager.npcInThisMap = GameObject.Find("NPC").GetComponent<NPCstory>();
			Game_Controller.cameraFirst = GameObject.Find("Main Camera");
            Transform player = GameObject.FindGameObjectWithTag("Player").transform;
            player.position = new Vector3(32.4f, -19.6f, 0f);
			GameObject[] enemySpawn = GameObject.FindGameObjectsWithTag("Enemy");
			Game_Controller.enemyInThisMap.Clear ();
			Game_Controller.enemySpawnInMap.Clear();
			Game_Controller.enemySplash.Clear();
			foreach(GameObject enemy in enemySpawn){
				Game_Controller.enemyInThisMap.Add(enemy.GetComponent<Enemy>());
			}
			foreach(GameObject enemy in enemySpawn){
				enemy.SetActive(false);
			}
			foreach(Player_Skill skill in Skill_Controller.Allskill){
				skill.skillTextTyping[1].text = "";
				skill.localIndexSkill = 0;
			}
			Game_Controller.indexGlobal = 0;
			Game_Controller.nowScene = "StartField";
		}else if (level == 2) {
            Game_Controller.LoadScene.SetActive(false);
            NPCManager.npcInThisMap = GameObject.Find("NPC").GetComponent<NPCstory>();
			Game_Controller.cameraFirst = GameObject.Find("Main Camera");
            Transform player = GameObject.FindGameObjectWithTag("Player").transform;
			player.position = new Vector3(5.74f,-19.97f,0f);
			GameObject[] enemySpawn = GameObject.FindGameObjectsWithTag("Enemy");
			GameObject[] treasureInMap = GameObject.FindGameObjectsWithTag("Treasure");
			GameObject[] QnTInMap = GameObject.FindGameObjectsWithTag("QnTAns");
			Game_Controller.QuizNTypeMinigame.Clear();
			Game_Controller.enemyInThisMap.Clear ();
			Game_Controller.enemySpawnInMap.Clear();
			Game_Controller.treasureMinigame.Clear();
			Game_Controller.enemySplash.Clear();
			foreach(GameObject enemy in enemySpawn){
				Game_Controller.enemySpawnInMap.Add(enemy);
				Game_Controller.enemyInThisMap.Add(enemy.GetComponent<Enemy>());
			}
			foreach(GameObject enemy in enemySpawn){
				//Debug.Log("enemy");
				enemy.SetActive(false);
			}
			foreach (GameObject chest in treasureInMap) {
				//Debug.Log("treasure");
				Game_Controller.treasureMinigame.Add (chest.GetComponent<Treasure>());
			}
			foreach(GameObject monQnTAns in QnTInMap){
				Game_Controller.QuizNTypeMinigame.Add(monQnTAns.GetComponent<QnTChoice>());
			}
			foreach(Player_Skill skill in Skill_Controller.Allskill){
				skill.skillTextTyping[1].text = "";
				skill.localIndexSkill = 0;
			}
			Game_Controller.indexGlobal = 0;
			Game_Controller.nowScene = "Town";
		}else if(level == 3){
            Game_Controller.LoadScene.SetActive(false);
            NPCManager.npcInThisMap = GameObject.Find("NPC").GetComponent<NPCstory>();
			Game_Controller.cameraFirst = GameObject.Find("Main Camera");
            Transform player = GameObject.FindGameObjectWithTag("Player").transform;
			player.position = new Vector3(6.36f,-32.1f,0f);
			GameObject[] enemySpawn = GameObject.FindGameObjectsWithTag("Enemy");
			GameObject[] treasureInMap = GameObject.FindGameObjectsWithTag("Treasure");
			GameObject[] QnTInMap = GameObject.FindGameObjectsWithTag("QnTAns");
			Game_Controller.QuizNTypeMinigame.Clear();
			Game_Controller.enemyInThisMap.Clear ();
			Game_Controller.enemySpawnInMap.Clear();
			Game_Controller.treasureMinigame.Clear();
			Game_Controller.enemySplash.Clear();
			foreach(GameObject enemy in enemySpawn){
				Game_Controller.enemySpawnInMap.Add(enemy);
				Game_Controller.enemyInThisMap.Add(enemy.GetComponent<Enemy>());
			}
			foreach(GameObject enemy in enemySpawn){
				enemy.SetActive(false);
			}
			foreach (GameObject chest in treasureInMap) {
				Game_Controller.treasureMinigame.Add (chest.GetComponent<Treasure>());
			}
			foreach(GameObject monQnTAns in QnTInMap){
				Game_Controller.QuizNTypeMinigame.Add(monQnTAns.GetComponent<QnTChoice>());
			}
			foreach(Player_Skill skill in Skill_Controller.Allskill){
				skill.skillTextTyping[1].text = "";
				skill.localIndexSkill = 0;
			}
			Game_Controller.indexGlobal = 0;
			Game_Controller.nowScene = "DeadForestEntrance";
		}else if(level == 4){
            Game_Controller.LoadScene.SetActive(false);
            NPCManager.npcInThisMap = GameObject.Find("NPC").GetComponent<NPCstory>();
			Game_Controller.cameraFirst = GameObject.Find("Main Camera");
            Transform player = GameObject.FindGameObjectWithTag("Player").transform;
			player.position = new Vector3(5.068f,-24.59527f,0f);
			GameObject[] enemySpawn = GameObject.FindGameObjectsWithTag("Enemy");
			GameObject[] treasureInMap = GameObject.FindGameObjectsWithTag("Treasure");
			GameObject[] QnTInMap = GameObject.FindGameObjectsWithTag("QnTAns");
			Game_Controller.QuizNTypeMinigame.Clear();
			Game_Controller.enemyInThisMap.Clear ();
			Game_Controller.enemySpawnInMap.Clear();
			Game_Controller.treasureMinigame.Clear();
			Game_Controller.enemySplash.Clear();
			foreach(GameObject enemy in enemySpawn){
				Game_Controller.enemySpawnInMap.Add(enemy);
				Game_Controller.enemyInThisMap.Add(enemy.GetComponent<Enemy>());
			}
			foreach(GameObject enemy in enemySpawn){
				enemy.SetActive(false);
			}
			foreach (GameObject chest in treasureInMap) {
				Game_Controller.treasureMinigame.Add (chest.GetComponent<Treasure>());
			}
			foreach(GameObject monQnTAns in QnTInMap){
				Game_Controller.QuizNTypeMinigame.Add(monQnTAns.GetComponent<QnTChoice>());
			}
			foreach(Player_Skill skill in Skill_Controller.Allskill){
				skill.skillTextTyping[1].text = "";
				skill.localIndexSkill = 0;
			}
			Game_Controller.indexGlobal = 0;
			Game_Controller.nowScene = "NormalForest";
		}else if(level == 5){
            Game_Controller.LoadScene.SetActive(false);
            NPCManager.npcInThisMap = GameObject.Find("NPC").GetComponent<NPCstory>();
			Game_Controller.cameraFirst = GameObject.Find("Main Camera");
            Transform player = GameObject.FindGameObjectWithTag("Player").transform;
			player.position = new Vector3(5.668777f,-3.787293f,0f);
			GameObject[] enemySpawn = GameObject.FindGameObjectsWithTag("Enemy");
			GameObject[] treasureInMap = GameObject.FindGameObjectsWithTag("Treasure");
			GameObject[] QnTInMap = GameObject.FindGameObjectsWithTag("QnTAns");
			Game_Controller.QuizNTypeMinigame.Clear();
			Game_Controller.enemyInThisMap.Clear ();
			Game_Controller.enemySpawnInMap.Clear();
			Game_Controller.treasureMinigame.Clear();
			Game_Controller.enemySplash.Clear();
			foreach(GameObject enemy in enemySpawn){
				Game_Controller.enemySpawnInMap.Add(enemy);
				Game_Controller.enemyInThisMap.Add(enemy.GetComponent<Enemy>());
			}
			foreach(GameObject enemy in enemySpawn){
				enemy.SetActive(false);
			}
			foreach (GameObject chest in treasureInMap) {
				Game_Controller.treasureMinigame.Add (chest.GetComponent<Treasure>());
			}
			foreach(GameObject monQnTAns in QnTInMap){
				Game_Controller.QuizNTypeMinigame.Add(monQnTAns.GetComponent<QnTChoice>());
			}
			foreach(Player_Skill skill in Skill_Controller.Allskill){
				skill.skillTextTyping[1].text = "";
				skill.localIndexSkill = 0;
			}
			Game_Controller.indexGlobal = 0;
			Game_Controller.nowScene = "FtoD";
		}else if(level == 6){
            Game_Controller.LoadScene.SetActive(false);
            NPCManager.npcInThisMap = GameObject.Find("NPC").GetComponent<NPCstory>();
			Game_Controller.cameraFirst = GameObject.Find("Main Camera");
            Transform player = GameObject.FindGameObjectWithTag("Player").transform;
			player.position = new Vector3(4.371268f,-29.1707f,0f);
			GameObject[] enemySpawn = GameObject.FindGameObjectsWithTag("Enemy");
			GameObject[] treasureInMap = GameObject.FindGameObjectsWithTag("Treasure");
			GameObject[] QnTInMap = GameObject.FindGameObjectsWithTag("QnTAns");
			Game_Controller.QuizNTypeMinigame.Clear();
			Game_Controller.enemyInThisMap.Clear ();
			Game_Controller.enemySpawnInMap.Clear();
			Game_Controller.treasureMinigame.Clear();
			Game_Controller.enemySplash.Clear();
			foreach(GameObject enemy in enemySpawn){
				Game_Controller.enemySpawnInMap.Add(enemy);
				Game_Controller.enemyInThisMap.Add(enemy.GetComponent<Enemy>());
			}
			foreach(GameObject enemy in enemySpawn){
				enemy.SetActive(false);
			}
			foreach (GameObject chest in treasureInMap) {
				Game_Controller.treasureMinigame.Add (chest.GetComponent<Treasure>());
			}
			foreach(GameObject monQnTAns in QnTInMap){
				Game_Controller.QuizNTypeMinigame.Add(monQnTAns.GetComponent<QnTChoice>());
			}
			foreach(Player_Skill skill in Skill_Controller.Allskill){
				skill.skillTextTyping[1].text = "";
				skill.localIndexSkill = 0;
			}
			Game_Controller.indexGlobal = 0;
			Game_Controller.nowScene = "Crypt";
		}else if(level == 7){
            Game_Controller.LoadScene.SetActive(false);
            NPCManager.npcInThisMap = GameObject.Find("NPC").GetComponent<NPCstory>();
			Game_Controller.cameraFirst = GameObject.Find("Main Camera");
            Transform player = GameObject.FindGameObjectWithTag("Player").transform;
			player.position = new Vector3(4.812857f,-22.82976f,0f);
			GameObject[] enemySpawn = GameObject.FindGameObjectsWithTag("Enemy");
			GameObject[] treasureInMap = GameObject.FindGameObjectsWithTag("Treasure");
			GameObject[] QnTInMap = GameObject.FindGameObjectsWithTag("QnTAns");
			Game_Controller.QuizNTypeMinigame.Clear();
			Game_Controller.enemyInThisMap.Clear ();
			Game_Controller.enemySpawnInMap.Clear();
			Game_Controller.treasureMinigame.Clear();
			Game_Controller.enemySplash.Clear();
			foreach(GameObject enemy in enemySpawn){
				Game_Controller.enemySpawnInMap.Add(enemy);
				Game_Controller.enemyInThisMap.Add(enemy.GetComponent<Enemy>());
			}
			foreach(GameObject enemy in enemySpawn){
				enemy.SetActive(false);
			}
			foreach (GameObject chest in treasureInMap) {
				Game_Controller.treasureMinigame.Add (chest.GetComponent<Treasure>());
			}
			foreach(GameObject monQnTAns in QnTInMap){
				Game_Controller.QuizNTypeMinigame.Add(monQnTAns.GetComponent<QnTChoice>());
			}
			foreach(Player_Skill skill in Skill_Controller.Allskill){
				skill.skillTextTyping[1].text = "";
				skill.localIndexSkill = 0;
			}
			Game_Controller.indexGlobal = 0;
			Game_Controller.nowScene = "Fortess01";
		}else if(level == 8){
            Game_Controller.LoadScene.SetActive(false);
            NPCManager.npcInThisMap = GameObject.Find("NPC").GetComponent<NPCstory>();
			Game_Controller.cameraFirst = GameObject.Find("Main Camera");
            Transform player = GameObject.FindGameObjectWithTag("Player").transform;
			player.position = new Vector3(10.01f,-29.08f,0f);
			GameObject[] enemySpawn = GameObject.FindGameObjectsWithTag("Enemy");
			GameObject[] treasureInMap = GameObject.FindGameObjectsWithTag("Treasure");
			GameObject[] QnTInMap = GameObject.FindGameObjectsWithTag("QnTAns");
			Game_Controller.QuizNTypeMinigame.Clear();
			Game_Controller.enemyInThisMap.Clear ();
			Game_Controller.enemySpawnInMap.Clear();
			Game_Controller.treasureMinigame.Clear();
			Game_Controller.enemySplash.Clear();
			foreach(GameObject enemy in enemySpawn){
				Game_Controller.enemySpawnInMap.Add(enemy);
				Game_Controller.enemyInThisMap.Add(enemy.GetComponent<Enemy>());
			}
			foreach(GameObject enemy in enemySpawn){
				enemy.SetActive(false);
			}
			foreach (GameObject chest in treasureInMap) {
				Game_Controller.treasureMinigame.Add (chest.GetComponent<Treasure>());
			}
			foreach(GameObject monQnTAns in QnTInMap){
				Game_Controller.QuizNTypeMinigame.Add(monQnTAns.GetComponent<QnTChoice>());
			}
			foreach(Player_Skill skill in Skill_Controller.Allskill){
				skill.skillTextTyping[1].text = "";
				skill.localIndexSkill = 0;
			}
			Game_Controller.indexGlobal = 0;
			Game_Controller.nowScene = "Fortess02";
		}else if(level == 9){
            Game_Controller.LoadScene.SetActive(false);
            NPCManager.npcInThisMap = GameObject.Find("NPC").GetComponent<NPCstory>();
			Game_Controller.cameraFirst = GameObject.Find("Main Camera");
            Transform player = GameObject.FindGameObjectWithTag("Player").transform;
			player.position = new Vector3(4.15f,-7.63f,0f);
			GameObject[] enemySpawn = GameObject.FindGameObjectsWithTag("Enemy");
			GameObject[] treasureInMap = GameObject.FindGameObjectsWithTag("Treasure");
			GameObject[] QnTInMap = GameObject.FindGameObjectsWithTag("QnTAns");
			Game_Controller.QuizNTypeMinigame.Clear();
			Game_Controller.enemyInThisMap.Clear ();
			Game_Controller.enemySpawnInMap.Clear();
			Game_Controller.treasureMinigame.Clear();
			Game_Controller.enemySplash.Clear();
			foreach(GameObject enemy in enemySpawn){
				Game_Controller.enemySpawnInMap.Add(enemy);
				Game_Controller.enemyInThisMap.Add(enemy.GetComponent<Enemy>());
			}
			foreach(GameObject enemy in enemySpawn){
				enemy.SetActive(false);
			}
			foreach (GameObject chest in treasureInMap) {
				Game_Controller.treasureMinigame.Add (chest.GetComponent<Treasure>());
			}
			foreach(GameObject monQnTAns in QnTInMap){
				Game_Controller.QuizNTypeMinigame.Add(monQnTAns.GetComponent<QnTChoice>());
			}
			foreach(Player_Skill skill in Skill_Controller.Allskill){
				skill.skillTextTyping[1].text = "";
				skill.localIndexSkill = 0;
			}
			Game_Controller.indexGlobal = 0;
			Game_Controller.nowScene = "D01";
		}else if(level == 10){
            Game_Controller.LoadScene.SetActive(false);
            NPCManager.npcInThisMap = GameObject.Find("NPC").GetComponent<NPCstory>();
			Game_Controller.cameraFirst = GameObject.Find("Main Camera");
            Transform player = GameObject.FindGameObjectWithTag("Player").transform;
			player.position = new Vector3(25.43914f,-3.585174f,0f);
			GameObject[] enemySpawn = GameObject.FindGameObjectsWithTag("Enemy");
			GameObject[] treasureInMap = GameObject.FindGameObjectsWithTag("Treasure");
			GameObject[] QnTInMap = GameObject.FindGameObjectsWithTag("QnTAns");
			Game_Controller.QuizNTypeMinigame.Clear();
			Game_Controller.enemySpawnInMap.Clear();
			Game_Controller.enemyInThisMap.Clear ();
			Game_Controller.treasureMinigame.Clear();
			Game_Controller.enemySplash.Clear();
			foreach(GameObject enemy in enemySpawn){
				Game_Controller.enemySpawnInMap.Add(enemy);
				Game_Controller.enemyInThisMap.Add(enemy.GetComponent<Enemy>());
			}
			foreach(GameObject enemy in enemySpawn){
				enemy.SetActive(false);
			}
			foreach (GameObject chest in treasureInMap) {
				Game_Controller.treasureMinigame.Add (chest.GetComponent<Treasure>());
			}
			foreach(GameObject monQnTAns in QnTInMap){
				Game_Controller.QuizNTypeMinigame.Add(monQnTAns.GetComponent<QnTChoice>());
			}
			foreach(Player_Skill skill in Skill_Controller.Allskill){
				skill.skillTextTyping[1].text = "";
				skill.localIndexSkill = 0;
			}
			Game_Controller.indexGlobal = 0;
			Game_Controller.nowScene = "D02";
		}
	}


	public void Quit(){
		Application.Quit ();
	}
}
