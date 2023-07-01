using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public void ShowResult(bool isVictory)
    {
        view.ShowResult(isVictory);
    }

    /// <summary>
    /// show the next level menu 
    /// </summary>
    public void ShowNextLevel() 
    { 
        view.ShowNextLevel();
    }

    /// <summary>
    /// Continues to the next level 
    /// </summary>
    public void GoToNextLevel()
    {
        
    }

    /// <summary>
    /// continute to return to menu 
    /// </summary>
    public void ReturnToMenu()
    {
        //swithc to menu
    }
}
