using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;

    private Transform itemContainer;
    private Transform itemImage;
    private void Awake()
    {
        itemContainer = transform.Find("container");
        itemImage = itemContainer.Find("image");

        Debug.Log(itemImage);
        Debug.Log(itemContainer);

    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        RefreshInventoryItems();
    }
    private void RefreshInventoryItems()
    {

        int x = 0;
        int y = 0;
        float itemSlotCellSize = 30f;

      

        foreach (Item item in inventory.GetItemList())
        {
           
            RectTransform itemImageRectTransform = Instantiate(itemImage, itemContainer).GetComponent<RectTransform>();
            RectTransform itemContainerRectTransform = Instantiate(itemContainer).GetComponent<RectTransform>();
            itemImageRectTransform.gameObject.SetActive(true);
            itemContainerRectTransform.gameObject.SetActive(true);
            itemContainerRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            itemImageRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            x = x+6;
            if (x> 36 )
            {
                x = 0;
                y = y+6;
            }
        }
    }
}
