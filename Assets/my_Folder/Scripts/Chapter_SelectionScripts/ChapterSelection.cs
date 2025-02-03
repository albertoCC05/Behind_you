using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChapterSelection : MonoBehaviour
{

    private DataPersistance dataPersistance;

    [SerializeField] private Button chapter2Button;
    [SerializeField] private Button chapter3Button;

    private void Start()
    {
        dataPersistance = FindObjectOfType<DataPersistance>();

        if (dataPersistance.saveFileExist)
        {
            dataPersistance.Load();
        }
        ActivateChapterButtons();
    }
    public void Return()
    {
        SceneManager.LoadScene(0);
        
    }
    public void ActivateChapterButtons()
    {
        if (dataPersistance.level1)
        {
            chapter2Button.interactable = true;
        }
        else
        {
            chapter2Button.interactable = false;
        }
        if (dataPersistance.level2) 
        {
            chapter3Button.interactable = true;
        }
        else
        {
            chapter3Button.interactable = false;
        }
    }
}
