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

    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI speakerName;

    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundEfectsSlider;
    [SerializeField] private AudioSource musicAudiosource;
    [SerializeField] public AudioSource gunAudiosource;
    [SerializeField] public AudioSource monsterAudiosource;



    public int textState;

    

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


    public void ShowTextPanel()
    {

        tutorialPanel.SetActive(true);


    }
    public void HideTextPanel()
    {
        tutorialPanel.SetActive(false);
    }
   
    public void StartText()
    {
        if (gameManagerScript.currentLevel == 1)
        {
            textState = 1;
            text.text = "QUE DEMONIOS LE PASA A ESTA CASA!!!? Menos mal que he podido escapar de esa cosa a tiempo, tengo que buscar una forma de salir de aquí, ( muévete con W,A,D ). ";
            speakerName.text = "Milia";
        }
        if (gameManagerScript.currentLevel == 2)
        {
            textState = 1;
            speakerName.text = "";
            text.text = "Al cruzar la puerta, ves al otro lado a un conejo de peluche el cual te empieza a hablar en cuanto te ve";
        }
        if(gameManagerScript.currentLevel == 3)
        {
            textState = 1;
            speakerName.text = "Algodón";
            text.text = "Bien, hemos conseguido atravesar otra puerta más, puedo sentirlo, cada vez nos adentramos más en la maldición, sigamos asi";
        }
    }

    public void nextButtonFunction()
    {
        if (gameManagerScript.currentLevel == 1)
        {
            if (textState == 1)
            {
                text.text = "Milia, Ven aquí, detrás de la puerta que tienes en frente, aquí estarás a salvo";
                speakerName.text = "???";
                textState = 2;
            }
            else if (textState == 2)
            {
                text.text = "AAAA!! ¿Quién eres!? ¿Y por qué sabes mi nombre!?";
                speakerName.text = "Milia";
                textState = 3;
            }
            else if (textState == 3)
            {
                text.text = "Luego te lo explico, pero primero busca la llave que abre esa puerta que tienes en frente para llegar hasta mí. Prometo que no intentaré matarte, a diferencia de esa cosa, puedes fiarte de mí. Te ayudaré a escapar. Y una última cosa, por lo que más quieras, no te des la vuelta";
                speakerName.text = "???";
                textState = 4;
            }
            else if (textState == 4)
            {
                text.text = "Esta bien...";
                speakerName.text = "Milia";
                textState = 0;
            }
            else if (textState == 5)
            {
                text.text = "¡Una linterna! Me servirá para ver mejor (puedes equipártela desde el inventario para alumbrar zonas oscuras)";
                speakerName.text = "Milia";
                textState = 0;
            }
            else if (textState == 6)
            {
                text.text = "La antigua pistola de papa de cuando trabajaba de policía y una bala, quizá pueda usarla contra esa cosa que me está siguiendo todo el rato (equípate la pistola desde el inventario, tal vez sirva contra el monstruo)";
                speakerName.text = "Milia";
                textState = 0;
            }
            else if (textState == 7)
            {
                text.text = "¡Al fin! La llave para salir de aquí, ahora a buscar la puerta. (busca la puerta de salida y ábrela equipándote la llave y acercándote a la puerta)";
                speakerName.text = "Milia";
                textState = 0;
            }
            else if (textState == 0)
            {
                HideTextPanel();
                textState = 0;
                playerControllerScript.enabled = true;
            }


        }
        if (gameManagerScript.currentLevel == 2)
        {
            if (textState == 1)
            {
                text.text = "Milia! me alegro de que hayas conseguido llegar aqui a salvo, pero no tenemos mucho tiempo, hay que terminar con esto rápido";
                speakerName.text = "???";
                textState = 2;
            }
            else if (textState == 2)
            {
                text.text = "AAAA!! Otro peluche que habla!! atras, no me hagas daño!!";
                speakerName.text = "Milia";
                textState = 3;
            }
            else if (textState == 3)
            {
                text.text = "Hey, tranquila, no voy a hacerte daño, ¿no me reconoces? Soy yo Algodón, tu juguete favorito cuando eras pequeña, siempre dormíamos juntos. Esta casa está afectada por una maldición que ha hecho que tus juguetes antiguos cobren vida";
                speakerName.text = "Algodón";
                textState = 4;
            }
            else if (textState ==4)
            {
                text.text = "De hecho, ese monstruo que te persigue todo el rato es bigotitos, era de tus peluches favoritos, jugabas mucho con él..";
                speakerName.text = "Algodón";
                textState = 5;
            }
            else if (textState == 5)
            {
                text.text = "Un momento...¡¿como que la casa esta malida, donde voy a vivir yo ahora?! ";
                speakerName.text = "Milia";
                textState = 6;
            }
            else if (textState == 6)
            {
                text.text = "No te preocupes, para eso vine a ayudarte. Hay más puertas como la que acabas de cruzar, pero están cerradas y hay que buscar las llaves para abrirlas, una vez cruces una puerta, avanzarás en la maldición. Una vez llegues al final todo terminará, o eso creo... ";
                speakerName.text = "Algodón";
                textState = 7;
            }
            else if (textState == 7)
            {
                text.text = "¿Cómo que \"creo\"? Tú tampoco sabes cómo arreglar esto, pues ya empezamos bien ";
                speakerName.text = "Milia";
                textState = 8;
            }
            else if (textState == 8)
            {
                text.text = "Lo siento, pero solo puede llegar hasta aquí, así que no sé qué hay más adelante, pero tampoco tenemos otra opción. Una vez entras en esta casa, no se puede salir, ya lo he intentado";
                speakerName.text = "Algodón";
                textState = 9;
            }
            else if (textState == 9)
            {
                text.text = "Esta bien, busquemos la salida, cuento con tu ayuda";
                speakerName.text = "Milia";
                textState = 10;
            }
            else if (textState == 10)
            {
                text.text = "Por supuesto";
                speakerName.text = "Algodón";
                textState = 0;
            }
            else if (textState == 0)
            {
                HideTextPanel();
                textState = 0;
                playerControllerScript.enabled = true;
            }


        }
        if (gameManagerScript.currentLevel == 3)
        {
            if (textState == 1)
            {
                text.text = "Espero que no falte mucho, me aterra este sitio";
                speakerName.text = "Milia";
                textState = 0;
            }
            else if (textState == 0)
            {
                HideTextPanel();
                textState = 0;
                playerControllerScript.enabled = true;
            }

        }

       

    }

    

}
