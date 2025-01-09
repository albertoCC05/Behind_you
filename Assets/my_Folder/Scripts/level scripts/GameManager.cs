using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public enum Direction
{
    Forward = 0,
    Back = 180,
    Rigth = 90,
    Left = 270,

}

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

    

    private Player_Controller playerController;

    public GameObject[] trigerPointsArray;

    


    
    

    private void Start()
    {
        uiManager = FindObjectOfType<UiManager>();
        playerController = FindObjectOfType<Player_Controller>();
        isGameOver = false;
        Time.timeScale = 1;
        StartSetLoseAngles();

        Debug.Log(currentDirection);
        
    }

    public void RotatePlayer(float rotationChange)
    {

        

        playerReference.transform.rotation = Quaternion.Euler(playerReference.transform.rotation.x, rotationChange, playerReference.transform.rotation.z);

        currentDirection = playerReference.transform.rotation.eulerAngles.y;
     
        SetAngles();
    }
    public void RotatePlayerGun(float rotationChange)
    {
        //TODO: quiza esto deba estar en otro script.

        playerReference.transform.rotation = Quaternion.Euler(playerReference.transform.rotation.x, currentDirection + rotationChange, playerReference.transform.rotation.z);

        currentDirection = playerReference.transform.rotation.eulerAngles.y;

      
       

        SetAngles();
    }
   
    private void StartSetLoseAngles()
    {
       

      
        currentDirection = 0;
        leftLoseRotation = 270;
        rigthLoseRotation = 90;
        behindDirection = 180;

       


    }
    public void SetAngles()
    {

      
       

        if (currentDirection % 360 == ((float)Direction.Forward))
        {
            

            leftLoseRotation = 270;
            rigthLoseRotation = 90;
            behindDirection = 180;
        }
        if (currentDirection % 360 == ((float)Direction.Back))
        {
            

            rigthLoseRotation = 270;
            leftLoseRotation = 90;
            behindDirection = 360;

           
        }

        if (currentDirection % 360 == ((float)Direction.Left))
        {
           

            rigthLoseRotation = 0;
            leftLoseRotation = 180;
            behindDirection = 90;

        }

        if (currentDirection % 360 == ((float)Direction.Rigth))
        {
            
            leftLoseRotation = 360;
            rigthLoseRotation = 180;
            behindDirection = 270;
        }

        
        

  


      
       

    }

    public void EnableTrigerPointCollider()
    {
        foreach (GameObject triggerP in trigerPointsArray)
        {
            triggerP.GetComponent<BoxCollider>().enabled = true;
        }
    }
    public void CheckGameOver()
    {

        if (playerController.currentItem.type == Item.ItemType.gun && playerController.numberOfBullets > 0)
        {
            RotatePlayerGun(-180);
            playerController.numberOfBullets--;
            uiManager.UpdateNumberOfBullets(playerController.numberOfBullets);
            EnableTrigerPointCollider();
        }
        else
        {
            isGameOver = true;
            uiManager.ShowGameOverPanel();
            Time.timeScale = 0;
        }
     


    }
    public void Win()
    {
        Time.timeScale = 0;
        uiManager.ShowWinPanel();
    }
  
}
