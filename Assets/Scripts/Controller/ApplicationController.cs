using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// controlls the flow of the application
/// </summary>
public class ApplicationController : MonoBehaviour
{
    /// <summary>
    /// Represent the different modes of the application
    /// </summary>
    public enum ApplicationMode
    {
            MENU,
            ONE_PLAYER,
            TWO_PLAYERS
    }    

    public static ApplicationController instance {  get; private set; }

    ApplicationMode currentMode;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// starts a single player game
    /// </summary>
    public void StartOnePlayerGame()
    {
        if (currentMode != ApplicationMode.MENU)
            return;

        currentMode = ApplicationMode.ONE_PLAYER;
        SceneManager.LoadScene("GameScreen");
    }

    /// <summary>
    /// Starts a two players game
    /// </summary>
    public void StartTwoPlayerGame()
    {
        if (currentMode != ApplicationMode.MENU)
            return;

        currentMode = ApplicationMode.TWO_PLAYERS;
        SceneManager.LoadScene("GameScreen");
    }

    /// <summary>
    /// retuns the Aplication to the menu
    /// </summary>
    public void ReturnToMenu()
    {
        currentMode = ApplicationMode.MENU;
        SceneManager.LoadScene("MainMenu");
    }

    /// <summary>
    /// return the current application mode
    /// </summary>
    public ApplicationMode GetCurrentMode()
    {
        return currentMode;
    }
}
