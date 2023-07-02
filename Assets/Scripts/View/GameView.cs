using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the UI and the sprites on screen
/// </summary>
public class GameView : MonoBehaviour
{
    public GameObject BallHolder;
    public GameObject ObstacleHolder;
    public GameObject PlayerHolder;
    public GameResultController gameResultController;

    /// <summary>
    /// spawns a player to the game
    /// </summary>
    /// <param name="playerPrefab"> the player prefab to spawn</param>
    public void InstantiatePlayer(GameObject playerPrefab)
    {
        Instantiate(playerPrefab, PlayerHolder.transform);
    }

    /// <summary>
    /// destorys all obstacles on screen
    /// </summary>
    public void RemoveOnstacles()
    {
        foreach(Transform obstacle in ObstacleHolder.transform)
        {
            Destroy(obstacle.gameObject);
        }
    }

    /// <summary>
    /// Spawn a new ball to the game
    /// </summary>
    /// <param name="position">the position in the world</param>
    /// <param name="ballPrefab">the prefab of the ball to spawn</param>
    /// <returns>return the new ball gameobject</returns>
    public GameObject CreateBall(Vector2 position, GameObject ballPrefab)
    {
        GameObject newBall = Instantiate(ballPrefab, BallHolder.transform);
        newBall.transform.position = position;
        return newBall;
    }


    /// <summary>
    /// Creates a new Obstacl
    /// </summary>
    /// <param name="width">wifth of the obstacle</param>
    /// <param name="height">height of the obstacle</param>
    /// <param name="position">position of the obstacle</param>
    /// <param name="obstaclePrefab">obstacle prefab to spawn</param>
    public void CreateObstacle(float width, float height,Vector2 position, GameObject obstaclePrefab)
    {
        GameObject newObstacle = Instantiate(obstaclePrefab, ObstacleHolder.transform);
        Vector3 scale= newObstacle.transform.localScale;
        scale.x = width;
        scale.y = height;
        newObstacle.transform.localScale=scale;
        newObstacle.transform.position=position;
    }

    /// <summary>
    /// Displays the result of the game to the screen
    /// </summary>
    /// <param name="didWin">did the player win or lose</param>
    /// <param name="BallScore">the score of the player</param>
    public void DisplayGameResult(bool didWin,int BallScore)
    {
        gameResultController.ShowResult(didWin, BallScore);
    }

    /// <summary>
    /// check if the there are no more balls left
    /// </summary>
    /// <returns>true if no balls are left or false otherwise </returns>
    public bool IsBallHolderEmpty()
    {
        //the ball only destroys in the next frame so we either check for one or make this function and enumerable 
        return (BallHolder.transform.childCount <= 1);
    }

}
