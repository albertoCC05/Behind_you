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

    private float losePositiveRotations = 0.90f;
    private float loseNegativeRotations = -0.90f;
    

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
        
    }

 
   
    

    private void GameOver()
    {
        

        if (transform.rotation.y <= loseNegativeRotations || transform.rotation.y >= losePositiveRotations )
        {

            gameManager.SetGameOver();
            

        }
    }
}
