using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public LivesController livesController;
    public TextMeshPro scoreText;
    
    public int startingLives = 3;
    int point = 0;
    public GameObject gameOverSign;
    
    JumperSpawner jumperSpawner;
    

    private void OnEnable()
    {
        JumperController.OnSave += JumperSaved;
        JumperController.OnCrash += JumperCrashed;
    }

    private void OnDisable()
    {
        JumperController.OnSave -= JumperSaved;
        JumperController.OnCrash -= JumperCrashed;
    }

    private void Start()
    {
        jumperSpawner = GetComponent<JumperSpawner>();
        gameOverSign.SetActive(false);
        livesController.StartingLives(startingLives);
    }

    private void JumperSaved()
    {
        point++;
        updateScoreLabel();
    }

    private void JumperCrashed()
    {
        if(!livesController.RemoveLife())
        {

            jumperSpawner.Stop();
            Debug.Log("Game Is Over");
            GameOver();
            
        }
    }

    private void updateScoreLabel()
    {
        scoreText.text = point.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Main");
    }

    private void GameOver()
    {
        gameOverSign.SetActive(true);
    }
}
