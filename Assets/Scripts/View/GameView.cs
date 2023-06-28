using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameView : MonoBehaviour
{
    public GameObject ballHolder;


    public GameObject CreateBall(Vector3 position, GameObject ballPrefab)
    {
        GameObject newBall = Instantiate(ballPrefab, ballHolder.transform);
        newBall.transform.position = position;
        return newBall;
    }



}
