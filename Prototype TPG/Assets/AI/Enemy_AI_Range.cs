using UnityEngine;
using System.Collections;

public class Enemy_AI_Range : MonoBehaviour {
	
	Animator enemy_Anim;
	Enemy status;

	float distanceAttack;

	void Awake(){
		status = GetComponent<Enemy> ();
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void EnemyShootArrow(){
		distanceAttack = Vector2.Distance (gameObject.transform.position, status.player.position);

		if(distanceAttack < 3){

		}
//
//		}
	}
}
