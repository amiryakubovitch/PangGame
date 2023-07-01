using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel : MonoBehaviour
{
    public GameObject BallPrefab;
    public List<LevelLayout> LevelLayouts;

    [HideInInspector]
    public int TotalBalls;
}
