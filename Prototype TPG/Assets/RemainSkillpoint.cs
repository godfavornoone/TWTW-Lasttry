using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RemainSkillpoint : MonoBehaviour {

    Text remain;

	// Use this for initialization
	void Start () {

        remain = GetComponent<Text>();
	
	}
	
	// Update is called once per frame
	void Update () {

        remain.text = "Remaining Skill Point Left is : " + Game_Controller.playerInThisMap.skillPoint;
	
	}
}
