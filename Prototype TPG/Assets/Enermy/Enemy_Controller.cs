using UnityEngine;
using System.Collections;

public class Enemy_Controller : MonoBehaviour {

	public Transform player;
	public Animator enemy_Anim;
	public Vector3 distance;
	private Enemy_Status spd;
	private bool walk = true;
	private bool struckPlayer = false;
	private float nextAtk = 0f;
	// Use this for initialization

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		enemy_Anim = GetComponent<Animator> ();
		spd = (Enemy_Status)FindObjectOfType (typeof(Enemy_Status));
	}
	
	// Update is called once per frame
	void Update () {
		Enemy_Movement (walk);
	}

	void Enemy_Movement(bool walk){

		if(walk){
			distance = player.InverseTransformPoint (transform.position);
			
			if(Mathf.Abs(distance.x) > Mathf.Abs(distance.y)){
				if(distance.x > 0){
					enemy_Anim.SetBool ("Walk_Left", true);
					enemy_Anim.SetBool ("Walk_Right", false);
					enemy_Anim.SetBool ("Walk_Down", false);
					enemy_Anim.SetBool ("Walk_Up", false);
					transform.position += (player.position - transform.position).normalized * spd.baseRunSpeed * Time.deltaTime;
				}else{
					enemy_Anim.SetBool ("Walk_Right", true);
					enemy_Anim.SetBool ("Walk_Left", false);
					enemy_Anim.SetBool ("Walk_Down", false);
					enemy_Anim.SetBool ("Walk_Up", false);

					transform.position += (player.position - transform.position).normalized * spd.baseRunSpeed * Time.deltaTime;
				}
			}else if(Mathf.Abs(distance.x) < Mathf.Abs(distance.y)){
				if(distance.y > 0){
					enemy_Anim.SetBool ("Walk_Down", true);
					enemy_Anim.SetBool ("Walk_Left", false);
					enemy_Anim.SetBool ("Walk_Right", false);
					enemy_Anim.SetBool ("Walk_Up", false);
					transform.position += (player.position - transform.position).normalized * spd.baseRunSpeed * Time.deltaTime;
				}else{
					enemy_Anim.SetBool ("Walk_Up", true);
					enemy_Anim.SetBool ("Walk_Left", false);
					enemy_Anim.SetBool ("Walk_Right", false);
					enemy_Anim.SetBool ("Walk_Down", false);
					transform.position += (player.position - transform.position).normalized * spd.baseRunSpeed * Time.deltaTime;
				}
			}
		}

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Enemy") {
			Enemy_Controller a = (Enemy_Controller)other.GetComponent(typeof(Enemy_Controller));
			if(a.struckPlayer && !a.walk){
//				Debug.Log("abcd");
				enemy_Anim.SetBool ("Walk_Left", false);
				enemy_Anim.SetBool ("Walk_Right", false);
				enemy_Anim.SetBool ("Walk_Down", false);
				enemy_Anim.SetBool ("Walk_Up", false);
				walk = false;
			}
//			Debug.Log ("Stop");
		}
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.tag == "Enemy") {
			Enemy_Controller a = (Enemy_Controller)other.GetComponent(typeof(Enemy_Controller));
			if(a.struckPlayer && !a.walk){
//				Debug.Log("abcd");
				enemy_Anim.SetBool ("Walk_Left", false);
				enemy_Anim.SetBool ("Walk_Right", false);
				enemy_Anim.SetBool ("Walk_Down", false);
				enemy_Anim.SetBool ("Walk_Up", false);
				walk = false;
			}
//			Debug.Log ("Stop");
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.tag == "Enemy"){
			walk = true;
//			Debug.Log("Walk Again");
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Player"){
			enemy_Anim.SetBool ("Walk_Left", false);
			enemy_Anim.SetBool ("Walk_Right", false);
			enemy_Anim.SetBool ("Walk_Down", false);
			enemy_Anim.SetBool ("Walk_Up", false);
			walk = false;
			struckPlayer = true;
		}
	}

	void OnCollisionStay2D(Collision2D other){
		if(other.gameObject.tag == "Player"){
			if(Time.time > nextAtk){
				nextAtk = Time.time + spd.baseAspd;
				other.gameObject.GetComponent<Player_Status>().EnemyAttacked(spd.Attack);
			}
//			Debug.Log("Attack");
		}
	}

	void OnCollisionExit2D(Collision2D other){
		if(other.gameObject.tag == "Player"){
			walk = true;
			struckPlayer = false;
//			Debug.Log("Walk Again");
		}
	}
	
}
