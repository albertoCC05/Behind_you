using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isGameOver;
    private UiManager uiManager;
    private TrigerPoint trigerPointScript;

    [SerializeField] private GameObject playerReference;

    public float leftLoseRotation;
    public float rigthLoseRotation;
    public float currentDirection;
    public float behindDirection;

    public float currentDirection2;
    


    
    

    private void Start()
    {
        uiManager = FindObjectOfType<UiManager>();
        isGameOver = false;
        Time.timeScale = 1;
        StartSetLoseAngles();
        Debug.Log(currentDirection2);
    }

    public void RotatePlayer(float rotationChange)
    {
        Debug.Log($"currentDirection2 {currentDirection2}");
        Debug.Log($"rotationChange {rotationChange}");
        playerReference.transform.rotation = Quaternion.Euler(playerReference.transform.rotation.x, currentDirection2 + rotationChange, playerReference.transform.rotation.z);
       
        currentDirection = playerReference.transform.rotation.eulerAngles.y;
        currentDirection2 = playerReference.transform.rotation.eulerAngles.y;
        SetAngles();
    }
   
    private void StartSetLoseAngles()
    {
        // positiveLoseRotation = (playerReference.transform.rotation.eulerAngles.y + 0.90f) * Mathf.Rad2Deg;
        // negativeLoseRotation = (playerReference.transform.rotation.eulerAngles.y  - 0.90f) * Mathf.Rad2Deg; 

        currentDirection2 = playerReference.transform.rotation.eulerAngles.y;
        currentDirection = 360;
        leftLoseRotation = 270;
        rigthLoseRotation = 90;
        behindDirection = 180;

        
    }
    public void SetAngles()
    {

        Debug.Log($"currentDirection {currentDirection}");
       

        if (currentDirection % 360 == 0)
        {
            Debug.Log("caso 360");

            leftLoseRotation = 270;
            rigthLoseRotation = 90;
            behindDirection = 180;
        }
        if (currentDirection % 360 == 180)
        {
            Debug.Log("caso 180");

            rigthLoseRotation = 270;
            leftLoseRotation = 90;
            behindDirection = 360;

           
        }

        if (currentDirection % 360 == 270)
        {
            Debug.Log("caso 270");

            rigthLoseRotation = 0;
            leftLoseRotation = 180;
            behindDirection = 90;

        }

        if (currentDirection % 360 == 90)
        {
            Debug.Log("caso 90");

            leftLoseRotation = 360;
            rigthLoseRotation = 180;
            behindDirection = 270;
        }

        Debug.Log(currentDirection2);
        

       // if ( leftLoseRotation == 0 )
        {
            // leftLoseRotation = 360;
        }
      //  if (rigthLoseRotation == 0)
        {
          //  rigthLoseRotation = 360;
        }


      
       

    }
    public void SetGameOver()
    {
        isGameOver = true;
        uiManager.ShowGameOverPanel();
        Time.timeScale = 0;
    }
  
}
