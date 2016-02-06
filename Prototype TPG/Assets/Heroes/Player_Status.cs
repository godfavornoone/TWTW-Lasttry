using UnityEngine;
using System.Collections;

public class Player_Status : MonoBehaviour {

	public float baseHP;
	public float baseSP;
	public float baseAtk;
	public float baseRange;
	public float baseSpeed;
	public float baselvlup;
	public float baselvl;
	private Player_Controller playerDeath;

	[HideInInspector]
	public float HP;
	[HideInInspector]
	public float SP;
	[HideInInspector]
	public float range;
	[HideInInspector]
	public float speed;
	[HideInInspector]
	public float lvlup;
	[HideInInspector]
	public float lvl;
	[HideInInspector]
	public float Atk;

	// Use this for initialization
	void Start () {
		playerDeath = (Player_Controller)FindObjectOfType (typeof(Player_Controller));
		realStatus ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void realStatus(){
		HP = baseHP;
		SP = baseSP;
		Atk = baseAtk;
		lvl = baselvl;
		lvlup = baselvlup * lvl;
	}

	public void EnemyAttacked(float dmg){
		HP = HP - dmg;
		if(HP <= 0){
			playerDeath.PlayerDeath();
		}
//		Debug.Log (HP);
	}

	public void PlayerLVLUp(float exp){
		if (lvlup - exp > 0) {
			lvlup = lvlup - exp;
		} else if (lvlup - exp < 0) {
			float tmp = exp - lvlup;
			lvl++;
			lvlup = lvlup * lvl;
			lvlup = lvlup - tmp;
			StatusUp(lvl);
		} else {
			lvl++;
			lvlup = lvlup * lvl;
			StatusUp(lvl);
		}
	}

	void StatusUp(float currentlvl){
		HP = HP * ((100 + currentlvl) / 100);
		SP = SP * ((100 + currentlvl) / 100);

	}

}
