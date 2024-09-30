using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    //movment variables

    [SerializeField] private float playerSpeed;
    [SerializeField] private float rotationPlayerSpeed;
    private float horizontalInput;
    private float verticalInput;

    //Script references

    private GameManager gameManager;




    // prueba de game over

   
    

    private void Start()
    {
       gameManager = FindObjectOfType<GameManager>();
      


    }
    private void Update()
    {
        PlayerMovment();
        PlayerRotation();
        GameOver();

        

        
        

    }

  
   

    private void PlayerMovment()
    {
        verticalInput = Input.GetAxis("Vertical");
        
        if (verticalInput >= 0 )
        {
            transform.Translate(Vector3.forward * playerSpeed * verticalInput * Time.deltaTime);
        }
    }
   
    private void PlayerRotation()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        
            transform.Rotate(Vector3.up * rotationPlayerSpeed * horizontalInput * Time.deltaTime);
       
       if ( horizontalInput > 0 )
        {
            float degrees = transform.rotation.eulerAngles.y;

            if (degrees >= gameManager.positiveLoseRotation)
            {
                Debug.Log($"PositiveDetection{gameManager.positiveLoseRotation} AAAA {transform.rotation.eulerAngles.y}");
                //  Debug.Log(degrees);


                 gameManager.SetGameOver();


            }
        }
        if (horizontalInput < 0)
        {
            float degrees = transform.rotation.eulerAngles.y;

            if (degrees <= gameManager.negativeLoseRotation)
            {
                Debug.Log("NegativeDetection");
                // Debug.Log(degrees);
                 gameManager.SetGameOver();


            }
        }

    }

 
   
    

    private void GameOver()
    {
        float degrees = transform.rotation.eulerAngles.y;

        if ( degrees >= gameManager.positiveLoseRotation )
        {
            Debug.Log($"PositiveDetection{gameManager.positiveLoseRotation} AAAA {transform.rotation.eulerAngles.y}");
          //  Debug.Log(degrees);
            

          //  gameManager.SetGameOver();


        }
        if (degrees <= gameManager.negativeLoseRotation )
        {
            Debug.Log("NegativeDetection");
           // Debug.Log(degrees);
            // gameManager.SetGameOver();


        }
    }
}
