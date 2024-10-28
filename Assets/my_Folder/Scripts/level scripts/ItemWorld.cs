using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] private int itemType;
    

    // 1 = gun
    // 2 = flashligth
    // 3 = bullets
    // 4 = key


    private void Start()
    {
        inventory = FindObjectOfType<Player_Controller>().GetPlayerInventory();
      //  Debug.Log(FindObjectOfType<Player_Controller>().GetPlayerInventory());

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {      
            if (itemType == 1)
            {
                inventory.AddItem(new Item { type = Item.ItemType.gun, amount = 1 });
            }
            if (itemType == 2)
            {
                inventory.AddItem(new Item { type = Item.ItemType.flashligth, amount = 1 });
            }
            if (itemType == 3)
            {
                inventory.AddItem(new Item { type = Item.ItemType.bullets, amount = 1 });
            }
            if (itemType == 4)
            {
                inventory.AddItem(new Item { type = Item.ItemType.key, amount = 1 });
            }
        }
    }











}
