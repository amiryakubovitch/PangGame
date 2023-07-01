using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls the view of the game result panel, the panel includes game over screen and next level menu
/// </summary>
[RequireComponent(typeof(GameResultController))]
public class GameResultView : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI resultTitle;
    [SerializeField]
    GameObject resultPanel;
    [SerializeField]
    GameObject nextLevel;

    GameResultController controller;

    private void Start()
    {
        controller = GetComponent<GameResultController>();
    }

    /// <summary>
    /// display the game over screen with accurate title
    /// </summary>
    /// <param name="isWinning">did the player win or lose</param>
    public void ShowResult(bool isWinning)
    {
        resultPanel.SetActive(true);
        nextLevel.SetActive(false);
        if (isWinning)
        {
            resultTitle.text = "Victory";
        }
        else
        {
            resultTitle.text = "You Lost";
        }
    }

    /// <summary>
    /// shows the next level menu
    /// </summary>
    public void ShowNextLevel() 
    {
        nextLevel.SetActive(true);
        resultPanel.SetActive(false);
    }

    /// <summary>
    /// called when user presses next level button 
    /// </summary>
    public void OnNextLevel()
    {
        resultPanel.SetActive(false);
        nextLevel.SetActive(false);
        controller.GoToNextLevel();
    }

    /// <summary>
    /// called when user presses on return to menu
    /// </summary>
    public void OnReturnToMenu()
    {
        resultPanel.SetActive(false);
        nextLevel.SetActive(false);
        controller.ReturnToMenu();
    }
}
