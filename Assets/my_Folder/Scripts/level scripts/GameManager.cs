using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isGameOver;
    private UiManager uiManager;

    [SerializeField] private GameObject playerReference;

    public float positiveLoseRotation;
    public float negativeLoseRotation;
    public float currentDirection;
    


    
    

    private void Start()
    {
        uiManager = FindObjectOfType<UiManager>();
        isGameOver = false;
        Time.timeScale = 1;
        StartSetLoseAngles();
    }

    public void RotatePlayer(float rotationChange)
    {
        playerReference.transform.rotation = Quaternion.Euler(playerReference.transform.rotation.x, playerReference.transform.rotation.y + rotationChange, playerReference.transform.rotation.z);
       // SetLoseAngles();
    }

    private void StartSetLoseAngles()
    {
        // positiveLoseRotation = (playerReference.transform.rotation.eulerAngles.y + 0.90f) * Mathf.Rad2Deg;
        // negativeLoseRotation = (playerReference.transform.rotation.eulerAngles.y  - 0.90f) * Mathf.Rad2Deg; 

        positiveLoseRotation = 90;
        negativeLoseRotation = 270;
        currentDirection = 360;

        Debug.Log(positiveLoseRotation);
        Debug.Log(negativeLoseRotation);
    }
    public void SetLoseAngles()
    {
        positiveLoseRotation = playerReference.transform.rotation.eulerAngles.y + 90;
        negativeLoseRotation = playerReference.transform.rotation.eulerAngles.y - 90;

        Debug.Log(positiveLoseRotation);
        Debug.Log(negativeLoseRotation);
    }


    public void SetGameOver()
    {
        isGameOver = true;
        uiManager.ShowGameOverPanel();
        Time.timeScale = 0;
    }
  
}
