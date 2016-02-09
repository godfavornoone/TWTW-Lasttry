using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class NPCstory : MonoBehaviour {

    public string nameNPC;
    public List<string> story = new List<string>();
    public List<string> story2 = new List<string>();

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

    bool check = false;

    int i = 0; //ถ้า i มันหมดหมดแล้ว ก็ให้ขึ้น choice1 กับ choice2 >>> ทำไงให้พิมพ์ได้

    //choice จะผูกกับ warppoint และ choice2 จะถูกผูกกับ warppoint2
    //Choice ... แล้วก็คำพูดของตัวละครเราล่ะ ... ต้องมี Image ด้วย

    //ประเด็นคือ เราจะทำยังไง ให้มันโผล่มาได้เรื่อยๆนะ -..-
    //BUTTON

	// Use this for initialization
	void Start () {

        gameControllerScript = GameObject.Find("Game_Controller").GetComponent<Game_Controller>();
        exclaim = transform.GetChild(0).gameObject;
	}

    public void choice1Pressed()
    {
        if (Game_Controller.world == 0)
        {
            World1warpPoint.SetActive(true);
            Game_Controller.detail.text = World1TextonDetail1;
        }
        else if (Game_Controller.world == 1)
        {
            World2warpPoint.SetActive(true);
            Game_Controller.detail.text = World2TextonDetail1;
        }

        Game_Controller.conversation.SetActive(false);
        Game_Controller.blackScene.SetActive(false);
        Game_Controller.displayGameObj.SetActive(false);
        Game_Controller.NPCnameGameObj.SetActive(false);
        Game_Controller.choice1.SetActive(false);
        Game_Controller.choice2.SetActive(false);

        exclaim.SetActive(false);


        Time.timeScale = 1;

    }
    public void choice2Pressed()
    {

        if (Game_Controller.world == 0)
        {
            World1warpPoint2.SetActive(true);
            Game_Controller.detail.text = World1TextonDetail2;
        }
        else if (Game_Controller.world == 1)
        {
            World2warpPoint2.SetActive(true);
            Game_Controller.detail.text = World2TextonDetail2;
        }

        Time.timeScale = 1;

        Game_Controller.conversation.SetActive(false);
        Game_Controller.blackScene.SetActive(false);
        Game_Controller.displayGameObj.SetActive(false);
        Game_Controller.NPCnameGameObj.SetActive(false);
        Game_Controller.choice1.SetActive(false);
        Game_Controller.choice2.SetActive(false);

        exclaim.SetActive(false);

    }



    public void EnterPressed()
    {
        if (Game_Controller.world == 0)
        {

            if(i==face.Count) //ปุ่ม continue ต้องหาย... choice ต้องเด้ง...
            {

                Game_Controller.NPCnameGameObj.SetActive(false);
                Game_Controller.talkGameObj.SetActive(false);
                Game_Controller.continueButton.SetActive(false);
                Game_Controller.choice1.SetActive(true);
                Game_Controller.choice2.SetActive(true);

                Game_Controller.display.sprite = gameControllerScript.playerFace;

                Game_Controller.choice1Text.text = World1choice;
                Game_Controller.choice2Text.text = World1choice2;

            }
            else
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

                i++;
            }

            

        }
        else if (Game_Controller.world == 1)
        {

            if (i == face2.Count)
            {

                Game_Controller.NPCnameGameObj.SetActive(false);
                Game_Controller.talkGameObj.SetActive(false);
                Game_Controller.continueButton.SetActive(false);
                Game_Controller.choice1.SetActive(true);
                Game_Controller.choice2.SetActive(true);

                Game_Controller.display.sprite = gameControllerScript.playerFace;

                Game_Controller.choice1Text.text = World2choice;
                Game_Controller.choice2Text.text = World2choice2;

            }
            else
            {
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

                i++;
            }
        }



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
            Debug.Log("yaha");

            Game_Controller.conversation.SetActive(true);
            Game_Controller.blackScene.SetActive(true);
            Game_Controller.displayGameObj.SetActive(true);
            Game_Controller.NPCnameGameObj.SetActive(true);
            Game_Controller.talkGameObj.SetActive(true);
            Game_Controller.continueButton.SetActive(true);

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
            Time.timeScale = 0;

            //pause ด้วยนะ


        }


    }

}
