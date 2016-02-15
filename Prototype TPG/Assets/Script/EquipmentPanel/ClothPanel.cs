﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class ClothPanel : MonoBehaviour, IDropHandler
{

    private Inventory inv;
    public bool isInside = false;
    

    void Start()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();

        if (droppedItem.item.type == "cloth")
        {
            if (isInside == false) //ไม่มีของอยู่ข้างใน
            {
                inv.checkSlot[droppedItem.slot] = -1;
                inv.items[droppedItem.slot] = new Item();

                inv.itemCloth = droppedItem.item;
                droppedItem.slot = 1003;

                Game_Controller.playerInThisMap.EquipCloth(inv.itemCloth);

                isInside = true;
            }
            else if (isInside == true) //มีของอยู่ข้างในแต่แรก (สลับตำแหน่ง)
            {

                Game_Controller.playerInThisMap.EquipCloth(droppedItem.item);

                Transform item = inv.currentCloth.transform.GetChild(0); //ไอเทมที่อยู่ใน sword แต่แรก

                inv.itemCloth = droppedItem.item;
                inv.items[droppedItem.slot] = item.GetComponent<ItemData>().item;

                item.transform.SetParent(inv.slots[droppedItem.slot].transform);
                item.transform.position = inv.slots[droppedItem.slot].transform.position;
                item.GetComponent<ItemData>().slot = droppedItem.slot;

                droppedItem.slot = 1003;
                droppedItem.transform.SetParent(inv.currentCloth.transform);
                droppedItem.transform.position = inv.currentCloth.transform.position;

            }

        }

//        for (int i = 0; i < inv.items.Count; i++)
//        {
//            Debug.Log("YEAHHHH" + "i is: " + i + " " + inv.items[i].damage.ToString());
//
//        }
//        Debug.Log("Sword: " + inv.itemSword.damage);
//        Debug.Log("Bow: " + inv.itemBow.damage);
    }
}
