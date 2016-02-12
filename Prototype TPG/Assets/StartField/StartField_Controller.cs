using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StartField_Controller : MonoBehaviour {

	bool set_I_Dead = false;
	bool set_II_Dead = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		SpawnSetI ();
		ToStory ();
	}

	void LateUpdate(){
		CheckSetIAllDead ();
		CheckSetIIAllDead ();
	}

	void SpawnSetI(){
		foreach (Enemy enemy in Game_Controller.enemyInThisMap) {
			if(enemy.set == 1 && !set_I_Dead){
				enemy.gameObject.SetActive(true);
			}
		}
	}

	void SpawnSetII(){
		foreach (Enemy enemy in Game_Controller.enemyInThisMap) {
			if (enemy.set == 2 && set_I_Dead) {
				enemy.gameObject.SetActive (true);
			}
		}
	}

	void SpawnSetIII(){
		foreach (Enemy enemy in Game_Controller.enemyInThisMap) {
			if(enemy.set == 3 && set_I_Dead && set_II_Dead){
				enemy.gameObject.SetActive(true);
			}
		}
	}

	void CheckSetIAllDead(){
		foreach(Enemy enemy in Game_Controller.enemyInThisMap){
			if(enemy.set == 1 && enemy.gameObject.activeInHierarchy && enemy.gameObject.activeSelf){
				set_I_Dead = false;
			}else{
				set_I_Dead = true;
			}
		}
		if(set_I_Dead){
			SpawnSetII();
		}
	}

	void CheckSetIIAllDead(){
		foreach(Enemy enemy in Game_Controller.enemyInThisMap){
			if(enemy.set == 2 && enemy.gameObject.activeInHierarchy && enemy.gameObject.activeSelf){
				set_II_Dead = false;
			}else{
				set_II_Dead = true;
			}
		}
		if(set_II_Dead){
			SpawnSetIII();
		}
	}

	void ToStory(){
		if(Game_Controller.playerInThisMap.HP <= 100){
			Time.timeScale = 0f;
		}
	}
}
