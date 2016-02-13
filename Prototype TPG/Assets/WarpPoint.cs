using UnityEngine;
using System.Collections;

public class WarpPoint : MonoBehaviour {

   
	public string sceneName;
    public textManager textManagerScript;
    public Transform player;

    // Use this for initialization
    void Start () {
        textManagerScript = GameObject.Find("TextManager").GetComponent<textManager>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Player"){
            //Invoke("ChangeLevel", 0.25f);
            StartCoroutine(ChangeLevel());
		}
	}

    
	IEnumerator ChangeLevel(){ 

        Game_Controller.LoadScene.SetActive(true);
        player.position = new Vector3(-1827f, -1542f, 0f);

        //LoadText.loadText();

        textManagerScript.Analysis();

        yield return new WaitForSeconds(1);


        Application.LoadLevel(sceneName);

    }
    
    /*
    void ChangeLevel()
    {

        //Game_Controller.LoadScene.SetActive(true);
        //player.position = new Vector3(-1827f, -1542f, 0f); //แค่กันโดนตีเท่านั้นแหละ

        Debug.Log("No Analy ไง"); // >> ขึ้น 2 ครั้งด้วย..
        //textManagerScript.Analysis();

        
        Application.LoadLevel(sceneName);


    }
    */
}
