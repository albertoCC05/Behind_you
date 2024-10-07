using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerPoint : MonoBehaviour
{
    [SerializeField] private float newCurrentDirection;

    private Player_Controller playerControllerScript;
    private GameManager gameManagerScript;
    private bool rotationChanged = false;

    private void Start()
    {
        playerControllerScript = FindObjectOfType<Player_Controller>();
        gameManagerScript = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && rotationChanged == false)
        {
            rotationChanged = true;
            Debug.Log("Hello");

            playerControllerScript.enabled = false;
            gameManagerScript.RotatePlayer(newCurrentDirection);

            StartCoroutine(EnablePlayerScript());


           
        }
       
   
    }
 
    private IEnumerator EnablePlayerScript()
    {
        yield return new WaitForSeconds(1);

        playerControllerScript.enabled = true;
        rotationChanged = false;

    }

}
