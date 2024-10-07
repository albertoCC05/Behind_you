using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Player_Controller : MonoBehaviour
{
    //movment variables

    [SerializeField] private float playerSpeed;
    [SerializeField] private float rotationPlayerSpeed;
    private float horizontalInput;
    private float verticalInput;

    //Script references

    private GameManager gameManager;
    private TrigerPoint triggerPointScript;


    //

  [SerializeField]  private LayerMask doorLayerMask;






    private void Start()
    {
       gameManager = FindObjectOfType<GameManager>();
       triggerPointScript = FindObjectOfType<TrigerPoint>();



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
        
        if (verticalInput >= 0 )
        {
            transform.Translate(Vector3.forward * playerSpeed * verticalInput * Time.deltaTime);
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
   
    

   
}
