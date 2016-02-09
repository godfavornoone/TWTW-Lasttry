using UnityEngine;
using System.Collections;

public class Player_Arrow : MonoBehaviour {


	float speed;
	Vector2 _direction;
	bool isReady;
	string name;

	void Awake(){
		speed = 5f;
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
					enemy.HpDown(Game_Controller.playerInThisMap.Atk);
				}
			}

		}
	}
}
