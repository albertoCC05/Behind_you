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
       

      
        currentDirection = ((float)Direction.Forward);
        leftLoseRotation = ((float)Direction.Left);
        rigthLoseRotation = ((float)Direction.Rigth);
        behindDirection = ((float)Direction.Back);

       


    }
    public void SetAngles()
    {

      
       

        if (currentDirection % 360 == ((float)Direction.Forward))
        {
            

            leftLoseRotation = ((float)Direction.Left);
            rigthLoseRotation = ((float)Direction.Rigth);
            behindDirection = ((float)Direction.Back);
        }
        if (currentDirection % 360 == ((float)Direction.Back))
        {
            

            rigthLoseRotation = ((float)Direction.Left);
            leftLoseRotation = ((float)Direction.Rigth);
            behindDirection = ((float)Direction.Forward);

           
        }

        if (currentDirection % 360 == ((float)Direction.Left))
        {
           

            rigthLoseRotation = ((float)Direction.Forward);
            leftLoseRotation = ((float)Direction.Back);
            behindDirection = ((float)Direction.Rigth);

        }

        if (currentDirection % 360 == ((float)Direction.Rigth))
        {
            
            leftLoseRotation = ((float)Direction.Forward);
            rigthLoseRotation = ((float)Direction.Back);
            behindDirection = ((float)Direction.Left);
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
