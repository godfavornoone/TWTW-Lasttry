using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuLevelText : MonoBehaviour {

    Text a;

	// Use this for initialization
	void Start () {
        a = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        a.text = PlayerPrefs.GetInt("currentLevel").ToString();
	}
}
