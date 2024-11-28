using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory 
{
    public List<Item> itemList;


    public Inventory()
    {
         itemList = new List<Item>();
       
    }
    public void AddItem(Item item)
    {
        itemList.Add(item);
        Debug.Log(item.type);

    }
   
}
