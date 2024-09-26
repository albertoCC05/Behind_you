using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isGameOver;
    private UiManager uiManager;

    private void Start()
    {
        uiManager = FindObjectOfType<UiManager>();
        isGameOver = false;  
    }

    public void SetGameOver()
    {
        isGameOver = true;
        uiManager.ShowGameOverPanel();
    }
}
