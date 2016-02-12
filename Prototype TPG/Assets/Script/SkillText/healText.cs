using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class healText : MonoBehaviour
{

    Skill_Heal a;
    Text b;

    // Use this for initialization
    void Start()
    {

        a = GameObject.Find("HealSkillPanel").GetComponent<Skill_Heal>();
        b = GetComponent<Text>();


    }

    // Update is called once per frame
    void Update()
    {

        b.text = "Heal Lv. " + a.healLVL;

    }
}



