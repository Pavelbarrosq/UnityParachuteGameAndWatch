using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameOver : MonoBehaviour
{
    public GameManager gameManager;

    private void OnMouseDown()
    {
        gameManager.RestartGame();
    }
}
