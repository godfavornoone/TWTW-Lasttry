using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class NPCstory : MonoBehaviour {

    public string nameNPC;
    public List<string> story = new List<string>();
    public List<string> story2 = new List<string>();

    public List<string> Starterstory = new List<string>();
    public List<int> Starterface = new List<int>();

    public List<int> face = new List<int>();
    public List<int> face2 = new List<int>();

    public string World1choice;
    public string World1choice2;

    public string World2choice;
    public string World2choice2;

    public string World1TextonDetail1;
    public string World1TextonDetail2;
    public string World2TextonDetail1;
    public string World2TextonDetail2;

    public GameObject World1warpPoint;
    public GameObject World1warpPoint2;

    public GameObject World2warpPoint;
    public GameObject World2warpPoint2;

    public GameObject exclaim;

    public Sprite NPCface;

    public Game_Controller gameControllerScript;

    public bool check = false;

    public bool isTheEnd;
    public bool isStart;

    public int i = 0; //ถ้า i มันหมดหมดแล้ว ก็ให้ขึ้น choice1 กับ choice2 >>> ทำไงให้พิมพ์ได้
    public int j = 0;

    //choice จะผูกกับ warppoint และ choice2 จะถูกผูกกับ warppoint2
    //Choice ... แล้วก็คำพูดของตัวละครเราล่ะ ... ต้องมี Image ด้วย

    //ประเด็นคือ เราจะทำยังไง ให้มันโผล่มาได้เรื่อยๆนะ -..-
    //BUTTON

	// Use this for initialization
	void Start () {

        gameControllerScript = GameObject.Find("Game_Controller").GetComponent<Game_Controller>();
        exclaim = transform.GetChild(0).gameObject;
	}


    void OnCollisionEnter2D(Collision2D other)
    {

        Debug.Log(other.gameObject.tag);

        if (other.gameObject.tag == "Player")
        {
            check = true;
            
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && check==true )
        {
            check = false;
            Time.timeScale = 0;
            Debug.Log("yaha");
            Debug.Log("Check the index: " + i);

            Game_Controller.conversation.SetActive(true);
            Game_Controller.blackScene.SetActive(true);
            Game_Controller.displayGameObj.SetActive(true);
            Game_Controller.NPCnameGameObj.SetActive(true);
            Game_Controller.talkGameObj.SetActive(true);
            Game_Controller.continueButton.SetActive(true);

            Game_Controller.choice1.SetActive(false);
            Game_Controller.choice2.SetActive(false);

            if (Game_Controller.world == 0)
            {
                if (face[i] == 0)
                {
                    Game_Controller.display.sprite = NPCface;
                    Game_Controller.NPCname.text = nameNPC;
                    Game_Controller.talk.text = story[i];
                }
                else if (face[i] == 1)
                {
                    Game_Controller.display.sprite = gameControllerScript.playerFace;
                    Game_Controller.NPCname.text = Game_Controller.playerName;
                    Game_Controller.talk.text = story[i];
                }

            }
            else if (Game_Controller.world == 1)
            {
                Game_Controller.conversation.SetActive(true);
                Game_Controller.blackScene.SetActive(true);
                Game_Controller.displayGameObj.SetActive(true);

                if (face2[i] == 0)
                {
                    Game_Controller.display.sprite = NPCface;
                    Game_Controller.NPCname.text = nameNPC;
                    Game_Controller.talk.text = story2[i];
                }
                else if (face2[i] == 1)
                {
                    Game_Controller.display.sprite = gameControllerScript.playerFace;
                    Game_Controller.NPCname.text = Game_Controller.playerName;
                    Game_Controller.talk.text = story2[i];
                }

            }

            i++;
            check = false;
            

            //pause ด้วยนะ


        }


    }

    public void forStartField()
    {
        Time.timeScale = 0;

        Game_Controller.conversation.SetActive(true);
        Game_Controller.blackScene.SetActive(true);
        Game_Controller.displayGameObj.SetActive(true);
        Game_Controller.NPCnameGameObj.SetActive(true);
        Game_Controller.talkGameObj.SetActive(true);
        Game_Controller.continueButton.SetActive(true);

        Game_Controller.choice1.SetActive(false);
        Game_Controller.choice2.SetActive(false);

        if (Game_Controller.world == 0)
        {
            if (face[i] == 0)
            {
                Game_Controller.display.sprite = NPCface;
                Game_Controller.NPCname.text = nameNPC;
                Game_Controller.talk.text = story[i];
            }
            else if (face[i] == 1)
            {
                Game_Controller.display.sprite = gameControllerScript.playerFace;
                Game_Controller.NPCname.text = Game_Controller.playerName;
                Game_Controller.talk.text = story[i];
            }

        }
        else if (Game_Controller.world == 1)
        {
            Game_Controller.conversation.SetActive(true);
            Game_Controller.blackScene.SetActive(true);
            Game_Controller.displayGameObj.SetActive(true);

            if (face2[i] == 0)
            {
                Game_Controller.display.sprite = NPCface;
                Game_Controller.NPCname.text = nameNPC;
                Game_Controller.talk.text = story2[i];
            }
            else if (face2[i] == 1)
            {
                Game_Controller.display.sprite = gameControllerScript.playerFace;
                Game_Controller.NPCname.text = Game_Controller.playerName;
                Game_Controller.talk.text = story2[i];
            }

        }

        i++;
    }

    public void storyForStart()
    {
        Time.timeScale = 0;

        Game_Controller.conversation.SetActive(true);
        Game_Controller.blackScene.SetActive(true);
        Game_Controller.displayGameObj.SetActive(true);
        Game_Controller.NPCnameGameObj.SetActive(true);
        Game_Controller.talkGameObj.SetActive(true);
        Game_Controller.continueButton.SetActive(true);

        Game_Controller.choice1.SetActive(false);
        Game_Controller.choice2.SetActive(false);

            if (Starterface[j] == 0)
            {
                Game_Controller.display.sprite = NPCface;
                Game_Controller.NPCname.text = nameNPC;
                Game_Controller.talk.text = Starterstory[j];
            }
            else if (Starterface[j] == 1)
            {
                Game_Controller.display.sprite = gameControllerScript.playerFace;
                Game_Controller.NPCname.text = Game_Controller.playerName;
                Game_Controller.talk.text = Starterstory[j];
            }

        j++;
    }

}
