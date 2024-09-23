using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    //movment variables

    [SerializeField] private float playerSpeed;
    [SerializeField] private float rotationPlayerSpeed;
    private float horizontalInput;
     private float verticalInput;

    private void Start()
    {
        
    }
    private void Update()
    {
        PlayerMovment();
        PlayerRotation();
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
}
