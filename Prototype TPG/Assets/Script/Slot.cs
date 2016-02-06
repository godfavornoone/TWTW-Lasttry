using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class Slot : MonoBehaviour, IDropHandler {

    public int id;
    private Inventory inv;
    private GameObject SwordPanel;
    private SwordPanel SwordPanelScript;

    private GameObject BowPanel;
    private BowPanel BowPanelScript;

    public void OnDrop(PointerEventData eventData)
    {
        ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();

        if(droppedItem.gameObject.transform.parent.name.Equals("InventoryPanel") && droppedItem.item.type.Equals("sword"))
        {
            
            if(inv.checkSlot[id] == -1)
            {
                SwordPanelScript.isInside = false;
                inv.itemSword = new Item(); //เคลียของเก่าจ้า !!
                inv.items[id] = droppedItem.item;
                droppedItem.slot = id;
                inv.checkSlot[id] = 1;
            }
            else //ถ้าหากไม่ใช่ ต้องมีการสลับกันนะจ้ะ
            {
                Debug.Log("มานี่ใช่ไหมจ้าาาา");

                //Transform item = inv.currentSword.transform.GetChild(0); //ไอเทมที่อยู่ใน sword แต่แรก //มันหายไปแล้วไงล่ะะะะะ เพราะมึงดึงมันขึ้นมา 55555555555555555555555


                Transform yahoo = this.transform.GetChild(0);
                
                droppedItem.slot = id;
                droppedItem.transform.SetParent(inv.slots[id].transform);
                droppedItem.transform.position = inv.slots[id].transform.position;

                //ต้องเอาของที่อยู่ในช่องนั้นมาอ่ะ =3=

                yahoo.transform.SetParent(inv.currentSword.transform);
                yahoo.transform.position = inv.currentSword.transform.position;
                yahoo.GetComponent<ItemData>().slot = 1001;

                //สลับละ ... ดู index อีกที
                inv.itemSword = inv.items[id];
                inv.items[id] = droppedItem.item;

                //แม่งงงงงงงงงงงงงงงงงงงง ต้องใส่ให้ BOWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW ด้วยยยยยยย

            }

            

            for (int i = 0; i < inv.items.Count; i++)
            {
                Debug.Log("Inventory List: " + "i is: " + i + " " + inv.items[i].damage.ToString());

            }
            Debug.Log("Sword: " + inv.itemSword.damage);
            Debug.Log("Bow: " + inv.itemBow.damage);
        }

        else if (droppedItem.gameObject.transform.parent.name.Equals("InventoryPanel") && droppedItem.item.type.Equals("bow"))
        {

            if (inv.checkSlot[id] == -1)
            {
                BowPanelScript.isInside = false;
                inv.itemBow = new Item(); //เคลียของเก่าจ้า !!
                inv.items[id] = droppedItem.item;
                droppedItem.slot = id;
                inv.checkSlot[id] = 1;
            }
            else
            {
                Debug.Log("มานี่ใช่ไหมจ้าาาา");

                //Transform item = inv.currentSword.transform.GetChild(0); //ไอเทมที่อยู่ใน sword แต่แรก //มันหายไปแล้วไงล่ะะะะะ เพราะมึงดึงมันขึ้นมา 55555555555555555555555


                Transform yahoo = this.transform.GetChild(0);

                droppedItem.slot = id;
                droppedItem.transform.SetParent(inv.slots[id].transform);
                droppedItem.transform.position = inv.slots[id].transform.position;

                //ต้องเอาของที่อยู่ในช่องนั้นมาอ่ะ =3=

                yahoo.transform.SetParent(inv.currentBow.transform);
                yahoo.transform.position = inv.currentBow.transform.position;
                yahoo.GetComponent<ItemData>().slot = 1000;

                //สลับละ ... ดู index อีกที
                inv.itemBow = inv.items[id];
                inv.items[id] = droppedItem.item;

            }

            for (int i = 0; i < inv.items.Count; i++)
            {
                Debug.Log("Inventory List: " + "i is: " + i + " " + inv.items[i].damage.ToString());

            }
            Debug.Log("Sword: " + inv.itemSword.damage);
            Debug.Log("Bow: " + inv.itemBow.damage);
        }
        //ตรงนี้ก็จะมี else if Armor อีกอันนึงนะจ้ะ ^_^

        else if(inv.checkSlot[id] == -1)
        {
            
            inv.checkSlot[droppedItem.slot] = -1; //เคลียให้ของเก่าว่าง เพราะ -1 อ่ะคือว่างจ้า
            inv.items[droppedItem.slot] = new Item(); //อันเก่าจะกลายเป็นโล่ง ?????????????????????? ลองดู Clip
            inv.items[id] = droppedItem.item; //อันนี้คือแปะ Item ให้มาในที่ที่ใหม่เรียบร้อย !!
            droppedItem.slot = id; //อันนี้ก็บอกว่า Item ที่แตะอยู่อ่ะ ให้เปลี่ยนค่า Slot ให้เป็นอันปัจจุบันจ้า
            inv.checkSlot[id] = 1; //น่าจะมีอันนี้นะ ที่ของเค้าไม่ต้องใส่ ก็เพราะว่า เวลาเค้ายัด มันมีเลข ID ตามไปอยู่แล้ว

            for (int i = 0; i < inv.items.Count; i++)
            {
                Debug.Log("Inventory List: " + "i is: " + i + " " + inv.items[i].damage.ToString());

            }
            Debug.Log("Sword: " + inv.itemSword.damage);
            Debug.Log("Bow: " + inv.itemBow.damage);

            //แล้วไม่เซ็ตให้ช่องนี้ไม่ว่างเหรอ ??

        }
        
        else if(droppedItem.slot!= id) //เค้าบอกว่านี่เป็นเคสสลับสิ่งของสินะ ก็นะ ถ้าด้านบน มันหลุดออกมาได้ แสดงว่า ช่องนี้มีของไง
        {
            //id ห้ามเปลี่ยนเด็ดขาด เพราะ Slot ห้ามเปลี่ยนค่า....
            //Slot.id ห้ามเปลี่ยนเด็ดขาด...


            Transform item = this.transform.GetChild(0); 


            //droppedItem มันคือ 0
            item.GetComponent<ItemData>().slot = droppedItem.slot; //เดี๋ยวนะ อันนี้มึงเล่นเอาค่า slot ของตัวดรอปลงมาใส่ แสดงว่า slot ของ item = 0...
            Debug.Log("ช่องที่ 2 หลังจากนั้น: " + item.GetComponent<ItemData>().slot);
            item.transform.SetParent(inv.slots[droppedItem.slot].transform);
            item.transform.position = inv.slots[droppedItem.slot].transform.position;

            Debug.Log("ช่องที่ 1 ตอนนี้เท่าไหร่: " + droppedItem.slot); //ต้อง 0 !!!
            droppedItem.slot = id; //ถ้าอันนี้เดาไม่ผิดจะต้องเป็น 1 แล้วนะ
            Debug.Log("ช่องที่ 1 หลังจากนั้น: " + droppedItem.slot); //ต้อง 1
            droppedItem.transform.SetParent(this.transform);
            droppedItem.transform.position = this.transform.position;



            Debug.Log("ก่อนนะจ้ะ");
            Debug.Log(item.GetComponent<ItemData>().item.damage);
            Debug.Log(droppedItem.item.damage);


            inv.items[droppedItem.slot] = droppedItem.item;
            inv.items[item.GetComponent<ItemData>().slot] = item.GetComponent<ItemData>().item;
            

            for (int i = 0; i < inv.items.Count; i++)
            {
                Debug.Log("YEAHHHH" + "i is: " + i + " " + inv.items[i].damage.ToString());

            }
            Debug.Log("Sword: " + inv.itemSword.damage);
            Debug.Log("Bow: " + inv.itemBow.damage);

        }
        
    }

    // Use this for initialization
    void Start () {

        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        SwordPanel = GameObject.Find("SwordPanel");
        SwordPanelScript = SwordPanel.GetComponent<SwordPanel>();
        BowPanel = GameObject.Find("BowPanel");
        BowPanelScript = BowPanel.GetComponent<BowPanel>();


    }
	

}
