using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiInventory : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] inventoryTextArray;
    [SerializeField] private Button[] inventoryButtonArray;

    [SerializeField] private GameObject inventoryPanel;
    private Inventory inventory;

    private bool isActive;

    public static UiInventory Instance { get; private set; }
    private Player_Controller playerController;

    [SerializeField] private TextMeshProUGUI currentItemText;


    private void Start()
    {

        playerController = FindObjectOfType<Player_Controller>();

        HideInventory();
        isActive = false;
        ChangeCurrentItemText();
        DesactivateAllButtonsAtStart();
    }
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("ya existe una instancia ");
        }
        Instance = this;
    }
  
    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
    }

    // Updates the inventory Ui when you get a new item.

    public void UpdateInventory(Item item)
    {
        
        for ( int index = 0; index < inventory.itemList.Count; index++)
        {
            inventoryTextArray[index].text = $"- {inventory.itemList[index].type}";
            inventoryButtonArray[index].interactable = true;
        }


    }
    private void DesactivateAllButtonsAtStart()
    {
        foreach (Button button in inventoryButtonArray)
        {
            button.interactable = false;
        }
    }

    //Shows th inventory panel

    public void ShowInventory()
    {

        
            inventoryPanel.SetActive(true);
            
        
       
        
    }

    //Hides the inventory panel

    public void HideInventory()
    {

        inventoryPanel.SetActive(false);


    }
    public void ReturnInventoryButton()
    {
        HideInventory();
    }

    //Equips an item when you pres his button on inventory panel

    public void UseItemButton(int CurrentItem)
    {
        playerController.SetCurrentItem(CurrentItem);
        Debug.Log(playerController.currentItem.type);
        ChangeCurrentItemText();
    }

    //Changes the text of the current item that you have equiped

    public void ChangeCurrentItemText()
    {
        currentItemText.text = $"Objeto: {playerController.currentItem.type}";
    }



}
