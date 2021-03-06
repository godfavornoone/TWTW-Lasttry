﻿using UnityEngine;
using System.Collections;

public class Camera_Follow : MonoBehaviour {

	private Vector2 velocity;
	
	public float smoothTimeY;
	public float smoothTimeX;
	
	public GameObject player;

	public bool bounds;

	public Vector3 minCameraPos;
	public Vector3 maxCameraPos;

    int a = 0;

    void Awake(){

	}

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        /*
        while (a > 0)
        {
            transform.position = Random.insideUnitCircle * 1;
            a--;
        }
        */

        float posX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
		float posY = Mathf.SmoothDamp (transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);
		
		transform.position = new Vector3 (posX, posY, transform.position.z);

		if (bounds) {
			transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x), 
			                                 Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y), 
			                                 Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));

		}
        

        /*
        if (Input.anyKeyDown)
        {
            a = 10;

        }
        */
        //transform.position = Random.insideUnitCircle * 1;
    }
}
