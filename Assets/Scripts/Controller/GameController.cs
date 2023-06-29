using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// controlls the game flow and level creation
/// </summary>
public class GameController : MonoBehaviour
{
    public static GameController instance;
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

    /// <summary>
    /// called when a ball is removed
    /// </summary>
    public void RemovedBall()
    {
       
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
    public void CreateBall(Vector3 position,int level,float speedY, float speedX,float size,float gravitScale)
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
