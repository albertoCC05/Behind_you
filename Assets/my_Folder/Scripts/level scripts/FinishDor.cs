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


    // This script is for th detection of the collision of the player with the finish dor, if player has the key equiped when he collides with the dor, the player wins

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && playerController.currentItem.type == Item.ItemType.llave)
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
