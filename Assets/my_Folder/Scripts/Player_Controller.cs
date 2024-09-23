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
    private bool isGameOver;

    // prueba de game over

    [SerializeField] private GameObject gameOverPanel;

    private void Start()
    {
        gameOverPanel.SetActive(false);
    }
    private void Update()
    {
        PlayerMovment();
        PlayerRotation();
        GameOver();
        Debug.Log(isGameOver);

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
        if (transform.rotation.y <= -90f || transform.rotation.y >= 90f )
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            isGameOver = true;

        }
    }
}
