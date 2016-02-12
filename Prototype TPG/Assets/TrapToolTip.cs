using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class TrapToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Skill_Trap a;
    string data;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Game_Controller.SkillToolTip.SetActive(true);
        data = "<color=#d99a9a><b>" + "Trap Lv. " + a.trapLVL + "</b></color>\n\n" + "Place the trap and when enemy touches will deal " + Skill_Controller.trapDmg + " Damage \n" + "Mana Cost: " + a.trapMana + " SP \n" + "Cooldown Time: " + a.coolDownSkillTrap + " Seconds";
        Game_Controller.SkillToolTip.transform.GetChild(0).GetComponent<Text>().text = data;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Game_Controller.SkillToolTip.SetActive(false);
    }

    // Use this for initialization
    void Start()
    {

        a = GameObject.Find("TrapSkillPanel").GetComponent<Skill_Trap>();

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
