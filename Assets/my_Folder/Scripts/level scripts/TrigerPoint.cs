using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class TrigerPoint : MonoBehaviour
{
    [SerializeField] private float newCurrentDirection;


    private Player_Controller playerControllerScript;
    private GameManager gameManagerScript;
    private bool rotationChanged = false;

    [SerializeField] private int[] rotationChangeIf90;
    [SerializeField] private int[] rotationChangeIf270;
    [SerializeField] private int[] rotationChangeIf0;
    [SerializeField] private int[] rotationChangeIf180;




    private void Start()
    {
        playerControllerScript = FindObjectOfType<Player_Controller>();
        gameManagerScript = FindObjectOfType<GameManager>();
        playerControllerScript.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        //TODO: dar la posibilidad de girar a un lado o a otro -- 2 direcciones posibles.
        //TODO: dar la opcion de girar o seguir recto.

        if (other.gameObject.CompareTag("Player") && rotationChanged == false )
        {

            if (gameManagerScript.currentDirection == 180)
            {

            }


            rotationChanged = true;
            

            playerControllerScript.enabled = false;
            gameManagerScript.RotatePlayer(newCurrentDirection);

            StartCoroutine(EnablePlayerScript());
            gameManagerScript.EnableTrigerPointCollider();
            DisableCollider();

           // this.enabled = false;
           
        }
       
   
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
