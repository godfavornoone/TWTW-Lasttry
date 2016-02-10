using UnityEngine;
using System.Collections;

public class Player_Arrow : MonoBehaviour {


	float speed;
	Vector2 _direction;
	bool isReady;
	string name;

	void Awake(){
		speed = 10f;
		isReady = false;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(isReady){
			Vector2 position = transform.position;
			position += _direction * speed * Time.deltaTime;
			transform.position = position;

			Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
			Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
			
			if(transform.position.x < min.x || transform.position.x > max.x || transform.position.y < min.y || transform.position.y > max.y){
				Destroy(gameObject);
			}
		}
	}

	public void SetDirection(Vector2 direction, string eName){
		_direction = direction.normalized;
		name = eName;
		isReady = true;
	}

	void OnTriggerEnter2D (Collider2D other){
		if(other.gameObject.name.Equals(name)){
			Destroy(gameObject);
			foreach(Enemy enemy in Game_Controller.enemyInThisMap){
				if(enemy.name.Equals(name)){

                    int chanceCri;
                    bool oneTimeOnly = true;
                    float dmg = Game_Controller.playerInThisMap.BowAtk;

                    Debug.Log("Damage Before Cri: " + dmg);

                    if (Game_Controller.playerInThisMap.currentBoot.hitpoint != 0 && oneTimeOnly)
                    {

                        if (Game_Controller.playerInThisMap.currentBoot.option[3] != 0)
                        {
                            chanceCri = Random.Range(0, 100);
                            if (chanceCri <= Game_Controller.playerInThisMap.currentBoot.optionChance[3])
                            {
                                Debug.Log("Cri by boot! in currentWP = bow");
                                dmg = dmg + dmg;
                                oneTimeOnly = false;
                            }
                        }
                    }

                    if (Game_Controller.playerInThisMap.currentCloth.hitpoint != 0 && oneTimeOnly)
                    {

                        if (Game_Controller.playerInThisMap.currentCloth.option[3] != 0)
                        {
                            chanceCri = Random.Range(0, 100);
                            if (chanceCri <= Game_Controller.playerInThisMap.currentCloth.optionChance[3])
                            {
                                Debug.Log("Cri by cloth! in currentWP = bow");
                                dmg = dmg + dmg;
                                oneTimeOnly = false;
                            }
                        }
                    }

                    if (Game_Controller.playerInThisMap.currentSword.damage != 0 && oneTimeOnly)
                    {

                        if (Game_Controller.playerInThisMap.currentSword.option[3] != 0)
                        {
                            chanceCri = Random.Range(0, 100);
                            if (chanceCri <= Game_Controller.playerInThisMap.currentSword.optionChance[3])
                            {
                                Debug.Log("Cri by sword! in currentWP = bow");
                                dmg = dmg + dmg;
                                oneTimeOnly = false;
                            }
                        }
                    }

                    if (Game_Controller.playerInThisMap.currentBow.damage != 0 && oneTimeOnly)
                    {

                        if (Game_Controller.playerInThisMap.currentBow.option[3] != 0)
                        {
                            chanceCri = Random.Range(0, 100);
                            if (chanceCri <= Game_Controller.playerInThisMap.currentBow.optionChance[3])
                            {
                                Debug.Log("Cri by bow! in currentWP = bow");
                                dmg = dmg + dmg;
                                oneTimeOnly = false;
                            }
                        }
                    }

                    Debug.Log("Damage After Cri: " + dmg);



                    enemy.HpDown(dmg);
				}
			}

		}
	}
}
