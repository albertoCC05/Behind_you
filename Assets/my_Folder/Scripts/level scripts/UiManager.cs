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
    [SerializeField] private GameObject instructionsPanel; 

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
    public void HideInstrucctions()
    {
        Time.timeScale = 1f;
        instructionsPanel.SetActive(false);
    }
    private void ShowInstrucctions()
    {
        Time.timeScale = 0f;
        instructionsPanel.SetActive(true);
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


            gameManagerScript.RotatePlayer(gameManagerScript.currentDirection);
            playerControllerScript.playerIsChangingDirection = false;
           

        }
        if (direcction == 2)
        {
            if (gameManagerScript.currentDirection == 0)
            {
                playerControllerScript.enabled = false;
                gameManagerScript.RotatePlayer(270);
                StartCoroutine(trigerPoint.EnablePlayerScript());
              
            }
            else if (gameManagerScript.currentDirection == 90)
            {
                playerControllerScript.enabled = false;
                gameManagerScript.RotatePlayer(0f);
                StartCoroutine(trigerPoint.EnablePlayerScript());
           

            }
            else if (gameManagerScript.currentDirection == 270)
            {
                playerControllerScript.enabled = false;
                gameManagerScript.RotatePlayer(-180f);
                StartCoroutine(trigerPoint.EnablePlayerScript());
               

            }
            else if (gameManagerScript.currentDirection == 180)
            {
                playerControllerScript.enabled = false;
                gameManagerScript.RotatePlayer(90f);
                StartCoroutine(trigerPoint.EnablePlayerScript());
              

            }


            playerControllerScript.playerIsChangingDirection = false;

        }
        if (direcction == 3)
        {

            if (gameManagerScript.currentDirection == 0)
            {
                playerControllerScript.enabled = false;
                gameManagerScript.RotatePlayer(90f);
                StartCoroutine(trigerPoint.EnablePlayerScript());
                

            }
            else if (gameManagerScript.currentDirection == 90)
            {
                playerControllerScript.enabled = false;
                gameManagerScript.RotatePlayer(-180f);
                StartCoroutine(trigerPoint.EnablePlayerScript());
            
         
            }
            else if (gameManagerScript.currentDirection == 270)
            {
                playerControllerScript.enabled = false;
                gameManagerScript.RotatePlayer(0f);
                StartCoroutine(trigerPoint.EnablePlayerScript());
           
            }
            else if (gameManagerScript.currentDirection == 180)
            {
                playerControllerScript.enabled = false;
                gameManagerScript.RotatePlayer(270);
                StartCoroutine(trigerPoint.EnablePlayerScript());
             
            }



            playerControllerScript.playerIsChangingDirection = false;


            // this.enabled = false;
        }

        Debug.Log(gameManagerScript.currentDirection);
        foreach (Button buton in trigerPoint.changeButtons)
        {
            buton.gameObject.SetActive(false);


        }
        trigerPoint.HideSelectDirectionPanel();
    }

}
