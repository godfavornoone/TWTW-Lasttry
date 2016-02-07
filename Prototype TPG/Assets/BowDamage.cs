using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BowDamage : MonoBehaviour {

    public Text a;

    // Use this for initialization
    void Awake()
    {
        a = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        a.text = "B.Damage: " + (Game_Controller.playerInThisMap.baseAtk + Game_Controller.playerInThisMap.currentBow.damage);
    }
}
