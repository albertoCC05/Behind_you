using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishDor : MonoBehaviour
{
    private Player_Controller playerController;
    private GameManager gameManager;
  


    private void Start()
    {
        playerController = FindObjectOfType<Player_Controller>();
        gameManager = FindObjectOfType<GameManager>();
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && playerController.currentItem.type == Item.ItemType.key)
        {

            gameManager.Win();

            Scene currentScene = SceneManager.GetActiveScene();

            if (currentScene.name == "Level_1")
            {
                Debug.Log("hello");
                DataPersistance.level1 = true;
                DataPersistance.Save();

            }
            if (currentScene.name == "Level_2")
            {
                Debug.Log("hello");
                DataPersistance.level2 = true;
                DataPersistance.Save();

            }
        }





    }
}
