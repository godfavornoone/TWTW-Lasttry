using UnityEngine;
using System.Collections;

public class PlayerTestByPop : MonoBehaviour {

    GameObject inventory;
    Inventory inventoryScript;
    Game_Controller a;
    bool check = false;

	// Use this for initialization
	void Start () {

        inventory = GameObject.Find("Inventory");
        inventoryScript = inventory.GetComponent<Inventory>();
        a = GameObject.Find("Game_Controller").GetComponent<Game_Controller>();

    }
	
	// Update is called once per frame
	void Update () {
        
    }

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Item")
        {
           

            if(Inventory.checkCollectedItem>0)
            {
                Inventory.checkCollectedItem--;
                Item addItem = new Item(other.gameObject.GetComponent<Weapon_Status>().attack, other.gameObject.GetComponent<Weapon_Status>().image, other.gameObject.GetComponent<Weapon_Status>().type, other.gameObject.GetComponent<Weapon_Status>().title, other.gameObject.GetComponent<Weapon_Status>().option, other.gameObject.GetComponent<Weapon_Status>().optionChance, other.gameObject.GetComponent<Weapon_Status>().hitpoint);
                Inventory.collectedItem.Add(addItem);
                yield return new WaitForSeconds(0);
                Destroy(other.gameObject);
            }

            else //ไอเทมเต็มนะจ้ะ
            {
                Game_Controller.playerInThisMap.notify.SetActive(true);
                Game_Controller.playerInThisMap.notification.text = "Inventory is Full!";
                yield return new WaitForSeconds(3);
                Game_Controller.playerInThisMap.notify.SetActive(false);

            }
            
        }
    }

   
}
