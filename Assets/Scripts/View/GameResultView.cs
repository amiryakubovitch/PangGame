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
    TextMeshProUGUI scoreText;
    [SerializeField]
    GameObject resultPanel;

    GameResultController controller;

    private void Start()
    {
        controller = GetComponent<GameResultController>();
    }

    /// <summary>
    /// display the game over screen with accurate title
    /// </summary>
    /// <param name="isWinning">did the player win or lose</param>
    /// <param name="score">the score of the player</param> 
    public void ShowResult(bool isWinning,int score)
    {
        resultPanel.SetActive(true);
        if (isWinning)
        {
            resultTitle.text = "Victory";
        }
        else
        {
            resultTitle.text = "You Lost";
        }

        scoreText.text = "Your score is:" + score;
    }

    /// <summary>
    /// called when user presses on return to menu
    /// </summary>
    public void OnReturnToMenu()
    {
        resultPanel.SetActive(false);
        controller.ReturnToMenu();
    }
}
