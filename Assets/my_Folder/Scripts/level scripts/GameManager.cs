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
        Time.timeScale = 1;
    }

    public void SetGameOver()
    {
        isGameOver = true;
        uiManager.ShowGameOverPanel();
        Time.timeScale = 0;
    }
}
