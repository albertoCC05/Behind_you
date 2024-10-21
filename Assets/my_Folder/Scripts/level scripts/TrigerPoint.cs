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

    public bool canOpenDoor = false;

    private void Start()
    {
        playerControllerScript = FindObjectOfType<Player_Controller>();
        gameManagerScript = FindObjectOfType<GameManager>();
        playerControllerScript.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && rotationChanged == false )
        {
            rotationChanged = true;
            

            playerControllerScript.enabled = false;
            gameManagerScript.RotatePlayer(newCurrentDirection);

            StartCoroutine(EnablePlayerScript());

           // this.enabled = false;
           
        }
       
   
    }
    

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && canOpenDoor == true ) 
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
        }
    }
  

}
