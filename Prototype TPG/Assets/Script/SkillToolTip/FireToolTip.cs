using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class FireToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Skill_Fire a;
    string data;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Game_Controller.SkillToolTip.SetActive(true);
        data = "<color=#d99a9a><b>" + "Fire Lv. " + a.fireLVL + "</b></color>\n\n" + "Damage all enemies nearby by " + a.fireDMG + " Damage \n" + "Mana Cost: " + a.fireMana + " SP \n" + "Cooldown Time: " + a.coolDownSkillFire + " Seconds";
        Game_Controller.SkillToolTip.transform.GetChild(0).GetComponent<Text>().text = data;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Game_Controller.SkillToolTip.SetActive(false);
    }

    // Use this for initialization
    void Start()
    {

        a = GameObject.Find("FireSkillPanel").GetComponent<Skill_Fire>();

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
