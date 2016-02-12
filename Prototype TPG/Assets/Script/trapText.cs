using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class trapText : MonoBehaviour
{

    Skill_Trap a;
    Text b;

    // Use this for initialization
    void Start()
    {

        a = GameObject.Find("TrapSkillPanel").GetComponent<Skill_Trap>();
        b = GetComponent<Text>();


    }

    // Update is called once per frame
    void Update()
    {

        b.text = "Trap Lv. " + a.trapLVL;

    }
}


