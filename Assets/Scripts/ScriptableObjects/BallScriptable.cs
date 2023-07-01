using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// represent a single ball to be spawned in a level
/// </summary>
[CreateAssetMenu(fileName = "New Ball", menuName = "Level/Ball")]
public class BallScriptable : ScriptableObject
{
    public GameObject Prefab;
    public float Size;
    public float SpeedX;
    public float SpeedY;
    public float GravityScale;

    //the amount of times the ball wil split
    public int Level;
}
