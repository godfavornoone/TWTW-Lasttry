using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public static List<Item> collectedItem = new List<Item>();
    public static int checkCollectedItem = 8;

    GameObject inventoryPanel;
    GameObject slotPanel;
    public GameObject inventorySlot; //ลากใส่เองใน Inspector อ่ะ Prefab Slot กับ Item
    public GameObject inventoryItem;

    int slotAmount;
    public List<Item> items = new List<Item>(); //เก็บ item ไว้ใน Slot น่ะ ข้อมูลของ Item
    //public List<int> damage = new List<int>();
    //public List<Sprite> image = new List<Sprite>();
    public List<GameObject> slots = new List<GameObject>(); //ก็ Slot น่ะนะ
    public List<int> checkSlot = new List<int>();

    //public Item currentSword;
    //public Item currentBow;

    public GameObject currentSword;
    public GameObject currentBow;
    public GameObject currentCloth;
    public GameObject currentBoot;

    public Item itemSword;
    public Item itemBow;
    public Item itemCloth;
    public Item itemBoot;

    public List<GameObject> yahoo = new List<GameObject>();
    public GameObject[] yeeha;

    public GameObject prefab;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject prefab4;
    public GameObject prefab5;
    public GameObject prefab6;
    public GameObject prefab7;
    public GameObject prefab8;
    public GameObject prefab9;
    public GameObject prefab10;

    public GameObject blackScene;

    void Start()
    {
        blackScene = GameObject.Find("BlackScene");
        
        /*
        Instantiate(prefab, new Vector3(-5.87f, -0.88f, 0), Quaternion.identity);
        Instantiate(prefab2, new Vector3(-8.59f, 0.97f, 0), Quaternion.identity);
        Instantiate(prefab3, new Vector3(-7.52f, 1.86f, 0), Quaternion.identity);
        Instantiate(prefab4, new Vector3(-5.98f, 2.22f, 0), Quaternion.identity);
        Instantiate(prefab5, new Vector3(-5.18f, 1.18f, 0), Quaternion.identity);
        Instantiate(prefab6, new Vector3(-4.71f, 0.29f, 0), Quaternion.identity);
        Instantiate(prefab7, new Vector3(-4.29f, -1.2f, 0), Quaternion.identity);
        Instantiate(prefab8, new Vector3(-6.2f, 3.43f, 0), Quaternion.identity);
        Instantiate(prefab9, new Vector3(-10.57f, 1.85f, 0), Quaternion.identity);
        Instantiate(prefab10, new Vector3(-10.86f, -2.67f, 0), Quaternion.identity);
        */

        slotAmount = 8;
        inventoryPanel = GameObject.Find("InventoryPanel");
        
        slotPanel = inventoryPanel.transform.FindChild("SlotPanel").gameObject;
        currentSword = GameObject.Find("SwordPanel");
        currentBow = GameObject.Find("BowPanel");
        currentCloth = GameObject.Find("ClothPanel");
        currentBoot = GameObject.Find("BootPanel");
        itemSword = new Item();
        itemBow = new Item();
        itemCloth = new Item();
        itemBoot = new Item();

        yeeha = GameObject.FindGameObjectsWithTag("Enemy");




        for (int i = 0; i< slotAmount;i++)
        {
            checkSlot.Add(-1); //ทุกช่องเป็น -1 ก่อนนะ พอมีก็จะเปลี่ยนช่องนั้นเป็น 0
            items.Add(new Item());
            //ตรงนี้อ่ะ Items เค้ามีใส่เว้ยยยยยยยยยยยยยยยย !!!!
            slots.Add(slotPanel.gameObject.transform.GetChild(i).gameObject);
            //slots.Add(Instantiate(inventorySlot)); >> ของเก่า !!
            slots[i].GetComponent<Slot>().id = i;
            //slots[i].transform.SetParent(slotPanel.transform); //ตั้ง Slot เป็นลูกของ SlotPanel
        }

        inventoryPanel.SetActive(false);
        blackScene.SetActive(false);

    }

    /*
    public void addItem(GameObject item)
    {

        for(int i =0;i<slotAmount;i++)
        {
            if(checkSlot[i]==-1)
            {
                checkSlot[i] = 0;
                Item itemToAdd = new Item(item.GetComponent<Weapon_Status>().attack, item.GetComponent<Weapon_Status>().image, item.GetComponent<Weapon_Status>().type, item.GetComponent<Weapon_Status>().title, item.GetComponent<Weapon_Status>().option, item.GetComponent<Weapon_Status>().optionChance,item.GetComponent<Weapon_Status>().hitpoint);
                //items.Add(itemToAdd);
                items[i] = itemToAdd;

                //Debug.Log("Damage of item yaha: " + items[0].damage);
                //damage.Add(item.GetComponent<Weapon_Status>().attack);
                //image.Add(item.GetComponent<Weapon_Status>().image);

                GameObject itemObj = Instantiate(inventoryItem);
                itemObj.GetComponent<ItemData>().item = itemToAdd; //เหมือนเก็บใน Script ด้วยจ้า
                itemObj.GetComponent<ItemData>().slot = i; 
                itemObj.GetComponent<Image>().sprite = items[i].image;
                itemObj.transform.SetParent(slots[i].transform); //item ก็จะเป็นลูกของ Slot ไงจ้ะ
                itemObj.transform.GetComponent<RectTransform>().localPosition= new Vector2(0, 0);
                break;

            }
        }
    }
    */

    public void addItem(Item item)
    {
        for (int i = 0; i < slotAmount; i++)
        {
            if (checkSlot[i] == -1)
            {
                checkSlot[i] = 0;
                items[i] = item;

                GameObject itemObj = Instantiate(inventoryItem);
                itemObj.GetComponent<ItemData>().item = item; //เหมือนเก็บใน Script ด้วยจ้า
                itemObj.GetComponent<ItemData>().slot = i;
                itemObj.GetComponent<Image>().sprite = items[i].image;
                itemObj.transform.SetParent(slots[i].transform); //item ก็จะเป็นลูกของ Slot ไงจ้ะ
                itemObj.transform.GetComponent<RectTransform>().localPosition = new Vector2(0, 0);
                break;
            }
        }

    }

    public void openInventory()
    {
        inventoryPanel.SetActive(true);
        blackScene.SetActive(true);
        for (int i = 0; i<collectedItem.Count;i++)
        {
            addItem(collectedItem[i]);
        }
        Time.timeScale = 0;
    }

    //ล้าง มันซะ ไม่ได้เช็คจากตรงนั้น แต่เช็คตามว่า ไอ่นั่นมันว่างไหมมมมม

    public void closeInventory()
    {
        inventoryPanel.SetActive(false);
        blackScene.SetActive(false);

        collectedItem.Clear();

        checkCollectedItem = 0;

        for(int i = 0;i<checkSlot.Count;i++)
        {
            if(checkSlot[i] == -1) //-1 คือว่างนะ...
            {
                checkCollectedItem++;
            }
        }

        Time.timeScale = 1;
    }


}

public class Item
{
    public Sprite image;
    public int damage;
    public string type;
    public string title;
    public int hitpoint;
    public List<int> option = new List<int>();
    public List<int> optionChance = new List<int>();

    public Item(int a , Sprite b, string c, string d, List<int> e, List<int> f, int g)
    {
        image = b;
        damage = a;
        type = c;
        title = d;
        option = e;
        optionChance = f;
        hitpoint = g;
    }
    public Item()
    {

    }
}
