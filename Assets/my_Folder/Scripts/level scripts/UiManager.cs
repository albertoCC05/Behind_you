using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI numberOfBullets;
    [SerializeField] GameObject winPanel;
    [SerializeField] private GameObject instructionsPanel; 

    private Player_Controller playerController;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {

            ShowInstrucctions();
        
        }
    }
    private void Start()
    {

        playerController = FindObjectOfType<Player_Controller>();

        HideGameOverPanel();
        HideWinPanel();
        ShowInstrucctions();
    }

    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
    private void HideGameOverPanel()
    {
        gameOverPanel.SetActive(false);
    }
    public void UpdateNumberOfBullets(int numberOfBullet)
    {
        numberOfBullets.text = $"Bullets = {numberOfBullet}";
    }
    public void HideWinPanel()
    {
        winPanel.SetActive(false);
    }
    public void ShowWinPanel()
    {
        winPanel.SetActive(true);
    }
    public void HideInstrucctions()
    {
        Time.timeScale = 1f;
        instructionsPanel.SetActive(false);
    }
    private void ShowInstrucctions()
    {
        Time.timeScale = 0f;
        instructionsPanel.SetActive(true);
    }
    public void RestartLevelB()
    {
        SceneManager.LoadScene(0);
    }


}
