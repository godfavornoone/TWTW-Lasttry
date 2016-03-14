using UnityEngine;
using System.Collections;

public class Destroy_Effect_Ice : MonoBehaviour {

	Skill_Ice requestIceData;

	void Awake(){
		requestIceData = GameObject.Find ("IceSkillPanel").GetComponent<Skill_Ice> ();
	}

	// Update is called once per frame
	void Update () {
		StartCoroutine (AnimateAndDestroy ());
	}
	
	private IEnumerator AnimateAndDestroy(){
		yield return new WaitForSeconds (0f);
		Invoke ("Delay", requestIceData.nowIceTime);
	}

	void Delay(){
		Destroy (gameObject);
	}

}
