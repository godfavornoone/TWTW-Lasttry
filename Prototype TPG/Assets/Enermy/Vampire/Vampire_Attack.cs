using UnityEngine;
using System.Collections;

public class Vampire_Attack : MonoBehaviour {

	public GameObject vampireBall;

	[HideInInspector]
	public Enemy enemy;

	// Use this for initialization
	void Start () {
		enemy = GetComponentInParent<Enemy> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ShootingBall(Transform player){
		GameObject ball = (GameObject)Instantiate (vampireBall);
		ball.transform.position = transform.position;
		Vector2 direction = player.position - ball.transform.position;
		Debug.Log (direction);
		ball.GetComponent<Vampire_Ball> ().SetDirection (direction, enemy.Attack);
		
	}
}
