using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// controlls the game flow and level creation
/// </summary>
public class GameController : MonoBehaviour
{
    public static GameController instance { get; private set; }
    public GameModel gameModel;
    public GameView gameView;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadPlayers();
        LoadLevel();
    }

    public void LoadPlayers()
    {
        //if(Application.isEditor) //check if running in editor 
        //{
        //    gameView.InstantiatePlayer(gameModel.FirstLocalPlayer);
        //    return;
        //}

        switch (ApplicationController.instance.GetCurrentMode())
        {
            case ApplicationController.ApplicationMode.MENU: //should not get here
                Debug.Log("Error: Game in menu mode on game screen");
                ApplicationController.instance.ReturnToMenu();
                break;
            case ApplicationController.ApplicationMode.ONE_PLAYER:
                gameView.InstantiatePlayer(gameModel.FirstLocalPlayer);
                break;
            case ApplicationController.ApplicationMode.TWO_PLAYERS:
                gameView.InstantiatePlayer(gameModel.FirstLocalPlayer);
                gameView.InstantiatePlayer(gameModel.SecondLocalPlayer);
                break;
        }
    }


    /// <summary>
    /// initiate the current level by iterating the level layout 
    /// </summary>
    public void LoadLevel()
    {
        if(gameModel.CurrentLevel >= gameModel.LevelLayouts.Count)
        {
            Debug.LogError("current level out of bounds");
            return;
        }
        LevelLayout currentLayout = gameModel.LevelLayouts[gameModel.CurrentLevel];
        foreach(LevelLayout.ballInLayout ball in currentLayout.ballScriptables)
        {
            BallScriptable ballParam = ball.Ball;
            CreateBall(ball.Position, ballParam.Level, ballParam.SpeedY, ballParam.SpeedX, ballParam.Size, ballParam.GravityScale);
            
        }
    }

    /// <summary>
    /// called when a ball is removed
    /// </summary>
    public void RemovedBall()
    {
        gameModel.BallsCount++;
    }

    /// <summary>
    /// Called when a new ball need to be created
    /// </summary>
    /// <param name="position">the ball Position</param>
    /// <param name="level">the ball level</param>
    /// <param name="speedY">the speed of the ball in the y axis</param>
    /// <param name="speedX">the speed of the ball in the x axis</param>
    /// <param name="size">the size of the ball</param>
    /// <param name="gravitScale">the gravity scale of the ball</param>
    public void CreateBall(Vector2 position,int level,float speedY, float speedX,float size,float gravitScale)
    {
        GameObject newBall= gameView.CreateBall(position, gameModel.BallPrefab);
        BallModel model = newBall.GetComponent<BallModel>();
        model.SpeedX = speedX;
        model.Size = size;
        model.Level = level;
        model.SpeedY = speedY;
        model.GravityScale=gravitScale;
    }
}
