using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IceText : MonoBehaviour
{

    Skill_Ice a;
    Text b;

    // Use this for initialization
    void Start()
    {

        a = GameObject.Find("IceSkillPanel").GetComponent<Skill_Ice>();
        b = GetComponent<Text>();


    }

    // Update is called once per frame
    void Update()
    {

        b.text = "Ice Lv. " + a.iceLVL;

    }
}

