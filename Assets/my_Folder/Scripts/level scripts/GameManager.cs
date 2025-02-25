using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;
using UnityEngine.SceneManagement;

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

    private bool gameOverIsSet;
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

    private float speed = 1.0f;
    private float gameOverSpeed = 10.0f;

    [SerializeField] private Animator gunHandAnimator;
     public int currentLevel;

    [SerializeField] private ParticleSystem gunParticleSistem;






    private void Start()
    {
        uiManager = FindObjectOfType<UiManager>();
        playerController = FindObjectOfType<Player_Controller>();

        SetCurrentLevel();
        StartCurrentLevel();

    }
    private void SetCurrentLevel()
    {
        if (SceneManager.GetActiveScene().name == "Level_1")
        {
            currentLevel = 1;
        }
        else if (SceneManager.GetActiveScene().name == "Level_2")
        {
            currentLevel = 2;
        }
        else if (SceneManager.GetActiveScene().name == "Level_3")
        {
            currentLevel = 3;
        }

    }
    private void StartCurrentLevel()
    {
        gameOverIsSet = false;
        Time.timeScale = 1;
        currentDirection = Direction.Forward;
        uiManager.StartText();
        uiManager.ShowTextPanel();

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
        playerController.enabled = false;

        Vector3 spawnPositionMonster = playerReference.transform.position + new Vector3(0, -1.7f, 0) - 2f * directions[currentDirection];

        GameObject monster = Instantiate(monsterReference, spawnPositionMonster, Quaternion.identity);
        monster.transform.forward = directions[currentDirection];


        while (Vector3.Angle(playerReference.transform.forward, targetVector) > 0.25f)
        {
           
            Vector3 newDirection = Vector3.RotateTowards(playerReference.transform.forward, targetVector, singleStep, 0.0f);

            playerReference.transform.rotation = Quaternion.LookRotation(newDirection);

            yield return new WaitForSeconds(0.01f);
          
        }

        gunHandAnimator.SetTrigger("shoot");
        
        playerReference.transform.forward = targetVector;
        currentDirection = targetDirection;
        playerController.enabled = true;
        Debug.Log("He terminado de girar (gun)");

        yield return new WaitForSeconds(0.3f);

        Destroy(monster);
        uiManager.gunAudiosource.Play();
        gunParticleSistem.Play();
        playerController.enabled = true;


    }


    public void EnableTrigerPointCollider()
    {
        foreach (GameObject triggerP in trigerPointsArray)
        {
            triggerP.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    public IEnumerator RotationGameOver (Direction targetDirection)
    {

        playerController.enabled = false;

        float singleStep = gameOverSpeed * Time.deltaTime;
        Vector3 targetVector = directions[targetDirection];

  

        if (gameOverIsSet == false)
        {
            gameOverIsSet = true;

            Vector3 spawnPositionMonster = playerReference.transform.position + new Vector3(0, -1.7f, 0) - 0.8f * directions[currentDirection];

            GameObject monster = Instantiate(monsterReference, spawnPositionMonster, Quaternion.identity);
            monster.transform.forward = directions[currentDirection];

            while (Vector3.Angle(playerReference.transform.forward, targetVector) > 0.25f)
            {




                // Debug.Log($"ANGLE DIF {Vector3.Angle(playerReference.transform.forward, targetVector) < 0.05f} - TF {playerReference.transform.forward} - target {targetVector} - angle {Vector3.Angle(playerReference.transform.forward, targetVector)} ");

                Vector3 newDirection = Vector3.RotateTowards(playerReference.transform.forward, targetVector, singleStep, 0.0f);

                playerReference.transform.rotation = Quaternion.LookRotation(newDirection);

                yield return new WaitForSeconds(0.0001f);




            }


            playerReference.transform.forward = targetVector;

            playerController.enabled = true;
            uiManager.monsterAudiosource.Play();

         


            StartCoroutine(ShowGameOverPanelCorroutine());
            

           
        }

       

    }

    private IEnumerator ShowGameOverPanelCorroutine()
    {
        yield return new WaitForSeconds (2);
        uiManager.ShowGameOverPanel();
    }
    public void CheckGameOver()
    {

        if (playerController.currentItem.type == Item.ItemType.pistola && playerController.numberOfBullets > 0)
        {
            playerController.enabled = false;
            nextDirection = BackDirections[currentDirection];
            StartCoroutine(RotationGun(nextDirection));
            playerController.numberOfBullets--;
            uiManager.UpdateNumberOfBullets(playerController.numberOfBullets);
            EnableTrigerPointCollider();

          
        }
        else
        {




           
           

            StartCoroutine(RotationGameOver(BackDirections[currentDirection]));
        }
     


    }
    public void Win()
    {
        Time.timeScale = 0;
        uiManager.ShowWinPanel();
    }
  
}
