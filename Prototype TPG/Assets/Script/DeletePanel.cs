using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class DeletePanel : MonoBehaviour, IDropHandler
{

    private Inventory inv;

    private GameObject SwordPanel;
    private SwordPanel SwordPanelScript;

    private GameObject BowPanel;
    private BowPanel BowPanelScript;

    public void OnDrop(PointerEventData eventData)
    {
        ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();

        if (droppedItem.gameObject.transform.parent.name.Equals("InventoryPanel") && droppedItem.item.type.Equals("sword"))
        {
            SwordPanelScript.isInside = false;
            inv.itemSword = new Item(); //เคลียของเก่าจ้า !!
            Destroy(droppedItem.gameObject);
            
            for (int i = 0; i < inv.items.Count; i++)
            {
                Debug.Log("Inventory List: " + "i is: " + i + " " + inv.items[i].damage.ToString());

            }
            Debug.Log("Sword: " + inv.itemSword.damage);
            Debug.Log("Bow: " + inv.itemBow.damage);
        }

        else if (droppedItem.gameObject.transform.parent.name.Equals("InventoryPanel") && droppedItem.item.type.Equals("bow"))
        {
            BowPanelScript.isInside = false;
            inv.itemBow = new Item(); //เคลียของเก่าจ้า !!
            Destroy(droppedItem.gameObject);
            
            for (int i = 0; i < inv.items.Count; i++)
            {
                Debug.Log("Inventory List: " + "i is: " + i + " " + inv.items[i].damage.ToString());

            }
            Debug.Log("Sword: " + inv.itemSword.damage);
            Debug.Log("Bow: " + inv.itemBow.damage);
        }

        //แน่นอนตรงนี้ก็ต้องมีของ Armor อ่ะ

        else
        {
            inv.checkSlot[droppedItem.slot] = -1;
            inv.items[droppedItem.slot] = new Item();
            Destroy(droppedItem.gameObject);

            for (int i = 0; i < inv.items.Count; i++)
            {
                Debug.Log("YEAHHHH" + "i is: " + i + " " + inv.items[i].damage.ToString());

            }
            Debug.Log("Weapon: " + inv.itemSword.damage);
            Debug.Log("Bow: " + inv.itemBow.damage);
        }

            

        //จะมีไรอีกไหมว้าาาา 55555555555555


    }

    void Start()
    {

        inv = GameObject.Find("Inventory").GetComponent<Inventory>();

        SwordPanel = GameObject.Find("SwordPanel");
        SwordPanelScript = SwordPanel.GetComponent<SwordPanel>();
        BowPanel = GameObject.Find("BowPanel");
        BowPanelScript = BowPanel.GetComponent<BowPanel>();

    }
}
