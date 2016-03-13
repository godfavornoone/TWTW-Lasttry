using UnityEngine;
using System.Collections;

public class Destroy_Identity : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine (AnimateAndDestroy ());
	}

	private IEnumerator AnimateAndDestroy(){
		yield return new WaitForSeconds (0f);
		Invoke ("Delay", 1f);
	}
	
	void Delay(){
		Destroy (gameObject);
	}
}
