using UnityEngine;
using System.Collections;

public class Layer_Control : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<MeshRenderer> ().sortingOrder = 11;
	}

}
