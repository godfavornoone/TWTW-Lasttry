using UnityEngine;
using System.Collections;

public class Fuckyou : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<MeshRenderer>().sortingOrder = 10;
    //transform.GetComponent<MeshRenderer>().sortingOrder = 10;

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
