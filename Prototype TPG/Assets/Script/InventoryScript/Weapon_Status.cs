using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Weapon_Status : MonoBehaviour {


    public int attack;
    public int hitpoint;
    public Sprite image;
    public string type;
    public string title;
    public List<int> option = new List<int>();
    public List<int> optionChance = new List<int>();

    public int minAttack;
    public int maxAttack;

    public int minHitpoint;
    public int maxHitpoint;

    //option chance to get in weapon
    public int oneLetterOption;
    public int sameLetterOption;
    public int sameWordOption;
    public int criticalOption;

    //How chance to occur
    public int oneLetterChance;
    public int sameLetterChance;
    public int sameWordChance;
    public int criticalChance;

    // Use this for initialization
    void Start() {

        image = GetComponent<SpriteRenderer>().sprite;

        getAllStatus();

    }

    void getAllStatus()
    {
        //ตรง GameDiff มันต้องขอจาก Player น้าาาาา (ที่จริงไม่ต้องให้ Player ตายก็ได้มั้ง)


        if (type == "sword" || type=="bow")
        {
            attack = Random.Range(minAttack *Game_Controller.gameDiff, maxAttack * Game_Controller.gameDiff);
        }

        if(type=="cloth" || type=="boot")
        {
            hitpoint = Random.Range(minHitpoint * Game_Controller.gameDiff, maxHitpoint * Game_Controller.gameDiff);
        }
        

        int oneLetter = Random.Range(0, 100);
        int sameLetter = Random.Range(0, 100);
        int sameWord = Random.Range(0, 100);
        int critical = Random.Range(0, 100);

        int oneChance = Random.Range(1, oneLetterChance  + (Game_Controller.gameDiff * 2)); 
        int LetterChance = Random.Range(1, sameLetterChance + (Game_Controller.gameDiff * 2));
        int WordChance = Random.Range(1, sameWordChance + (Game_Controller.gameDiff * 2));

        int criChance = Random.Range(1, criticalChance + (Game_Controller.gameDiff * 2));
        //ตรงนี้คือเช็คว่ามี Option อะไรบ้างน่อ
        //ใส่ต่ออีกว่ามันคุณภาพเท่าไหร่
        if(oneLetter <= oneLetterOption+(Game_Controller.gameDiff * 2))
        {
            option.Add(1);
            optionChance.Add(oneChance);
        }
        else
        {
            option.Add(0);
            optionChance.Add(0);
        }

        if (sameLetter <= sameLetterOption + (Game_Controller.gameDiff * 2))
        {
            option.Add(1);
            optionChance.Add(LetterChance);
        }
        else
        {
            option.Add(0);
            optionChance.Add(0);
        }

        if (sameWord <= sameWordOption + (Game_Controller.gameDiff * 2))
        {
            option.Add(1);
            optionChance.Add(WordChance);
        }
        else
        {
            option.Add(0);
            optionChance.Add(0);
        }

        if (critical <= criticalOption + (Game_Controller.gameDiff * 2))
        {
            option.Add(1);
            optionChance.Add(criChance);
        }
        else
        {
            option.Add(0);
            optionChance.Add(0);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

//    void OnTriggerEnter2D(Collider2D other)
//    {
//
//        if (other.gameObject.tag == "Enemy")
//        {
//            Physics2D.IgnoreLayerCollision(9, 8, true);
//        }
//    }
//
//    void OnCollisionStay2D(Collision2D other)
//    {
//        if (other.gameObject.tag == "Enemy")
//        {
//            Physics2D.IgnoreLayerCollision(9, 8, true);
//        }
//    }
}
