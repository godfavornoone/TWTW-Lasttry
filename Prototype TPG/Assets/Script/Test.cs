using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

    public GameObject a;
    public Enemy_Controller yaha;
    public double timer;
    public bool check = false;

	// Use this for initialization
	void Start () {

        /*
        a = GameObject.Find("Enemy");
        yaha = (Enemy_Controller)a.GetComponent(typeof(Enemy_Controller));
        yaha.calculatehp();

        Debug.Log(yaha.hitpoint);
        Debug.Log(yaha.realhp);

        a = GameObject.Find("Enemy2");
        yaha = (Enemy_Controller)a.GetComponent(typeof(Enemy_Controller));
        yaha.calculatehp();

        Debug.Log(yaha.hitpoint);
        Debug.Log(yaha.realhp);
        */
        /*
        a = GameObject.FindGameObjectWithTag("CanvasYeeha");
        //a.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
        a.transform.GetChild(1).gameObject.SetActive(false);
        */
    }
	
	// Update is called once per frame
	void Update () {

        /*
        if(check==true)
        {
            timer += Time.deltaTime;
        }

        if(Input.anyKeyDown)
        {
            if(timer != 0)
            {
                Debug.Log(Input.inputString);
                Debug.Log(timer);
                timer = 0;
                check = false;
            }
            else
            {
                Debug.Log(Input.inputString);
                check = true;
            }
        }
        
        */
	
	}

    public void showDebug()
    {
        Debug.Log("YAHOOOOOO");
    }
}
