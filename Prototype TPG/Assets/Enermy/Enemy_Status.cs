using UnityEngine;
using System.Collections;

public class Enemy_Status : MonoBehaviour {

	public float baseHP;
	public float baseAttack;
	public float baseRunSpeed;
	public float baseEXP;
	public float baseDropRate;
	public float baseAspd;

	[HideInInspector]
	public float hitPoint;
	[HideInInspector]
	public float Attack;
	[HideInInspector]
	public float runSpeed;
	[HideInInspector]
	public float EXP;
	[HideInInspector]
	public float dropRate;
	
	// Use this for initialization
	void Start () {
		realStatus (2);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void realStatus(int gameDifficult){
		hitPoint = baseHP * gameDifficult;
		Attack = baseAttack * gameDifficult;
		EXP = baseEXP * gameDifficult;
		dropRate = baseDropRate * gameDifficult * 0.8f;
//		Debug.Log (hitPoint);
//		Debug.Log (Attack);
//		Debug.Log (EXP);
//		Debug.Log (dropRate);
	}

	public void HpDown(float dmg){
		hitPoint = hitPoint - dmg;
		Debug.Log (gameObject.name + " = " +hitPoint);
	}
	
}
