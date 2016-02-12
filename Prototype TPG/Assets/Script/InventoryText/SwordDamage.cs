using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SwordDamage : MonoBehaviour {

    public Text a;

    // Use this for initialization
    void Awake()
    {
        a = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        a.text = "S.Damage: " + Game_Controller.playerInThisMap.SwordAtk;
    }
}
