using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MainMenuController class listens to button presses
/// </summary>
public class MainMenuController : MonoBehaviour
{
    /// <summary>
    /// called upon single player button press
    /// </summary>
    public void OnOnePlayerPress()
    {
        ApplicationController.instance.StartOnePlayerGame();
    }

    /// <summary>
    /// called upon two player button press
    /// </summary>
    public void OnTwoPlayerPress()
    {
        ApplicationController.instance.StartTwoPlayerGame();
    }
}
