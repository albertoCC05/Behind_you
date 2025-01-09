using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class TrigerPoint : MonoBehaviour
{
    [SerializeField] private float newCurrentDirection;


    private Player_Controller playerControllerScript;
    private GameManager gameManagerScript;
    private bool rotationChanged = false;

    [SerializeField] private Button[] rotationChangeIf90Buttons;
    [SerializeField] private Button[] rotationChangeIf270Buttons;
    [SerializeField] private Button[] rotationChangeIf0Buttons;
    [SerializeField] private Button[] rotationChangeIf180Buttons;

  


    [SerializeField] private GameObject selectChangeDirectionPanel;
    [SerializeField] private Button[] changeButtons;

   



    private void Start()
    {
        playerControllerScript = FindObjectOfType<Player_Controller>();
        gameManagerScript = FindObjectOfType<GameManager>();
        playerControllerScript.enabled = true;

        selectChangeDirectionPanel.SetActive(false);



    }

    private void OnTriggerEnter(Collider other)
    {
        //TODO: dar la posibilidad de girar a un lado o a otro -- 2 direcciones posibles.
        //TODO: dar la opcion de girar o seguir recto.

        if (other.gameObject.CompareTag("Player") && rotationChanged == false )
        {
            ShowSelectDirectionPanel();

            if (gameManagerScript.currentDirection == ((float)Direction.Forward) )
            {
                Debug.Log($"direction = {360}");

                foreach (Button button in rotationChangeIf0Buttons)
                {
                  
                    button.gameObject.SetActive(true);


                }
                
            }
            if (gameManagerScript.currentDirection == ((float)Direction.Rigth))
            {
                Debug.Log($"direction = {90}");

                foreach (Button button in rotationChangeIf90Buttons)
                {

                    button.gameObject.SetActive(true);


                }

            }
            if (gameManagerScript.currentDirection == ((float)Direction.Left))
            {
                Debug.Log($"direction = {270}");

                foreach (Button button in rotationChangeIf270Buttons)
                {

                    button.gameObject.SetActive(true);


                }

            }
            if (gameManagerScript.currentDirection == ((float)Direction.Back))
            {
                Debug.Log($"direction = {180}");

                foreach (Button button in rotationChangeIf180Buttons)
                {

                    button.gameObject.SetActive(true);


                }

            }
           

       
            

         
        }
       
   
    }
    public void ChangeDirection(int direcction)
    {
        // direction = 1 = go straight
        //direction = 2 = left
        //direction = 3 rigth

       

        if (direcction == 1)
        {
           

            gameManagerScript.RotatePlayer(gameManagerScript.currentDirection);


        }
        if (direcction == 2)
        {
            if (gameManagerScript.currentDirection == ((float)Direction.Forward))
            {
                playerControllerScript.enabled = false;
                gameManagerScript.RotatePlayer(((float)Direction.Left));
                StartCoroutine(EnablePlayerScript());
                gameManagerScript.EnableTrigerPointCollider();
                DisableCollider();

            }
            else if (gameManagerScript.currentDirection == ((float)Direction.Rigth))
            {
                playerControllerScript.enabled = false;
                gameManagerScript.RotatePlayer(((float)Direction.Forward));
                StartCoroutine(EnablePlayerScript());
                gameManagerScript.EnableTrigerPointCollider();
                DisableCollider();
            }
            else if (gameManagerScript.currentDirection == ((float)Direction.Left))
            {
                playerControllerScript.enabled = false;
                gameManagerScript.RotatePlayer(((float)Direction.Back));
                StartCoroutine(EnablePlayerScript());
                gameManagerScript.EnableTrigerPointCollider();
                DisableCollider();
            }
            else if (gameManagerScript.currentDirection == ((float)Direction.Back))
            {
                playerControllerScript.enabled = false;
                gameManagerScript.RotatePlayer(((float)Direction.Rigth));
                StartCoroutine(EnablePlayerScript());
                gameManagerScript.EnableTrigerPointCollider();
                DisableCollider();
            }
        }
        if (direcction == 3)
        {

            if (gameManagerScript.currentDirection == ((float)Direction.Forward))
            {
                playerControllerScript.enabled = false;
                gameManagerScript.RotatePlayer(((float)Direction.Rigth));
                StartCoroutine(EnablePlayerScript());
                gameManagerScript.EnableTrigerPointCollider();
                DisableCollider();

            }
            else if (gameManagerScript.currentDirection == ((float)Direction.Rigth))
            {
                playerControllerScript.enabled = false;
                gameManagerScript.RotatePlayer(((float)Direction.Back));
                StartCoroutine(EnablePlayerScript());
                gameManagerScript.EnableTrigerPointCollider();
                DisableCollider();
            }
            else if (gameManagerScript.currentDirection == ((float)Direction.Left))
            {
                playerControllerScript.enabled = false;
                gameManagerScript.RotatePlayer(((float)Direction.Forward));
                StartCoroutine(EnablePlayerScript());
                gameManagerScript.EnableTrigerPointCollider();
                DisableCollider();
            }
            else if(gameManagerScript.currentDirection == ((float)Direction.Left))
            {
                playerControllerScript.enabled = false;
                gameManagerScript.RotatePlayer(((float)Direction.Left));
                StartCoroutine(EnablePlayerScript());
                gameManagerScript.EnableTrigerPointCollider();
                DisableCollider();
            }



         
            

            this.enabled = false;
        }

        Debug.Log(gameManagerScript.currentDirection);
        foreach (Button buton in changeButtons)
        {
            buton.gameObject.SetActive(false);

            
        }
        selectChangeDirectionPanel.SetActive(false);
    }
    private void ShowSelectDirectionPanel()
    {
        selectChangeDirectionPanel.SetActive(true);
    }
    
    

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && playerControllerScript.canOpenDoor == true ) 
        {
            DoorTriggerPoint();
        }
    }

    private void DoorTriggerPoint()
    {
        rotationChanged = true;
        Debug.Log("Hello");

        playerControllerScript.enabled = false;
        gameManagerScript.RotatePlayer(newCurrentDirection);

        StartCoroutine(EnablePlayerScript());

      
    }

    private IEnumerator EnablePlayerScript()
    {
        yield return new WaitForSeconds(1);

        playerControllerScript.enabled = true;
        rotationChanged = false;
       
        if (this.gameObject.CompareTag("Door"))
        {
            GameObject.Destroy(this.gameObject);
            gameManagerScript.EnableTrigerPointCollider();
        }
    }
    private void DisableCollider()
    {
        this.GetComponent<BoxCollider>().enabled = false;

       
    }
    
  

}
