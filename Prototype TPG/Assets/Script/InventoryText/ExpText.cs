using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ExpText : MonoBehaviour {

    public Text a;

    // Use this for initialization
    void Awake()
    {
        a = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        a.text = "XP Left: " + Game_Controller.playerInThisMap.lvlup;
    }
}
