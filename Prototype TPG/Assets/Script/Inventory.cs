using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {


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
    public GameObject currentArmor;

    public Item itemSword;
    public Item itemBow;
    public Item itemArmor;

    public List<GameObject> yahoo = new List<GameObject>();
    public GameObject[] yeeha;

    void Start()
    {
        slotAmount = 16;
        inventoryPanel = GameObject.Find("InventoryPanel");
        slotPanel = inventoryPanel.transform.FindChild("SlotPanel").gameObject;
        currentSword = GameObject.Find("SwordPanel");
        currentBow = GameObject.Find("BowPanel");
        currentArmor = GameObject.Find("ArmorPanel");
        itemSword = new Item();
        itemBow = new Item();
        itemArmor = new Item();

        yeeha = GameObject.FindGameObjectsWithTag("Enemy");


        for (int i = 0; i< slotAmount;i++)
        {
            checkSlot.Add(-1); //ทุกช่องเป็น -1 ก่อนนะ พอมีก็จะเปลี่ยนช่องนั้นเป็น 0
            items.Add(new Item());
            //ตรงนี้อ่ะ Items เค้ามีใส่เว้ยยยยยยยยยยยยยยยย !!!!
            slots.Add(Instantiate(inventorySlot));
            slots[i].GetComponent<Slot>().id = i;
            slots[i].transform.SetParent(slotPanel.transform); //ตั้ง Slot เป็นลูกของ SlotPanel
        }
    }

    public void addItem(GameObject item)
    {
        Debug.Log("Yahoo");

        for(int i =0;i<slotAmount;i++)
        {
            if(checkSlot[i]==-1)
            {
                checkSlot[i] = 0;
                Item itemToAdd = new Item(item.GetComponent<Weapon_Status>().attack, item.GetComponent<Weapon_Status>().image, item.GetComponent<Weapon_Status>().type);
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


}

public class Item
{
    public Sprite image;
    public int damage;
    public string type;

    public Item(int a , Sprite b, string c)
    {
        image = b;
        damage = a;
        type = c;
    }
    public Item()
    {

    }
}
