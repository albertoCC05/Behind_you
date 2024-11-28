using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;



    private void Start()
    {
        HideGameOverPanel();
    }

    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
    private void HideGameOverPanel()
    {
        gameOverPanel.SetActive(false);
    }

}
