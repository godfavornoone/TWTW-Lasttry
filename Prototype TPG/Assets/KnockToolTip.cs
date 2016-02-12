using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class KnockToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Skill_Knock a;
    string data;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Game_Controller.SkillToolTip.SetActive(true);
        data = "<color=#d99a9a><b>" + "Knock Lv. " + a.knockLVL + "</b></color>\n\n" + "Knock all enemies back by " + a.knockLong + " Distance \n" + "Mana Cost: " + a.knockMana + " SP \n" + "Cooldown Time: " + a.coolDownSkillKnock + " Seconds";
        Game_Controller.SkillToolTip.transform.GetChild(0).GetComponent<Text>().text = data;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Game_Controller.SkillToolTip.SetActive(false);
    }

    // Use this for initialization
    void Start()
    {

        a = GameObject.Find("KnockSkillPanel").GetComponent<Skill_Knock>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Game_Controller.SkillToolTip.activeSelf)
        {
            Game_Controller.SkillToolTip.transform.position = Input.mousePosition;
        }
    }
}
