using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadText : MonoBehaviour {

    public static Text a;
    public static bool check = false;

	// Use this for initialization
	void Start () {
        a = GetComponent<Text>();	
	}
	
	// Update is called once per frame
	void Update () {
        
	
	}
    
    public static IEnumerator loadText()
    {
        

        a.text = "LOADING.";
        yield return new WaitForSeconds(0.5f);
        a.text = "LOADING..";
        yield return new WaitForSeconds(0.5f);
        a.text = "LOADING...";
        yield return new WaitForSeconds(0.5f);
        

    }

}
