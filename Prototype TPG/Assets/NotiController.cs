using UnityEngine;
using System.Collections;

public class NotiController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
    public void OnEnable()
    {
        StartCoroutine(SetDisable());
    }

    public IEnumerator SetDisable()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }



	// Update is called once per frame
	void Update () {
	
	}
    /*
    public IEnumerator waitForDisappear()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }
    */
}
