using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChapterSelection : MonoBehaviour
{


    [SerializeField] private Button chapter2Button;
    [SerializeField] private Button chapter3Button;

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
