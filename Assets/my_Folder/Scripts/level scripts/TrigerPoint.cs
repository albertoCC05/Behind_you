using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;

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

    public bool isChangingDirection;


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

        playerControllerScript.enabled = false;

        if (other.gameObject.CompareTag("Player") && rotationChanged == false )
        {
            ShowSelectDirectionPanel();

            isChangingDirection = true;

            other.gameObject.transform.position = new Vector3 (transform.position.x, other.gameObject.transform.position.y, transform.position.z);

            if (gameManagerScript.currentDirection == Direction.Forward )
            {
                Debug.Log($"direction = {360}");

                foreach (Button button in rotationChangeIf0Buttons)
                {
                  
                    button.gameObject.SetActive(true);


                }
                
            }
            if (gameManagerScript.currentDirection == Direction.Rigth)
            {
                Debug.Log($"direction = {90}");

                foreach (Button button in rotationChangeIf90Buttons)
                {

                    button.gameObject.SetActive(true);


                }

            }
            if (gameManagerScript.currentDirection == Direction.Left)
            {
                Debug.Log($"direction = {270}");

                foreach (Button button in rotationChangeIf270Buttons)
                {

                    button.gameObject.SetActive(true);


                }

            }
            if (gameManagerScript.currentDirection == Direction.Back)
            {
                Debug.Log($"direction = {180}");

                foreach (Button button in rotationChangeIf180Buttons)
                {

                    button.gameObject.SetActive(true);


                }

            }

            gameManagerScript.EnableTrigerPointCollider();
            DisableMeshRenderer();

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

 
    public void DisableMeshRenderer()
    {
        this.GetComponent<MeshRenderer>().enabled = false;

       
    }
    
  

}
