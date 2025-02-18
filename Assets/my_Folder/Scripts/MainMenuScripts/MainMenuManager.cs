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

    [SerializeField] AudioSource cameraAudiosource;

    [SerializeField] Slider musicSlider;
    [SerializeField] Slider soundEfectsSlider;

   
    


    private void Start()
    {
        DataPersistance.Load();
       

       HideOptionsPanel();

        SetMusic();
       
        ContinueButtonInteractable();

        cameraAudiosource.Play();

        musicSlider.value = cameraAudiosource.volume;
       
        
    }
    public void SetMusic()
    {
        DataPersistance.LoadMusic();
        cameraAudiosource.volume = DataPersistance.musicValue;
        musicSlider.value = DataPersistance.musicValue;
        soundEfectsSlider.value = DataPersistance.fxValue;
    }
    public void SliderMusic()
    {
        cameraAudiosource.volume = musicSlider.value;
    }
    public void HideOptionsPanel()
    {
        DataPersistance.SaveMusic(musicSlider.value, soundEfectsSlider.value);
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
        DataPersistance.DeleteSaveFiles();
        SceneManager.LoadScene(1);

       
    }
    public void ExitButton()
    {
        Application.Quit();

    }
    public void ContinueButtton()
    {
        SceneManager.LoadScene(1);
    }
   public void ContinueButtonInteractable()
    {
        if (DataPersistance.saveFileExist == true)
        {
            Debug.Log("Patata");
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
