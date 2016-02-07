using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class maxSp : MonoBehaviour
{
    public Text a;

    // Use this for initialization
    void Awake()
    {
        a = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        a.text = "MaxSP: " + Game_Controller.playerInThisMap.MaxSP;
    }
}