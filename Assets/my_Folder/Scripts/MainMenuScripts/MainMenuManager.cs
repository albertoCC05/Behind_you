using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject optionsPanel;
    [SerializeField] GameObject creditsPanel;
    [SerializeField] Button continueButton;

    private DataPersistance dataPersistance;


    private void Start()
    {
        dataPersistance = FindObjectOfType<DataPersistance>();
        ContinueButtonInteractable();

    }
    public void HideOptionsPanel()
    {
        optionsPanel.SetActive(false);
    }
    public void ShowOptionsPanel()
    {
        optionsPanel.SetActive(true);
    }
    public void HideCreditsPanel()
    {
        creditsPanel.SetActive(false);
    }
    public void ShowCreditsPanel()
    {
        creditsPanel.SetActive(true);
    }
    public void NewGameButton()
    {
        dataPersistance.DeleteSaveFiles();
        SceneManager.LoadScene(1);
    }
    public void ContinueButtton()
    {
        SceneManager.LoadScene(1);
    }
   public void ContinueButtonInteractable()
    {
        if (dataPersistance.saveFileExist == true)
        {
            continueButton.gameObject.SetActive(true);
            continueButton.interactable = true;
        }
        else
        {
            continueButton.interactable = false;
            continueButton.gameObject.SetActive(false);
        }
    }

}
