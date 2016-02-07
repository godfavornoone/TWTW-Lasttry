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

		if (level == 1) {

			Debug.Log ("OnLevel work inside");

			Instantiate (target, new Vector3(-3.944f,-1.014f,0f),Quaternion.identity);
			Game_Controller.playerInThisMap = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
			GameObject[] enemySpawn = GameObject.FindGameObjectsWithTag("Enemy");
			Game_Controller.enemyInThisMap.Clear ();
			foreach(GameObject enemy in enemySpawn){
				Game_Controller.enemyInThisMap.Add(enemy.GetComponent<Enemy>());
			}
			foreach (GameObject enemy in enemySpawn) {
				Debug.Log(enemy.name);
			}
		}
	}


	public void Quit(){
		Application.Quit ();
	}
}
