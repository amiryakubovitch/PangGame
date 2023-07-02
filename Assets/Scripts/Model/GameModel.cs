using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// contains Asset refrences and the levels of the game also contains parameters for score and level
/// </summary>
public class GameModel : MonoBehaviour
{
    public GameObject BallPrefab;
    public GameObject ObstaclePrefab;
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
