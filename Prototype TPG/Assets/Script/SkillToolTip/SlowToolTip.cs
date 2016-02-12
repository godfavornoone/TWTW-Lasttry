using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class SlowToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Skill_Slow a;
    string data;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Game_Controller.SkillToolTip.SetActive(true);
        data = "<color=#d99a9a><b>" + "Slow Lv. " + a.slowLVL + "</b></color>\n\n" + "Slow all enemies nearby by " + a.nowSlowTime + " Seconds \n" + "Mana Cost: " + a.slowMana + " SP \n" + "Cooldown Time: " + a.coolDownSkillSlow + " Seconds";
        Game_Controller.SkillToolTip.transform.GetChild(0).GetComponent<Text>().text = data;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Game_Controller.SkillToolTip.SetActive(false);
    }

    // Use this for initialization
    void Start()
    {

        a = GameObject.Find("SlowSkillPanel").GetComponent<Skill_Slow>();

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
