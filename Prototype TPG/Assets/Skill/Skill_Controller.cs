using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Skill_Controller : MonoBehaviour {

	public static List<Player_Skill> Allskill = new List<Player_Skill>();
	public static bool checkWrongAllSkillInPanel = true;
	public static float trapDmg = 80f;

	// Use this for initialization
	void Start () {
		GameObject[] skillInPanel = GameObject.FindGameObjectsWithTag("Skill");
		foreach (GameObject skill in skillInPanel) {
			Allskill.Add (skill.GetComponent<Player_Skill>());
		}
	}
}
