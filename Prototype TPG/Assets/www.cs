using UnityEngine;
using System.Collections;

public class www : MonoBehaviour {

    GameObject b;
    Sprite m;
    SpriteRenderer c;

	// Use this for initialization
	void Start () {
        Sprite spr = Resources.Load<Sprite>("boot1");
        transform.GetComponent<SpriteRenderer>().sprite = spr;

        //c.sprite = Resources.Load("boot2") as Sprite;

        /*
        b = this.gameObject;
        /*
        Debug.Log(b);
        m = GetComponent<SpriteRenderer>().sprite;
        Debug.Log(m.name);
        m = Resources.Load("boot1") as Sprite;
        
        b.GetComponent<SpriteRenderer>().sprite = Resources.Load("boot1") as Sprite; ;
        */

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
