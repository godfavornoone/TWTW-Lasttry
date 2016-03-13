using UnityEngine;
using System.Collections;

public class damagePopup2 : MonoBehaviour {

    public Color TextColor = Color.red;

	// Use this for initialization
	void Start () {

        gameObject.GetComponent<TextMesh>().color = TextColor;

	}
	
	// Update is called once per frame
	void Update () {

        //transform.GetComponent<Renderer>().material.SetColor("_Color",new Color())

        transform.Translate(new Vector3(0, 0.025f, 0));
        TextColor.a = TextColor.a - 0.03f;
        gameObject.GetComponent<TextMesh>().color = TextColor;
        Destroy(gameObject, 0.25f);
        

        //transform.localScale -= new Vector3(0.015f, 0.015f, 0);

    }
}
