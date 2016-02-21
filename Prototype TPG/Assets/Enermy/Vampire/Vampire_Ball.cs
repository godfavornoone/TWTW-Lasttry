using UnityEngine;
using System.Collections;

public class Vampire_Ball : MonoBehaviour {

	float speed;
	Vector2 _direction;
	bool isReady;
	float damage;


	void Awake(){
		speed = 20f;
		isReady = false;
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

	public void SetDirection(Vector2 direction, float dmg){
		_direction = direction.normalized;
		damage = dmg;
		isReady = true;
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Player"){
			Game_Controller.playerInThisMap.EnemyAttacked(damage);
			Destroy(gameObject);
		}
	}
}
