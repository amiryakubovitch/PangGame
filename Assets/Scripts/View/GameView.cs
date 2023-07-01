using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameView : MonoBehaviour
{
    public GameObject ballHolder;
    public GameObject PlayerHolder;

    /// <summary>
    /// spawns a player to the game
    /// </summary>
    /// <param name="playerPrefab"> the player prefab to spawn</param>
    public void InstantiatePlayer(GameObject playerPrefab)
    {
        Instantiate(playerPrefab, PlayerHolder.transform);
    }

    /// <summary>
    /// Spawn a new ball to the game
    /// </summary>
    /// <param name="position">the position in the world</param>
    /// <param name="ballPrefab">the prefab of the ball to spawn</param>
    /// <returns>return the new ball gameobject</returns>
    public GameObject CreateBall(Vector2 position, GameObject ballPrefab)
    {
        GameObject newBall = Instantiate(ballPrefab, ballHolder.transform);
        newBall.transform.position = position;
        return newBall;
    }



}
