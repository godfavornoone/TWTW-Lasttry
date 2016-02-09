using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler {

    public Item item;
    public int amount;
    public int slot;

    private Inventory inv;
    private Tooltip tooltip;
    private Vector2 offset;

    void Start()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        tooltip = inv.GetComponent<Tooltip>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(item!=null)
        {
            offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
            this.transform.SetParent(this.transform.parent.parent);
            this.transform.position = eventData.position - offset; //ได้ mouse position
            GetComponent<CanvasGroup>().blocksRaycasts = false;

        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            this.transform.position = eventData.position - offset; //ได้ mouse position

        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //เหมือนแค่กลับที่เดิมเลย 55555555555555555555
        Debug.Log("Slot is: " + slot);

        //ตรงนี้อ่ะ ถ้าปล่อยไม่ถูกที่ คือมันจับ Slot ไม่ได้ จะกลายเป็น 0 แต่ถ้าจับได้ จะมีค่าของอันนั้นจ้า

        if(slot == 1000) //Bow
        {
            this.transform.SetParent(inv.currentBow.transform);
            this.transform.position = inv.currentBow.transform.position;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        else if(slot == 1001) //Sword
        {
            this.transform.SetParent(inv.currentSword.transform);
            this.transform.position = inv.currentSword.transform.position;
            GetComponent<CanvasGroup>().blocksRaycasts = true;

        }
        else if (slot == 1002) //Boot
        {
            this.transform.SetParent(inv.currentBoot.transform);
            this.transform.position = inv.currentBoot.transform.position;
            GetComponent<CanvasGroup>().blocksRaycasts = true;

        }
        else if (slot == 1003) //Cloth
        {
            this.transform.SetParent(inv.currentCloth.transform);
            this.transform.position = inv.currentCloth.transform.position;
            GetComponent<CanvasGroup>().blocksRaycasts = true;

        }
        //ตรงนี้ต้องมีอีก ELSE IF สำหรับ ARMOR อ่ะ
        else //นี่ของเก่า หลัง else ทั้งหมด
        {
            this.transform.SetParent(inv.slots[slot].transform); //อันนี้มันเหมือนไปหย่อนที่นั่นอะไรทำนองนั้น
            this.transform.position = inv.slots[slot].transform.position; //มันก็จะไปลงช่องนั้นเรียบร้อยจ้า !! SetParent อะไรเสร็จสรรพ และ ย้ายตำแหน่ง
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }

    
    public void OnPointerDown(PointerEventData eventData)
    {
        if(item!=null)
        {
            offset = eventData.position = new Vector2(this.transform.position.x, this.transform.position.y);
        }
    }
    

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.Activate(item);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.Deactivate();
    }
}
