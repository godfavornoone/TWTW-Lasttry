﻿using UnityEngine;
using System.Collections;

public class Destroy_Effect_Dead : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine (AnimateAndDestroy ());
	}
	
	private IEnumerator AnimateAndDestroy(){
		yield return new WaitForSeconds (1f);
		Destroy (gameObject);
	}
}