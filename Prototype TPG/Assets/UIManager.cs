using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	public GameObject target;
	public Transform startPosition;


    string sName;

	void Awake(){
		DontDestroyOnLoad(transform.gameObject);

    }

	public void switchScene(string sceneName){
		Application.LoadLevel(sceneName);
	}

	void OnLevelWasLoaded(int level)
	{
		Debug.Log ("OnLevel work");

        Game_Controller.LoadScene.SetActive(false);

        if (level == 1){


            Transform player = GameObject.FindGameObjectWithTag("Player").transform;
            
			player.position = new Vector3(5.74f,-19.97f,0f);
			GameObject[] enemySpawn = GameObject.FindGameObjectsWithTag("Enemy");
			Game_Controller.enemyInThisMap.Clear ();
			foreach(GameObject enemy in enemySpawn){
				Game_Controller.enemyInThisMap.Add(enemy.GetComponent<Enemy>());
			}
			Game_Controller.nowScene = "StartField";
		}else if (level == 2) {
			Transform player = GameObject.FindGameObjectWithTag("Player").transform;
			player.position = new Vector3(5.74f,-19.97f,0f);
			GameObject[] enemySpawn = GameObject.FindGameObjectsWithTag("Enemy");
			Game_Controller.enemyInThisMap.Clear ();
			foreach(GameObject enemy in enemySpawn){
				Game_Controller.enemyInThisMap.Add(enemy.GetComponent<Enemy>());
			}
			Game_Controller.nowScene = "Town";
		}else if(level == 3){
			Transform player = GameObject.FindGameObjectWithTag("Player").transform;
			player.position = new Vector3(6.36f,-32.1f,0f);
			GameObject[] enemySpawn = GameObject.FindGameObjectsWithTag("Enemy");
			Game_Controller.enemyInThisMap.Clear ();
			foreach(GameObject enemy in enemySpawn){
				Game_Controller.enemyInThisMap.Add(enemy.GetComponent<Enemy>());
			}
			Game_Controller.nowScene = "DeadForestEntrance";
		}else if(level == 4){
			Transform player = GameObject.FindGameObjectWithTag("Player").transform;
			player.position = new Vector3(5.068f,-24.59527f,0f);
			GameObject[] enemySpawn = GameObject.FindGameObjectsWithTag("Enemy");
			Game_Controller.enemyInThisMap.Clear ();
			foreach(GameObject enemy in enemySpawn){
				Game_Controller.enemyInThisMap.Add(enemy.GetComponent<Enemy>());
			}
			Game_Controller.nowScene = "NormalForest";
		}else if(level == 5){
			Transform player = GameObject.FindGameObjectWithTag("Player").transform;
			player.position = new Vector3(5.668777f,-3.787293f,0f);
			GameObject[] enemySpawn = GameObject.FindGameObjectsWithTag("Enemy");
			Game_Controller.enemyInThisMap.Clear ();
			foreach(GameObject enemy in enemySpawn){
				Game_Controller.enemyInThisMap.Add(enemy.GetComponent<Enemy>());
			}
			Game_Controller.nowScene = "FtoD";
		}else if(level == 6){
			Transform player = GameObject.FindGameObjectWithTag("Player").transform;
			player.position = new Vector3(4.371268f,-29.1707f,0f);
			GameObject[] enemySpawn = GameObject.FindGameObjectsWithTag("Enemy");
			Game_Controller.enemyInThisMap.Clear ();
			foreach(GameObject enemy in enemySpawn){
				Game_Controller.enemyInThisMap.Add(enemy.GetComponent<Enemy>());
			}
			Game_Controller.nowScene = "Crypt";
		}else if(level == 7){
			Transform player = GameObject.FindGameObjectWithTag("Player").transform;
			player.position = new Vector3(4.812857f,-22.82976f,0f);
			GameObject[] enemySpawn = GameObject.FindGameObjectsWithTag("Enemy");
			Game_Controller.enemyInThisMap.Clear ();
			foreach(GameObject enemy in enemySpawn){
				Game_Controller.enemyInThisMap.Add(enemy.GetComponent<Enemy>());
			}
			Game_Controller.nowScene = "Fortess01";
		}else if(level == 8){
			Transform player = GameObject.FindGameObjectWithTag("Player").transform;
			player.position = new Vector3(10.01f,-29.08f,0f);
			GameObject[] enemySpawn = GameObject.FindGameObjectsWithTag("Enemy");
			Game_Controller.enemyInThisMap.Clear ();
			foreach(GameObject enemy in enemySpawn){
				Game_Controller.enemyInThisMap.Add(enemy.GetComponent<Enemy>());
			}
			Game_Controller.nowScene = "Fortess02";
		}else if(level == 9){
			Transform player = GameObject.FindGameObjectWithTag("Player").transform;
			player.position = new Vector3(4.15f,-7.63f,0f);
			GameObject[] enemySpawn = GameObject.FindGameObjectsWithTag("Enemy");
			Game_Controller.enemyInThisMap.Clear ();
			foreach(GameObject enemy in enemySpawn){
				Game_Controller.enemyInThisMap.Add(enemy.GetComponent<Enemy>());
			}
			Game_Controller.nowScene = "D01";
		}else if(level == 10){
			Transform player = GameObject.FindGameObjectWithTag("Player").transform;
			player.position = new Vector3(25.43914f,-3.585174f,0f);
			GameObject[] enemySpawn = GameObject.FindGameObjectsWithTag("Enemy");
			Game_Controller.enemyInThisMap.Clear ();
			foreach(GameObject enemy in enemySpawn){
				Game_Controller.enemyInThisMap.Add(enemy.GetComponent<Enemy>());
			}
			Game_Controller.nowScene = "D02";
		}
	}


	public void Quit(){
		Application.Quit ();
	}
}
