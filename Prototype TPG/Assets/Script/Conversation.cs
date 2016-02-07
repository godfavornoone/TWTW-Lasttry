using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Conversation : MonoBehaviour {

    public string str;
    public Text a;

	// Use this for initialization
	void Start () {
        a = GetComponent<Text>();
        str = "Panwad:\n" + "Yeeha";
        a.text = str;
        
        //StartCoroutine(AnimateText("Hello! Panwad, How are you?"));
	
	}

    IEnumerator AnimateText(string strComplete)
    {
        int i = 0;
        while(i<strComplete.Length)
        {
            a.text += strComplete[i++];
            yield return new WaitForSeconds(0.05F);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
