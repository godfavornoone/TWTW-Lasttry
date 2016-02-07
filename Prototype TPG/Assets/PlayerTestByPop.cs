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

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Item")
        {
            Debug.Log("Item damage: " + other.gameObject.GetComponent<Weapon_Status>().attack);
            inventoryScript.addItem(other.gameObject);
            Destroy(other.gameObject);
        }
    }
}
