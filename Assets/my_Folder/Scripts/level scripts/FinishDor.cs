using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if ( collision.gameObject.CompareTag("Player") && playerController.currentItem.type == Item.ItemType.key)
        {

            gameManager.Win();
        }
    }





}
