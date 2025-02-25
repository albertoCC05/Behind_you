using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    private Inventory inventory;
    private UiInventory inventoryUi;
    [SerializeField] public int itemType;
    
    // 1 = gun
    // 2 = flashligth
    // 3 = bullets
    // 4 = key

    private void Start()
    {
        inventory = FindObjectOfType<Player_Controller>().GetPlayerInventory();
        inventoryUi = FindObjectOfType<UiInventory>();
     

    }


   
    }












