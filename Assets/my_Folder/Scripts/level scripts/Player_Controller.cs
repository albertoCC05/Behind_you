using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using static Item;

public class Player_Controller : MonoBehaviour
{
    //movment variables

    [SerializeField] private float playerSpeed;
    [SerializeField] private float rotationPlayerSpeed;
    private float horizontalInput;
    private float verticalInput;
    [SerializeField] private Rigidbody playerRb;
    

    //Script references

    private GameManager gameManager;
    private TrigerPoint triggerPointScript;
    private UiInventory uiInventory;
    private UiManager uiManager;
   

  [SerializeField]  private LayerMask doorLayerMask;

    private Inventory inventory;

    public Item currentItem;

    public bool canOpenDoor = false;

    [SerializeField]  private GameObject Flashligth;

    public int numberOfBullets;

    public bool playerIsChangingDirection;

    private int rigthLimit;
   private int leftLimit;




    private void Start()
    {
       gameManager = FindObjectOfType<GameManager>();
       triggerPointScript = FindObjectOfType<TrigerPoint>();
       uiInventory = FindObjectOfType<UiInventory>();
        uiManager = FindObjectOfType<UiManager>();
        inventory = new Inventory();
        UiInventory.Instance.SetInventory(inventory);

       currentItem = new Item { type = Item.ItemType.nothing, amount = 1 }; ;

        rigthLimit = (gameManager.directionAngles[gameManager.currentDirection] + 90) % 360;
        leftLimit = (gameManager.directionAngles[gameManager.currentDirection] - 90) % 360;
    }
  
    private void Update()
    {

            Rotation();
        
       

        RaycastDoorDetection();
       
     
    }
    private void FixedUpdate()
    {
       
        
            PlayerMovment();
     
    }




    private void PlayerMovment()
    {


        verticalInput = Input.GetAxis("Vertical");
        Vector3 movment = (verticalInput * transform.forward).normalized * playerSpeed;
        

        if (playerIsChangingDirection == false)
        {
            if (verticalInput >= 0)
            {
                //  transform.Translate(Vector3.forward * playerSpeed * verticalInput * Time.deltaTime);

                playerRb.AddForce(transform.forward * playerSpeed * verticalInput * Time.deltaTime);



            }
            else
            {
                playerRb.velocity = Vector3.zero;
            }
        }

       
    }
   
   

    private void Rotation()
    {
       // Debug.Log(transform.rotation.eulerAngles.y);

        horizontalInput = Input.GetAxis("Horizontal");

        if (playerIsChangingDirection == false)
        {
            transform.Rotate(Vector3.up * rotationPlayerSpeed * horizontalInput * Time.deltaTime);

            Debug.Log((gameManager.directionAngles[gameManager.currentDirection] + 90) % 360 );
            Debug.Log((gameManager.directionAngles[gameManager.currentDirection] + 270) % 360);

            if ((Vector3.SignedAngle( gameManager.leftDirections[gameManager.currentDirection] , transform.forward, Vector3.up) + 360) % 360 > 180)
            {
                gameManager.CheckGameOver();
            }



        }

    }

    private void RaycastDoorDetection()
    {
        bool raycastDoor = Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 1.5f, doorLayerMask);

        Color raycastHitColor = (raycastDoor) ? Color.green : Color.magenta;
        Debug.DrawRay(transform.position, transform.forward * 1.5f, raycastHitColor);

        if (raycastDoor)
        {
            canOpenDoor = true;
        }
        else
        {
           canOpenDoor = false;
        }
    }

    public Inventory GetPlayerInventory()
    {
        return inventory;
    }

    private void OnTriggerEnter(Collider other)
    {

        

        if (other.gameObject.CompareTag("Item"))
        {
            if (other.GetComponent<ItemWorld>().itemType == 1)
            {
                Item saveItem = new Item { type = Item.ItemType.gun, amount = 1 };

                inventory.AddItem(saveItem);
                uiInventory.UpdateInventory(saveItem);

               
            }
            if (other.GetComponent<ItemWorld>().itemType == 2)
            {
                Item saveItem = new Item { type = Item.ItemType.flashligth, amount = 1 };

                inventory.AddItem(saveItem);
                uiInventory.UpdateInventory(saveItem);

                
            }
            if (other.GetComponent<ItemWorld>().itemType == 3)
            {
                Item saveItem = new Item { type = Item.ItemType.key, amount = 1 };

                inventory.AddItem(saveItem);
                uiInventory.UpdateInventory(saveItem);

               
            }
            if (other.GetComponent<ItemWorld>().itemType == 4)
            {

                numberOfBullets++;
                uiManager.UpdateNumberOfBullets(numberOfBullets);

              
            }
            Destroy(other.gameObject);

        }
    }
    
   public void SetCurrentItem(int SetItem)
   {
        currentItem = inventory.itemList[SetItem];
        FlashligthEffect();
   }

   public void FlashligthEffect()
    {
        if (currentItem.type == Item.ItemType.flashligth)
        {
            Flashligth.SetActive(true);
        }
        else
        {
            Flashligth.SetActive(false);
        }

       
    }
}
