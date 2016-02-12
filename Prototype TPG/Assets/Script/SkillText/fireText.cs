using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fireText : MonoBehaviour {

    Skill_Fire a;
    Text b;

	// Use this for initialization
	void Start () {

        a = GameObject.Find("FireSkillPanel").GetComponent<Skill_Fire>();
        b = GetComponent<Text>();
        
	
	}
	
	// Update is called once per frame
	void Update () {

        b.text = "Fire Lv. " + a.fireLVL;
	
	}
}
