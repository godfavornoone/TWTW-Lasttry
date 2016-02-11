using UnityEngine;
using System.Collections;

public class WarpPoint : MonoBehaviour {

	public string sceneName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D other){
		if(other.gameObject.tag == "Player"){
			Invoke("ChangeLevel", 0.25f);
		}
	}

	void ChangeLevel(){
		Application.LoadLevel(sceneName);
	}
}
