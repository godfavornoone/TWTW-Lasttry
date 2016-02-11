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

		if (level == 2) {
			Debug.Log ("OnLevel work inside");

			Transform player = GameObject.FindGameObjectWithTag("Player").transform;
			player.position = new Vector3(5.74f,-19.97f,0f);
			GameObject[] enemySpawn = GameObject.FindGameObjectsWithTag("Enemy");
			Game_Controller.enemyInThisMap.Clear ();
			foreach(GameObject enemy in enemySpawn){
				Game_Controller.enemyInThisMap.Add(enemy.GetComponent<Enemy>());
			}
			foreach (GameObject enemy in enemySpawn) {
				Debug.Log(enemy.name);
			}
		}else if(level == 3){
			Transform player = GameObject.FindGameObjectWithTag("Player").transform;
			player.position = new Vector3(6.36f,-32.1f,0f);
			GameObject[] enemySpawn = GameObject.FindGameObjectsWithTag("Enemy");
			Game_Controller.enemyInThisMap.Clear ();
			foreach(GameObject enemy in enemySpawn){
				Game_Controller.enemyInThisMap.Add(enemy.GetComponent<Enemy>());
			}
		}
	}


	public void Quit(){
		Application.Quit ();
	}
}
