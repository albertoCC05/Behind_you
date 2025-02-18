using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChapterSelection : MonoBehaviour
{


    [SerializeField] private Button chapter2Button;
    [SerializeField] private Button chapter3Button;



    //This script have the function of the chapter selection buttons and depending of the levels completed, you can acces to more levels or less.
    //When you complete the level 1, you unlock level 2. 
    //And when you complete level 2 you unlock level 3.

    private void Start()
    {
        if (DataPersistance.saveFileExist)
        {
            Debug.Log("Hola");
            DataPersistance.Load();
        }
        ActivateChapterButtons();
    }
    public void Return()
    {
        SceneManager.LoadScene(0);
    }
    public void ActivateChapterButtons()
    {
        if (DataPersistance.level1)
        {
            chapter2Button.interactable = true;
        }
        else
        {
            chapter2Button.interactable = false;
        }
        if (DataPersistance.level2) 
        {
            chapter3Button.interactable = true;
        }
        else
        {
            chapter3Button.interactable = false;
        }
    }
    public void Level1Button()
    {
        SceneManager.LoadScene(2);
    }
    public void Level2Button()
    {
        SceneManager.LoadScene(3);
    }
    public void Level3Button()
    {
        SceneManager.LoadScene(4);
    }
}
