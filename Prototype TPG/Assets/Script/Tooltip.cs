using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour {

    private Item item;
    private string data;
    private GameObject tooltip;

    void Start()
    {
        tooltip = GameObject.Find("Tooltip");
        tooltip.SetActive(false);
    }

    void Update()
    {
        if(tooltip.activeSelf)
        {
            tooltip.transform.position = Input.mousePosition;
        }
    }

    public void Activate(Item item)
    {
        this.item = item;
        ConstructDataString();
        tooltip.SetActive(true);
    }
    public void Deactivate()
    {
        tooltip.SetActive(false);
    }

    public void ConstructDataString()
    {
        data = "<color=#d99a9a><b>" + item.title + "</b></color>\n\n"; 
        
        if(item.type == "sword" || item.type == "bow")
        {
            data += "Damage: " + item.damage.ToString() + "\n";
        }

        if (item.type == "cloth" || item.type == "boot")
        {
            data += "Hitpoint: " + item.hitpoint.ToString() + "\n";
        }

        if (item.option[0]==1 || item.option[1]==1 || item.option[2]==1 || item.option[3]==1)
        {
            data += "Option:" + "\n";
        }

        if(item.option[0]!=0)
        {
            data += "- Has " + item.optionChance[0] + " % That Word Will Be 1 Letter"+"\n";
        }
        if (item.option[1] != 0)
        {
            data += "- Has " + item.optionChance[1] + " % That Word Will Have Same Letter" + "\n";
        }
        if (item.option[2] != 0)
        {
            data += "- Has " + item.optionChance[2] + " % That Word Won't Change" + "\n";
        }
        if (item.option[3] != 0)
        {
            data += "- Has " + item.optionChance[3] + " % That Player Will Deal Critical Attack" + "\n";
        }
        tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
    }
}
