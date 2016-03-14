using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPCManager : MonoBehaviour {

    public static NPCstory npcInThisMap;

    public textManager a;
    public Inventory inv;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(transform.gameObject);
        a = GameObject.Find("TextManager").GetComponent<textManager>();
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
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

        Game_Controller.playerInThisMap.transform.position = new Vector3(-1827f, -1542f, 0f);
        Debug.Log("FUCK COUNT: " + Game_Controller.playerInThisMap.historyWeaknesses.Count);
        //Analysis แมพสุดท้ายอ่ะจ้ะ...
        a.Analysis();
        string b = a.computeWeakness();
        int WPM = a.computeWPM();


        if (b.Length < 3)
        {
            b = "abc";
        }

        Game_Controller.playerInThisMap.historyWeaknesses.Add(b);
        Game_Controller.playerInThisMap.historyWPM.Add(WPM);
        Debug.Log(WPM);
        //เอาไอ่บ้านี้ไว้ดึงศัพท์นะ...
        SaveData.Save("top3Weakness", b);

        Debug.Log("FUCK COUNT: " + Game_Controller.playerInThisMap.historyWeaknesses.Count);

        //ดาบ

        //ก็ถ้ามันไม่มีดาบ มันก็จะไม่มีชื่อ =3=
        //มีตัวแปรชื่อ haveCurrentSword ไรงี้มะ ถ้าไม่มี ก็ไม่ต้องยุ่งอะไรกับ Key ของ Sword ตรงนี้ทั้งหมด
        //ถ้ามีค่อยยุ่งไรงี้ ??

        if (Game_Controller.playerInThisMap.currentSword.damage!=0)
        {
            SaveData.Save("HasSword", true);
            SaveData.Save("SwordImage", Game_Controller.playerInThisMap.currentSword.image.name);
            SaveData.Save("SwordDamage", Game_Controller.playerInThisMap.currentSword.damage);
            SaveData.Save("SwordType", Game_Controller.playerInThisMap.currentSword.type);
            SaveData.Save("SwordTitle", Game_Controller.playerInThisMap.currentSword.title);
            SaveData.Save("SwordHitpoint", Game_Controller.playerInThisMap.currentSword.hitpoint);
            SaveData.Save("SwordOption1", Game_Controller.playerInThisMap.currentSword.option[0]);
            SaveData.Save("SwordOption2", Game_Controller.playerInThisMap.currentSword.option[1]);
            SaveData.Save("SwordOption3", Game_Controller.playerInThisMap.currentSword.option[2]);
            SaveData.Save("SwordOption4", Game_Controller.playerInThisMap.currentSword.option[3]);
            SaveData.Save("SwordOption1Chance", Game_Controller.playerInThisMap.currentSword.optionChance[0]);
            SaveData.Save("SwordOption2Chance", Game_Controller.playerInThisMap.currentSword.optionChance[1]);
            SaveData.Save("SwordOption3Chance", Game_Controller.playerInThisMap.currentSword.optionChance[2]);
            SaveData.Save("SwordOption4Chance", Game_Controller.playerInThisMap.currentSword.optionChance[3]);
        }
        else
        {
            SaveData.Save("HasSword", false);
        }

        Debug.Log("FUCK COUNT: " + Game_Controller.playerInThisMap.historyWeaknesses.Count);

        if (Game_Controller.playerInThisMap.currentBow.damage!=0)
        {
            SaveData.Save("HasBow", true);
            //ธนู
            SaveData.Save("BowImage", Game_Controller.playerInThisMap.currentBow.image.name);
            SaveData.Save("BowDamage", Game_Controller.playerInThisMap.currentBow.damage);
            SaveData.Save("BowType", Game_Controller.playerInThisMap.currentBow.type);
            SaveData.Save("BowTitle", Game_Controller.playerInThisMap.currentBow.title);
            SaveData.Save("BowHitpoint", Game_Controller.playerInThisMap.currentBow.hitpoint);
            SaveData.Save("BowOption1", Game_Controller.playerInThisMap.currentBow.option[0]);
            SaveData.Save("BowOption2", Game_Controller.playerInThisMap.currentBow.option[1]);
            SaveData.Save("BowOption3", Game_Controller.playerInThisMap.currentBow.option[2]);
            SaveData.Save("BowOption4", Game_Controller.playerInThisMap.currentBow.option[3]);
            SaveData.Save("BowOption1Chance", Game_Controller.playerInThisMap.currentBow.optionChance[0]);
            SaveData.Save("BowOption2Chance", Game_Controller.playerInThisMap.currentBow.optionChance[1]);
            SaveData.Save("BowOption3Chance", Game_Controller.playerInThisMap.currentBow.optionChance[2]);
            SaveData.Save("BowOption4Chance", Game_Controller.playerInThisMap.currentBow.optionChance[3]);
        }
        else
        {
            SaveData.Save("HasBow", false);
        }

        Debug.Log("FUCK COUNT: " + Game_Controller.playerInThisMap.historyWeaknesses.Count);

        if (Game_Controller.playerInThisMap.currentCloth.hitpoint!=0)
        {
            SaveData.Save("HasCloth", true);
            //เสื้อ
            SaveData.Save("ClothImage", Game_Controller.playerInThisMap.currentCloth.image.name);
            SaveData.Save("ClothDamage", Game_Controller.playerInThisMap.currentCloth.damage);
            SaveData.Save("ClothType", Game_Controller.playerInThisMap.currentCloth.type);
            SaveData.Save("ClothTitle", Game_Controller.playerInThisMap.currentCloth.title);
            SaveData.Save("ClothHitpoint", Game_Controller.playerInThisMap.currentCloth.hitpoint);
            SaveData.Save("ClothOption1", Game_Controller.playerInThisMap.currentCloth.option[0]);
            SaveData.Save("ClothOption2", Game_Controller.playerInThisMap.currentCloth.option[1]);
            SaveData.Save("ClothOption3", Game_Controller.playerInThisMap.currentCloth.option[2]);
            SaveData.Save("ClothOption4", Game_Controller.playerInThisMap.currentCloth.option[3]);
            SaveData.Save("ClothOption1Chance", Game_Controller.playerInThisMap.currentCloth.optionChance[0]);
            SaveData.Save("ClothOption2Chance", Game_Controller.playerInThisMap.currentCloth.optionChance[1]);
            SaveData.Save("ClothOption3Chance", Game_Controller.playerInThisMap.currentCloth.optionChance[2]);
            SaveData.Save("ClothOption4Chance", Game_Controller.playerInThisMap.currentCloth.optionChance[3]);
        }
        else
        {
            SaveData.Save("HasCloth", false);
        }

        if(Game_Controller.playerInThisMap.currentBoot.hitpoint!=0)
        {
            SaveData.Save("HasBoot",true);
            //รองเท้า
            SaveData.Save("BootImage", Game_Controller.playerInThisMap.currentBoot.image.name);
            SaveData.Save("BootDamage", Game_Controller.playerInThisMap.currentBoot.damage);
            SaveData.Save("BootType", Game_Controller.playerInThisMap.currentBoot.type);
            SaveData.Save("BootTitle", Game_Controller.playerInThisMap.currentBoot.title);
            SaveData.Save("BootHitpoint", Game_Controller.playerInThisMap.currentBoot.hitpoint);
            SaveData.Save("BootOption1", Game_Controller.playerInThisMap.currentBoot.option[0]);
            SaveData.Save("BootOption2", Game_Controller.playerInThisMap.currentBoot.option[1]);
            SaveData.Save("BootOption3", Game_Controller.playerInThisMap.currentBoot.option[2]);
            SaveData.Save("BootOption4", Game_Controller.playerInThisMap.currentBoot.option[3]);
            SaveData.Save("BootOption1Chance", Game_Controller.playerInThisMap.currentBoot.optionChance[0]);
            SaveData.Save("BootOption2Chance", Game_Controller.playerInThisMap.currentBoot.optionChance[1]);
            SaveData.Save("BootOption3Chance", Game_Controller.playerInThisMap.currentBoot.optionChance[2]);
            SaveData.Save("BootOption4Chance", Game_Controller.playerInThisMap.currentBoot.optionChance[3]);

        }
        else
        {
            SaveData.Save("HasBoot", false);
        }


        Debug.Log("FUCK COUNT: " + Game_Controller.playerInThisMap.historyWeaknesses.Count);

        //ถ้าไม่มีของในช่องนั้นต้องลบ Key นั้นออกไปด้วยอ่ะ....ไม่งั้นนะ มันจะวุ่นมั้ง
        for (int i = 0;i<inv.slotAmount;i++)
        {
            string key = "Slot" + i;

            if(inv.checkSlot[i]!=-1) //เอาช่องที่ไม่ว่าง ช่องนี้มีของนะจ้ะ
            {
                SaveData.Save(key+"Image", inv.slots[i].transform.GetChild(0).GetComponent<ItemData>().item.image.name);
                SaveData.Save(key+"Damage", inv.slots[i].transform.GetChild(0).GetComponent<ItemData>().item.damage);
                SaveData.Save(key+"Type", inv.slots[i].transform.GetChild(0).GetComponent<ItemData>().item.type);
                SaveData.Save(key+"Title", inv.slots[i].transform.GetChild(0).GetComponent<ItemData>().item.title);
                SaveData.Save(key+"Hitpoint", inv.slots[i].transform.GetChild(0).GetComponent<ItemData>().item.hitpoint);
                SaveData.Save(key+"Option1", inv.slots[i].transform.GetChild(0).GetComponent<ItemData>().item.option[0]);
                SaveData.Save(key+"Option2", inv.slots[i].transform.GetChild(0).GetComponent<ItemData>().item.option[1]);
                SaveData.Save(key+"Option3", inv.slots[i].transform.GetChild(0).GetComponent<ItemData>().item.option[2]);
                SaveData.Save(key+"Option4", inv.slots[i].transform.GetChild(0).GetComponent<ItemData>().item.option[3]);
                SaveData.Save(key+"Option1Chance", inv.slots[i].transform.GetChild(0).GetComponent<ItemData>().item.optionChance[0]);
                SaveData.Save(key+"Option2Chance", inv.slots[i].transform.GetChild(0).GetComponent<ItemData>().item.optionChance[1]);
                SaveData.Save(key+"Option3Chance", inv.slots[i].transform.GetChild(0).GetComponent<ItemData>().item.optionChance[2]);
                SaveData.Save(key+"Option4Chance", inv.slots[i].transform.GetChild(0).GetComponent<ItemData>().item.optionChance[3]);
            }
            else 
            {
                PlayerPrefs.DeleteKey(key + "Image");
                PlayerPrefs.DeleteKey(key + "Damage");
                PlayerPrefs.DeleteKey(key + "Type");
                PlayerPrefs.DeleteKey(key + "Title");
                PlayerPrefs.DeleteKey(key + "Hitpoint");
                PlayerPrefs.DeleteKey(key + "Option1");
                PlayerPrefs.DeleteKey(key + "Option2");
                PlayerPrefs.DeleteKey(key + "Option3");
                PlayerPrefs.DeleteKey(key + "Option4");
                PlayerPrefs.DeleteKey(key + "Option1Chance");
                PlayerPrefs.DeleteKey(key + "Option2Chance");
                PlayerPrefs.DeleteKey(key + "Option3Chance");
                PlayerPrefs.DeleteKey(key + "Option4Chance");
            }
        }

        Debug.Log("FUCK COUNT: " + Game_Controller.playerInThisMap.historyWeaknesses.Count);

        //สมมติว่า 5 เงี้ย มันก็จะวิ่งตั้งแต่ 0 - 4 นะ
        SaveData.Save("indexOfHistoryTyping", Game_Controller.playerInThisMap.historyWeaknesses.Count);

        Debug.Log(Game_Controller.playerInThisMap.historyWeaknesses.Count);

        for(int i =0;i<Game_Controller.playerInThisMap.historyWeaknesses.Count;i++)
        {
            string key = "WPM" + i;
            string key2 = "Weakness" + i;
            
            SaveData.Save(key, Game_Controller.playerInThisMap.historyWPM[i]);
            SaveData.Save(key2, Game_Controller.playerInThisMap.historyWeaknesses[i]);
        }

        SaveData.Save("currentLevel", Game_Controller.playerInThisMap.lvl);
        SaveData.Save("EXPLeft", Game_Controller.playerInThisMap.lvlup);
        SaveData.Save("maxHP", Game_Controller.playerInThisMap.MaxHP);
        SaveData.Save("maxSP", Game_Controller.playerInThisMap.MaxSP);
        SaveData.Save("currentHP", Game_Controller.playerInThisMap.HP);
        SaveData.Save("currentSP", Game_Controller.playerInThisMap.SP);
        SaveData.Save("currentSkillPoint", Game_Controller.playerInThisMap.skillPoint);
        SaveData.Save("currentSpeed", Game_Controller.playerInThisMap.speed);
        SaveData.Save("BowAtk", Game_Controller.playerInThisMap.BowAtk);
        SaveData.Save("SwordAtk", Game_Controller.playerInThisMap.SwordAtk);

        //สกิลละ
        SaveData.Save("trapLVL", Game_Controller.skillTrap.trapLVL);
        SaveData.Save("trapMana", Game_Controller.skillTrap.trapMana);
        SaveData.Save("trapDMG", Skill_Controller.trapDmg);

        SaveData.Save("knockLVL", Game_Controller.skillKnock.knockLVL);
        SaveData.Save("cooldownSkillKnock", Game_Controller.skillKnock.coolDownSkillKnock);
        SaveData.Save("KnockMana", Game_Controller.skillKnock.knockMana);

        SaveData.Save("HealLVL", Game_Controller.skillHeal.healLVL);
        SaveData.Save("HealDMG", Game_Controller.skillHeal.healDMG);
        SaveData.Save("HealMana", Game_Controller.skillHeal.healMana);

        SaveData.Save("SlowLVL", Game_Controller.skillSlow.slowLVL);
        SaveData.Save("nowSlowTime", Game_Controller.skillSlow.nowSlowTime);
        SaveData.Save("SlowMana", Game_Controller.skillSlow.slowMana);

        SaveData.Save("IceLVL", Game_Controller.skillIce.iceLVL);
        SaveData.Save("nowIceTime", Game_Controller.skillIce.nowIceTime);
        SaveData.Save("IceMana", Game_Controller.skillIce.iceMana);

        SaveData.Save("FireLVL", Game_Controller.skillFire.fireLVL);
        SaveData.Save("fireDMG", Game_Controller.skillFire.fireDMG);
        SaveData.Save("fireMana", Game_Controller.skillFire.fireMana);

        //แถวๆนี้โคตรน่าระวัง เพราะนี่คือการเคลียเกมนะ gameDiff มันเลยจะ +1 ตลอดอ่ะ
        if(!PlayerPrefs.HasKey("maxGameDifficulty"))
        {
            SaveData.Save("maxGameDifficulty", 1);
        }

        SaveData.Save("currentWordDifficulty", a.computeWordDiff(WPM));

        //จะมี MAX DIFF ของผู้เล่น
        if (Game_Controller.gameDiff + 1 > SaveData.Load("maxGameDifficulty", 1, true))
        {
            SaveData.Save("maxGameDifficulty", (Game_Controller.gameDiff + 1));
        }
        
        //ถ้าตอนจบอ่ะจะสลับโลกคู่ขนานให้ละกัน ซึ่งถ้าไม่ใช่เคลีย ต้องไม่ใช่แบบนี้อ่ะ
        if(Game_Controller.world==0)
        {
            SaveData.Save("currentParallelWorld", 1);
        }
        else
        {
            SaveData.Save("currentParallelWorld", 0);
        }


        //ไอ่บ้านี่อ่ะมันจะ FIX ให้ไปที่ Town นะ
        //ถ้าปกติก็ควรจะ Game_Controller.nowScene
        SaveData.Save("currentScene", "Town");
        //ล้างข้อมูล Quest อันนี้น่าจะต้องทำทุกอันนะ 55555555555+
        Game_Controller.detail.text = "";

        //It's TIME TO //DebugGGGGGG !!!!
        //Debug.Log("Weaknesses: " + b);

        if(Game_Controller.playerInThisMap.currentSword.damage!=0)
        {
            //Debug.Log("SwordImage " + Game_Controller.playerInThisMap.currentSword.image.name);
            //Debug.Log("SwordDamage " + Game_Controller.playerInThisMap.currentSword.damage);
            //Debug.Log("SwordType " + Game_Controller.playerInThisMap.currentSword.type);
            //Debug.Log("SwordTitle " + Game_Controller.playerInThisMap.currentSword.title);
            //Debug.Log("SwordHitpoint " + Game_Controller.playerInThisMap.currentSword.hitpoint);
            //Debug.Log("SwordOption1 " + Game_Controller.playerInThisMap.currentSword.option[0]);
            //Debug.Log("SwordOption2 " + Game_Controller.playerInThisMap.currentSword.option[1]);
            //Debug.Log("SwordOption3 " + Game_Controller.playerInThisMap.currentSword.option[2]);
            //Debug.Log("SwordOption4 " + Game_Controller.playerInThisMap.currentSword.option[3]);
            //Debug.Log("SwordOption1Chance " + Game_Controller.playerInThisMap.currentSword.optionChance[0]);
            //Debug.Log("SwordOption2Chance " + Game_Controller.playerInThisMap.currentSword.optionChance[1]);
            //Debug.Log("SwordOption3Chance " + Game_Controller.playerInThisMap.currentSword.optionChance[2]);
            //Debug.Log("SwordOption4Chance " + Game_Controller.playerInThisMap.currentSword.optionChance[3]);
        }
        
        if(Game_Controller.playerInThisMap.currentBow.damage!=0)
        {
            //ธนู
            //Debug.Log("BowImage " + Game_Controller.playerInThisMap.currentBow.image.name);
            //Debug.Log("BowDamage " + Game_Controller.playerInThisMap.currentBow.damage);
            //Debug.Log("BowType " + Game_Controller.playerInThisMap.currentBow.type);
            //Debug.Log("BowTitle " + Game_Controller.playerInThisMap.currentBow.title);
            //Debug.Log("BowHitpoint " + Game_Controller.playerInThisMap.currentBow.hitpoint);
            //Debug.Log("BowOption1 " + Game_Controller.playerInThisMap.currentBow.option[0]);
            //Debug.Log("BowOption2 " + Game_Controller.playerInThisMap.currentBow.option[1]);
            //Debug.Log("BowOption3 " + Game_Controller.playerInThisMap.currentBow.option[2]);
            //Debug.Log("BowOption4 " + Game_Controller.playerInThisMap.currentBow.option[3]);
            //Debug.Log("BowOption1Chance " + Game_Controller.playerInThisMap.currentBow.optionChance[0]);
            //Debug.Log("BowOption2Chance " + Game_Controller.playerInThisMap.currentBow.optionChance[1]);
            //Debug.Log("BowOption3Chance " + Game_Controller.playerInThisMap.currentBow.optionChance[2]);
            //Debug.Log("BowOption4Chance " + Game_Controller.playerInThisMap.currentBow.optionChance[3]);
        }
        
        if(Game_Controller.playerInThisMap.currentCloth.hitpoint!=0)
        {
            //เสื้อ
            //Debug.Log("ClothImage " + Game_Controller.playerInThisMap.currentCloth.image.name);
            //Debug.Log("ClothDamage " + Game_Controller.playerInThisMap.currentCloth.damage);
            //Debug.Log("ClothType " + Game_Controller.playerInThisMap.currentCloth.type);
            //Debug.Log("ClothTitle " + Game_Controller.playerInThisMap.currentCloth.title);
            //Debug.Log("ClothHitpoint " + Game_Controller.playerInThisMap.currentCloth.hitpoint);
            //Debug.Log("ClothOption1 " + Game_Controller.playerInThisMap.currentCloth.option[0]);
            //Debug.Log("ClothOption2 " + Game_Controller.playerInThisMap.currentCloth.option[1]);
            //Debug.Log("ClothOption3 " + Game_Controller.playerInThisMap.currentCloth.option[2]);
            //Debug.Log("ClothOption4 " + Game_Controller.playerInThisMap.currentCloth.option[3]);
            //Debug.Log("ClothOption1Chance " + Game_Controller.playerInThisMap.currentCloth.optionChance[0]);
            //Debug.Log("ClothOption2Chance " + Game_Controller.playerInThisMap.currentCloth.optionChance[1]);
            //Debug.Log("ClothOption3Chance " + Game_Controller.playerInThisMap.currentCloth.optionChance[2]);
            //Debug.Log("ClothOption4Chance " + Game_Controller.playerInThisMap.currentCloth.optionChance[3]);
        }

        if(Game_Controller.playerInThisMap.currentBoot.hitpoint!=0)
        {
            //รองเท้า
            //Debug.Log("BootImage " + Game_Controller.playerInThisMap.currentBoot.image.name);
            //Debug.Log("BootDamage " + Game_Controller.playerInThisMap.currentBoot.damage);
            //Debug.Log("BootType " + Game_Controller.playerInThisMap.currentBoot.type);
            //Debug.Log("BootTitle " + Game_Controller.playerInThisMap.currentBoot.title);
            //Debug.Log("BootHitpoint " + Game_Controller.playerInThisMap.currentBoot.hitpoint);
            //Debug.Log("BootOption1 " + Game_Controller.playerInThisMap.currentBoot.option[0]);
            //Debug.Log("BootOption2 " + Game_Controller.playerInThisMap.currentBoot.option[1]);
            //Debug.Log("BootOption3 " + Game_Controller.playerInThisMap.currentBoot.option[2]);
            //Debug.Log("BootOption4 " + Game_Controller.playerInThisMap.currentBoot.option[3]);
            //Debug.Log("BootOption1Chance " + Game_Controller.playerInThisMap.currentBoot.optionChance[0]);
            //Debug.Log("BootOption2Chance " + Game_Controller.playerInThisMap.currentBoot.optionChance[1]);
            //Debug.Log("BootOption3Chance " + Game_Controller.playerInThisMap.currentBoot.optionChance[2]);
            //Debug.Log("BootOption4Chance " + Game_Controller.playerInThisMap.currentBoot.optionChance[3]);

        }


        //ถ้าไม่มีของในช่องนั้นต้องลบ Key นั้นออกไปด้วยอ่ะ....ไม่งั้นนะ มันจะวุ่นมั้ง
        for (int i = 0; i < inv.slotAmount; i++)
        {
            string key = "Slot" + i;

            if (inv.checkSlot[i] != -1) //เอาช่องที่ไม่ว่าง ช่องนี้มีของนะจ้ะ
            {
                //Debug.Log(key + "Image " + inv.slots[i].transform.GetChild(0).GetComponent<ItemData>().item.image.name);
                //Debug.Log(key + "Damage " + inv.slots[i].transform.GetChild(0).GetComponent<ItemData>().item.damage);
                //Debug.Log(key + "Type " + inv.slots[i].transform.GetChild(0).GetComponent<ItemData>().item.type);
                //Debug.Log(key + "Title " + inv.slots[i].transform.GetChild(0).GetComponent<ItemData>().item.title);
                //Debug.Log(key + "Hitpoint " + inv.slots[i].transform.GetChild(0).GetComponent<ItemData>().item.hitpoint);
                //Debug.Log(key + "Option1 " + inv.slots[i].transform.GetChild(0).GetComponent<ItemData>().item.option[0]);
                //Debug.Log(key + "Option2 " + inv.slots[i].transform.GetChild(0).GetComponent<ItemData>().item.option[1]);
                //Debug.Log(key + "Option3 " + inv.slots[i].transform.GetChild(0).GetComponent<ItemData>().item.option[2]);
                //Debug.Log(key + "Option4 " + inv.slots[i].transform.GetChild(0).GetComponent<ItemData>().item.option[3]);
                //Debug.Log(key + "Option1Chance " + inv.slots[i].transform.GetChild(0).GetComponent<ItemData>().item.optionChance[0]);
                //Debug.Log(key + "Option2Chance " + inv.slots[i].transform.GetChild(0).GetComponent<ItemData>().item.optionChance[1]);
                //Debug.Log(key + "Option3Chance " + inv.slots[i].transform.GetChild(0).GetComponent<ItemData>().item.optionChance[2]);
                //Debug.Log(key + "Option4Chance " + inv.slots[i].transform.GetChild(0).GetComponent<ItemData>().item.optionChance[3]);
            }
            else
            {
                //Debug.Log("PlayerPrefs.DeleteKey " +key + "Image");
                //Debug.Log("PlayerPrefs.DeleteKey "+key + "Damage");
                //Debug.Log("PlayerPrefs.DeleteKey "+key + "Type");
                //Debug.Log("PlayerPrefs.DeleteKey "+key + "Title");
                //Debug.Log("PlayerPrefs.DeleteKey "+key + "Hitpoint");
                //Debug.Log("PlayerPrefs.DeleteKey "+key + "Option1");
                //Debug.Log("PlayerPrefs.DeleteKey "+key + "Option2");
                //Debug.Log("PlayerPrefs.DeleteKey "+key + "Option3");
                //Debug.Log("PlayerPrefs.DeleteKey "+key + "Option4");
                //Debug.Log("PlayerPrefs.DeleteKey "+key + "Option1Chance");
                //Debug.Log("PlayerPrefs.DeleteKey "+key + "Option2Chance");
                //Debug.Log("PlayerPrefs.DeleteKey "+key + "Option3Chance");
                //Debug.Log("PlayerPrefs.DeleteKey "+key + "Option4Chance");
            }
        }

        //สมมติว่า 5 เงี้ย มันก็จะวิ่งตั้งแต่ 0 - 4 นะ
        //Debug.Log("indexOfHistoryTyping "+Game_Controller.playerInThisMap.historyWeaknesses.Count);

        for (int i = 0; i < Game_Controller.playerInThisMap.historyWeaknesses.Count; i++)
        {
            //string key = "WPM" + i;
            //string key2 = "Weakness" + i;

            //Debug.Log(key+" " +Game_Controller.playerInThisMap.historyWeaknesses[i]);
            //Debug.Log(key2+" "+Game_Controller.playerInThisMap.historyWPM[i]);
        }

        //Debug.Log("currentLevel "+Game_Controller.playerInThisMap.lvl);
        //Debug.Log("EXPLeft "+Game_Controller.playerInThisMap.lvlup);
        //Debug.Log("maxHP "+Game_Controller.playerInThisMap.MaxHP);
        //Debug.Log("maxSP "+Game_Controller.playerInThisMap.MaxSP);
        //Debug.Log("currentHP "+Game_Controller.playerInThisMap.HP);
        //Debug.Log("currentSP "+Game_Controller.playerInThisMap.SP);
        //Debug.Log("currentSkillPoint "+Game_Controller.playerInThisMap.skillPoint);
        //Debug.Log("BowAtk "+Game_Controller.playerInThisMap.BowAtk);
        //Debug.Log("SwordAtk "+Game_Controller.playerInThisMap.SwordAtk);
        //Debug.Log("baseHP "+Game_Controller.playerInThisMap.baseHP);
        //Debug.Log("baseSP "+Game_Controller.playerInThisMap.baseSP);
        //Debug.Log("baseAtk "+Game_Controller.playerInThisMap.baseAtk);
        //ตรงนี้ขอข้อมูลของ Typing's progress อีกอัน...
        //Debug.Log("trapLVL "+Game_Controller.skillTrap.trapLVL);
        //Debug.Log("trapMana "+Game_Controller.skillTrap.trapMana);
        //Debug.Log("trapDMG "+Skill_Controller.trapDmg);

        //Debug.Log("knockLVL "+Game_Controller.skillKnock.knockLVL);
        //Debug.Log("cooldownSkillKnock "+Game_Controller.skillKnock.coolDownSkillKnock);
        //Debug.Log("KnockMana "+Game_Controller.skillKnock.knockMana);

        //Debug.Log("HealLVL "+Game_Controller.skillHeal.healLVL);
        //Debug.Log("HealDMG "+Game_Controller.skillHeal.healDMG);
        //Debug.Log("HealMana "+Game_Controller.skillHeal.healMana);

        //Debug.Log("SlowLVL "+Game_Controller.skillSlow.slowLVL);
        //Debug.Log("nowSlowTime "+Game_Controller.skillSlow.nowSlowTime);
        //Debug.Log("SlowMana "+Game_Controller.skillSlow.slowMana);

        //Debug.Log("IceLVL "+Game_Controller.skillIce.iceLVL);
        //Debug.Log("nowIceTime "+Game_Controller.skillIce.nowIceTime);
        //Debug.Log("IceMana "+Game_Controller.skillIce.iceMana);

        //Debug.Log("FireLVL "+Game_Controller.skillFire.fireLVL);
        //Debug.Log("fireDMG "+Game_Controller.skillFire.fireDMG);
        //Debug.Log("fireMana "+Game_Controller.skillFire.fireMana);

        //ยังขาด word Diff
        //Debug.Log("maxGameDifficulty "+(Game_Controller.gameDiff + 1));
        //Debug.Log("currentWordDifficulty "+a.computeWordDiff(WPM));
        if (Game_Controller.world == 0)
        {
            //Debug.Log("currentParallelWorld"+1);
        }
        else
        {
            //Debug.Log("currentParallelWorld"+0);
        }
        //ไอ่บ้านี่อ่ะมันจะ FIX ให้ไปที่ Town นะ
        //ถ้าปกติก็ควรจะ Game_Controller.nowScene
        //Debug.Log("currentScene "+"Town");


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
            if(npcInThisMap.j==npcInThisMap.Starterstory.Count && npcInThisMap.isStart == true) //จบ Starter story อันหลังอ่ะ
            {
                Game_Controller.NPCnameGameObj.SetActive(false);
                Game_Controller.talkGameObj.SetActive(false);
                Game_Controller.continueButton.SetActive(false);
                Game_Controller.conversation.SetActive(false);
                Game_Controller.blackScene.SetActive(false);
                Game_Controller.displayGameObj.SetActive(false);

                //ได้เวลาวาร์ปแล้วอีหนู !!!!
                //
                Game_Controller.LoadScene.SetActive(true);
                a.Analysis();
                if(a.check<3) //ดักไว้เลย ว่ายังไงก็มีศัพท์แน่อนนล่ะวะ
                {
                    //Debug.Log("It Must Come Here");
                    a.sendTimeData('a', 10);
                    a.sendTimeData('a', 10);
                    a.sendTimeData('a', 10);
                    a.sendTimeData('b', 10);
                    a.sendTimeData('b', 10);
                    a.sendTimeData('b', 10);
                    a.sendTimeData('c', 10);
                    a.sendTimeData('c', 10);
                    a.sendTimeData('c', 10);
                    a.Analysis();
                }

                Game_Controller.wordDiff = a.computeWordDiff(a.computeWPM()); //ไม่ค่อยชัว ไม่เก็บมันละกัน 5555555555 แต่ ณ ตรงนี้อ่ะจะได้ Word's Diff เริ่มต้นมาแบ้ววววว
                string weakness = a.computeWeakness(); //แค่เอาออกมาแล้วก็ทิ้งไปกร๊ากกกกก
                //Debug.Log("Word's Diff Starter is!!!!: " + Game_Controller.wordDiff);

                Time.timeScale = 1;
                //Refill เลือดหน่อย 55555555
                Game_Controller.playerInThisMap.HP = Game_Controller.playerInThisMap.MaxHP;
                Game_Controller.playerInThisMap.SP = Game_Controller.playerInThisMap.MaxSP;

                Application.LoadLevel("Town");


                //เอางี้ มันจะเป็นข้อมูลไงดีหว่า 55555555555555

            }

            else if(npcInThisMap.j!=0 && npcInThisMap.isStart == true)
            {
                if (npcInThisMap.Starterface[npcInThisMap.j] == 0)
                {
                    Game_Controller.display.sprite = npcInThisMap.NPCface;
                    Game_Controller.NPCname.text = npcInThisMap.nameNPC;
                    Game_Controller.talk.text = npcInThisMap.Starterstory[npcInThisMap.j];
                }
                else if (npcInThisMap.Starterface[npcInThisMap.j] == 1)
                {
                    Game_Controller.display.sprite = npcInThisMap.gameControllerScript.playerFace;
                    Game_Controller.NPCname.text = Game_Controller.playerName;
                    Game_Controller.talk.text = npcInThisMap.Starterstory[npcInThisMap.j];
                }

                npcInThisMap.j++;

            }

            //ต้องเพิ่มในอีก World ด้วยนะ
            else if(npcInThisMap.i == npcInThisMap.face.Count && npcInThisMap.isStart == true)
            {
                Game_Controller.NPCnameGameObj.SetActive(false);
                Game_Controller.talkGameObj.SetActive(false);
                Game_Controller.continueButton.SetActive(false);
                Game_Controller.conversation.SetActive(false);
                Game_Controller.blackScene.SetActive(false);
                Game_Controller.displayGameObj.SetActive(false);

                Time.timeScale = 1;
            }
            else if(npcInThisMap.i == npcInThisMap.face.Count && npcInThisMap.isTheEnd == true)
            {
                Game_Controller.NPCnameGameObj.SetActive(false);
                Game_Controller.talkGameObj.SetActive(false);
                Game_Controller.continueButton.SetActive(false);
                Game_Controller.conversation.SetActive(false);
                Game_Controller.blackScene.SetActive(false);
                Game_Controller.displayGameObj.SetActive(false);

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

            if (npcInThisMap.j == npcInThisMap.Starterstory.Count && npcInThisMap.isStart == true)
            {
                Game_Controller.NPCnameGameObj.SetActive(false);
                Game_Controller.talkGameObj.SetActive(false);
                Game_Controller.continueButton.SetActive(false);
                Game_Controller.conversation.SetActive(false);
                Game_Controller.blackScene.SetActive(false);
                Game_Controller.displayGameObj.SetActive(false);

                Game_Controller.LoadScene.SetActive(true);
                a.Analysis();
                if (a.check < 3) //ดักไว้เลย ว่ายังไงก็มีศัพท์แน่อนนล่ะวะ
                {
                    //Debug.Log("It Must Come Here");
                    a.sendTimeData('a', 10);
                    a.sendTimeData('a', 10);
                    a.sendTimeData('a', 10);
                    a.sendTimeData('b', 10);
                    a.sendTimeData('b', 10);
                    a.sendTimeData('b', 10);
                    a.sendTimeData('c', 10);
                    a.sendTimeData('c', 10);
                    a.sendTimeData('c', 10);
                    a.Analysis();
                }


                Game_Controller.wordDiff = a.computeWordDiff(a.computeWPM()); //ไม่ค่อยชัว ไม่เก็บมันละกัน 5555555555 แต่ ณ ตรงนี้อ่ะจะได้ Word's Diff เริ่มต้นมาแบ้ววววว
                string weakness = a.computeWeakness(); //แค่เอาออกมาแล้วก็ทิ้งไปกร๊ากกกกก
                //Debug.Log("Word's Diff Starter is!!!!: " + Game_Controller.wordDiff);

                Time.timeScale = 1;
                //Refill เลือดหน่อย 55555555
                Game_Controller.playerInThisMap.HP = Game_Controller.playerInThisMap.MaxHP;
                Game_Controller.playerInThisMap.SP = Game_Controller.playerInThisMap.MaxSP;

                Application.LoadLevel("Town");

                
            }

            else if (npcInThisMap.j != 0 && npcInThisMap.isStart == true)
            {
                if (npcInThisMap.Starterface[npcInThisMap.j] == 0)
                {
                    Game_Controller.display.sprite = npcInThisMap.NPCface;
                    Game_Controller.NPCname.text = npcInThisMap.nameNPC;
                    Game_Controller.talk.text = npcInThisMap.Starterstory[npcInThisMap.j];
                }
                else if (npcInThisMap.Starterface[npcInThisMap.j] == 1)
                {
                    Game_Controller.display.sprite = npcInThisMap.gameControllerScript.playerFace;
                    Game_Controller.NPCname.text = Game_Controller.playerName;
                    Game_Controller.talk.text = npcInThisMap.Starterstory[npcInThisMap.j];
                }

                npcInThisMap.j++;

            }

            else if (npcInThisMap.i == npcInThisMap.face.Count && npcInThisMap.isStart == true)
            {
                Game_Controller.NPCnameGameObj.SetActive(false);
                Game_Controller.talkGameObj.SetActive(false);
                Game_Controller.continueButton.SetActive(false);
                Game_Controller.conversation.SetActive(false);
                Game_Controller.blackScene.SetActive(false);
                Game_Controller.displayGameObj.SetActive(false);

                Time.timeScale = 1;
            }

            else if (npcInThisMap.i == npcInThisMap.face.Count && npcInThisMap.isTheEnd == true)
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

            else if (npcInThisMap.i == npcInThisMap.face2.Count)
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
