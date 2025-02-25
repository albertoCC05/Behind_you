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

    [SerializeField] private GameObject[] playerHandsArray;
 



    private void Start()
    {
       gameManager = FindObjectOfType<GameManager>();
       triggerPointScript = FindObjectOfType<TrigerPoint>();
       uiInventory = FindObjectOfType<UiInventory>();
        uiManager = FindObjectOfType<UiManager>();
        inventory = new Inventory();
        UiInventory.Instance.SetInventory(inventory);

       currentItem = new Item { type = Item.ItemType.nada, amount = 1 }; ;

        HideAllHands();
        ShowIdleHand();

        rigthLimit = (gameManager.directionAngles[gameManager.currentDirection] + 90) % 360;
        leftLimit = (gameManager.directionAngles[gameManager.currentDirection] - 90) % 360;
    }
  
    private void Update()
    {

            Rotation();
        
       

       
       
     
    }
    private void FixedUpdate()
    {
       
        
            PlayerMovment();
     
    }


    //Movment of player 


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


    //Rotation of the player and detection  of game over

    private void Rotation()
    {
       // Debug.Log(transform.rotation.eulerAngles.y);

        horizontalInput = Input.GetAxis("Horizontal");

        if (playerIsChangingDirection == false)
        {
            transform.Rotate(Vector3.up * rotationPlayerSpeed * horizontalInput * Time.deltaTime);

         

            if ((Vector3.SignedAngle( gameManager.leftDirections[gameManager.currentDirection] , transform.forward, Vector3.up) + 360) % 360 > 180)
            {
               
                gameManager.CheckGameOver();
            }



        }

    }

  

    public Inventory GetPlayerInventory()
    {
        return inventory;
    }


    //Detection Collision with items to pick them

    private void OnTriggerEnter(Collider other)
    {

        

        if (other.gameObject.CompareTag("Item"))
        {
            if (other.GetComponent<ItemWorld>().itemType == 1)
            {
                Item saveItem = new Item { type = Item.ItemType.pistola, amount = 1 };

                inventory.AddItem(saveItem);
                uiInventory.UpdateInventory(saveItem);

                if (gameManager.currentLevel == 1)
                {
                    this.enabled = false;
                    uiManager.textState = 6;
                    uiManager.nextButtonFunction();
                    uiManager.ShowTextPanel();
                }

               
            }
            if (other.GetComponent<ItemWorld>().itemType == 2)
            {
                Item saveItem = new Item { type = Item.ItemType.linterna, amount = 1 };

                inventory.AddItem(saveItem);
                uiInventory.UpdateInventory(saveItem);

                if (gameManager.currentLevel == 1)
                {
                    this.enabled = false;
                    uiManager.textState = 5;
                    uiManager.nextButtonFunction();
                    uiManager.ShowTextPanel();
                }


            }
            if (other.GetComponent<ItemWorld>().itemType == 3)
            {
                Item saveItem = new Item { type = Item.ItemType.llave, amount = 1 };

                inventory.AddItem(saveItem);
                uiInventory.UpdateInventory(saveItem);


                if (gameManager.currentLevel == 1)
                {
                    this.enabled = false;
                    uiManager.textState = 7;
                    uiManager.nextButtonFunction();
                    uiManager.ShowTextPanel();
                }


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
        HideAllHands();

        if (currentItem.type == Item.ItemType.pistola) 
        {
            ShowGunHand();
        }
        if (currentItem.type == Item.ItemType.linterna)
        {
            ShowFlashligthHand();
        }
        if (currentItem.type == Item.ItemType.llave)
        {
            ShowKeyHand();
        }
    }


    //Functios for show the current hand of the player depending of the item tha you have equiped

    private void HideAllHands()
    {
        foreach (GameObject hand in playerHandsArray)
        {
            hand.SetActive(false);
        }
        Flashligth.SetActive(false);
    }
    

     private void ShowFlashligthHand()
    {
          
            Flashligth.SetActive(true);
            playerHandsArray[1].SetActive(true);
       
       
    }
    private void ShowIdleHand()
    {
        playerHandsArray[0].SetActive(true);
    }
    private void ShowGunHand()
    {
        playerHandsArray[3].SetActive(true);
    }
    private void ShowKeyHand()
    {
        playerHandsArray[2].SetActive(true);
    }
}
