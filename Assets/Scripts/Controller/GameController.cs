using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void RemovedBall()
    {
       
    }

    public void CreateBall(Vector3 position,int level,float height, float speed,float size)
    {
        GameObject newBall= gameView.CreateBall(position, gameModel.BallPrefab);
        BallModel model = newBall.GetComponent<BallModel>();
        model.Speed = speed;
        model.Size = size;
        model.Level = level;
        model.Height = height;
    }
}
