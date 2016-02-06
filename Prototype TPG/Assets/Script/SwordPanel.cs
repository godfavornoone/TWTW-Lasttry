﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class SwordPanel : MonoBehaviour, IDropHandler
{

    //ชิบหายแล้ว ต้องเอาออกได้ด้วย 555555555555555555555555555555555555555555
    private Inventory inv;
    public bool isInside = false;

    void Start()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();

        if (droppedItem.item.type == "sword")
        {
            if (isInside == false) //ไม่มีของอยู่ข้างใน
            {
                inv.checkSlot[droppedItem.slot] = -1;
                inv.items[droppedItem.slot] = new Item();

                inv.itemSword = droppedItem.item;
                droppedItem.slot = 1001;

                isInside = true;
            }
            else if (isInside == true) //มีของอยู่ข้างในแต่แรก (สลับตำแหน่ง)
            {

                Transform item = inv.currentSword.transform.GetChild(0); //ไอเทมที่อยู่ใน sword แต่แรก

                inv.itemSword = droppedItem.item;
                inv.items[droppedItem.slot] = item.GetComponent<ItemData>().item;

                item.transform.SetParent(inv.slots[droppedItem.slot].transform);
                item.transform.position = inv.slots[droppedItem.slot].transform.position;
                item.GetComponent<ItemData>().slot = droppedItem.slot;

                droppedItem.slot = 1001;
                droppedItem.transform.SetParent(inv.currentSword.transform);
                droppedItem.transform.position = inv.currentSword.transform.position;

            }

        }

        for (int i = 0; i < inv.items.Count; i++)
        {
            Debug.Log("YEAHHHH" + "i is: " + i + " " + inv.items[i].damage.ToString());

        }
        Debug.Log("Sword: " + inv.itemSword.damage);
        Debug.Log("Bow: " + inv.itemBow.damage);
    }
}
