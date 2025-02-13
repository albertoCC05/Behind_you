using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public enum Direction
{
    Forward,
    Left,
    Rigth,
    Back,

}

    




public class GameManager : MonoBehaviour
{

    public Dictionary<Direction, Vector3> directions = new Dictionary<Direction, Vector3>()
    { {Direction.Forward, Vector3.forward },
      { Direction.Left, Vector3.left},
      {Direction.Rigth, Vector3.right },
       { Direction.Back, Vector3.back},
    };

    public Dictionary<Direction, int> directionAngles = new Dictionary<Direction, int>()
  

    {
        {Direction.Forward, 0 },
        {Direction.Left, 270 },
        {Direction.Rigth, 90 },
        {Direction.Back, 180 },
    };

    public Dictionary<Direction, Vector3> leftDirections = new Dictionary<Direction, Vector3>()
  { {Direction.Forward, Vector3.left },
    { Direction.Left, Vector3.back },
    {Direction.Back, Vector3.right },
    {Direction.Rigth, Vector3.forward },


    };

    public Dictionary<Direction, Direction> BackDirections = new Dictionary<Direction, Direction>()
  { {Direction.Forward, Direction.Back },
    { Direction.Left, Direction.Rigth },
    {Direction.Back, Direction.Forward },
    {Direction.Rigth, Direction.Left },


    };

    private bool isGameOver;
    private UiManager uiManager;
    private TrigerPoint trigerPointScript;

    [SerializeField] private GameObject playerReference;
    [SerializeField] private GameObject monsterReference;

   // public float leftLoseRotation;
   // public float rigthLoseRotation;
    public Direction currentDirection;
    public Direction nextDirection;
  //  public float behindDirection;

    

    private Player_Controller playerController;

    public GameObject[] trigerPointsArray;

    public float speed = 5.0f;






    private void Start()
    {
        uiManager = FindObjectOfType<UiManager>();
        playerController = FindObjectOfType<Player_Controller>();
        isGameOver = false;
        Time.timeScale = 1;

        currentDirection = Direction.Forward;

        
        
    }


    public IEnumerator Rotation(Direction targetDirection )
    {
        playerReference.transform.forward = directions[currentDirection]; 

        float singleStep = speed * Time.deltaTime;
        Vector3 targetVector = directions[targetDirection];

 
        while (Vector3.Angle(playerReference.transform.forward, targetVector) > 0.25f)
        {
           // Debug.Log($"ANGLE DIF {Vector3.Angle(playerReference.transform.forward, targetVector) < 0.05f} - TF {playerReference.transform.forward} - target {targetVector} - angle {Vector3.Angle(playerReference.transform.forward, targetVector)} ");

            Vector3 newDirection = Vector3.RotateTowards(playerReference.transform.forward, targetVector, singleStep, 0.0f);

            playerReference.transform.rotation = Quaternion.LookRotation(newDirection);

            yield return new WaitForSeconds(0.01f);

            

            
        }


        playerReference.transform.forward = targetVector;
        currentDirection = targetDirection;
        playerController.enabled = true;

    }
    public IEnumerator RotationGun(Direction targetDirection)
    {
        

        float singleStep = speed * Time.deltaTime;
        Vector3 targetVector = directions[targetDirection];


        while (Vector3.Angle(playerReference.transform.forward, targetVector) > 0.25f)
        {
           
            Vector3 newDirection = Vector3.RotateTowards(playerReference.transform.forward, targetVector, singleStep, 0.0f);

            playerReference.transform.rotation = Quaternion.LookRotation(newDirection);

            yield return new WaitForSeconds(0.01f);
          
        }

        
        playerReference.transform.forward = targetVector;
        currentDirection = targetDirection;
        Debug.Log("He terminado de girar (gun)");
        

    }


    public void EnableTrigerPointCollider()
    {
        foreach (GameObject triggerP in trigerPointsArray)
        {
            triggerP.GetComponent<BoxCollider>().enabled = true;
        }
    }

    public IEnumerator RotationGameOver (Direction targetDirection)
    {


        float singleStep = speed * Time.deltaTime;
        Vector3 targetVector = directions[targetDirection];


        while (Vector3.Angle(playerReference.transform.forward, targetVector) > 0.25f)
        {


           

            // Debug.Log($"ANGLE DIF {Vector3.Angle(playerReference.transform.forward, targetVector) < 0.05f} - TF {playerReference.transform.forward} - target {targetVector} - angle {Vector3.Angle(playerReference.transform.forward, targetVector)} ");

            Vector3 newDirection = Vector3.RotateTowards(playerReference.transform.forward, targetVector, singleStep, 0.0f);

            playerReference.transform.rotation = Quaternion.LookRotation(newDirection);

            yield return new WaitForSeconds(0.01f);




        }


        playerReference.transform.forward = targetVector;
      
        playerController.enabled = true;

        Instantiate(monsterReference, playerReference.transform);

        isGameOver = true;
        uiManager.ShowGameOverPanel();
        Time.timeScale = 0;

    }
    public void CheckGameOver()
    {

        if (playerController.currentItem.type == Item.ItemType.gun && playerController.numberOfBullets > 0)
        {
            nextDirection = BackDirections[currentDirection];
            StartCoroutine(RotationGun(nextDirection));
            playerController.numberOfBullets--;
            uiManager.UpdateNumberOfBullets(playerController.numberOfBullets);
            EnableTrigerPointCollider();
        }
        else
        {

            

           /* isGameOver = true;
            uiManager.ShowGameOverPanel();
            Time.timeScale = 0; */
            RotationGameOver(BackDirections[currentDirection]);
        }
     


    }
    public void Win()
    {
        Time.timeScale = 0;
        uiManager.ShowWinPanel();
    }
  
}
