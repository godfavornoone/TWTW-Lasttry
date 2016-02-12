using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class HealToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Skill_Heal a;
    string data;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Game_Controller.SkillToolTip.SetActive(true);
        data = "<color=#d99a9a><b>" + "Heal Lv. " + a.healLVL + "</b></color>\n\n" + "Heal player's hitpoint by: " + a.healDMG + " hitpoint \n" + "Mana Cost: " + a.healMana + " SP \n" + "Cooldown Time: " + a.coolDownSkillHeal + " Seconds";
        Game_Controller.SkillToolTip.transform.GetChild(0).GetComponent<Text>().text = data;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Game_Controller.SkillToolTip.SetActive(false);
    }

    // Use this for initialization
    void Start()
    {

        a = GameObject.Find("HealSkillPanel").GetComponent<Skill_Heal>();

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
