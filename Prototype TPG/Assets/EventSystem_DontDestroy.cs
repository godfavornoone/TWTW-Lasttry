using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EventSystem_DontDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
