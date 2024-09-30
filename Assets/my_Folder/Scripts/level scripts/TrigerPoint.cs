using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerPoint : MonoBehaviour
{
    [SerializeField] private float rotationCange;

    private Player_Controller playerControllerScript;
    private GameManager gameManagerScript;

    private void Start()
    {
        playerControllerScript = FindObjectOfType<Player_Controller>();
        gameManagerScript = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           playerControllerScript.enabled = false;
            gameManagerScript.RotatePlayer(rotationCange);
            gameManagerScript.positiveLoseRotation = 180;
            gameManagerScript.negativeLoseRotation = 0;
            
            
           StartCoroutine(EnablePlayerScript());
           


        }
    }
    private IEnumerator EnablePlayerScript()
    {
        yield return new WaitForSeconds(1);

        playerControllerScript.enabled = true;
    }

}
