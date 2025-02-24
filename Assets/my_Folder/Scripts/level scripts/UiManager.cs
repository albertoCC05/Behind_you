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

    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundEfectsSlider;
    [SerializeField] private AudioSource musicAudiosource;
    [SerializeField] public AudioSource gunAudiosource;
    [SerializeField] public AudioSource monsterAudiosource;



    public int tutorialState;

    

    private void Start()
    {

        playerControllerScript = FindObjectOfType<Player_Controller>();
        gameManagerScript = FindObjectOfType<GameManager>();
        trigerPoint = FindObjectOfType<TrigerPoint>();

        pausePanel.SetActive(false);
        optionsPanel.SetActive(false);

        HideGameOverPanel();
        HideWinPanel();

        SetMusic();
       
    }

    public void SetMusic()
    {
        DataPersistance.LoadMusic();

        musicSlider.value = DataPersistance.musicValue;
        musicAudiosource.volume = DataPersistance.musicValue;
        soundEfectsSlider.value = DataPersistance.fxValue;
        gunAudiosource.volume = DataPersistance.fxValue;
        monsterAudiosource.volume = DataPersistance.fxValue;
        
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
        numberOfBullets.text = $"{numberOfBullet}";
    }
    public void HideWinPanel()
    {
        winPanel.SetActive(false);
    }
    public void ShowWinPanel()
    {
        winPanel.SetActive(true);
    }
    public void ExitButton()
    {
        SceneManager.LoadScene(0);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void GoToChapterSelection()
    {
        SceneManager.LoadScene(1);
    }
    public void PauseButton()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void ContinueButton()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void ShowOptionsButton()
    {
        optionsPanel.SetActive(true);
        pausePanel.SetActive(false);
    }
    public void MusicSlider()
    {
        musicAudiosource.volume = musicSlider.value;
    }
    public void SoundEfectsSlider()
    {
        monsterAudiosource.volume = soundEfectsSlider.value;
        gunAudiosource.volume = soundEfectsSlider.value;
    }
    public void HideOptionsButton()
    {
        optionsPanel.SetActive(false);
        DataPersistance.SaveMusic(musicSlider.value, soundEfectsSlider.value);
        pausePanel.SetActive(true);
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

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
        tutorialText.text = "QUE DEMONIOS LE PASA A ESTA CASA!!!? Menos mal que he podido escapar de esa cosa a tiempo, tengo que buscar una forma de salir de aquí, ( muévete con W,A,D ). ";
        speakerName.text = "Milia";

    }

    public void nextButtonFunction()
    {

       
        if (tutorialState == 1)
        {
            tutorialText.text = "Milia, Ven aquí, detrás de la puerta que tienes en frente, aquí estarás a salvo";
            speakerName.text = "???";
            tutorialState = 2;
        }
        else if (tutorialState == 2)
        {
            tutorialText.text = "AAAA!! ¿Quién eres!? ¿Y por qué sabes mi nombre!?";
            speakerName.text = "Milia";
            tutorialState = 3;
        }
        else if (tutorialState == 3)
        {
            tutorialText.text = "Luego te lo explico, pero primero busca la llave que abre esa puerta que tienes en frente para llegar hasta mí. Prometo que no intentaré matarte, a diferencia de esa cosa, puedes fiarte de mí. Te ayudaré a escapar. Y una última cosa, por lo que más quieras, no te des la vuelta";
            speakerName.text = "???";
            tutorialState = 4;
        }
        else if (tutorialState == 4)
        {
            tutorialText.text = "Esta bien...";
            speakerName.text = "Milia";
            tutorialState = 0;
        }
        else if (tutorialState == 5)
        {
            tutorialText.text = "¡Una linterna! Me servirá para ver mejor (puedes equipártela desde el inventario para alumbrar zonas oscuras)";
            speakerName.text = "Milia";
            tutorialState = 0;
        }
        else if (tutorialState == 6)
        {
            tutorialText.text = "La antigua pistola de papa de cuando trabajaba de policía y una bala, quizá pueda usarla contra esa cosa que me está siguiendo todo el rato (equípate la pistola desde el inventario, tal vez sirva contra el monstruo)";
            speakerName.text = "Milia";
            tutorialState = 0;
        }
        else if (tutorialState == 7)
        {
            tutorialText.text = "¡Al fin! La llave para salir de aquí, ahora a buscar la puerta. (busca la puerta de salida y ábrela equipándote la llave y acercándote a la puerta)";
            speakerName.text = "Milia";
            tutorialState = 0;
        }
        else if (tutorialState == 0)
        {
            HideTutorialPanel();
            tutorialState = 0;
            playerControllerScript.enabled = true;
        }

    }

    

}
