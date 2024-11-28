using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor.Search;
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


    private void Start()
    {
        HideInventory();
        isActive = false;
    }
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("ya existe una instancia ");
        }
        Instance = this;
    }
    private void Update()
    {
        
        if (Input.GetKeyUp(KeyCode.L))
        {
            ShowInventory();
        }

        
    }
    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
    }
    public void UpdateInventory(Item item)
    {
        
        for ( int index = 0; index < inventory.itemList.Count; index++)
        {
            inventoryTextArray[index].text = $"- {inventory.itemList[index].type}";
            inventoryButtonArray[index].interactable = true;
        }


    }
    public void ShowInventory()
    {

        
            inventoryPanel.SetActive(true);
            
        
       
        
    }
    public void HideInventory()
    {

        inventoryPanel.SetActive(false);


    }




}
