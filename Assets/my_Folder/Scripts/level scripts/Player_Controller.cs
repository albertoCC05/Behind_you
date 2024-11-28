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


    

  [SerializeField]  private LayerMask doorLayerMask;

    private Inventory inventory;
    




    private void Start()
    {
       gameManager = FindObjectOfType<GameManager>();
       triggerPointScript = FindObjectOfType<TrigerPoint>();
       uiInventory = FindObjectOfType<UiInventory>();
        inventory = new Inventory();
        UiInventory.Instance.SetInventory(inventory);

       
        

    }
    private void Awake()
    {
        
       
    }
    private void Update()
    {
        PlayerMovment();
        Rotation();

        RaycastDoorDetection();
     
    }

  
   

    private void PlayerMovment()
    {
        verticalInput = Input.GetAxis("Vertical");
        Vector3 movment = (verticalInput * transform.forward).normalized * playerSpeed;


        if (verticalInput >= 0 )
        {
            //  transform.Translate(Vector3.forward * playerSpeed * verticalInput * Time.deltaTime);

            playerRb.AddForce(transform.forward * playerSpeed * verticalInput * Time.deltaTime);
            

            
        }
        else
        {
            playerRb.velocity = Vector3.zero;
        }
    }
   
   

    private void Rotation()
    {
       // Debug.Log(transform.rotation.eulerAngles.y);

        horizontalInput = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up * rotationPlayerSpeed * horizontalInput * Time.deltaTime);

        float currentDirection = gameManager.currentDirection;
        float loseDirectionLeft = gameManager.leftLoseRotation;
        float loseDirectionRigth = gameManager.rigthLoseRotation;
        float behindDirection = gameManager.behindDirection;
        float playerDirection = transform.rotation.eulerAngles.y;
       
        if(currentDirection == 180)
        {
            if (playerDirection >= loseDirectionRigth && playerDirection <= behindDirection)
            {
                gameManager.SetGameOver();
            }
            if (playerDirection <= loseDirectionLeft && playerDirection >= 0)
            {
                gameManager.SetGameOver();
            }
        }
        else
        {
            if (playerDirection >= loseDirectionRigth && playerDirection <= behindDirection)
            {
                gameManager.SetGameOver();
            }
            if (playerDirection <= loseDirectionLeft && playerDirection >= behindDirection)
            {
                gameManager.SetGameOver();
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
            triggerPointScript.canOpenDoor = true;
        }
        else
        {
            triggerPointScript.canOpenDoor = false;
        }
    }

    public Inventory GetPlayerInventory()
    {
        return inventory;
    }

    private void OnTriggerEnter(Collider other)
    {

        ;

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
                Item saveItem = new Item { type = Item.ItemType.bullets, amount = 1 };

                inventory.AddItem(saveItem);
                uiInventory.UpdateInventory(saveItem);
            }
            if (other.GetComponent<ItemWorld>().itemType == 4)
            {
                Item saveItem = new Item { type = Item.ItemType.key, amount = 1 };

                Debug.Log(inventory);

                inventory.AddItem(saveItem);
                uiInventory.UpdateInventory(saveItem);



            }
        }
    }
}
