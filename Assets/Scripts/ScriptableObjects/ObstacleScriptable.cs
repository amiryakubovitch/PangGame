using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// represents an obstacle in the game
/// </summary>
[CreateAssetMenu(fileName = "New Obstacle", menuName = "Level/Obstacle")]
public class ObstacleScriptable : ScriptableObject
{
    public float Width;
    public float Height;
}
