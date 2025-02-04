using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI numberOfBullets;
    [SerializeField] GameObject winPanel;
    
    private Player_Controller playerControllerScript;
    private GameManager gameManagerScript;
    private TrigerPoint trigerPoint;

    


   
    private void Start()
    {

        playerControllerScript = FindObjectOfType<Player_Controller>();
        gameManagerScript = FindObjectOfType<GameManager>();
        trigerPoint = FindObjectOfType<TrigerPoint>();

        HideGameOverPanel();
        HideWinPanel();
       
    }

    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
    private void HideGameOverPanel()
    {
        gameOverPanel.SetActive(false);
    }
    public void UpdateNumberOfBullets(int numberOfBullet)
    {
        numberOfBullets.text = $"Bullets = {numberOfBullet}";
    }
    public void HideWinPanel()
    {
        winPanel.SetActive(false);
    }
    public void ShowWinPanel()
    {
        winPanel.SetActive(true);
    }
   
    public void RestartLevelB()
    {
        SceneManager.LoadScene(0);
    }



    public void ChangeDirection(int direcction)
    {
        // direction = 1 = go straight
        //direction = 2 = left
        //direction = 3 rigth



        if (direcction == 1)
        {


            StartCoroutine(gameManagerScript.Rotation(gameManagerScript.currentDirection));
            playerControllerScript.playerIsChangingDirection = false;
           

        }
        if (direcction == 2)
        {
            if (gameManagerScript.currentDirection == Direction.Forward)
            {
                playerControllerScript.enabled = false;
                gameManagerScript.nextDirection = Direction.Left;
                StartCoroutine(gameManagerScript.Rotation(gameManagerScript.nextDirection));
                
              
            }
            else if (gameManagerScript.currentDirection == Direction.Rigth)
            {
                playerControllerScript.enabled = false;
                gameManagerScript.nextDirection = Direction.Forward;
                StartCoroutine(gameManagerScript.Rotation(gameManagerScript.nextDirection));
               
           

            }
            else if (gameManagerScript.currentDirection == Direction.Left)
            {
                playerControllerScript.enabled = false;
                gameManagerScript.nextDirection = Direction.Back;
                StartCoroutine(gameManagerScript.Rotation(gameManagerScript.nextDirection));
               
               

            }
            else if (gameManagerScript.currentDirection == Direction.Back)
            {
                playerControllerScript.enabled = false;
                gameManagerScript.nextDirection = Direction.Rigth;
                StartCoroutine(gameManagerScript.Rotation(gameManagerScript.nextDirection));
              
              

            }


            playerControllerScript.playerIsChangingDirection = false;

        }
        if (direcction == 3)
        {

            if (gameManagerScript.currentDirection == Direction.Forward)
            {
                playerControllerScript.enabled = false;
                gameManagerScript.nextDirection = Direction.Rigth;
                StartCoroutine(gameManagerScript.Rotation(gameManagerScript.nextDirection));
                
                

            }
            else if (gameManagerScript.currentDirection == Direction.Rigth)
            {
                playerControllerScript.enabled = false;
                gameManagerScript.nextDirection = Direction.Back;
                StartCoroutine(gameManagerScript.Rotation(gameManagerScript.nextDirection));
                
            
         
            }
            else if (gameManagerScript.currentDirection == Direction.Left)
            {
                playerControllerScript.enabled = false;
                gameManagerScript.nextDirection = Direction.Forward;
                StartCoroutine(gameManagerScript.Rotation(gameManagerScript.nextDirection));
               
           
            }
            else if (gameManagerScript.currentDirection == Direction.Back)
            {
                playerControllerScript.enabled = false;
                gameManagerScript.nextDirection = Direction.Left;
                StartCoroutine(gameManagerScript.Rotation(gameManagerScript.nextDirection));
                
             
            }



            playerControllerScript.playerIsChangingDirection = false;


             this.enabled = false;
        }

        Debug.Log(gameManagerScript.currentDirection);
        foreach (Button buton in trigerPoint.changeButtons)
        {
            buton.gameObject.SetActive(false);


        }
        trigerPoint.HideSelectDirectionPanel();
    }

}
