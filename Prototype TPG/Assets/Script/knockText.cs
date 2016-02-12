using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class knockText : MonoBehaviour
{

    Skill_Knock a;
    Text b;

    // Use this for initialization
    void Start()
    {

        a = GameObject.Find("KnockSkillPanel").GetComponent<Skill_Knock>();
        b = GetComponent<Text>();


    }

    // Update is called once per frame
    void Update()
    {

        b.text = "Knock Lv. " + a.knockLVL;

    }
}

