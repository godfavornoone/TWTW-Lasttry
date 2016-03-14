using UnityEngine;
using System.Collections;

public class Destroy_Effect_Slow : MonoBehaviour {

	Skill_Slow requestSlowData;

	// Use this for initialization
	void Awake () {
		requestSlowData = GameObject.Find ("SlowSkillPanel").GetComponent<Skill_Slow> ();
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine (AnimateAndDestroy ());
	}
	
	private IEnumerator AnimateAndDestroy(){
		yield return new WaitForSeconds (0f);
		Invoke ("Delay", requestSlowData.nowSlowTime);
	}
	
	void Delay(){
		Destroy (gameObject);
	}
}
