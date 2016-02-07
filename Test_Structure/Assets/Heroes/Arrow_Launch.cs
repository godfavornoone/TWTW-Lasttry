using UnityEngine;
using System.Collections;

public class Arrow_Launch : MonoBehaviour {

	public GameObject playerArrow;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void ShootingArrow(Transform enemy, float angle, string eName){

		GameObject arrow = (GameObject)Instantiate (playerArrow);
		arrow.transform.position = transform.position;
		arrow.transform.rotation = Quaternion.Euler (0, 0, angle);
		Vector2 direction = enemy.position - arrow.transform.position;
		arrow.GetComponent<Player_Arrow> ().SetDirection (direction, eName);

	}
}
