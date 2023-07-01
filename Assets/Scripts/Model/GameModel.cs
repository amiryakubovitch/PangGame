using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel : MonoBehaviour
{
    public GameObject BallPrefab;
    public GameObject FirstLocalPlayer;
    public GameObject SecondLocalPlayer;
    
    public List<LevelLayout> LevelLayouts;

    [HideInInspector]
    public int BallsCount;
    [HideInInspector]
    public int CurrentLevel;

    private void Start()
    {
        BallsCount = 0;
        CurrentLevel = 0;
    }
}
