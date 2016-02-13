using UnityEngine;
using System.Collections;

public class NPCManager : MonoBehaviour {

    public static NPCstory npcInThisMap;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void choice1Pressed()
    {
        if (Game_Controller.world == 0)
        {
            npcInThisMap.World1warpPoint.SetActive(true);
            Game_Controller.detail.text = npcInThisMap.World1TextonDetail1;
        }
        else if (Game_Controller.world == 1)
        {
            npcInThisMap.World2warpPoint.SetActive(true);
            Game_Controller.detail.text = npcInThisMap.World2TextonDetail1;
        }

        Game_Controller.conversation.SetActive(false);
        Game_Controller.blackScene.SetActive(false);
        Game_Controller.displayGameObj.SetActive(false);
        Game_Controller.NPCnameGameObj.SetActive(false);
        Game_Controller.choice1.SetActive(false);
        Game_Controller.choice2.SetActive(false);

        npcInThisMap.exclaim.SetActive(false);


        Time.timeScale = 1;

    }
    public void choice2Pressed()
    {

        if (Game_Controller.world == 0)
        {
            npcInThisMap.World1warpPoint2.SetActive(true);
            Game_Controller.detail.text = npcInThisMap.World1TextonDetail2;
        }
        else if (Game_Controller.world == 1)
        {
            npcInThisMap.World2warpPoint2.SetActive(true);
            Game_Controller.detail.text = npcInThisMap.World2TextonDetail2;
        }

        Time.timeScale = 1;

        Game_Controller.conversation.SetActive(false);
        Game_Controller.blackScene.SetActive(false);
        Game_Controller.displayGameObj.SetActive(false);
        Game_Controller.NPCnameGameObj.SetActive(false);
        Game_Controller.choice1.SetActive(false);
        Game_Controller.choice2.SetActive(false);

        npcInThisMap.exclaim.SetActive(false);

    }


    public void clearButton()
    {
        Game_Controller.ClearGameScene.SetActive(false);


        Game_Controller.playerStatus.SetActive(false);
        Game_Controller.weaponPanel.SetActive(false);
        Game_Controller.skillPanel.SetActive(false);
        Game_Controller.typingProgressButton.SetActive(false);
        Game_Controller.skillButton.SetActive(false);
        Game_Controller.inventoryButton.SetActive(false);
        Game_Controller.objectivePanel.SetActive(false);

        Game_Controller.newGameButton.SetActive(true);
        Game_Controller.loadGameButton.SetActive(true);
        Game_Controller.exitGameButton.SetActive(true);
        Game_Controller.startPicture.SetActive(true);

        Time.timeScale = 1;


    }


