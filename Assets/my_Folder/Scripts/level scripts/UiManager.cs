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

    [SerializeField] private GameObject tutorialPanel;

    [SerializeField] private TextMeshProUGUI tutorialText;
    [SerializeField] private TextMeshProUGUI speakerName;

    public int tutorialState;

    // 1 startTutorial == el primer panel que se muestra en el nivel 1 y funciona a modo de tutroial
    // 2 flashligth tutorial 
    //3 gun and bullets tutorial
    // 4 key tutorial

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
        foreach (Button button in trigerPoint.changeButtons)
        {
            button.gameObject.SetActive(false);


        }
        trigerPoint.HideSelectDirectionPanel();
    }

    public void ShowTutorialPanel()
    {

        tutorialPanel.SetActive(true);


    }
    public void HideTutorialPanel()
    {
        tutorialPanel.SetActive(false);
    }
    public void StartTutorialText()
    {
        tutorialState = 1;
        tutorialText.text = "arf... arf.. QUE DEMONIOS LE PASA A ESTA CASA!!!?, menos mal que he podido escapar de esa cosa a tiempo, tengo que buscar una forma de salir de aqui, muevete con W,A,D y";
        speakerName.text = "Milia";

    }

    public void nextButtonFunction()
    {


        if (tutorialState == 1)
        {
            tutorialText.text = "Milia, Ven aqui, aqui estaras a salvo";
            tutorialState = 2;
        }
        if (tutorialState == 2)
        {
            tutorialText.text = "AAAA!! Quien eres!? y porque sabes mi nombre!?";
            speakerName.text = "Milia";
        }
        if (tutorialState == 3)
        {
            tutorialText.text = "Luego te lo explico, pero primero busca la llave que abre esa puerta que tienes en frente para llegar hasta mi, prometo que no intentare matarte puedes fiarte de mi. te ayudare a escapar";
        }
        if (tutorialState == 4)
        {
            tutorialText.text = "Esta bien...";
            speakerName.text = "Milia";
            HideTutorialPanel();
            tutorialState = 0;
            playerControllerScript.enabled = true;
            
        }

    }

}
