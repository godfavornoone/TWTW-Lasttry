using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Weapon_Status : MonoBehaviour {

    public List<int> possibleAttack;
    public int attack;
    public Sprite image;
    public string type;

	// Use this for initialization
	void Start () {

        image = GetComponent<SpriteRenderer>().sprite;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
