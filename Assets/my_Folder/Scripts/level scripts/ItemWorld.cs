using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    private Inventory inventory;


    private void Start()
    {
        //inventory = FindObjectOfType<Player_Controller>().GetPlayerInventory();
        Debug.Log(FindObjectOfType<Player_Controller>().GetPlayerInventory());

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           
            inventory.AddItem(new Item { type = Item.ItemType.key, amount = 1 });



        }
    }











}
