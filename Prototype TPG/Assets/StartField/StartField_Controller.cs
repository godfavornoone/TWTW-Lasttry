using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StartField_Controller : MonoBehaviour {

	bool set_I_Dead = false;
	bool set_II_Dead = false;
	bool set_III_Dead = false;

	bool tmpdead = false;
	bool tmpdead2 = true;

    bool playerNotDead = true;

    NPCstory a;

	List<Enemy> enemySetI = new List<Enemy> ();

	GameObject[] setI;
	// Use this for initialization
	void Start () {
        Game_Controller.wordDiff = 0;
        a = GameObject.Find("NPC").GetComponent<NPCstory>();
        a.forStartField();

        //ถ้าเริ่มมาให้เรียกของ NPC จะไหวมะ...เรียก 2 ทีอะไรทำนองนี้ ??? ไม่น่าจะได้ 1 แมพ เรามี NPC ได้คนเดียว ให้ได้ครั้งเดียว 55555555555

	}
	
	// Update is called once per frame
	void Update () {
		SpawnSetI ();
        if(playerNotDead)
        {
            ToStory();
        }
		
	}

	void LateUpdate(){
		Invoke ("SpawnSetII", 45f);
		Invoke ("SpawnSetIII", 90f);
//		CheckSetIAllDead ();
//		CheckSetIIAllDead ();
//		CheckSetIIIAllDead ();
	}

	void SpawnSetI(){
		foreach (Enemy enemy in Game_Controller.enemyInThisMap) {
			if(enemy.set == 1){
				enemy.gameObject.SetActive(true);
			}
		}
	}

	void SpawnSetII(){
		foreach (Enemy enemy in Game_Controller.enemyInThisMap) {
			if (enemy.set == 2) {
				enemy.gameObject.SetActive (true);
			}
		}
	}

	void SpawnSetIII(){
		foreach (Enemy enemy in Game_Controller.enemyInThisMap) {
			if(enemy.set == 3){
				enemy.gameObject.SetActive(true);
			}
		}
	}

//	void CheckSetIAllDead(){
//		foreach(Enemy enemy in Game_Controller.enemyInThisMap){
//			if(enemy.set == 1 && enemy.gameObject.activeInHierarchy && enemy.gameObject.activeSelf){
//				set_I_Dead = false;
////				Debug.Log(enemy.gameObject.name + " = " + enemy.gameObject.activeInHierarchy);
//				Debug.Log(enemy.gameObject.name + " = " + set_I_Dead);
//			}else if(enemy.set == 1){
//				set_I_Dead = true;
//				Debug.Log(enemy.gameObject.name + " = " + enemy.gameObject.activeInHierarchy);
//			}
//		}
//
////		foreach (Enemy enemy in Game_Controller.enemyInThisMap) {
////			if(enemy.set == 1 && !enemy.gameObject.activeInHierarchy && !enemy.gameObject.activeSelf){
////				set_I_Dead = true && tmpdead;
////			}
////		}
////
////		if(set_I_Dead){
////			SpawnSetII();
////		}
//	}
//
//	void CheckSetIIAllDead(){
//		foreach(Enemy enemy in Game_Controller.enemyInThisMap){
//			if(enemy.set == 2 && enemy.gameObject.activeInHierarchy && enemy.gameObject.activeSelf){
//				set_II_Dead = false && tmpdead;
//			}else{
//				tmpdead = true;
//			}
//		}
//		if(set_II_Dead){
//			SpawnSetIII();
//		}
//	}
//
//	void CheckSetIIIAllDead(){
//		foreach(Enemy enemy in Game_Controller.enemyInThisMap){
//			if(enemy.set == 3 && enemy.gameObject.activeInHierarchy && enemy.gameObject.activeSelf){
//				set_III_Dead = false && tmpdead;
//			}else{
//				tmpdead = true;
//			}
//		}
//	}
//	void DieAll(){
//		foreach(Enemy enemy in Game_Controller.enemyInThisMap){
//			if(enemy.gameObject.activeInHierarchy == false){
//				tmpdead = true && tmpdead2;
//			}
//		}
//	}
    
        //คิดอยู่ว่าตอนเริ่มก็ควรมีนะ 55555555555

	void ToStory(){
		if(Game_Controller.playerInThisMap.HP <= 100){

            playerNotDead = false;
            a.storyForStart();
			
            

        }
//			else if(set_III_Dead){
//			Time.timeScale = 0f;
//		}
	}
}
