using UnityEngine;
using System.Collections;

public class Text_Position : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TextPosition(string tmp){
		int a = tmp.Length;
		if (a == 1) {
			gameObject.transform.position += new Vector3(-0.1f, 0, 0);
		}else if(a == 2){
			gameObject.transform.position += new Vector3(-0.165f, 0, 0);
		}else if(a == 3){
			gameObject.transform.position += new Vector3(-0.28f, 0, 0);
		}
	}
}
