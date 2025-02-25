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
            text.text = "QUE DEMONIOS LE PASA A ESTA CASA!!!? Menos mal que he podido escapar de esa cosa a tiempo, tengo que buscar una forma de salir de aqu�, ( mu�vete con W,A,D ). ";
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
            speakerName.text = "Algod�n";
            text.text = "Bien, hemos conseguido atravesar otra puerta m�s, puedo sentirlo, cada vez nos adentramos m�s en la maldici�n, sigamos asi";
        }
    }

    public void nextButtonFunction()
    {
        if (gameManagerScript.currentLevel == 1)
        {
            if (textState == 1)
            {
                text.text = "Milia, Ven aqu�, detr�s de la puerta que tienes en frente, aqu� estar�s a salvo";
                speakerName.text = "???";
                textState = 2;
            }
            else if (textState == 2)
            {
                text.text = "AAAA!! �Qui�n eres!? �Y por qu� sabes mi nombre!?";
                speakerName.text = "Milia";
                textState = 3;
            }
            else if (textState == 3)
            {
                text.text = "Luego te lo explico, pero primero busca la llave que abre esa puerta que tienes en frente para llegar hasta m�. Prometo que no intentar� matarte, a diferencia de esa cosa, puedes fiarte de m�. Te ayudar� a escapar. Y una �ltima cosa, por lo que m�s quieras, no te des la vuelta";
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
                text.text = "�Una linterna! Me servir� para ver mejor (puedes equip�rtela desde el inventario para alumbrar zonas oscuras)";
                speakerName.text = "Milia";
                textState = 0;
            }
            else if (textState == 6)
            {
                text.text = "La antigua pistola de papa de cuando trabajaba de polic�a y una bala, quiz� pueda usarla contra esa cosa que me est� siguiendo todo el rato (equ�pate la pistola desde el inventario, tal vez sirva contra el monstruo)";
                speakerName.text = "Milia";
                textState = 0;
            }
            else if (textState == 7)
            {
                text.text = "�Al fin! La llave para salir de aqu�, ahora a buscar la puerta. (busca la puerta de salida y �brela equip�ndote la llave y acerc�ndote a la puerta)";
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
                text.text = "Milia! me alegro de que hayas conseguido llegar aqui a salvo, pero no tenemos mucho tiempo, hay que terminar con esto r�pido";
                speakerName.text = "???";
                textState = 2;
            }
            else if (textState == 2)
            {
                text.text = "AAAA!! Otro peluche que habla!! atras, no me hagas da�o!!";
                speakerName.text = "Milia";
                textState = 3;
            }
            else if (textState == 3)
            {
                text.text = "Hey, tranquila, no voy a hacerte da�o, �no me reconoces? Soy yo Algod�n, tu juguete favorito cuando eras peque�a, siempre dorm�amos juntos. Esta casa est� afectada por una maldici�n que ha hecho que tus juguetes antiguos cobren vida";
                speakerName.text = "Algod�n";
                textState = 4;
            }
            else if (textState ==4)
            {
                text.text = "De hecho, ese monstruo que te persigue todo el rato es bigotitos, era de tus peluches favoritos, jugabas mucho con �l..";
                speakerName.text = "Algod�n";
                textState = 5;
            }
            else if (textState == 5)
            {
                text.text = "Un momento...��como que la casa esta malida, donde voy a vivir yo ahora?! ";
                speakerName.text = "Milia";
                textState = 6;
            }
            else if (textState == 6)
            {
                text.text = "No te preocupes, para eso vine a ayudarte. Hay m�s puertas como la que acabas de cruzar, pero est�n cerradas y hay que buscar las llaves para abrirlas, una vez cruces una puerta, avanzar�s en la maldici�n. Una vez llegues al final todo terminar�, o eso creo... ";
                speakerName.text = "Algod�n";
                textState = 7;
            }
            else if (textState == 7)
            {
                text.text = "�C�mo que \"creo\"? T� tampoco sabes c�mo arreglar esto, pues ya empezamos bien ";
                speakerName.text = "Milia";
                textState = 8;
            }
            else if (textState == 8)
            {
                text.text = "Lo siento, pero solo puede llegar hasta aqu�, as� que no s� qu� hay m�s adelante, pero tampoco tenemos otra opci�n. Una vez entras en esta casa, no se puede salir, ya lo he intentado";
                speakerName.text = "Algod�n";
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
                speakerName.text = "Algod�n";
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
