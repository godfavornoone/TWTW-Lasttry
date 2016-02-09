using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class maxHp : MonoBehaviour {

    public Text a;

    // Use this for initialization
    void Awake()
    {
        a = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        a.text = "MaxHp: " + Game_Controller.playerInThisMap.MaxHP;
    }
}
