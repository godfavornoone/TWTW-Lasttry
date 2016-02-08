using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelTextScript : MonoBehaviour {

    public Text a;

	// Use this for initialization
	void Awake () {
        a= GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        a.text = "Lv. " + Game_Controller.playerInThisMap.lvl;
    }
}
