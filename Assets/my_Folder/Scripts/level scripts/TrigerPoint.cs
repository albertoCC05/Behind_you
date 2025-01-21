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
    [SerializeField] public Button[] changeButtons;

   



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

        playerControllerScript.playerIsChangingDirection = true;

        if (other.gameObject.CompareTag("Player") && rotationChanged == false )
        {
            ShowSelectDirectionPanel();

            if (gameManagerScript.currentDirection == 0 )
            {
                Debug.Log($"direction = {360}");

                foreach (Button button in rotationChangeIf0Buttons)
                {
                  
                    button.gameObject.SetActive(true);


                }
                
            }
            if (gameManagerScript.currentDirection == 90)
            {
                Debug.Log($"direction = {90}");

                foreach (Button button in rotationChangeIf90Buttons)
                {

                    button.gameObject.SetActive(true);


                }

            }
            if (gameManagerScript.currentDirection == 270)
            {
                Debug.Log($"direction = {270}");

                foreach (Button button in rotationChangeIf270Buttons)
                {

                    button.gameObject.SetActive(true);


                }

            }
            if (gameManagerScript.currentDirection == 180)
            {
                Debug.Log($"direction = {180}");

                foreach (Button button in rotationChangeIf180Buttons)
                {

                    button.gameObject.SetActive(true);


                }

            }

            gameManagerScript.EnableTrigerPointCollider();
            DisableCollider();

        }

    }
  
    public void ShowSelectDirectionPanel()
    {
        selectChangeDirectionPanel.SetActive(true);
    }
    public void HideSelectDirectionPanel()
    {
        selectChangeDirectionPanel.SetActive(false);
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

    public IEnumerator EnablePlayerScript()
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
    public void DisableCollider()
    {
        this.GetComponent<BoxCollider>().enabled = false;

       
    }
    
  

}
