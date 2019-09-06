using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public LivesController livesController;
    public TextMeshPro scoreText;
    
    public int startingLives = 3;
    int point = 0;

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
            Debug.Log("Game Is Over");
        }
    }

    private void updateScoreLabel()
    {
        scoreText.text = point.ToString();
    }

}
