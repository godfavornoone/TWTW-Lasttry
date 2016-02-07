using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class sp : MonoBehaviour {
    public Text a;

    // Use this for initialization
    void Awake()
    {
        a = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        a.text = "SP: " + Game_Controller.playerInThisMap.SP;
    }
}
