using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game_Controller : MonoBehaviour {

	public GameObject target;
	private Enemy_Controller[] enemyWalk;

	[HideInInspector]
	public static int indexGlobal = 0;
	public static bool wrongAll = true;
	public static int gameDifficult = 1;
//	public static bool attackAble = false;
	public static bool greyWord = true;
//	public static bool isEnemyDead = false;
	public static bool ESC = false;

	void Awake(){
		Instantiate (target, new Vector3(-7.0f,0.3f,0f),Quaternion.identity);
	}

	void Start(){
		enemyWalk = (Enemy_Controller[])FindObjectsOfType (typeof(Enemy_Controller));
	}

	void Update(){
		if(Input.GetKeyUp(KeyCode.Space)){
			foreach(Enemy_Controller enemy in enemyWalk){
				enemy.enemy_Anim.SetBool("Walk_Right", false);
				enemy.enemy_Anim.SetBool("Walk_Left", false);
				enemy.enemy_Anim.SetBool("Walk_Down", false);
				enemy.enemy_Anim.SetBool("Walk_Up", false);
				enemy.enabled = !enemy.enabled;
			}
		}
//		Debug.Log (attackAble);
	}

}
