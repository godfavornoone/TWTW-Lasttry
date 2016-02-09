using UnityEngine;
using System.Collections;

public class PlayerTestByPop : MonoBehaviour {

    GameObject inventory;
    Inventory inventoryScript;

	// Use this for initialization
	void Start () {

        inventory = GameObject.Find("Inventory");
        inventoryScript = inventory.GetComponent<Inventory>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Item")
        {
            Debug.Log("Item damage: " + other.gameObject.GetComponent<Weapon_Status>().attack);

            if(Inventory.checkCollectedItem>0)
            {
                Inventory.checkCollectedItem--;
                Item addItem = new Item(other.gameObject.GetComponent<Weapon_Status>().attack, other.gameObject.GetComponent<Weapon_Status>().image, other.gameObject.GetComponent<Weapon_Status>().type, other.gameObject.GetComponent<Weapon_Status>().title, other.gameObject.GetComponent<Weapon_Status>().option, other.gameObject.GetComponent<Weapon_Status>().optionChance, other.gameObject.GetComponent<Weapon_Status>().hitpoint);
                Inventory.collectedItem.Add(addItem);
                Destroy(other.gameObject);
            }
        }
    }
}
