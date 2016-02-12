using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class slowText : MonoBehaviour
{

    Skill_Slow a;
    Text b;

    // Use this for initialization
    void Start()
    {

        a = GameObject.Find("SlowSkillPanel").GetComponent<Skill_Slow>();
        b = GetComponent<Text>();


    }

    // Update is called once per frame
    void Update()
    {

        b.text = "Slow Lv. " + a.slowLVL;

    }
}


