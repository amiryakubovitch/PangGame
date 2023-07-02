using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the result manu at the end of the game
/// </summary>
[RequireComponent(typeof(GameResultView))]
public class GameResultController : MonoBehaviour
{

    GameResultView view;

    private void Start()
    {
        view = GetComponent<GameResultView>();
    }

    /// <summary>
    /// show the result menu with relavent win or lose status
    /// </summary>
    /// <param name="isVictory">did the player win or lose</param>
    /// <param name="score">the score of the player</param> 
    public void ShowResult(bool isVictory,int score)
    {
        view.ShowResult(isVictory, score);
    }

    /// <summary>
    /// continute to return to menu 
    /// </summary>
    public void ReturnToMenu()
    {
        GameController.instance.ReturnToMenu();
    }
}