    public void EnterPressed()
    {
        if (Game_Controller.world == 0)
        {

            //ต้องเพิ่มในอีก World ด้วยนะ
            if(npcInThisMap.i == npcInThisMap.face.Count && npcInThisMap.isTheEnd == true)
            {
                Game_Controller.NPCnameGameObj.SetActive(false);
                Game_Controller.talkGameObj.SetActive(false);
                Game_Controller.continueButton.SetActive(false);
                Game_Controller.conversation.SetActive(false);
                Game_Controller.blackScene.SetActive(false);
                Game_Controller.displayGameObj.SetActive(false);
                Game_Controller.NPCnameGameObj.SetActive(false);

                Game_Controller.ClearGameScene.SetActive(true);
                Game_Controller.clearButton.SetActive(true);

                

                //ตรงนี้ต้องมีกระบวนการ Save Game ระดับนึง
                //จากนั้นก็โผล่มา Scene แรก พร้อม Load Game อ่ะ
                //มันต้องให้พวก ปุ่ม Load,Save,Exit ไรพวกนั้นโผล่มาอีกรอบอ่ะ เพราะมันจะต้องถูกปิดไปจ้า...
                //แล้วก็เอาอย่างอื่นออกให้หมดด้วย พวกปุ่ม Inventory ห่าเหวไรทั้งหมด
                

            }

            else if (npcInThisMap.i == npcInThisMap.face.Count) //ปุ่ม continue ต้องหาย... choice ต้องเด้ง...
            {

                Game_Controller.NPCnameGameObj.SetActive(false);
                Game_Controller.talkGameObj.SetActive(false);
                Game_Controller.continueButton.SetActive(false);
                Game_Controller.choice1.SetActive(true);
                Game_Controller.choice2.SetActive(true);

                Game_Controller.display.sprite = npcInThisMap.gameControllerScript.playerFace;

                Game_Controller.choice1Text.text = npcInThisMap.World1choice;
                Game_Controller.choice2Text.text = npcInThisMap.World1choice2;

            }
            else
            {
                if (npcInThisMap.face[npcInThisMap.i] == 0)
                {
                    Game_Controller.display.sprite = npcInThisMap.NPCface;
                    Game_Controller.NPCname.text = npcInThisMap.nameNPC;
                    Game_Controller.talk.text = npcInThisMap.story[npcInThisMap.i];
                }
                else if (npcInThisMap.face[npcInThisMap.i] == 1)
                {
                    Game_Controller.display.sprite = npcInThisMap.gameControllerScript.playerFace;
                    Game_Controller.NPCname.text = Game_Controller.playerName;
                    Game_Controller.talk.text = npcInThisMap.story[npcInThisMap.i];
                }

                npcInThisMap.i++;
            }



        }
        else if (Game_Controller.world == 1)
        {

            if (npcInThisMap.i == npcInThisMap.face.Count && npcInThisMap.isTheEnd == true)
            {
                Game_Controller.NPCnameGameObj.SetActive(false);
                Game_Controller.talkGameObj.SetActive(false);
                Game_Controller.continueButton.SetActive(false);
                Game_Controller.conversation.SetActive(false);
                Game_Controller.blackScene.SetActive(false);
                Game_Controller.displayGameObj.SetActive(false);
                Game_Controller.NPCnameGameObj.SetActive(false);

                Game_Controller.ClearGameScene.SetActive(true);
                Game_Controller.clearButton.SetActive(true);



                //ตรงนี้ต้องมีกระบวนการ Save Game ระดับนึง
                //จากนั้นก็โผล่มา Scene แรก พร้อม Load Game อ่ะ
                //มันต้องให้พวก ปุ่ม Load,Save,Exit ไรพวกนั้นโผล่มาอีกรอบอ่ะ เพราะมันจะต้องถูกปิดไปจ้า...
                //แล้วก็เอาอย่างอื่นออกให้หมดด้วย พวกปุ่ม Inventory ห่าเหวไรทั้งหมด


            }

            if (npcInThisMap.i == npcInThisMap.face2.Count)
            {

                Game_Controller.NPCnameGameObj.SetActive(false);
                Game_Controller.talkGameObj.SetActive(false);
                Game_Controller.continueButton.SetActive(false);
                Game_Controller.choice1.SetActive(true);
                Game_Controller.choice2.SetActive(true);

                Game_Controller.display.sprite = npcInThisMap.gameControllerScript.playerFace;

                Game_Controller.choice1Text.text = npcInThisMap.World2choice;
                Game_Controller.choice2Text.text = npcInThisMap.World2choice2;

            }
            else
            {
                if (npcInThisMap.face2[npcInThisMap.i] == 0)
                {
                    Game_Controller.display.sprite = npcInThisMap.NPCface;
                    Game_Controller.NPCname.text = npcInThisMap.nameNPC;
                    Game_Controller.talk.text = npcInThisMap.story2[npcInThisMap.i];
                }
                else if (npcInThisMap.face2[npcInThisMap.i] == 1)
                {
                    Game_Controller.display.sprite = npcInThisMap.gameControllerScript.playerFace;
                    Game_Controller.NPCname.text = Game_Controller.playerName;
                    Game_Controller.talk.text = npcInThisMap.story2[npcInThisMap.i];

                }

                npcInThisMap.i++;
            }
        }



    }
}
