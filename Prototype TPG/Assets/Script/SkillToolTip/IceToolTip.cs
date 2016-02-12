using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class IceToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Skill_Ice a;
    string data;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Game_Controller.SkillToolTip.SetActive(true);
        data = "<color=#d99a9a><b>" + "Ice Lv. " + a.iceLVL + "</b></color>\n\n" + "Freeze all enemmies' movement by " + a.nowIceTime + " Seconds \n" + "Mana Cost: " + a.iceMana + " SP \n" + "Cooldown Time: " + a.coolDownSkillIce + " Seconds";
        Game_Controller.SkillToolTip.transform.GetChild(0).GetComponent<Text>().text = data;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Game_Controller.SkillToolTip.SetActive(false);
    }

    // Use this for initialization
    void Start()
    {

        a = GameObject.Find("IceSkillPanel").GetComponent<Skill_Ice>();

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

